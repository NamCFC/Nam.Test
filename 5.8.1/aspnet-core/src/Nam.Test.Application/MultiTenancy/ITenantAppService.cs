using Abp.Application.Services;
using Nam.Test.MultiTenancy.Dto;

namespace Nam.Test.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

