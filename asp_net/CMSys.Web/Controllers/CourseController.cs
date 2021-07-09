using CMSys.Common.Paging;
using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSys.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CourseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IActionResult ShowAllCourses(int page = 1)
        {
            int perPages = 3;
            IEnumerable<Course> allCourse = _uow.CourseRepository.All();
            IEnumerable<CourseGroup> allCourseGroup = _uow.CourseGroupRepository.All();
            List<Course> coursesPerPages = allCourse.Skip((page - 1) * perPages).Take(perPages).ToList();
            PageInfo pageInfo = new PageInfo(page, perPages);
            PagedList<Course> Courses = new PagedList<Course>(coursesPerPages, _uow.CourseRepository.All().Count(), pageInfo);
            PageNavigationViewModel pageNavigationViewModel = new PageNavigationViewModel(Courses, allCourseGroup, allCourse,  coursesPerPages);
            return View(pageNavigationViewModel);
        }

        public IEnumerable<CMSys.Core.Entities.Catalog.Course> getDataCourses()
        {
            IEnumerable<CMSys.Core.Entities.Catalog.Course> dataCourses = _uow.CourseRepository.All();
            return dataCourses;
        }
    }
}
