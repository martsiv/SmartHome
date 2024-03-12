using ApplicationCore.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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
