using Microsoft.AspNetCore.Mvc.Filters;
using TestLifeTime.Service;

namespace TestLifeTime.Filter
{
    public class LifeTimeIndicatrorFilter : IActionFilter
    {
        private readonly IdGenerator _idGenerator;
        private readonly ILogger<LifeTimeIndicatrorFilter> _logger;

        public LifeTimeIndicatrorFilter(IdGenerator idGenerator, ILogger<LifeTimeIndicatrorFilter> logger)
        {
            _idGenerator = idGenerator;
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = _idGenerator.Id;

            _logger.LogInformation($"{nameof(OnActionExecuting)} id was:{id}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var id = _idGenerator.Id;

            _logger.LogInformation($"{nameof(OnActionExecuted)} id was:{id}");
        }
    }
}
