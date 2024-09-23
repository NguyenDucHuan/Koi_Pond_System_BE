using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOCOS.Domain.DTOs
{
    public static class ConstantsResponseEntityMessage
    {
        public static class AccountResponseMessage
        {
            public const string Success = "Hoàn tắt tác vụ !";
            public const string DupplicateUserName = "User name đã tồn tại!";
            public const string AccountNotExist = "Account ko tồn tại!";

        }
    }
}
