using IB1.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace IB1.Services
{
    public class AccessService
    {

        
        private int SessionLoginAttempts = 1;
        private const int MAX_SESSION_LOGIN_ATTEMPTS = 3;
        private FileService fs;
        private UserModel authorizedUser;
        private AccountRoots roots;

        public UserModel AuthorizedUser { get { return authorizedUser; } }
        public AccountRoots RootsAuthorizedUser { get { return roots; } }

        public AccessService() {
            fs = new FileService();
        }

        // Авторизуй пользователя.
        //
        // -> Exeption
        public Boolean Login(String userName, String password) {
            if (SessionLoginAttempts == MAX_SESSION_LOGIN_ATTEMPTS) {
                throw new Exception("Access denied");
            }
            SessionLoginAttempts++;
            try
            {
                var findUser = fs.AuthorizedUsers.GetUser(userName);
                password = GetPasswordHash(password);
                if (!findUser.Password.Equals(password)) {
                    return false;
                }
                authorizedUser = findUser;
            } catch (Exception) {
                return false;
            }
            GetRoots();
            return true;
        }

        public Boolean UserIsExist(String userName)
        {
            return fs.AuthorizedUsers.UserIsExist(userName);
        }

        public UserModel FindUser(String userName)
        {
            if (UserIsExist(userName))
            {
                return fs.AuthorizedUsers.GetUser(userName);
            }
            throw new Exception("User isn't exist");
        }

        // Добавь нового пользователя.
        //
        // -> Exeption
        public void Register(String userName, String password)
        {
            if (authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (GetRoots() != AccountRoots.ADMIN)
            {
                throw new Exception("Insufficient access rights");
            }
            if (userName.Equals(string.Empty))
            {
                throw new Exception("Non valid data");
            }
            fs.AuthorizedUsers.Add(new UserModel { UserName = userName, Password = string.Empty });
        }

        public void Register(UserModel user)
        {
            if (authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (GetRoots() != AccountRoots.ADMIN)
            {
                throw new Exception("Insufficient access rights");
            }
            if (user.UserName.Equals(string.Empty))
            {
                throw new Exception("Non valid data");
            }
            user.Password = string.Empty;
            fs.AuthorizedUsers.Add(user);
        }

        // Верни права доступа, у авторизованного пользователя.
        //
        // -> Exeption
        public AccountRoots GetRoots()
        {
            if (authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (authorizedUser.UserName.Equals(fs.AdminUsername))
            {
                roots = AccountRoots.ADMIN;
                return roots;
            }
            roots = AccountRoots.USER;
            return roots;
        }

        // Обнови права доступа у выбранного пользователя.
        //
        // -> Exeption
        public void UpdateAccountAccessRights(String userName, AccountLockout accessRights, PasswordRestriction passwordRestriction) {
            if (authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (GetRoots() != AccountRoots.ADMIN)
            {
                throw new Exception("Insufficient access rights");
            }
            var updateUser = fs.AuthorizedUsers.GetUser(new UserModel() { UserName = userName});
            updateUser.Lockout = accessRights;
            updateUser.PasswordRestriction = passwordRestriction;
        }

        // Обнови права доступа у выбранного пользователя.
        //
        // -> Exeption
        public void UpdateAccountAccessRights(UserModel user, AccountLockout accessRights, PasswordRestriction passwordRestriction)
        {
            if (authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (GetRoots() != AccountRoots.ADMIN)
            {
                throw new Exception("Insufficient access rights");
            }
            var updateUser = fs.AuthorizedUsers.GetUser(user);
            updateUser.Lockout = accessRights;
            updateUser.PasswordRestriction = passwordRestriction;
        }

        // Обнови пароль.
        //
        // -> Exeption
        public void UpdatePassword(String userName, String newPassword, String oldPassword)
        {
            newPassword = GetPasswordHash(newPassword);
            var updateUser = fs.AuthorizedUsers.GetUser(new UserModel() { UserName = userName });

            if (updateUser.Password.Equals(string.Empty) || updateUser.Password == null)
            {
                updateUser.Password = newPassword;
                return;
            }
            else
            {
                if (!updateUser.Password.Equals(GetPasswordHash(oldPassword)))
                {
                    throw new Exception("Invalid old password");
                }
            }
            updateUser.Password = newPassword;
        }

        // Обнови пароль.
        //
        // -> Exeption
        public void UpdatePassword(UserModel user, String newPassword, String oldPassword)
        {
            newPassword = GetPasswordHash(newPassword);
            var updateUser = fs.AuthorizedUsers.GetUser(user);

            if (updateUser.Password.Equals(string.Empty) || updateUser.Password == null)
            {
                updateUser.Password = newPassword;
                return;
            }
            else
            {
                if (!updateUser.Password.Equals(GetPasswordHash(oldPassword)))
                {
                    throw new Exception("Invalid old password");
                }
            }
            updateUser.Password = newPassword;
        }

        // Верни список пользователей.
        //
        // -> Exeption
        public UserListModel GetUsers() {
            if (this.authorizedUser == null)
            {
                throw new Exception("Access denied or user isn't exist");
            }
            if (GetRoots() != AccountRoots.ADMIN)
            {
                throw new Exception("Insufficient access rights");
            }
            return fs.AuthorizedUsers;
        }

        public String GetPasswordHash(String password)
        {             
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
