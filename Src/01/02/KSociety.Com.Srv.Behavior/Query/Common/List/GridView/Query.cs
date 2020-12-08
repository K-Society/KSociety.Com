using AutoMapper;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Common.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using System.Linq;

namespace KSociety.Com.Srv.Behavior.Query.Common.List.GridView
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IMapper _mapper;
        private readonly ITag _commonTagRepository;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly IConnection _commonConnectionRepository;
        private readonly Contract.Query.Common.ListKeyValue.IQuery _queryListKeyValue;

        public Query
        (
            ILoggerFactory loggerFactory,
            IMapper mapper,
            ITag commonTagRepository,
            ITagGroup commonTagGroupRepository,
            IConnection commonConnectionRepository,
            Contract.Query.Common.ListKeyValue.IQuery queryListKeyValue
        )
        {
            _logger = loggerFactory.CreateLogger<Query>();
            _mapper = mapper;
            _commonTagRepository = commonTagRepository;
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonConnectionRepository = commonConnectionRepository;
            _queryListKeyValue = queryListKeyValue;
        }
        
        public Srv.Dto.Common.List.GridView.Tag Tag(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = _commonTagRepository.GetAllTag();
            var tagItems = repository.ToList().Select(
                tag => _mapper.Map<Srv.Dto.Common.Tag>(tag)
            ).ToList();

            var commonAutomationTypeDns = _queryListKeyValue.AutomationTypeId();

            var commonAnalogDigitalDns = _queryListKeyValue.AnalogDigitalSignal();

            var commonTagGroupDns = _queryListKeyValue.TagGroupId();

            var commonInOutDns = _queryListKeyValue.InputOutput();

            var commonConnectionDns = _queryListKeyValue.ConnectionId();

            var output = new Srv.Dto.Common.List.GridView.Tag(
                tagItems, commonAutomationTypeDns.List, 
                commonAnalogDigitalDns.List, commonTagGroupDns.List,
                commonInOutDns.List, commonConnectionDns.List);

            return output;
        }
        
        public Srv.Dto.Common.List.GridView.TagGroup TagGroup(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = _commonTagGroupRepository.GetAllTagGroup();
            var tagGroupItems = repository.ToList().Select(
                tagGroup => _mapper.Map<Srv.Dto.Common.TagGroup>(tagGroup)
            ).ToList();
            
            var output = new Srv.Dto.Common.List.GridView.TagGroup(tagGroupItems);

            return output;
        }
        
        public Srv.Dto.Common.List.GridView.Connection Connection(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = _commonConnectionRepository.GetAllConnection();
            var connectionItems = repository.ToList().Select(
                connection => _mapper.Map<Srv.Dto.Common.Connection>(connection)
            ).ToList();

            var commonAutomationTypeDns = _queryListKeyValue.AutomationTypeId();

            var output = new Srv.Dto.Common.List.GridView.Connection(connectionItems, commonAutomationTypeDns.List);

            return output;
        }
    }
}
