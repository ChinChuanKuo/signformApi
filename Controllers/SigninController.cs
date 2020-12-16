using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [EnableCors("Signin")]
    [ApiController]
    [Route("[controller]")]
    public class SigninController : Controller
    {
        [HttpPost]
        [Route("post")]
        public JsonResult InsertData([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new SigninClass().GetInsertModels(sItemData, clientip));
        }
    }
}