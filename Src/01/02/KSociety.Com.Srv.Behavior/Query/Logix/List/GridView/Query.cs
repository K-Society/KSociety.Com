using System;
using System.Linq;
using AutoMapper;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Domain.Repository.Common;
using KSociety.Com.Srv.Contract.Query.Logix.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Com.Srv.Dto.Logix.List.GridView;

namespace KSociety.Com.Srv.Behavior.Query.Logix.List.GridView
{

    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
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

        public Query(
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
            _logger = loggerFactory.CreateLogger<Query>();
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

        public LogixConnection LogixConnection(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = _logixConnectionRepository.GetAllLogixConnection();
            var connectionItems = repository.ToList().Select(
                connection => _mapper.Map<Srv.Dto.Logix.LogixConnection>(connection)
            ).ToList();

            var output = new Srv.Dto.Logix.List.GridView.LogixConnection(connectionItems);

            return output;
        }
        
        public Srv.Dto.Logix.List.GridView.LogixTag LogixTag(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            
            var repository = _logixTagRepository.GetAllLogixTag();
            var logixTagItems = repository.ToList().Select(
                logixTag => _mapper.Map<Srv.Dto.Logix.LogixTag>(logixTag)
            ).ToList();
            
            var commonAnalogDigitalRepository = _commonAnalogDigitalRepository.GetAllAnalogDigital();

            var commonAnalogDigitalDns = commonAnalogDigitalRepository.ToList().Select(
                    commonAnalogDigital =>
                        new KbKeyValuePair<string, string>(commonAnalogDigital.AnalogDigitalSignal, commonAnalogDigital.AnalogDigitalSignal))
                .ToList();

            var commonTagGroupRepository = _commonTagGroupRepository.GetAllTagGroup();

            var commonTagGroupDns = commonTagGroupRepository.ToList().Select(
                    commonTagGroup =>
                        new KbKeyValuePair<Guid, string>(commonTagGroup.Id, commonTagGroup.Name))
                .ToList();

            var commonInOutRepository = _commonInOutRepository.GetAllInOut();

            var commonInOutDns = commonInOutRepository.ToList().Select(
                    commonInOut =>
                        new KbKeyValuePair<string, string>(commonInOut.InputOutput, commonInOut.InputOutputName))
                .ToList();

            var commonConnectionRepository = _commonConnectionRepository.GetAllConnection();

            var commonConnectionDns = commonConnectionRepository.ToList().Select(
                    commonConnection =>
                        new KbKeyValuePair<Guid, string>(commonConnection.Id, commonConnection.Name))
                .ToList();

            var commonBitRepository = _commonBitRepository.GetAllBit();

            var commonBitDns = commonBitRepository.ToList().Select(
                    commonBit =>
                        new KbKeyValuePair<byte, string>(commonBit.BitOfByte, commonBit.BitName))
                .ToList();

            var output = new Srv.Dto.Logix.List.GridView.LogixTag(
                logixTagItems, commonAnalogDigitalDns, commonTagGroupDns,
                commonInOutDns, commonConnectionDns, commonBitDns);

            return output;
        }
    }
}
