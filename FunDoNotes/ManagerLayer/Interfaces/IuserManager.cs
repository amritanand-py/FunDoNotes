using CommonLayer.RequestModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface IuserManager
    {
        public UserEntity registration(RegisterReqModel model);
        public string UserLogin(LoginReqModel model);
        public ForgetPassModel ForgetPassword(ForgetPassModel model);
        public bool ResetPassword(string Email, ResetPasswordModel reset);
    }
}
