using System.Collections.Generic;
using Nam.Test.Roles.Dto;

namespace Nam.Test.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
