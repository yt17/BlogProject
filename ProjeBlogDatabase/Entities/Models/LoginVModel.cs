using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class LoginVModel
    {
        [DisplayName("Kullanıcı adınız"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string User_Name { get; set; }
        [DisplayName("Sifre"), Required(ErrorMessage = "{0} alani bos gecilemez"), DataType(DataType.Password)]
        public string PSW { get; set; }
    }
}
