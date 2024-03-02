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
        public bool UserLogin(LoginReqModel model);
    }
}
