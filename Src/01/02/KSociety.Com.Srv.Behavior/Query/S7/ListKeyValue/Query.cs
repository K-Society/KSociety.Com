using System;
using System.Linq;
using KSociety.Base.Srv.Dto;
using KSociety.Com.Domain.Repository.S7;
using KSociety.Com.Srv.Contract.Query.S7.ListKeyValue;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Com.Srv.Behavior.Query.S7.ListKeyValue
{
    public class Query :IQuery
    {
        private readonly ILogger<Query> _logger;
        private readonly IConnectionType _s7ConnectionTypeRepository;
        private readonly ICpuType _s7CpuTypeRepository;
        private readonly IArea _s7AreaRepository;
        private readonly IWordLen _s7WordLenRepository;
        private readonly IConnection _s7ConnectionRepository;


        public Query
        (
            ILoggerFactory loggerFactory,
            IConnectionType s7ConnectionTypeRepository,
            ICpuType s7CpuTypeRepository,
            IArea s7AreaRepository,
            IWordLen s7WordLenRepository,
            IConnection s7ConnectionRepository
        )
        {
            _logger = loggerFactory.CreateLogger<Query>();
            _s7ConnectionTypeRepository = s7ConnectionTypeRepository;
            _s7CpuTypeRepository = s7CpuTypeRepository;
            _s7AreaRepository = s7AreaRepository;
            _s7WordLenRepository = s7WordLenRepository;
            _s7ConnectionRepository = s7ConnectionRepository;
        }

        public ListKeyValuePair<int, string> ConnectionTypeId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var connectionTypeRepository = _s7ConnectionTypeRepository.GetAllConnectionType();

            var connectionTypeDns = connectionTypeRepository.ToList().Select(
                    connectionType =>
                        new KeyValuePair<int, string>(connectionType.Id, connectionType.Name))
                .ToList();

            return new ListKeyValuePair<int, string>(connectionTypeDns);
        }

        public ListKeyValuePair<int, string> CpuTypeId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var cpuTypeRepository = _s7CpuTypeRepository.GetAllCpuType();

            var cpuTypeDns = cpuTypeRepository.ToList().Select(
                    cpuType =>
                        new KeyValuePair<int, string>(cpuType.Id, cpuType.CpuTypeName))
                .ToList();

            return new ListKeyValuePair<int, string>(cpuTypeDns);
        }

        public ListKeyValuePair<int, string> AreaId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var areaRepository = _s7AreaRepository.GetAllArea();

            var areaDns = areaRepository.ToList().Select(
                    area =>
                        new KeyValuePair<int, string>(area.Id, area.AreaName))
                .ToList();

            return new ListKeyValuePair<int, string>(areaDns);
        }

        public ListKeyValuePair<int, string> WordLenId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var wordLenRepository = _s7WordLenRepository.GetAllWordLen();

            var wordLenDns = wordLenRepository.ToList().Select(
                    wordLen =>
                        new KeyValuePair<int, string>(wordLen.Id, wordLen.WordLenName))
                .ToList();

            return new ListKeyValuePair<int, string>(wordLenDns);
        }

        public ListKeyValuePair<Guid, string> S7ConnectionId(CallContext context = default)
        {
            _logger.LogTrace("Query: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var s7ConnectionRepository = _s7ConnectionRepository.GetAllS7Connection();

            var s7ConnectionDns = s7ConnectionRepository.ToList().Select(
                    s7Connection =>
                        new KeyValuePair<Guid, string>(s7Connection.Id, s7Connection.Name))
                .ToList();

            return new ListKeyValuePair<Guid, string>(s7ConnectionDns);
        }
    }
}
