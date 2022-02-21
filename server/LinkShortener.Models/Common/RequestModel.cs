using System.Runtime.Serialization;

namespace LinkShortener.Models.Common
{
    /// <summary>
    /// Generic request model used in Web API
    /// </summary>
    /// <typeparam name="TParams"></typeparam>
    [DataContract]
    public class RequestModel<TParams>
    {
        [DataMember]
        public TParams Params { get; set; }
    }
}
