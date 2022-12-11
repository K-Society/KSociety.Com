using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.Logix;
using KSociety.Com.Domain.Repository.Logix;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.ModifyField.Logix;

public class LogixTagReqHdlr :
    IRequestHandlerWithResponse<LogixTag, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag>,
    IRequestHandlerWithResponseAsync<LogixTag, KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag>
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<LogixTagReqHdlr> _logger;
    private readonly IDatabaseUnitOfWork _unitOfWork;
    private readonly ITag _tagRepository;

    public LogixTagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
    {
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<LogixTagReqHdlr>();
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag Execute(LogixTag request)
    {
        var logixTag = _tagRepository.Find(request.Id); //.GetAllLogixTag().SingleOrDefault(g => g.Id == request.Id);
        logixTag?.ModifyField(request.FieldName, request.Value);
        var result = _unitOfWork.Commit();
        return new KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag(result > 0);
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag> ExecuteAsync(LogixTag request, CancellationToken cancellationToken = default)
    {
        var logixTag = await  _tagRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllLogixTag().SingleOrDefault(g => g.Id == request.Id);
        logixTag?.ModifyField(request.FieldName, request.Value);
        var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
        return new KSociety.Com.App.Dto.Res.ModifyField.Logix.LogixTag(result > 0);
    }
}