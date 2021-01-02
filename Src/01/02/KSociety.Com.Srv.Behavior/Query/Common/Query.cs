using System;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Common;
using Microsoft.Extensions.Logging;
using KSociety.Com.Srv.Dto.Common;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Common
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly ITag _commonTagRepository;
        private readonly IConnection _commonConnectionRepository;

        public Query(
            ILoggerFactory loggerFactory,
            ITagGroup commonTagGroupRepository,
            ITag commonTagRepository,
            IConnection commonConnectionRepository
        )
        {
            _logger = loggerFactory.CreateLogger<Query>();
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonTagRepository = commonTagRepository;
            _commonConnectionRepository = commonConnectionRepository;
        }

        public Srv.Dto.Common.TagGroup GetTagGroupById(IdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.TagGroup tagGroup = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                tagGroup = _commonTagGroupRepository.Find(idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new TagGroup(tagGroup.Id, tagGroup.Name, tagGroup.Clock, tagGroup.Update, tagGroup.Enable);
        }

        public Srv.Dto.Common.Tag GetTagById(IdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.Tag tag = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                tag = _commonTagRepository.Find(idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Tag(tag.Id, tag.AutomationTypeId, tag.Name, tag.ConnectionId, tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal, tag.MemoryAddress, tag.Invoke, tag.TagGroupId);
        }

        public Srv.Dto.Common.Connection GetConnectionById(IdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.Connection connection = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                connection = _commonConnectionRepository.Find(idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Connection(connection.Id, connection.AutomationTypeId, connection.Name, connection.Ip, connection.Enable, connection.WriteEnable);
        }

    }
}
