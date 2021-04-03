using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Category_")]
    public class Category
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Category_Name { get; set; }
        //public String Category_desc { get; set; }
        [ScaffoldColumn(false)]
        public bool Active { get; set; }
    }
}
