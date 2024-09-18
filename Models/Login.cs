using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimals.Models
{
	public class Login
	{
		public string Email { get; set; } = default!;
		public string Password { get; set; } = default!;
	}
}