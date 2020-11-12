using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB1.Models
{
    public enum PasswordRestriction : int
    {
        MustBe = 20,     // Установленные ограничения на пароль 
        ShouldNot = -20  // Не установленные ограничения на пароль 
    }
}
