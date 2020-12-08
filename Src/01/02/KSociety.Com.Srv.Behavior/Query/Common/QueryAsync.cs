using System;
using System.Threading.Tasks;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Common;
using Microsoft.Extensions.Logging;
using KSociety.Com.Srv.Dto.Common;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Common
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly ITag _commonTagRepository;
        private readonly IConnection _commonConnectionRepository;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            ITagGroup commonTagGroupRepository,
            ITag commonTagRepository,
            IConnection commonConnectionRepository
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonTagRepository = commonTagRepository;
            _commonConnectionRepository = commonConnectionRepository;
        }

        public async ValueTask<Srv.Dto.Common.TagGroup> GetTagGroupByIdAsync(KbIdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.TagGroup tagGroup = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                tagGroup = await _commonTagGroupRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new TagGroup(tagGroup.Id, tagGroup.Name, tagGroup.Clock, tagGroup.Update, tagGroup.Enable);
        }

        public async ValueTask<Srv.Dto.Common.Tag> GetTagByIdAsync(KbIdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.Tag tag = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                tag = await _commonTagRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Tag(tag.Id, tag.AutomationTypeId, tag.Name, tag.ConnectionId, tag.Enable, tag.InputOutput, tag.AnalogDigitalSignal, tag.MemoryAddress, tag.Invoke, tag.TagGroupId);
        }

        public async ValueTask<Srv.Dto.Common.Connection> GetConnectionByIdAsync(KbIdObject idObject, CallContext context = default)
        {
            Domain.Entity.Common.Connection connection = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                connection = await _commonConnectionRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + ex.Message + " - " + ex.StackTrace);
            }

            return new Connection(connection.Id, connection.AutomationTypeId, connection.Name, connection.Ip, connection.Enable, connection.WriteEnable);
        }

    }
}

