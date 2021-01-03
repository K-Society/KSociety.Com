using System.Threading;
using System.Threading.Tasks;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Com.App.Dto.Req.ModifyField.Common;
using KSociety.Com.Domain.Repository.Common;
using Microsoft.Extensions.Logging;

namespace KSociety.Com.App.ReqHdlr.ModifyField.Common
{
    public class TagReqHdlr :
        IRequestHandlerWithResponse<Tag, KSociety.Com.App.Dto.Res.ModifyField.Common.Tag>,
        IRequestHandlerWithResponseAsync<Tag, KSociety.Com.App.Dto.Res.ModifyField.Common.Tag>
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

        public KSociety.Com.App.Dto.Res.ModifyField.Common.Tag Execute(Tag request)
        {

            var commonTag = _tagRepository.Find(request.Id); //GetAllTag().SingleOrDefault(tag => tag.Id == request.Id);
            commonTag?.ModifyField(request.FieldName, request.Value);
            return new KSociety.Com.App.Dto.Res.ModifyField.Common.Tag(_unitOfWork.Commit() > 0);
        }

        public async ValueTask<KSociety.Com.App.Dto.Res.ModifyField.Common.Tag> ExecuteAsync(Tag request, CancellationToken cancellationToken = default)
        {

            var commonTag = await _tagRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false); //.GetAllTag().SingleOrDefault(tag => tag.Id == request.Id);
            commonTag?.ModifyField(request.FieldName, request.Value);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return new KSociety.Com.App.Dto.Res.ModifyField.Common.Tag(result > 0);
        }
    }
}
