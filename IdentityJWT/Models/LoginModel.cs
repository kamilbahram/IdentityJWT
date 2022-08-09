using System.ComponentModel.DataAnnotations;

namespace IdentityJWT.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Passwor boş Geçilemez!")]
        public string Password { get; set; } = string.Empty;

    }
}
