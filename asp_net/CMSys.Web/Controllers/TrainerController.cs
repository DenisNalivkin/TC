using CMSys.Core.Entities;
using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Infrastructure;
using CMSys.Web.Models;
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

        public IActionResult ShowTrainerList()
        {
            IEnumerable<Trainer> listAllTrainers = _uow.TrainerRepository.All();
            return View(listAllTrainers);
        }

        [HttpGet]
        public IActionResult CreateTrainer()
        {
            return View(new CreateTrainerModel());
        }

        [HttpPost]
        public IActionResult CreateTrainer (CreateTrainerModel model)
        {
            if (ModelState.IsValid)
            {
                UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
                UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);

                Trainer newTrainer = new Trainer();
                TrainerGroup trainerGroup = (TrainerGroup)getEntityTrainerGroup(allRepositories, model);

                newTrainer.Description = model.Description;
                newTrainer.Id = allRepositories.UserRepository.All().Where(user => user.FullName == model.User).Select(user => user.Id).First();
                newTrainer.TrainerGroup = trainerGroup;
                newTrainer.TrainerGroupId = trainerGroup.Id;
                newTrainer.User = allRepositories.UserRepository.All().Where(user => user.FullName == model.User).Select(user => user).First();
                newTrainer.VisualOrder = model.Order;

                return View("CreateTrainer");
            }
            else
            {
                return View(model);
            }
        }
     
        private static VisibleEntity getEntityTrainerGroup(UnitOfWork allRepositories, CreateTrainerModel model)
        {         
            foreach (var item in allRepositories.TrainerGroupRepository.All())
            {
                if (item.Name == model.TrainerGroup)
                {
                    return item;
                }
            }         
            return null;
        }
    }
}
