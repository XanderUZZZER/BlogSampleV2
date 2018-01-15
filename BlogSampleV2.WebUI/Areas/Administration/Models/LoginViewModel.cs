using System.ComponentModel.DataAnnotations;

namespace BlogSampleV2.WebUI.Areas.Administration.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}