using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Srv.Contract.Query.Common.ListKeyValue;
using KSociety.Com.Domain.Repository.Common;
using System.Linq;

namespace KSociety.Com.Srv.Behavior.Query.Common.ListKeyValue
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IAnalogDigital _commonAnalogDigitalRepository;
        private readonly IInOut _commonInOutRepository;
        private readonly IAutomationType _commonAutomationTypeRepository;
        private readonly IConnection _commonConnectionRepository;
        private readonly ITagGroup _commonTagGroupRepository;
        private readonly IBit _commonBitRepository;

        public QueryAsync
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
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _commonAnalogDigitalRepository = commonAnalogDigitalRepository;
            _commonInOutRepository = commonInOutRepository;
            _commonAutomationTypeRepository = commonAutomationTypeRepository;
            _commonConnectionRepository = commonConnectionRepository;
            _commonTagGroupRepository = commonTagGroupRepository;
            _commonBitRepository = commonBitRepository;
        }

        public async ValueTask<KbListKeyValuePair<int, string>> AutomationTypeIdAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonAutomationTypeRepository = await _commonAutomationTypeRepository.GetAllAutomationTypeAsync();

            var commonAutomationTypeDns = commonAutomationTypeRepository.ToList().Select(
                    commonAutomationType =>
                        new KbKeyValuePair<int, string>(commonAutomationType.Id, commonAutomationType.Name))
                .ToList();

            return new KbListKeyValuePair<int, string>(commonAutomationTypeDns);
        }

        public async ValueTask<KbListKeyValuePair<string, string>> InputOutputAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonInOutRepository = await _commonInOutRepository.GetAllInOutAsync();

            var commonInOutDns = commonInOutRepository.ToList().Select(
                    commonInOut =>
                        new KbKeyValuePair<string, string>(commonInOut.InputOutput, commonInOut.InputOutputName))
                .ToList();

            return new KbListKeyValuePair<string, string>(commonInOutDns);
        }

        public async ValueTask<KbListKeyValuePair<string, string>> AnalogDigitalSignalAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonAnalogDigitalRepository = await _commonAnalogDigitalRepository.GetAllAnalogDigitalAsync();

            var commonAnalogDigitalDns = commonAnalogDigitalRepository.ToList().Select(
                    commonAnalogDigital =>
                        new KbKeyValuePair<string, string>(commonAnalogDigital.AnalogDigitalSignal, commonAnalogDigital.AnalogDigitalSignal))
                .ToList();

            return new KbListKeyValuePair<string, string>(commonAnalogDigitalDns);
        }

        public async ValueTask<KbListKeyValuePair<Guid, string>> ConnectionIdAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonConnectionRepository = await _commonConnectionRepository.GetAllConnectionAsync();

            var commonConnectionDns = commonConnectionRepository.ToList().Select(
                    commonConnection =>
                        new KbKeyValuePair<Guid, string>(commonConnection.Id, commonConnection.Name))
                .ToList();

            return new KbListKeyValuePair<Guid, string>(commonConnectionDns);
        }

        public async ValueTask<KbListKeyValuePair<Guid, string>> TagGroupIdAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var commonTagGroupRepository = await _commonTagGroupRepository.GetAllTagGroupAsync();

            var commonTagGroupDns = commonTagGroupRepository.ToList().Select(
                    commonTagGroup =>
                        new KbKeyValuePair<Guid, string>(commonTagGroup.Id, commonTagGroup.Name))
                .ToList();

            return new KbListKeyValuePair<Guid, string>(commonTagGroupDns);
        }

        public async ValueTask<KbListKeyValuePair<byte, string>> BitOfByteAsync(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var bitOfByteRepository = await _commonBitRepository.GetAllBitAsync();

            var bitOfByteDns = bitOfByteRepository.ToList().Select(
                    bitOfByte =>
                        new KbKeyValuePair<byte, string>(bitOfByte.BitOfByte, bitOfByte.BitName))
                .ToList();

            return new KbListKeyValuePair<byte, string>(bitOfByteDns);
        }
    }
}
