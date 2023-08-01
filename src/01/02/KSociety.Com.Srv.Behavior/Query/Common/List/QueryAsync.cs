using System;
using System.Linq;
using System.Threading.Tasks;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Common.List;
using KSociety.Com.Srv.Dto.Common;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Common.List;

//[ServiceBehavior(AddressFilterMode = AddressFilterMode.Prefix)]
//[GlobalExceptionHandlerBehaviour(typeof(GlobalExceptionHandler))]
public class QueryAsync : IQueryAsync
{
    private readonly ILogger<QueryAsync> _logger;
    private readonly ITagGroup _commonTagGroupRepository;
    private readonly ITag _commonTagRepository;
    private readonly IConnection _commonConnectionRepository;
    //private readonly ITagGroupReady _tagGroupReady;

    public QueryAsync
    (
        ILoggerFactory loggerFactory,
        ITagGroup commonTagGroupRepository,
        ITag commonTagRepository,
        IConnection commonConnectionRepository
        //ITagGroupReady tagGroupReady
    )
    {
        _logger = loggerFactory.CreateLogger<QueryAsync>();
        _commonTagGroupRepository = commonTagGroupRepository;
        _commonTagRepository = commonTagRepository;
        _commonConnectionRepository = commonConnectionRepository;
        //_tagGroupReady = tagGroupReady;
    }

    //public Dto.Common.List.Tag TagQuery(Expression<Func<Domain.Db.Entity.Common.Tag, bool>> filter)
    ////public Dto.Common.List.Tag TagQuery(Expression<Func<Dto.Common.Tag, bool>> filter)
    //{
    //    return new Dto.Common.List.Tag(
    //        _commonTagRepository.Query(filter).ToList().Select(tag => new Dto.Common.Tag(
    //            tag.TagId, tag.AutomationTypeId, tag.Name,
    //            tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
    //            tag.Invoke,
    //            tag.TagGroupId
    //        )).ToList()
    //    );
    //}

    //public async Task<Dto.Common.List.Tag> TagQueryAsync(Expression<Func<Domain.Db.Entity.Common.Tag, bool>> filter)
    //{
    //    return await Task<Dto.Common.List.Tag>.Factory.StartNew(() => TagQuery(filter));
    //}

    public async ValueTask<Srv.Dto.Common.List.Tag> TagAsync(/*bool enabledOnly*/CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        //if (enabledOnly)
        //{
        //    return new Dto.Common.List.Tag(
        //        _commonTagRepository.TagsEnabled.ToList().Select(tag => new Dto.Common.Tag(
        //            tag.TagId, /*tag.AutomationTypeId,*/ tag.Name,
        //            tag.StdConnectionId,
        //            tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //            tag.Invoke,
        //            tag.TagGroupId
        //        )).ToList()
        //    );
        //}
        //return new Dto.Common.List.Tag(
        //    _commonTagRepository.Tags.ToList().Select(tag => new Dto.Common.Tag(
        //        tag.Id, tag.AutomationTypeId, tag.Name,
        //        tag.ConnectionId,
        //        tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //        tag.Address,
        //        tag.Invoke,
        //        tag.TagGroupId
        //    )).ToList()
        //);

        return null;
    }

    public async ValueTask<Srv.Dto.Common.List.Tag> TagByGroupIdAsync(GroupId groupId, CallContext context = default)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Srv.Dto.Common.List.Tag> TagByGroupNameAsync(GroupName groupName, CallContext context = default)
    {
        throw new NotImplementedException();
    }

    //public async Task<Dto.Common.List.Tag> TagAsync(/*bool enabledOnly*/)
    //{
    //    return await Task<Dto.Common.List.Tag>.Factory.StartNew(() => Tag(/*enabledOnly*/));
    //}

    public async ValueTask<Srv.Dto.Common.List.Tag> TagByGroupIdAsync(/*bool enabledOnly,*/ Guid groupId, CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        //if (enabledOnly)
        //{
        //    //return new Dto.Common.List.Tag(
        //    //    _commonTagRepository.Query(tag => tag.TagGroupId.Equals(groupId)).ToList().Select(tag => new Dto.Common.Tag(
        //    //        tag.TagId, tag.AutomationTypeId, tag.Name,
        //    //        tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //    //        tag.Invoke,
        //    //        tag.TagGroupId
        //    //    )).ToList()
        //    //);
        //    return new Dto.Common.List.Tag(
        //        _commonTagRepository.TagsEnabled.Where(tag => tag.TagGroupId.Equals(groupId)).ToList().Select(tag => new Dto.Common.Tag(
        //            tag.TagId, /*tag.AutomationTypeId, */tag.Name,
        //            tag.StdConnectionId,
        //            tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //            tag.Invoke,
        //            tag.TagGroupId
        //        )).ToList()
        //    );
        //}
        return new Srv.Dto.Common.List.Tag(
            _commonTagRepository.Query(tag => tag.TagGroupId.Equals(groupId)).ToList().Select(tag => new Srv.Dto.Common.Tag(
                    tag.Id, tag.AutomationTypeId, tag.Name,
                    tag.ConnectionId,
                    tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
                    tag.MemoryAddress,
                    tag.Invoke,
                    tag.TagGroupId
                ))
                .ToList()
        );
        //return new Dto.Common.List.Tag(
        //    _commonTagRepository.Tags.Where(tag => tag.TagGroupId.Equals(groupId)).ToList().Select(tag => new Dto.Common.Tag(
        //        tag.TagId, tag.AutomationTypeId, tag.Name,
        //        tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //        tag.Invoke,
        //        tag.TagGroupId
        //    )).ToList()
        //);
    }

    //public async Task<Dto.Common.List.Tag> TagByGroupIdAsync(/*bool enabledOnly,*/ Guid groupId)
    //{
    //    return await Task<Dto.Common.List.Tag>.Factory.StartNew(() => TagByGroupId(/*enabledOnly,*/ groupId));
    //}

    public async ValueTask<Srv.Dto.Common.List.Tag> TagByGroupNameAsync(/*bool enabledOnly,*/ string groupName, CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        //if (enabledOnly)
        //{
        //    //return new Dto.Common.List.Tag(
        //    //    _commonTagRepository.TagsEnabled.Where(tag => tag.TagGroup.Name.Equals(groupName)).ToList().Select(tag => new Dto.Common.Tag(
        //    //        tag.TagId, tag.AutomationTypeId, tag.Name,
        //    //        tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //    //        tag.Invoke,
        //    //        tag.TagGroupId
        //    //    )).ToList()
        //    //);

        //    return new Dto.Common.List.Tag(
        //        _commonTagRepository.TagsEnabled.Where(tag => tag.TagGroup.Name.Equals(groupName)).ToList().Select(tag => new Dto.Common.Tag(
        //            tag.TagId, /*tag.AutomationTypeId,*/ tag.Name,
        //            tag.StdConnectionId,
        //            tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //            tag.Invoke,
        //            tag.TagGroupId
        //        )).ToList()
        //    );
        //}
        //return new Dto.Common.List.Tag(
        //    _commonTagRepository.Tags.Where(tag => tag.TagGroup.Name.Equals(groupName)).ToList().Select(tag => new Dto.Common.Tag(
        //        tag.Id, tag.AutomationTypeId, tag.Name,
        //        tag.ConnectionId,
        //        tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal,
        //        tag.Address,
        //        tag.Invoke,
        //        tag.TagGroupId
        //    )).ToList()
        //);

        return null;
    }

    //public async Task<Dto.Common.List.Tag> TagByGroupNameAsync(/*bool enabledOnly,*/ string groupName)
    //{
    //    return await Task<Dto.Common.List.Tag>.Factory.StartNew(() => TagByGroupName(/*enabledOnly,*/ groupName));
    //}

    public async ValueTask<Srv.Dto.Common.List.TagGroup> TagGroupAsync(/*bool enabledOnly*/CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        //if (enabledOnly)
        //{
        //    return new Dto.Common.List.TagGroup
        //    (
        //        _commonTagGroupRepository.TagGroupsEnabled.ToList().Select(tagGroup => new Dto.Common.TagGroup
        //        (tagGroup.TagGroupId, tagGroup.Name, tagGroup.Clock, tagGroup.Update, tagGroup.Enable
        //        )).ToList()
        //    );
        //}

        //return new Dto.Common.List.TagGroup
        //(
        //    _commonTagGroupRepository.TagGroups.ToList().Select(tagGroup => new Dto.Common.TagGroup
        //    (tagGroup.Id, tagGroup.Name, tagGroup.Clock, tagGroup.Update, tagGroup.Enable
        //    )).ToList()
        //);

        return null;
    }

    //public async Task<Dto.Common.List.TagGroup> TagGroupAsync(/*bool enabledOnly*/)
    //{
    //    return await Task<Dto.Common.List.TagGroup>.Factory.StartNew(() => TagGroup(/*enabledOnly*/));
    //}

    public async ValueTask<Srv.Dto.Common.List.Connection> ConnectionAsync(CallContext context = default)
    {
        _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        //return new Dto.Common.List.Connection(
        //    _commonConnectionRepository.Connections.ToList().Select(connection => new Dto.Common.Connection(
        //        connection.Id, connection.AutomationTypeId, connection.Name, connection.Ip,/* connection.StdConnectionId,*/
        //        //connection.Rack, connection.Slot, connection.ConnectionTypeId
        //        //connection.RequestedId,
        //        connection.Enable, connection.WriteEnable
        //    )).ToList()
        //);

        return null;
    }

    //public async Task<Dto.Common.List.Connection> ConnectionAsync()
    //{
    //    return await Task<Dto.Common.List.Connection>.Factory.StartNew(Connection);
    //}
}