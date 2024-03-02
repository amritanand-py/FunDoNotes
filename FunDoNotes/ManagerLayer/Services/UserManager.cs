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

        /*public UserEntity GetUserEntity(RegisterReqModel model)
        {
            UserManagerObj.registration(model);
        }*/


    }
}
