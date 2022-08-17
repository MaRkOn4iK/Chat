using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            _ = CreateMap<Person, PersonModel>()
                .ForMember(pm => pm.Id, p => p.MapFrom(x => x.Id))
                .ForMember(pm => pm.PersonName, p => p.MapFrom(x => x.PersonName))
                .ForMember(pm => pm.MessagesIds, p => p.MapFrom(x => x.Messages.Select(m => m.Id)))
                .ReverseMap();

            _ = CreateMap<Group, GroupModel>()
                .ForMember(gm => gm.Id, g => g.MapFrom(x => x.Id))
                .ForMember(gm => gm.GroupName, g => g.MapFrom(x => x.GroupName))
                .ForMember(gm => gm.MessagesIds, g => g.MapFrom(x => x.Messages.Select(m => m.Id)))
                .ReverseMap();

            _ = CreateMap<Message, MessageModel>()
                .ForMember(mm => mm.Id, m => m.MapFrom(x => x.Id))
                .ForMember(mm => mm.MessageBody, m => m.MapFrom(x => x.MessageBody))
                .ForMember(mm => mm.CreatedDate, m => m.MapFrom(x => x.CreatedDate))
                .ForMember(mm => mm.SenderId, m => m.MapFrom(x => x.SenderId))
                .ForMember(mm => mm.RecipientId, m => m.MapFrom(x => x.RecipientId))
                .ForMember(mm => mm.GroupId, m => m.MapFrom(x => x.GroupId))
                .ForMember(mm => mm.ParentMessageId, m => m.MapFrom(x => x.ParentMessage.Id))
                .ForMember(mm => mm.IsDeleted, m => m.MapFrom(x => x.IsDeleted))
                .ReverseMap();
        }
    }
}
