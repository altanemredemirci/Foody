using System.ComponentModel.DataAnnotations;

namespace Foody.WEBUI.Models
{
	public class ResetPasswordViewModel
	{
		public string Token { get; set; }

		public string UserId { get; set; }

		[DataType(DataType.Password)]
		[MinLength(6)]
		[Display(Name = "Yeni Şifre")]
		public string NewPassword { get; set; }

		[Compare("NewPassword")]
		[DataType(DataType.Password)]
		[Display(Name = "Tekrar Yeni Şifre")]
		public string ReNewPassword { get; set; }
	}
}
