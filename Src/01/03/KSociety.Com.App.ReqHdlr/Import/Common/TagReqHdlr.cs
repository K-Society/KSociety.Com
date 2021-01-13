using KSociety.Base.App.Shared;
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
        private readonly ITag _tagRepository;

        public TagReqHdlr(ILoggerFactory loggerFactory, ITag tagRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagReqHdlr>();
            _tagRepository = tagRepository;
        }

        public KSociety.Com.App.Dto.Res.Import.Common.Tag Execute(Tag request)
        {
            _tagRepository.ImportCsv(request.ByteArray);

            return new KSociety.Com.App.Dto.Res.Import.Common.Tag(true);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
        {
            await _tagRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);

            return new KSociety.Com.App.Dto.Res.Import.Common.Tag(true);
        }
    }
}
