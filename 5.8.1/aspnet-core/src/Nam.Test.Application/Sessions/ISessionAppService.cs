using System.Threading.Tasks;
using Abp.Application.Services;
using Nam.Test.Sessions.Dto;

namespace Nam.Test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
