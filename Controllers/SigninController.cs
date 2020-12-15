using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Signin")]
    public class SigninController : ControllerBase
    {
        [HttpPost]
        public statusModels Post([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return new SigninClass().GetInsertModels(sItemData, clientip);
        }
    }
}