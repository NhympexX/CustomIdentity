using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels
{
    public class LoginVm
    {
        [Required(ErrorMessage ="Username is required")]

        public string? username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]

        public string? password { get; set; }
        [Display(Name ="Remember Me")]

        public bool rememberMe { get; set;}
    }
}
