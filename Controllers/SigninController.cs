using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using signformApi.Models;

namespace signformApi.Controllers
{
    [EnableCors("Signin")]
    [ApiController]
    [Route("[controller]")]
    public class SigninController : ControllerBase
    {
        [HttpPost]
        [Route("post")]
        public statusModels insertData([FromBody] sItemData sItemData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return new SigninClass().GetInsertModels(sItemData, clientip);
        }
    }
}