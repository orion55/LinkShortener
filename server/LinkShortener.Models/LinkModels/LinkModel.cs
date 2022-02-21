using System;

namespace LinkShortener.Models.LinkModels
{
    public class LinkModel
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Code { get; set; }
        public DateTime DateCreated { get; set; }
        public int Clicks { get; set; }
    }
}