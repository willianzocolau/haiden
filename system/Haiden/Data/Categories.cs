using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("categories")]
    public partial class Categories
    {
        public Categories()
        {
            News = new HashSet<News>();
        }

        [Key]
        [Column("id_category")]
        public long IdCategory { get; set; }
        [Required]
        [Column("name_category")]
        public string NameCategory { get; set; }
        [Column("dt_inc_category", TypeName = "date")]
        public DateTime? DtIncCategory { get; set; }

        [InverseProperty("FkidCategoryNavigation")]
        public ICollection<News> News { get; set; }
    }
}
