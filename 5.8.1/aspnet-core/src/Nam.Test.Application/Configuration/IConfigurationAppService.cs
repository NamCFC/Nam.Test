using System.Threading.Tasks;
using Nam.Test.Configuration.Dto;

namespace Nam.Test.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
