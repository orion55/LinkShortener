using System.Runtime.Serialization;

namespace LinkShortener.Models.Common
{
    [DataContract]
    public class BadRequestModel
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}