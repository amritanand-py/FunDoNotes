using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using RepoLayer.Interfaces;

namespace FunDoNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepo usermanager;

        public UserController(IUserRepo usermanager)
        {
            this.usermanager = usermanager;
        }

        [HttpPost]
        [Route("Registration")]
        public ActionResult UserRegistration(RegisterReqModel model)
        {
            var tempVar = usermanager.registration(model);
            if (tempVar != null)
            {
                return Ok(new FunDoResponse<UserEntity> { Success = true, Message = "Regestration Successful", Data = tempVar });
            }
            else
            {
                return BadRequest(new FunDoResponse<UserEntity> { Success = true, Message = "Regestration Unsuccessful", Data = null });
            }

        }
    }
}
