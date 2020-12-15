using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("Signout")]
    public class SignoutController : ControllerBase
    {
        [HttpPost]
        public statusModels Post([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return new SignoutClass().GetInsertModels(sItemData, clientip);
        }
    }
}