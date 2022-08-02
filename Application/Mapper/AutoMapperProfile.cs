using Application.User.DTO;
using AutoMapper;

namespace Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Domain.Entities.User, UserDTO>();
        }
    }
}
