using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSys.Web.Controllers
{
    public class TrainerController : Controller
    {
        private readonly IUnitOfWork _uow;

        public TrainerController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public  IActionResult ShowAllTrainers()
        {
            IEnumerable<Trainer> listAllTrainers = _uow.TrainerRepository.All();
            return View(listAllTrainers);
        }

    }
}
