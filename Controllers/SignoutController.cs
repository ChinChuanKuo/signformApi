using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [EnableCors("Signout")]
    [ApiController]
    [Route("[controller]")]
    public class SignoutController : Controller
    {
        [HttpPost]
        [Route("post")]
        public JsonResult insertData([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new SignoutClass().GetInsertModels(sItemData, clientip));
        }
    }
}