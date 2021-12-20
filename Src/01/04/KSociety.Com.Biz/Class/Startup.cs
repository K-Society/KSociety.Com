using Autofac;
using KSociety.Com.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.Biz.Class;

public class Startup : IStartable
{
    private readonly ILogger<Startup> _logger;
    private readonly ILoggerFactory _loggerFactory;

    private readonly IBiz _biz;
    //private readonly IConnectionFactory _connectionFactory;
    //private readonly INotifierMediatorService _notifierMediatorService;
    //private readonly ITagGroupReady _tagGroupReady;
    //private readonly IAllTagGroupAllConnection _allTagGroupAllConnection;

    //private readonly string _machineName;
    //private List<Domain.Com.Entity.View.Joined.AllTagGroupAllConnection> _dataList;
    //public Dictionary<string, Domain.Com.Entity.Common.TagGroup> SystemGroups { get; } = new Dictionary<string, Domain.Com.Entity.Common.TagGroup>();

    //public Dictionary<string, IEventBus> TagGroupEventBus { get; } = new Dictionary<string, IEventBus>();
        
    public Startup(
        ILoggerFactory loggerFactory,
        IBiz biz
        //IConnectionFactory connectionFactory,
        //INotifierMediatorService notifierMediatorService,
        //ITagGroupReady tagGroupReady,
        //IAllTagGroupAllConnection allTagGroupAllConnection
    )
    {
            
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<Startup>();

        _biz = biz;
        //_connectionFactory = connectionFactory;
        //_notifierMediatorService = notifierMediatorService;
        //_tagGroupReady = tagGroupReady;
        //_allTagGroupAllConnection = allTagGroupAllConnection;

        //_machineName = Environment.MachineName;
        _logger.LogInformation("KBase.Business.Com startup machine name: ");
    }

    public void Start()
    {
        _logger.LogTrace("KBase.Business.Com staring...");
            

        _biz.LoadGroup();
    }
}