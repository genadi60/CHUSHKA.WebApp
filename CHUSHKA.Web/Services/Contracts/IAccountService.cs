using CHUSHKA.Web.ViewModels;

namespace CHUSHKA.Web.Services.Contracts
{
    public interface IAccountService
    {
        bool Create(RegisterViewModel model);
    }
}
