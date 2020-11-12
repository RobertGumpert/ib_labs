using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB1.Models
{
    public class UserModel
    {
        public PasswordRestriction PasswordRestriction { get; set; }
        public AccountLockout Lockout { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
