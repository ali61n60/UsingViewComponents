using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            string target = RouteData.Values["id"] as string;
            var cities = repository.Cities
                .Where(city => target == null ||
                               string.Compare(city.Country, target, true) == 0);
            return View(new CityViewModel
            {
                Cities = cities.Count(),
                Population = cities.Sum(c => c.Population)
            });
        }
    }
}
