using System.Runtime.Serialization;

namespace LinkShortener.Models.Common
{
    /// <summary>
    /// Generic response model used in Web API
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    [DataContract]
    public class ResponseModel<TData>
    {
        public ResponseModel(TData data)
        {
            Data = data;
        }

        [DataMember]
        public TData Data { get; set; }
    }
}