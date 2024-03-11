using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Mapping
{
	public class AccountProfile : Profile
	{
		public AccountProfile()
		{
			CreateMap<RegisterModel, IdentityUser>()
				.ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));
		}
	}
}
