using Abp.Authorization;
using Nam.Test.Authorization.Roles;
using Nam.Test.Authorization.Users;

namespace Nam.Test.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
