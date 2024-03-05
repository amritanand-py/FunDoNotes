using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Services
{
    public class UserManager : IuserManager
    {
        public readonly IUserRepo UserManagerObj;

        public UserManager(IUserRepo userManagerObj)
        {
            this.UserManagerObj = userManagerObj;
        }

        public UserEntity registration(RegisterReqModel model)
        {
            return UserManagerObj.registration(model);
        }

        public string UserLogin(LoginReqModel model)
        {
            return UserManagerObj.UserLogin(model);
        }

        public ForgetPassModel ForgetPassword(ForgetPassModel model)
        {
            return UserManagerObj.ForgetPassword(model.Email);
        }

        public bool ResetPassword(string Email, ResetPasswordModel reset)
        {
            return UserManagerObj.ResetPassword(Email, reset);
        }

    }
}
