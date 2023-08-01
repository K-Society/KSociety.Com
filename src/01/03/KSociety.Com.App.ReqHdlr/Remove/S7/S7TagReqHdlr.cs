using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Com.App.Dto.Req.Remove.S7;
using KSociety.Com.Domain.Repository.S7;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Remove.S7;

public class S7TagReqHdlr :
    IRequestHandlerWithResponse<S7Tag, KSociety.Com.App.Dto.Res.Remove.S7.S7Tag>,
    IRequestHandlerWithResponseAsync<S7Tag, KSociety.Com.App.Dto.Res.Remove.S7.S7Tag>
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

    public KSociety.Com.App.Dto.Res.Remove.S7.S7Tag Execute(S7Tag request)
    {
        try
        {
            //foreach (var VARIABLE in _tagRepository.GetAllS7Tag().Where(g => g.Id == request.Id))
            //{
            //    _logger.LogInformation(VARIABLE.Name + " " + VARIABLE.Id + " " + request.Id);
            //}
            var s7Tag = _tagRepository.Find(request.Id); //.GetAllS7Tag().SingleOrDefault(g => g.Id == request.Id);

            _tagRepository.Delete(s7Tag);
            var result = new KSociety.Com.App.Dto.Res.Remove.S7.S7Tag(_unitOfWork.Commit() > 0);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("" + ex.Message + " - " + ex.StackTrace);
            return new KSociety.Com.App.Dto.Res.Remove.S7.S7Tag(false);
        }
    }

    public async ValueTask<KSociety.Com.App.Dto.Res.Remove.S7.S7Tag> ExecuteAsync(S7Tag request, CancellationToken cancellationToken = default)
    {
        var s7Tag = await _tagRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllS7Tag().SingleOrDefault(g => g.Id == request.Id);

        _tagRepository.Delete(s7Tag);
        return new KSociety.Com.App.Dto.Res.Remove.S7.S7Tag(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
    }
}