using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {

        [Required(ErrorMessage ="Kullanıcı Adı gereklidir")]
        [Display(Name ="Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]

        [Required(ErrorMessage = "Şifre gereklidir")]
        public string Password { get; set; }

    }
}
