using System.ComponentModel.DataAnnotations;

namespace MVC_project.PL.ViewModels
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
	}
}
