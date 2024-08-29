using AutoMapper;
using ToDoApp.Domain.Models;
using ToDoApp.Web.Api.Models;

namespace ToDoApp.Web.Api.Mappings
{
    //TODO: In real application better to have separate files for different entities
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, BaseNamedViewModel>();
            CreateMap<Priority, BaseNamedViewModel>();
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.UsersTasks, opt => opt.Ignore());

            CreateMap<UpsertToDoTaskDto, ToDoTask>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.MinValue))
                .ForMember(dest => dest.LastModifiedDate, opt => opt.MapFrom(src => DateTime.MinValue))
                .ForMember(dest => dest.Priority, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedUser, opt => opt.Ignore())
                .ForMember(dest => dest.AssignedUserId,
                    opt => opt.MapFrom(src => src.AssignedUserId > 0 ? src.AssignedUserId : default(int?)));

            CreateMap<ToDoTask, ToDoTaskViewModel>();
            CreateMap<ToDoTask, ToDoTaskDetailsViewModel>();
        }
    }
}


