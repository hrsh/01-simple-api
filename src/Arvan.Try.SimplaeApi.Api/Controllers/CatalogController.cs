using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Arvan.Try.SimplaeApi.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly DatabaseOptions _databaseOptions;

        public CatalogController(IOptions<DatabaseOptions> options) =>
            _databaseOptions = options.Value;

        [HttpGet]
        public IActionResult Index() =>
            Ok(nameof(CatalogController));

        [HttpGet("db")]
        public IActionResult DatabaseOptions() =>
            new JsonResult(_databaseOptions);
    }
}