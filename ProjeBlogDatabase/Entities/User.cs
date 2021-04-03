using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users_")]
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string U_Name { get; set; }
        [Required]
        public string U_Surname { get; set; }
        [Required]
        public string Mail_Adress { get; set; }
        [ScaffoldColumn(false)]
        public bool Active { get; set; }
        [Required, ScaffoldColumn(false)]
        public Guid Guid_ID { get; set; }
        [ScaffoldColumn(false)]
        public bool Admin { get; set; }
        [Required,ScaffoldColumn(false)]
        public DateTime Reg_Date { get; set; }
    }
}
