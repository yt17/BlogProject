using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Articles_")]
    public class Article
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity),ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public int Category_ID { get; set; }
        [Required]
        public string Article_Name { get; set; }
        [Required]
        public string Article_Litle { get; set; }
        [Required]
        public string Article_Text { get; set; }
        [Required,ScaffoldColumn(false)]
        public string User_Name { get; set; }
        [Required,ScaffoldColumn(false)]
        public string Active { get; set; }
        [Required,ScaffoldColumn(false)]
        public DateTime Create_Date { get; set; }        

    }
}
