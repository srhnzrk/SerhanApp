namespace SerhanApp.Data.Entities.Settings
{
    public class CustomerPasswordSettings
    {
        public CustomerPasswordSettings()
        {
            this.MaximumLength = 20;
            this.MininumLength = 6;
            this.RequireDigit = true;
            this.RequireUppercase = true;
            this.RequireLowercase = true;
            this.RequireSpecialCharacter = true;
        }

        public int MininumLength { get; set; }

        public int MaximumLength { get; set; }

        public bool RequireDigit { get; set; }

        public bool RequireUppercase { get; set; }

        public bool RequireLowercase { get; set; }

        public bool RequireSpecialCharacter { get; set; }
    }
}
