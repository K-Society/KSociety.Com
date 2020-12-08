using AutoMapper;

namespace KSociety.Com.Srv.Host.AutoMapperProfile
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            //Common
            //Domain
            CreateMap<Domain.Entity.Common.TagGroup, Srv.Dto.Common.TagGroup>();
            CreateMap<Domain.Entity.Common.Tag, Srv.Dto.Common.Tag>();
            CreateMap<Domain.Entity.Common.Connection, Srv.Dto.Common.Connection>();

            //Add 
            CreateMap<App.Dto.Req.Add.Common.Connection, Domain.Entity.Common.Connection>();
            CreateMap<App.Dto.Req.Add.Common.Tag, Domain.Entity.Common.Tag>();
            CreateMap<App.Dto.Req.Add.Common.TagGroup, Domain.Entity.Common.TagGroup>();

            //Update
            CreateMap<App.Dto.Req.Update.Common.Connection, Domain.Entity.Common.Connection>();
            CreateMap<App.Dto.Req.Update.Common.Tag, Domain.Entity.Common.Tag>();
            CreateMap<App.Dto.Req.Update.Common.TagGroup, Domain.Entity.Common.TagGroup>();

            //Copy
            CreateMap<App.Dto.Req.Copy.Common.Connection, Domain.Entity.Common.Connection>();
            CreateMap<App.Dto.Req.Copy.Common.Tag, Domain.Entity.Common.Tag>();
            CreateMap<App.Dto.Req.Copy.Common.TagGroup, Domain.Entity.Common.TagGroup>();


            //Logix
            //Domain
            CreateMap<Domain.Entity.Logix.LogixTag, Srv.Dto.Logix.LogixTag>();
            CreateMap<Domain.Entity.Logix.LogixConnection, Srv.Dto.Logix.LogixConnection>();

            //Add
            CreateMap<App.Dto.Req.Add.Logix.LogixConnection, Domain.Entity.Logix.LogixConnection>();
            CreateMap<App.Dto.Req.Add.Logix.LogixTag, Domain.Entity.Logix.LogixTag>();

            //Update
            CreateMap<App.Dto.Req.Update.Logix.LogixConnection, Domain.Entity.Logix.LogixConnection>();
            CreateMap<App.Dto.Req.Update.Logix.LogixTag, Domain.Entity.Logix.LogixTag>();

            //Copy
            CreateMap<App.Dto.Req.Copy.Logix.LogixConnection, Domain.Entity.Logix.LogixConnection>();
            CreateMap<App.Dto.Req.Copy.Logix.LogixTag, Domain.Entity.Logix.LogixTag>();


            //S7
            //Domain
            CreateMap<Domain.Entity.S7.S7Tag, Srv.Dto.S7.S7Tag>();
            CreateMap<Domain.Entity.S7.S7Connection, Srv.Dto.S7.S7Connection>();

            //Add
            CreateMap<App.Dto.Req.Add.S7.S7Connection, Domain.Entity.S7.S7Connection>();
            CreateMap<App.Dto.Req.Add.S7.S7Tag, Domain.Entity.S7.S7Tag>();

            //Update
            CreateMap<App.Dto.Req.Update.S7.S7Connection, Domain.Entity.S7.S7Connection>();
            CreateMap<App.Dto.Req.Update.S7.S7Tag, Domain.Entity.S7.S7Tag>();

            //Copy
            CreateMap<App.Dto.Req.Copy.S7.S7Connection, Domain.Entity.S7.S7Connection>();
            CreateMap<App.Dto.Req.Copy.S7.S7Tag, Domain.Entity.S7.S7Tag>();

            //View Common
            CreateMap<Domain.Entity.View.Common.TagGroupReady, Srv.Dto.View.Common.TagGroupReady>();

            //View Join
            CreateMap<Domain.Entity.View.Joined.AllConnection, Srv.Dto.View.Joined.AllConnection>();
            CreateMap<Domain.Entity.View.Joined.AllTagGroupAllConnection, Srv.Dto.View.Joined.AllTagGroupAllConnection>();
            CreateMap<Domain.Entity.View.Joined.AllTagGroupConnection, Srv.Dto.View.Joined.AllTagGroupConnection>();
        }
    }
}
