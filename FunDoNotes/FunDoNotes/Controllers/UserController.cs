using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using CommonLayer.Utility;
using ManagerLayer.Services;
using MassTransit;
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
        public readonly IBus bus;


        public UserController(IUserRepo usermanager, IBus bus)
        {
            this.usermanager = usermanager;
            this.bus = bus; 
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
            return BadRequest(new FunDoResponse<UserEntity> { Success = true, Message = "Regestration Unsuccessful", Data = null });
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(LoginReqModel model)
        {
            var Response = usermanager.UserLogin(model);
            if (Response != null)
            {
                return Ok(new FunDoResponse<string> { Success = true, Message = "login Successful", Data = Response });
            }
            return BadRequest(new FunDoResponse<bool> { Success = true, Message = "Login Unsuccessful", Data = false });
        }

        [HttpPost]
        [Route("ForgetPassword")]
        
         public async Task<ActionResult> ForgetPasswordAPI(string email)
        {
            try
            {
                if (usermanager.checker(email))
                {
                    send send = new send();
                    ForgetPassModel model = usermanager.ForgetPassword(email);
                    string str = send.SendMail(model.Email, model.Token);
                    Uri uri = new Uri("rabbitmq://localhost/FundooNotesEmailQueue");
                    var endpoint = await bus.GetSendEndpoint(uri);
                    return Ok(new FunDoResponse<string> { Success = true, Message = "Forget password successful", Data = model.Token });
                }
                else
                {
                    throw new Exception("Failed to send email");
                }
            }
            catch (Exception er)
            {
                return BadRequest(new FunDoResponse<string> { Success = true, Message = er.Message, Data = null });
            }

        }



    }
}


