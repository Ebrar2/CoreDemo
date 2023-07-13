using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {

        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad Giriniz!")]
        public string NameSurname { get; set; }
        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Lütfen Şifre Giriniz!")]
        public string Password { get; set; }
        [Display(Name = "Tekrar Şifre")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen Mail Giriniz!")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz!")]
        public string UserName { get; set; }
        [Display(Name = "Kullanım Şartları")]
        [Required(ErrorMessage = "Lütfen Kullanım Şartlarını Kabul ediniz!")]
        public bool check { get; set; }
    }
}
