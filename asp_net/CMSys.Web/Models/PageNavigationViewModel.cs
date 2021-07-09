using CMSys.Common.Paging;
using CMSys.Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSys.Web.Models
{
    public class PageNavigationViewModel
    {
        public PagedList<Course> PagedList { get; set; } 
        public IEnumerable<CourseGroup> AllCourseGroup { get; set; }
        public IEnumerable<Course> AllCourse { get; set; }
        public IEnumerable<Course> CoursesPerPages { get; set; }

     

        public PageNavigationViewModel(PagedList<Course> pagedList, IEnumerable<CourseGroup> allCourseGroup, IEnumerable<Course> allCourse, IEnumerable<Course> coursesPerPages)
        {
            PagedList = pagedList;
            AllCourseGroup = allCourseGroup;
            AllCourse = allCourse;
            CoursesPerPages = coursesPerPages;
        }
    }
}
