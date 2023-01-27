using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage ="請輸入姓名")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage ="請輸入郵件地址")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Secret { get; set; } = null!;
        [Required(ErrorMessage ="請再輸入一次密碼")]
        [DataType(DataType.Password)]
        [Compare("Secret",ErrorMessage ="兩次輸入的密碼不同")]
        public string SecretRe { get; set; } = null!;
    }
}
