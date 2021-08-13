using System.Collections.Generic;
using Nam.Test.Roles.Dto;

namespace Nam.Test.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
