using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("font_links")]
    public partial class FontLinks
    {
        public FontLinks()
        {
            News = new HashSet<News>();
        }

        [Key]
        [Column("id_font_link")]
        public long IdFontLink { get; set; }
        [Column("fkid_font")]
        public long FkidFont { get; set; }
        [Column("type_link")]
        public long TypeLink { get; set; }
        [Required]
        [Column("src_font_link")]
        public string SrcFontLink { get; set; }
        [Column("dt_inc_font_linnk", TypeName = "date")]
        public DateTime DtIncFontLinnk { get; set; }

        [ForeignKey("FkidFont")]
        [InverseProperty("FontLinks")]
        public Fonts FkidFontNavigation { get; set; }
        [InverseProperty("FkidFontLinkNavigation")]
        public ICollection<News> News { get; set; }
    }
}
