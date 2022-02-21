using System.Collections.Generic;

namespace LinkShortener.Models.Common
{
    public class GetRecordsResponse<TRecord>
    {
        public int TotalRecords { get; set; }
        public int TotalFilteredRecords { get; set; }
        public IEnumerable<TRecord> Records { get; set; }
    }
}