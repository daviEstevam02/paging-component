using AutoMapper;
using EasyDocs.Application.Helper;
using Microsoft.AspNetCore.Http;

namespace EasyDocs.Application.AutoMapper;

public sealed class GeneralMappingProfile : Profile
{
	public GeneralMappingProfile()
	{
        CreateMap<string, byte[]>().ConvertUsing(str => Convert.FromBase64String(str));
        CreateMap<byte[], string>().ConvertUsing(bytes => Convert.ToBase64String(bytes));

        CreateMap<IFormFile, byte[]>().ConvertUsing(formFile => FormFileExtensions.GetBytes(formFile));
    }
}