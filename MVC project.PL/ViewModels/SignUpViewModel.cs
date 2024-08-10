using System.ComponentModel.DataAnnotations;

namespace MVC_project.PL.ViewModels
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[MinLength(5, ErrorMessage ="Minimum Password length is 5")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required")]
		[Compare(nameof(Password),ErrorMessage = "Confirm Password dose'nt Match !")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }


    }
}
