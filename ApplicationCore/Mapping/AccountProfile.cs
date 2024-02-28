using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
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
			CreateMap<RegisterModel, User>()
				.ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));
		}
	}
}
