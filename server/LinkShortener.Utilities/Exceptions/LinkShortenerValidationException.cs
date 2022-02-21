using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace LinkShortener.Utilities.Exceptions
{
    public class LinkShortenerValidationException : Exception
    {
        public IEnumerable<ValidationFailure> ValidationFailures { get; set; }
    }
}
