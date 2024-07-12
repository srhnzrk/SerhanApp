using SerhanApp.Core.Configuration;

namespace SerhanApp.Data.Entities.Settings
{
    public class AuthenticationSettings : ISetting
    {
        public AuthenticationSettings()
        {
            this.CannotLoginUntilTimeAsMinute = 30;
            this.FailedLoginAttemptMaximumTryCount = 3;
        }

        public int CannotLoginUntilTimeAsMinute { get; set; }
        public int FailedLoginAttemptMaximumTryCount { get; set; }
    }
}