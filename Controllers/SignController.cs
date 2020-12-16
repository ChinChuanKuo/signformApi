using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [EnableCors("Sign")]
    [ApiController]
    [Route("[controller]")]
    public class SignController : Controller
    {
        [HttpPost]
        [Route("get")]
        public JsonResult searchData([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new SignClass().GetSearchModels(sItemData, clientip));
        }
    }
}