using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinkShortener.Utilities.Constants;

namespace LinkShortener.Db.Entities.Core
{
    [Table("links", Schema = DbSchemaNames.CoreSchema)]
    public class Link
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("from")]
        public string From { get; set; }
        
        [Column("to")]
        public string To { get; set; }
        
        [Column("code")]
        public string Code { get; set; }
        
        [Column("date_created")]
        public DateTime DateCreated { get; set; }
        
        [Column("clicks")]
        public int Clicks { get; set; }
        
        [Column("user_id")]
        public int? UserId { get; set; }
    }
}