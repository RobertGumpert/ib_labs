using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB1.Models
{
    public enum AccountLockout: int
    {
        OK = 0,      // Не заблокирован
        Lockout = -1 // Заблокирован
    }
}
