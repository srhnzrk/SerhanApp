using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SerhanApp.Web.Areas.Admin.Models;
using SerhanApp.Web.Areas.Admin.Models.Sample;

namespace SerhanApp.Web.Areas.Admin.Controllers
{
    public class SampleController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            var model = new SampleModel();

            model.AvailableCountries.Add(new SelectListItem { Text = "Türkiye", Value = "1" });
            model.AvailableCountries.Add(new SelectListItem { Text = "Germany", Value = "2" });
            model.AvailableCountries.Add(new SelectListItem { Text = "Italy", Value = "3" });

            model.AvaliableRoles.Add(new SelectListItem { Text = "Admin" , Value = "1"});
            model.AvaliableRoles.Add(new SelectListItem { Text = "User", Value = "2" });

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SampleModel model)
        {
            return View(model);
        }



        public IActionResult Edit(int id)
        {
            var model = new SampleModel();

            model.AvailableCountries.Add(new SelectListItem { Text = "Türkiye", Value = "1" });
            model.AvailableCountries.Add(new SelectListItem { Text = "Germany", Value = "2" });
            model.AvailableCountries.Add(new SelectListItem { Text = "Italy", Value = "3" });

            model.AvaliableRoles.Add(new SelectListItem { Text = "Admin", Value = "1" });
            model.AvaliableRoles.Add(new SelectListItem { Text = "User", Value = "2" });

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(SampleModel model)
        {
            return View(model);
        }
    }
}
