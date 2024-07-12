using SerhanApp.Core.Entities;

namespace SerhanApp.Data.Entities.ApplicationUsers
{
    public class ApplicationUserPassword : BaseEntity
    {
        public string Password { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        public int PasswordTypeId { get; set; }

        public PasswordType PasswordType
        {
            get
            {
                return (PasswordType)PasswordTypeId;
            }
            set
            {
                this.PasswordTypeId = (int)value;
            }
        }
    }
}
