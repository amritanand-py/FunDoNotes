using CommonLayer.RequestModel;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepoLayer.Services
{
    public class UserServices : IUserRepo
    {
        public readonly FunDoContext FunDoContext;

        public UserServices(FunDoContext FunDoContext)
        {
            this.FunDoContext = FunDoContext;
        }
        public UserEntity registration(RegisterReqModel model)
        {
            UserEntity userobj = new UserEntity();
            userobj.Email = model.Email;
            userobj.Fname = model.Fname;
            userobj.Password = model.Password;
            userobj.Lname = model.Lname;

            FunDoContext.UserTable.Add(userobj);
            FunDoContext.SaveChanges();

            return userobj;
        }
    }
}
