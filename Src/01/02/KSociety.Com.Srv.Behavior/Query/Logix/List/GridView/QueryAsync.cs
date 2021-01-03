using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Logix.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.Logix.List.GridView
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IMapper _mapper;
        private readonly Domain.Repository.Logix.IConnection _logixConnectionRepository;
        private readonly Domain.Repository.Logix.ITag _logixTagRepository;
        private readonly IBit _commonBitRepository;
        private readonly Domain.Repository.Common.ITag _commonTagRepository;
        private readonly Domain.Repository.Common.IConnection _commonConnectionRepository;
        private readonly IAutomationType _commonAutomationTypeRepository;
        private readonly IAnalogDigital _commonAnalogDigitalRepository;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly IInOut _commonInOutRepository;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            Domain.Repository.Logix.IConnection logixConnectionRepository,
            Domain.Repository.Logix.ITag logixTagRepository,
            IBit commonBitRepository,
            Domain.Repository.Common.ITag commonTagRepository,
            Domain.Repository.Common.IConnection commonConnectionRepository,
            IAutomationType commonAutomationTypeRepository,
            IAnalogDigital commonAnalogDigitalRepository,
            ITagGroup commonTagGroupRepository,
            IInOut commonInOutRepository
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _mapper = mapper;
            _logixConnectionRepository = logixConnectionRepository;
            _logixTagRepository = logixTagRepository;
            _commonBitRepository = commonBitRepository;
            _commonTagRepository = commonTagRepository;
            _commonConnectionRepository = commonConnectionRepository;
            _commonAutomationTypeRepository = commonAutomationTypeRepository;
            _commonAnalogDigitalRepository = commonAnalogDigitalRepository;
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonInOutRepository = commonInOutRepository;
        }

        public async ValueTask<Dto.Logix.List.GridView.LogixConnection> LogixConnectionAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = await _logixConnectionRepository.GetAllLogixConnectionAsync();
            var connectionItems = repository.ToList().Select(
                connection => _mapper.Map<Srv.Dto.Logix.LogixConnection>(connection)
            ).ToList();

            var output = new Srv.Dto.Logix.List.GridView.LogixConnection(connectionItems);

            return output;
        }

        public async ValueTask<Srv.Dto.Logix.List.GridView.LogixTag> LogixTagAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = await _logixTagRepository.GetAllLogixTagAsync();
            var logixTagItems = repository.ToList().Select(
                logixTag => _mapper.Map<Srv.Dto.Logix.LogixTag>(logixTag)
            ).ToList();

            var commonAnalogDigitalRepository = await _commonAnalogDigitalRepository.GetAllAnalogDigitalAsync();

            var commonAnalogDigitalDns = commonAnalogDigitalRepository.ToList().Select(
                    commonAnalogDigital =>
                        new KeyValuePair<string, string>(commonAnalogDigital.AnalogDigitalSignal, commonAnalogDigital.AnalogDigitalSignal))
                .ToList();

            var commonTagGroupRepository = await _commonTagGroupRepository.GetAllTagGroupAsync();

            var commonTagGroupDns = commonTagGroupRepository.ToList().Select(
                    commonTagGroup =>
                        new KeyValuePair<Guid, string>(commonTagGroup.Id, commonTagGroup.Name))
                .ToList();

            var commonInOutRepository = await _commonInOutRepository.GetAllInOutAsync();

            var commonInOutDns = commonInOutRepository.ToList().Select(
                    commonInOut =>
                        new KeyValuePair<string, string>(commonInOut.InputOutput, commonInOut.InputOutputName))
                .ToList();

            var commonConnectionRepository = await _commonConnectionRepository.GetAllConnectionAsync();

            var commonConnectionDns = commonConnectionRepository.ToList().Select(
                    commonConnection =>
                        new KeyValuePair<Guid, string>(commonConnection.Id, commonConnection.Name))
                .ToList();

            var commonBitRepository = await _commonBitRepository.GetAllBitAsync();

            var commonBitDns = commonBitRepository.ToList().Select(
                    commonBit =>
                        new KeyValuePair<byte, string>(commonBit.BitOfByte, commonBit.BitName))
                .ToList();

            var output = new Srv.Dto.Logix.List.GridView.LogixTag(
                logixTagItems, commonAnalogDigitalDns, commonTagGroupDns,
                commonInOutDns, commonConnectionDns, commonBitDns);

            return output;
        }
    }
}
