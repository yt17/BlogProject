using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class RegisterVModel
    {
        [DisplayName("Kullanıcı adınızı giriniz"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string User_Name { get; set; }

        [DisplayName("Adınızı giriniz"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string U_Name { get; set; }
        [DisplayName("Soyadınızı giriniz"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı")]
        public string U_Surname { get; set; }
        [DisplayName("E-posta"), Required(ErrorMessage = "{0} alanı bos gecilemez"), StringLength(70, ErrorMessage = "{0} max {1} karakter olmalı"), EmailAddress(ErrorMessage = "{0} alanı icin gecerli bir e-posta adresi giriniz")]
        public string Mail_Adress { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı bos gecilemez"), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max {1} olmalıdır")]
        public string PSW { get; set; }

        [DisplayName("Şifreyi tekrar giriniz"), Required(ErrorMessage = "{0} alanı bos gecilemez"), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max {1} olmalıdır")]
        public string PSW_t { get; set; }
    }
}
