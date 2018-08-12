using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("fonts")]
    public partial class Fonts
    {
        public Fonts()
        {
            FontLinks = new HashSet<FontLinks>();
        }

        [Key]
        [Column("id_font")]
        public long IdFont { get; set; }
        [Required]
        [Column("name_font")]
        public string NameFont { get; set; }
        [Column("dt_inc_font", TypeName = "date")]
        public DateTime DtIncFont { get; set; }

        [InverseProperty("FkidFontNavigation")]
        public ICollection<FontLinks> FontLinks { get; set; }
    }
}
