namespace SerhanApp.Services.Authentication
{
    public enum LoginResult
    {
        Success = 10,

        Failed = 20,

        ApplicationUserNotFound = 21,

        RequireReLogin = 30,

        CannotLoginUntilDate = 40,

        WrongPassword = 50,

        RequireEmailVerification = 60,
    }
}
