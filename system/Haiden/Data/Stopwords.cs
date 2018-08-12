using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("stopwords")]
    public partial class Stopwords
    {
        [Key]
        [Column("id_stopword")]
        public long IdStopword { get; set; }
        [Column("fkid_language")]
        public long FkidLanguage { get; set; }
        [Required]
        [Column("stopword")]
        public string Stopword { get; set; }
        [Column("dt_inc_stopword", TypeName = "date")]
        public DateTime DtIncStopword { get; set; }

        [ForeignKey("FkidLanguage")]
        [InverseProperty("Stopwords")]
        public Languages FkidLanguageNavigation { get; set; }
    }
}
