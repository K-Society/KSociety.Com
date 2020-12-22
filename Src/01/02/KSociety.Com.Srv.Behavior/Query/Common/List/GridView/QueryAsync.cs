using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Common.List.GridView
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IMapper _mapper;
        private readonly ITag _commonTagRepository;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly IConnection _commonConnectionRepository;
        private readonly Contract.Query.Common.ListKeyValue.IQueryAsync _queryListKeyValue;

        public QueryAsync
        (
            ILoggerFactory loggerFactory,
            IMapper mapper,
            ITag commonTagRepository,
            ITagGroup commonTagGroupRepository,
            IConnection commonConnectionRepository,
            Contract.Query.Common.ListKeyValue.IQueryAsync queryListKeyValue
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _mapper = mapper;
            _commonTagRepository = commonTagRepository;
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonConnectionRepository = commonConnectionRepository;
            _queryListKeyValue = queryListKeyValue;
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.Tag> TagAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = await _commonTagRepository.GetAllTagAsync();
            var tagItems = repository.ToList().Select(
                tag => _mapper.Map<Srv.Dto.Common.Tag>(tag)
            ).ToList();

            var commonAutomationTypeDns = await _queryListKeyValue.AutomationTypeIdAsync(context);

            var commonAnalogDigitalDns = await _queryListKeyValue.AnalogDigitalSignalAsync(context);

            var commonTagGroupDns = await _queryListKeyValue.TagGroupIdAsync(context);

            var commonInOutDns = await _queryListKeyValue.InputOutputAsync(context);

            var commonConnectionDns = await _queryListKeyValue.ConnectionIdAsync(context);

            var output = new Srv.Dto.Common.List.GridView.Tag(
                tagItems, commonAutomationTypeDns.List,
                commonAnalogDigitalDns.List, commonTagGroupDns.List,
                commonInOutDns.List, commonConnectionDns.List);

            return output;
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.TagGroup> TagGroupAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                var repository = await _commonTagGroupRepository.GetAllTagGroupAsync();
                var tagGroupItems = repository.ToList().Select(
                    tagGroup => _mapper.Map<Srv.Dto.Common.TagGroup>(tagGroup)
                ).ToList();

                var output = new Srv.Dto.Common.List.GridView.TagGroup(tagGroupItems);

                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " - " + ex.StackTrace);
                return await new ValueTask<Dto.Common.List.GridView.TagGroup>();
            }
        }

        public async ValueTask<Srv.Dto.Common.List.GridView.Connection> ConnectionAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                var repository = await _commonConnectionRepository.GetAllConnectionAsync();
                var connectionItems = repository.ToList().Select(
                    connection => _mapper.Map<Srv.Dto.Common.Connection>(connection)
                ).ToList();

                var commonAutomationTypeDns = await _queryListKeyValue.AutomationTypeIdAsync(context);

                var output = new Srv.Dto.Common.List.GridView.Connection(connectionItems, commonAutomationTypeDns.List);

                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " - " + ex.StackTrace);
                return await new ValueTask<Dto.Common.List.GridView.Connection>();
            }
        }
    }
}
