using CommonLayer.RequestModel;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepoLayer.Interfaces
{
    public interface IUserRepo
    {
        public UserEntity registration(RegisterReqModel model );
        public string UserLogin(LoginReqModel model);

        public ForgetPassModel ForgetPassword(string Email);
        public bool checker(string Email);
        public bool ResetPassword(string Email, ResetPasswordModel reset);
    }
}
