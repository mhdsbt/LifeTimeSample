using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;
using TestLifeTime.Filter;
using TestLifeTime.Service;

namespace TestLifeTime.Controllers
{
    [ApiController]
    public class LifeTimeController : ControllerBase
    {
        private readonly IdGenerator _idGenerator;

        public LifeTimeController(IdGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        [HttpGet("lifetime")]
        [ServiceFilter(typeof(LifeTimeIndicatrorFilter))]//i use this filter for life time check first OnActionExecuting run second run GetId at the end run  OnActionExecuted for show life time 
        public IActionResult GetId()
        {
            var id = _idGenerator.Id;

            return Ok(id);
        }

       

    }
}
