using CMSys.Core.Entities.Catalog;
using CMSys.Core.Repositories;
using CMSys.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSys.Web.Models
{

    public class CreateTrainerModel
    {
        public string User { get; set; }

        [Required]
        public string TrainerGroup { get; set; }

        [Required]
        [RegularExpression("([0-9]*)", ErrorMessage = "Error! Use an integer number!")]
        public int Order { get; set; }

        [StringLength(4000)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public SelectList SelectListAllActiveUsers { get; set; }
        public SelectList SelectLisTrainerGroup { get; set; }

        public CreateTrainerModel()
        {
            UnitOfWorkOptions unitOfWorkOptions = new UnitOfWorkOptions();
            UnitOfWork allRepositories = new UnitOfWork(unitOfWorkOptions);
            SelectListAllActiveUsers = getArrayActiveNameUsers(allRepositories);
            SelectLisTrainerGroup = getArrayNameTrainerGroup(allRepositories);
        }
  
        public static SelectList getArrayActiveNameUsers(IUnitOfWork AllRepositories)
        {
            Trainer resultFindInTrainerRepository = null;
            List<string> allActiveUsers = new List<string>();
            foreach (var user in AllRepositories.UserRepository.All())
            {
                if(user.EndDate == null)
                {                   
                    resultFindInTrainerRepository = AllRepositories.TrainerRepository.Find(user.Id);
                    if (resultFindInTrainerRepository == null )
                    {
                        allActiveUsers.Add(user.FullName);
                        resultFindInTrainerRepository = null;
                    }
              
                }
                                       
            }
            string [] arrayAllActiveUsers = allActiveUsers.ToArray();
            Array.Sort(arrayAllActiveUsers);
            SelectList selectListItems = new SelectList(arrayAllActiveUsers);
            return selectListItems;
        }
        public static SelectList getArrayNameTrainerGroup(IUnitOfWork AllRepositories)
        {
            string[] arrayAllTrainerGroup = new string[AllRepositories.TrainerGroupRepository.All().Count()];
            int number = -1;
            foreach (var item in AllRepositories.TrainerGroupRepository.All())
            {
                number += 1;
                arrayAllTrainerGroup[number] = item.Name;
            }
            SelectList selectListItems = new SelectList(arrayAllTrainerGroup);
            return selectListItems;
        }
    }
}
