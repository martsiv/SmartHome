﻿using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Utilities
{
	public class JwtOptions
	{
		public string Issuer { get; set; }
		public string Key { get; set; }
		public int Lifetime { get; set; } // minutes
		public SymmetricSecurityKey GetSymmetricSecurityKey() =>
		new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
	}
}
