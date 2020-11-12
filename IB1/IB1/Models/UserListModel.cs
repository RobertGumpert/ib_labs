using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB1.Models
{
    public class UserListModel
    {
        public List<UserModel> Users { get; set; }

        public UserListModel()
        {
            this.Users = new List<UserModel>();
        }

        public Boolean UserIsExist(UserModel user) {
            if (!Users.Exists(u => u.UserName.Equals(user.UserName)))
            {
                return false;
            }
            return true;
        }

        public Boolean UserIsExist(String userName)
        {
            if (!Users.Exists(u => u.UserName.Equals(userName)))
            {
                return false;
            }
            return true;
        }

        // -> Exception
        public void Add(UserModel user) {
            if (UserIsExist(user)) {
                throw new Exception("User is exist");
            }
            if (user.UserName.Equals("")) {
                throw new Exception("User isn't valid data.");
            }
            Users.Add(user);
        }

        // -> Exception
        public UserModel GetUser(String userName)
        {
            var user = new UserModel() { UserName = userName };
            if (!UserIsExist(user))
            {
                throw new Exception("User isn't exist");
            }
            return FindUser(user);
        }
        
        // -> Exception
        public UserModel GetUser(UserModel user)
        {
            if (!UserIsExist(user))
            {
                throw new Exception("User isn't exist");
            }
            return FindUser(user);
        }


        private UserModel FindUser(UserModel user) {
            return Users.Find(u => u.UserName.Equals(user.UserName));
        }

    }
}
