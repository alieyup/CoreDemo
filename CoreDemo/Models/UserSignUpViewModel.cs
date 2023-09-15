using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz!")]
        public string NameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz!")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresi")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [Required(ErrorMessage = "Lütfen mail giriniz!")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kulanıcı adı giriniz!")]
        public string UserName { get; set; }
    }
}
