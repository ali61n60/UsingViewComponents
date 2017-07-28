using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public string Invoke()
        {
            return $"{repository.Cities.Count()} cities, "
                   + $"{repository.Cities.Sum(c => c.Population)} people";
        }
    }
}
