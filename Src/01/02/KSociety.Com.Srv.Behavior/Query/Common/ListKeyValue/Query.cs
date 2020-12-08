using System;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.ListKeyValue;
using KSociety.Com.Domain.Repository.Common;
using System.Linq;

namespace KSociety.Com.Srv.Behavior.Query.Common.ListKeyValue
{
    public class Query : IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IAnalogDigital _commonAnalogDigitalRepository;
        private readonly IInOut _commonInOutRepository;
        private readonly IAutomationType _commonAutomationTypeRepository;
        private readonly IConnection _commonConnectionRepository;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly IBit _commonBitRepository;

        public Query
        (
            ILoggerFactory loggerFactory,
            IAnalogDigital commonAnalogDigitalRepository,
            IInOut commonInOutRepository,
            IAutomationType commonAutomationTypeRepository,
            IConnection commonConnectionRepository,
            ITagGroup commonTagGroupRepository,
            IBit commonBitRepository
        )
        {
            _logger = loggerFactory.CreateLogger<Query>();
            _commonAnalogDigitalRepository = commonAnalogDigitalRepository;
            _commonInOutRepository = commonInOutRepository;
            _commonAutomationTypeRepository = commonAutomationTypeRepository;
            _commonConnectionRepository = commonConnectionRepository;
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonBitRepository = commonBitRepository;
        }

        public KbListKeyValuePair<int, string> AutomationTypeId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonAutomationTypeRepository = _commonAutomationTypeRepository.GetAllAutomationType();

            var commonAutomationTypeDns = commonAutomationTypeRepository.ToList().Select(
                    commonAutomationType =>
                        new KbKeyValuePair<int, string>(commonAutomationType.Id, commonAutomationType.Name))
                .ToList();

            return new KbListKeyValuePair<int, string>(commonAutomationTypeDns);
        }

        public KbListKeyValuePair<string, string> InputOutput(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonInOutRepository = _commonInOutRepository.GetAllInOut();

            var commonInOutDns = commonInOutRepository.ToList().Select(
                    commonInOut =>
                        new KbKeyValuePair<string, string>(commonInOut.InputOutput, commonInOut.InputOutputName))
                .ToList();

            return new KbListKeyValuePair<string, string>(commonInOutDns);
        }

        public KbListKeyValuePair<string, string> AnalogDigitalSignal(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonAnalogDigitalRepository = _commonAnalogDigitalRepository.GetAllAnalogDigital();

            var commonAnalogDigitalDns = commonAnalogDigitalRepository.ToList().Select(
                    commonAnalogDigital =>
                        new KbKeyValuePair<string, string>(commonAnalogDigital.AnalogDigitalSignal, commonAnalogDigital.AnalogDigitalSignal))
                .ToList();

            return new KbListKeyValuePair<string, string>(commonAnalogDigitalDns);
        }

        public KbListKeyValuePair<Guid, string> ConnectionId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonConnectionRepository = _commonConnectionRepository.GetAllConnection();

            var commonConnectionDns = commonConnectionRepository.ToList().Select(
                    commonConnection =>
                        new KbKeyValuePair<Guid, string>(commonConnection.Id, commonConnection.Name))
                .ToList();

            return new KbListKeyValuePair<Guid, string>(commonConnectionDns);
        }

        public KbListKeyValuePair<Guid, string> TagGroupId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonTagGroupRepository = _commonTagGroupRepository.GetAllTagGroup();

            var commonTagGroupDns = commonTagGroupRepository.ToList().Select(
                    commonTagGroup =>
                        new KbKeyValuePair<Guid, string>(commonTagGroup.Id, commonTagGroup.Name))
                .ToList();

            return new KbListKeyValuePair<Guid, string>(commonTagGroupDns);
        }

        public KbListKeyValuePair<byte, string> BitOfByte(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var bitOfByteRepository = _commonBitRepository.GetAllBit();

            var bitOfByteDns = bitOfByteRepository.ToList().Select(
                    bitOfByte =>
                        new KbKeyValuePair<byte, string>(bitOfByte.BitOfByte, bitOfByte.BitName))
                .ToList();

            return new KbListKeyValuePair<byte, string>(bitOfByteDns);
        }
    }
}
