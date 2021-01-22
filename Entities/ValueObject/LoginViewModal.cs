using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObject
{
    public class LoginViewModal
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max.{1} boş geçilemez.")]

        public string Username { get; set; }

        [DisplayName("Kullanıcı Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez"),DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max.{1} boş geçilemez.")]
        public string Password { get; set; }
    }
}