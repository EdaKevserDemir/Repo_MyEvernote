using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.Entities.ValueObject
{
    public class RegisterViewModal
    {
        [DisplayName("Kullanıcı Adı"),
         Required(ErrorMessage = "{0} alanı boş geçilemez"),
         StringLength(25, ErrorMessage = "{0} max.{1} boş geçilemez.")]
        public string Username { get; set; }

        [DisplayName("E-posta"),
         Required(ErrorMessage = "{0} alanı boş geçilemez"),
         StringLength(70, ErrorMessage = "{0} max.{1} boş geçilemez."),
         EmailAddress(ErrorMessage = "{0} alanı için geerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} alanı boş geçilemez"),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max.{1} karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Şifre Tekrar"),
         Required(ErrorMessage = "{0} alanı boş geçilemez"),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max.{1} karakter olmalı."),
         Compare("Password",ErrorMessage ="{0} ile {1} uyuşmuyor.")]
        public string RePassword { get; set; }
    }
}