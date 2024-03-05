using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.RequestModel
{
    public class ForgetPassModel
    {
        public int userID {  get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
