using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Core.Repositories.Catalog;
using CMSys.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSys.Web.Models
{
    /*
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
    public class IsTrueAttribute : ValidationAttribute
    {
        #region Overrides of ValidationAttribute

        /// <summary>
        /// Determines whether the specified value of the object is valid. 
        /// </summary>
        /// <returns>
        /// true if the specified value is valid; otherwise, false. 
        /// </returns>
        /// <param name="value">The value of the specified validation object on which the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> is declared.
        ///                 </param>
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");

            return (bool)value;
        }

        #endregion
    }

    */

    public class CreateCourseModel
    {

        [Required]
        [StringLength(64)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "The field Is Active must be checked.")]
        //[MustBeTrue(ErrorMessage = "Вы должны принять условия")]
        //[IsTrueAttribute (ErrorMessage ="error")]
        [Display(Name = "Is New")]
        public bool IsNew { get; set; }

        public string CourseGroup { get; set; }

        [Display(Name = "Course Type")]
        public string CourseType { get; set; }
   
        [Required]     
        [RegularExpression("([0-9]*)",ErrorMessage = "Error! Use an integer number!")]
        public int Order { get; set; }

        [StringLength(4000)]      
        [Display(Name = "Description")]
        public string Description { get; set; }

        public SelectList SelectListAllCourseGroup { get; set; } 
        public SelectList SelectListAllCourseType { get; set; }
        public SelectList SelectListAllCourse { get; set; }


        public CreateCourseModel ()
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
            SelectListAllCourseGroup = getArrayCourseGroup(allRepositories);
            SelectListAllCourseType = getArrayCourseType(allRepositories);
            SelectListAllCourse = getArrayCourse(allRepositories);
        }

        public static SelectList getArrayCourseGroup (IUnitOfWork AllRepositories)
        {
            string[] arrayAllCourseGroup = new string[AllRepositories.CourseGroupRepository.All().Count()];
            int number = -1;
            foreach(var item in AllRepositories.CourseGroupRepository.All())
            {
                number += 1;
                arrayAllCourseGroup[number] = item.Name;              
            }
            SelectList selectListItems = new SelectList(arrayAllCourseGroup);
            return selectListItems;
        }
        public static SelectList getArrayCourseType (IUnitOfWork AllRepositories)
        {
            string[] arrayAllCourseType = new string[AllRepositories.CourseTypeRepository.All().Count()];
            int number = -1;
            foreach (var item in AllRepositories.CourseTypeRepository.All())
            {
                number += 1;
                arrayAllCourseType[number] = item.Name;             
            }
            SelectList selectListItems = new SelectList(arrayAllCourseType);
            return selectListItems;
        }
        public static SelectList getArrayCourse(IUnitOfWork AllRepositories)
        {
            string[] arrayAllCourse = new string[AllRepositories.CourseRepository.All().Count()];
            int number = -1;
            foreach (var item in AllRepositories.CourseRepository.All())
            {
                number += 1;
                arrayAllCourse[number] = item.Name;
            }
            SelectList selectListItems = new SelectList(arrayAllCourse);
            return selectListItems;
        }



    }
}
