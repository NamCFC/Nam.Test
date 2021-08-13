using System.Collections.Generic;
using Nam.Test.Roles.Dto;

namespace Nam.Test.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}