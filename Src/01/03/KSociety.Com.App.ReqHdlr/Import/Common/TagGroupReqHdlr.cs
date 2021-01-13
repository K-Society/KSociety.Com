using KSociety.Base.App.Shared;
using KSociety.Com.App.Dto.Req.Import.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace KSociety.Com.App.ReqHdlr.Import.Common
{
    public class TagGroupReqHdlr :
        IRequestHandlerWithResponse<TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup>,
        IRequestHandlerWithResponseAsync<TagGroup, KSociety.Com.App.Dto.Res.Import.Common.TagGroup>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TagGroupReqHdlr> _logger;
        private readonly ITagGroup _tagGroupRepository;

        public TagGroupReqHdlr(ILoggerFactory loggerFactory, ITagGroup tagGroupRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TagGroupReqHdlr>();
            _tagGroupRepository = tagGroupRepository;
        }

        public KSociety.Com.App.Dto.Res.Import.Common.TagGroup Execute(TagGroup request)
        {
            _tagGroupRepository.ImportCsv(request.ByteArray);

            return new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(true);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.Import.Common.TagGroup> ExecuteAsync(TagGroup request, CancellationToken cancellationToken = default)
        {
            await _tagGroupRepository.ImportCsvAsync(request.ByteArray, cancellationToken).ConfigureAwait(false);

            return new KSociety.Com.App.Dto.Res.Import.Common.TagGroup(true);
        }
    }
}
