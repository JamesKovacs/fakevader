using System;
using AutoMapper;

namespace FakeVader.Core.Infrastructure.AutoMapping {
    public class DateFormatter : IValueFormatter {
        public string FormatValue(ResolutionContext context) {
            var sourceType = context.SourceType;
            if(sourceType != typeof(DateTime) && sourceType != typeof(DateTime?)) {
                throw new ArgumentException(sourceType.GetType().FullName + " is not a System.DateTime.", "context");
            }
            var dateTime = context.SourceValue as DateTime?;
            return dateTime.HasValue ? dateTime.Value.ToLongDateString() : "";
        }
    }
}