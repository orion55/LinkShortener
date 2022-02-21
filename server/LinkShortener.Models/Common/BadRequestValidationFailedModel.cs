using System.Collections.Generic;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace LinkShortener.Models.Common
{
    [DataContract]
    public class BadRequestValidationFailedModel : BadRequestModel
    {
        public BadRequestValidationFailedModel()
        {
            ErrorMessage = "Validation failed";
        }

        [DataMember]
        public IEnumerable<ValidationFailure> ValidationFailures { get; set; }
    }
}