using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("User_PSW")]
    public class User_PSW
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Mail_Adress { get; set; }
        [Required]
        public string PSW { get; set; }
    }
}
