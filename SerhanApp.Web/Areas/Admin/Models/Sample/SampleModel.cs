using Microsoft.AspNetCore.Mvc.Rendering;

namespace SerhanApp.Web.Areas.Admin.Models.Sample
{
    public class SampleModel
    {
        public SampleModel()
        {
            this.AvailableCountries = new List<SelectListItem>();
            this.AvaliableRoles = new List<SelectListItem>();
        }

        public List<SelectListItem> AvailableCountries { get; set; }

        public List<SelectListItem> AvaliableRoles { get; set; } 

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public int SelectedCountryId { get; set; }
        public int SelectedRoleId { get; set; }
        public string Gender { get; set; }
        public bool ReceiveEmailNotifications { get; set; }

    }

}
