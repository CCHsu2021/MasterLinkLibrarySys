using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "請輸入郵箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
