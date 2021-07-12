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
                newTrainer.User = allRepositories.UserRepository.All().Where(user => user.FullName == model.User).First();
                newTrainer.VisualOrder = model.Order;
               
                allRepositories.TrainerRepository.Add(newTrainer);
                allRepositories.Commit();
                               
                return View("CreateTrainer");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult UpdateTrainer(string allDataForUpdateTrainer)
        {          
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);

            string[] words = allDataForUpdateTrainer.Split('/');
            UpdateTrainer(allRepositories, words);
            allRepositories.Commit();
            return View("UpdateCourse");
        }

        [HttpPost]
        public void DeleteTrainer(string trainerForDelete)
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
            Guid idTrainerFordelete = allRepositories.TrainerRepository.All().Where(trainer => trainer.User.FullName == trainerForDelete).ToArray()[0].Id;
            Trainer _trainerForDelete = allRepositories.TrainerRepository.Find(idTrainerFordelete);
            allRepositories.TrainerRepository.Remove(_trainerForDelete);
            allRepositories.Commit();
        }
        

        public IEnumerable<CMSys.Core.Entities.Catalog.Course> getDataCourses()
        {
            IEnumerable<CMSys.Core.Entities.Catalog.Course> dataCourses = _uow.CourseRepository.All();
            return dataCourses;
        }
        public IEnumerable<CMSys.Core.Entities.Catalog.TrainerGroup> getDataTrainerGroup()
        {
            IEnumerable<CMSys.Core.Entities.Catalog.TrainerGroup> dataTrainerGroup = _uow.TrainerGroupRepository.All();
            return dataTrainerGroup;
        }
        public IEnumerable<CMSys.Core.Entities.Catalog.Trainer> getDataTrainers()
        {
            IEnumerable<CMSys.Core.Entities.Catalog.Trainer> dataTrainers = _uow.TrainerRepository.All();
            return dataTrainers;
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
        private static VisibleEntity getEntityTrainerGroupForUpdateTrainer(UnitOfWork allRepositories, string[] words)
        {
            foreach (var item in allRepositories.TrainerGroupRepository.All())
            {
                if (item.Name.Trim() == words[1].Trim())
                {
                    return item;
                }
            }
            return null;
        }
        private static void UpdateTrainer(UnitOfWork allRepositories, string[] words)
        {
            foreach (var item in allRepositories.TrainerRepository.All())
            {
                if(item.User.FullName.Trim() == words[0].Trim())
                {
                    item.TrainerGroup = (TrainerGroup)getEntityTrainerGroupForUpdateTrainer(allRepositories, words);
                    item.TrainerGroupId = item.TrainerGroup.Id;
                    item.VisualOrder = int.Parse(words[2]);
                    item.Description = words[3];
                    break;
                }        
            }
        }
    }
}
