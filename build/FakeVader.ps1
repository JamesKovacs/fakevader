$framework = '4.0'

properties {
  $config = 'Debug'
  $rootDir = resolve-path '..'
  $solutionFile = join-path $rootDir 'FakeVader.sln'
  $outputDir = join-path $rootDir 'buildartifacts\'
  $websiteDir = join-path $outputDir '_PublishedWebsites\Web'
  $toolsDir = join-path $rootDir 'thirdparty\tools\'
  $testAssembly = join-path $outputDir 'FakeVader.Tests.dll'
  $testResults = join-path $outputDir 'TestResults.xml'
}

task default -depends Test

task Test -depends Compile {
  exec { ..\packages\NUnit.2.5.9.10348\Tools\nunit-console.exe $testAssembly /xml=$testResults }
}

task Compile -depends Init {
  exec { msbuild $solutionFile /t:Rebuild /p:OutDir=$outputDir /p:Configuration=$config /maxcpucount }
}

task Init -depends Clean {
  mkdir $outputDir
}

task Clean {
  if(test-path $outputDir) {
    rm -re -fo $outputDir
  }
}
