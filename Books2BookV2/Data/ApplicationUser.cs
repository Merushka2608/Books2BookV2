using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books2BookV2.Data
{
	[Table("tblLogin")]
	public class ApplicationUser:IdentityUser
	{
		public string UserName {get;set;}
		public string Password {get;set;}

	}
}
