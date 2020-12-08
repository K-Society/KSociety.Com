using System.Threading.Tasks;
using Quartz;

namespace KSociety.Com.Domain.Entity.Common
{
    [DisallowConcurrentExecution]
    public class TaskRead : IJob
    {
        #region [Private]
        private SchedulerContext _sc;
        private TagGroup _tagGroup;
        private string _name = string.Empty;
        #endregion

        public Task Execute(IJobExecutionContext context)
        {
            _sc = context.Scheduler.Context;
            _name = context.JobDetail.Key.Name;

            _tagGroup = (TagGroup)_sc.Get(_name);

            return _tagGroup.OnSchedulerTriggerRead();
        }
    }
}
