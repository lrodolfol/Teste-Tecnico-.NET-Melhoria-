using AutoMapper;
using todo_manager.Models.Data.Dtos;
using todo_manager.Models.Entitie;

namespace todo_manager.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<CreateCardDto, Todo>();
        }

    }
}
