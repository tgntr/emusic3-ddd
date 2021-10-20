namespace SimpleMusicStore.Application.Identity
{
    using Commands;
    using Commands.ChangePassword;
    using Commands.LoginUser;
    using Common;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
