using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("news")]
    public partial class News
    {
        [Key]
        [Column("id_new")]
        public long IdNew { get; set; }
        [Column("fkid_category")]
        public long FkidCategory { get; set; }
        [Column("fkid_font_link")]
        public long FkidFontLink { get; set; }
        [Column("fkid_language")]
        public long FkidLanguage { get; set; }
        [Column("received_category")]
        public string ReceivedCategory { get; set; }
        [Column("author_new")]
        public string AuthorNew { get; set; }
        [Required]
        [Column("title_new")]
        public string TitleNew { get; set; }
        [Required]
        [Column("src_new")]
        public string SrcNew { get; set; }
        [Required]
        [Column("description_new")]
        public string DescriptionNew { get; set; }
        [Column("dt_publication_new", TypeName = "date")]
        public DateTime DtPublicationNew { get; set; }
        [Column("dt_modification_new")]
        public long? DtModificationNew { get; set; }
        [Column("src_image_new")]
        public long? SrcImageNew { get; set; }
        [Column("byte_image_new")]
        public byte[] ByteImageNew { get; set; }
        [Column("description_image_new")]
        public string DescriptionImageNew { get; set; }
        [Column("author_image_new")]
        public string AuthorImageNew { get; set; }
        [Column("dt_inc_new")]
        public long DtIncNew { get; set; }
        [Column("dt_alt_new")]
        public long? DtAltNew { get; set; }

        [ForeignKey("FkidCategory")]
        [InverseProperty("News")]
        public Categories FkidCategoryNavigation { get; set; }
        [ForeignKey("FkidFontLink")]
        [InverseProperty("News")]
        public FontLinks FkidFontLinkNavigation { get; set; }
        [ForeignKey("FkidLanguage")]
        [InverseProperty("News")]
        public Languages FkidLanguageNavigation { get; set; }
    }
}
