import-module .\thirdparty\tools\psake\psake.psm1
invoke-psake .\build\FakeVader.ps1 $args
remove-module psake