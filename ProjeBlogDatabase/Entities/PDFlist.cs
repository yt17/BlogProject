using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("PDFlist")]
    public class PDFlist
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string PDF_Name { get; set; }
        [Required, ScaffoldColumn(false)]
        public string User_Name { get; set; }
        [Required, ScaffoldColumn(false)]
        public string PDF_Way { get; set; }
        [Required, ScaffoldColumn(false)]
        public DateTime Dowloaned_Date { get; set; }

    }
}
