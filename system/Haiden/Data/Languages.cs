using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("languages")]
    public partial class Languages
    {
        public Languages()
        {
            News = new HashSet<News>();
            Stopwords = new HashSet<Stopwords>();
        }

        [Key]
        [Column("id_language")]
        public long IdLanguage { get; set; }
        [Required]
        [Column("name_language")]
        public string NameLanguage { get; set; }
        [Column("dt_inc_language", TypeName = "date")]
        public DateTime DtIncLanguage { get; set; }

        [InverseProperty("FkidLanguageNavigation")]
        public ICollection<News> News { get; set; }
        [InverseProperty("FkidLanguageNavigation")]
        public ICollection<Stopwords> Stopwords { get; set; }
    }
}
