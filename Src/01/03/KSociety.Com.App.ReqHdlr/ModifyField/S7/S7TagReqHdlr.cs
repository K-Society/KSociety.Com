using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.ModifyField.S7;

public class S7TagReqHdlr :
    IRequestHandlerWithResponse<S7Tag, KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag>,
    IRequestHandlerWithResponseAsync<S7Tag, KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<S7TagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;

    public S7TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<S7TagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag Execute(S7Tag request)
    {
        _logger.LogInformation("" + request.Id + " " + request.FieldName + " " + request.Value);
        var s7Tag = _tagRepository.Find(request.Id); //.GetAllS7Tag().SingleOrDefault(g => g.Id == request.Id);
        s7Tag.AddLoggerFactory(_loggerFactory);
        s7Tag?.ModifyField(request.FieldName, request.Value);
        var result = new KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag(_unitOfWork.Commit() > 0);
        return result;
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag> ExecuteAsync(S7Tag request, CancellationToken cancellationToken = default)
    {
        var s7Tag = await _tagRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllS7Tag().SingleOrDefault(g => g.Id == request.Id);
        s7Tag.AddLoggerFactory(_loggerFactory);
        s7Tag?.ModifyField(request.FieldName, request.Value);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return new KSociety.Com.App.Dto.Res.ModifyField.S7.S7Tag(result > 0);
    }
}