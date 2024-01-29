using System.ComponentModel.DataAnnotations;

namespace Snapp.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage ="لطفا شماره همراه معتبر وارد نمایید")]
        [MaxLength(11, ErrorMessage = "لطفا شماره همراه معتبر وارد نمایید")]
        [MinLength(11, ErrorMessage = "لطفا شماره همراه معتبر وارد نمایید")]
        [Phone(ErrorMessage = "لطفا شماره همراه معتبر وارد نمایید")]
        public string Username { get; set; }
    }
}
