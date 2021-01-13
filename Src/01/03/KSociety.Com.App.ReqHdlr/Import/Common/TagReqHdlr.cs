using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.Import.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Common
{
    public class TagReqHdlr :
        IRequestHandlerWithResponse<Tag, KSociety.Com.App.Dto.Res.Import.Common.Tag>,
        IRequestHandlerWithResponseAsync<Tag, KSociety.Com.App.Dto.Res.Import.Common.Tag>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TagReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly ITag _tagRepository;

        public TagReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, ITag tagRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagReqHdlr>();
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
        }

        public KSociety.Com.App.Dto.Res.Import.Common.Tag Execute(Tag request)
        {
            var result = _tagRepository.ImportCsv(request.ByteArray);
            var output = _unitOfWork.Commit();

            return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.Tag(result)
                : new KSociety.Com.App.Dto.Res.Import.Common.Tag(false);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
        {
            var result = await _tagRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);
            var output = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            return output == -1 ? new KSociety.Com.App.Dto.Res.Import.Common.Tag(result) : new KSociety.Com.App.Dto.Res.Import.Common.Tag(false);
        }
    }
}
