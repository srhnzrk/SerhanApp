using SerhanApp.Core.Configuration;

namespace SerhanApp.Data.Entities.Settings
{
    public class CustomerSettings : ISetting
    {
        public CustomerSettings()
        {
            this.EnableUsername = false;
            this.RequireEmailVerification = true;
        }

        public bool RequireEmailVerification { get; set; }
        public bool EnableUsername { get; set; }
    }
}
