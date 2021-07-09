using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Core.Repositories.Catalog;
using CMSys.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CMSys.Infrastructure.Repositories.Catalog;
using CMSys.Infrastructure;
using CMSys.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using CMSys.Common.Paging;

namespace CMSys.Web.Controllers
{
    public class CourseListController: Controller
    {
        private readonly IUnitOfWork _uow;

        public CourseListController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult ShowActionInCourseList(int page = 1)
        {
            int perPages = 3;
            IEnumerable<Course> allCourse = _uow.CourseRepository.All();
            IEnumerable<CourseGroup> allCourseGroup = _uow.CourseGroupRepository.All();
            List<Course> coursesPerPages = allCourse.Skip((page - 1) * perPages).Take(perPages).ToList();
            PageInfo pageInfo = new PageInfo(page, perPages);
            PagedList<Course> Courses = new PagedList<Course>(coursesPerPages, _uow.CourseRepository.All().Count(), pageInfo);
            PageNavigationViewModel pageNavigationViewModel = new PageNavigationViewModel(Courses, allCourseGroup, allCourse, coursesPerPages);
            return View(pageNavigationViewModel);
        }

        [HttpGet]
        public IActionResult CreateCourse()
        {                       
            return View( new CreateCourseModel());
        }

        [HttpPost]
        public IActionResult CreateCourse(CreateCourseModel model)
        {
            if(ModelState.IsValid)
            {
                UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
                UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
               
                Course newCourse = new Course();
                CourseGroup courseGroup = (CourseGroup)getEntity( allRepositories, model, "CourseGroupRepository");         
                CourseType courseType = (CourseType)getEntity(allRepositories, model, "CourseTypeRepository");         
            
                newCourse.CourseGroup = courseGroup;
                newCourse.CourseGroupId = courseGroup.Id;
                newCourse.CourseType = courseType;
                newCourse.CourseTypeId = courseType.Id;
                newCourse.Id = Guid.NewGuid();
                newCourse.IsNew = true;
                newCourse.Name = model.Name;
                newCourse.Trainers = null;
                newCourse.Description = model.Description;
                newCourse.VisualOrder = model.Order;
             
                allRepositories.CourseRepository.Add(newCourse);
                allRepositories.Commit();
                return View("CreateCourse");
             
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult EditCourseTrainers()
        {
            IEnumerable<Course> allCourse = _uow.CourseRepository.All();
            return View(allCourse);
        }

        public IActionResult UpdateCourse(CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
                UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
                UpdateCourse(allRepositories,model);
                allRepositories.Commit();
                return View("UpdateCourse");
            }
            else
            {
                return View(model);
            }
        }
      
        [HttpPost]
        public void DeleteCourse(string courseName)
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
            Guid idCourseFordelete = allRepositories.CourseRepository.All().Where(course => course.Name == courseName).ToArray()[0].Id;
            Course courseForDelete = allRepositories.CourseRepository.Find(idCourseFordelete);
            allRepositories.CourseRepository.Remove(courseForDelete);
            
            allRepositories.Commit();
        }

        [HttpGet]
        public void AddTrainer(string allDataForAddTrainer)
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);    
            string[] words = allDataForAddTrainer.Split('/');

            Guid idCourseForAddTrainer = allRepositories.CourseRepository.All().Where(course => course.Name.Trim() == words[1].Trim()).ToArray()[0].Id;
            Course courseForAddTrainer = allRepositories.CourseRepository.Find(idCourseForAddTrainer);
            Trainer [] trainerForAdd = allRepositories.TrainerRepository.All().Where(trainer => trainer.User.FullName == words[0]).ToArray();
            CourseTrainer courseTrainer = new CourseTrainer();
            courseTrainer.CourseId = courseForAddTrainer.Id;
            courseTrainer.Trainer = trainerForAdd[0];
            courseTrainer.TrainerId = trainerForAdd[0].Id;
            courseTrainer.VisualOrder = 0;
            allRepositories.CourseRepository.Find(idCourseForAddTrainer).Trainers.Add(courseTrainer);
            allRepositories.Commit();
        }

        [HttpGet]
        public void DeleteTrainer(string allDataForDeleteTrainer)
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
            string[] words = allDataForDeleteTrainer.Split('/');

            Guid idCourseForDeleteTrainer = allRepositories.CourseRepository.All().Where(course => course.Name.Trim() == words[3].Trim()).ToArray()[0].Id;
            Course courseForDeleteTrainer = allRepositories.CourseRepository.Find(idCourseForDeleteTrainer);
            Trainer[] trainerForDelete = allRepositories.TrainerRepository.All().Where(trainer => trainer.User.FullName.Trim() == words[0].Trim()).ToArray();          
            List<CourseTrainer> courseTrainerForDelete = courseForDeleteTrainer.Trainers.Where(tr => tr.TrainerId == trainerForDelete[0].Id).ToList();
            allRepositories.CourseRepository.Find(idCourseForDeleteTrainer).Trainers.Remove(courseTrainerForDelete[0]);
            allRepositories.Commit();
        }

        public IEnumerable<CMSys.Core.Entities.Catalog.Course> getDataCourses()
        {
            IEnumerable<CMSys.Core.Entities.Catalog.Course> dataCourses = _uow.CourseRepository.All();
            return dataCourses;
        }
        private static VisibleEntity getEntity (UnitOfWork allRepositories, CreateCourseModel model, string typeRepository)
        {
            if (typeRepository == "CourseGroupRepository")
            {
                foreach (var item in allRepositories.CourseGroupRepository.All())
                {
                    if (item.Name == model.CourseGroup)
                    {
                        return item;
                    }
                }          
            }
            if (typeRepository == "CourseTypeRepository")
            {
                foreach (var item in allRepositories.CourseTypeRepository.All())
                {
                    if (item.Name == model.CourseType)
                    {
                        return item;
                    }
                }
            }
          
            return null;
        }
        private static void UpdateCourse (UnitOfWork allRepositories, CreateCourseModel model)
        {
            foreach (var item in allRepositories.CourseRepository.All())
            {
                if (item.Name == model.Name)
                {
                    item.Description = null;
                    item.Description = model.Description;
                    item.VisualOrder = model.Order;
                    item.CourseGroup = (CourseGroup)getEntity(allRepositories, model, "CourseGroupRepository");
                    item.CourseType = (CourseType)getEntity(allRepositories, model, "CourseTypeRepository");
                    break;
                }
            }
        }
     
    }

}
