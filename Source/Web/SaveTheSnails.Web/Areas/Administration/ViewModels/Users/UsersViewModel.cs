using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Areas.Administration.ViewModels.Base;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Administration.ViewModels.Users
{
    public class UsersViewModel : AdministrationViewModel, IMapFrom<AppUser>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsCoordinator { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<AppUser, UsersViewModel>()
                .ForMember(m => m.IsCoordinator
                          , opt => opt.MapFrom(p => p.Roles
                                                     .Where(r => r.RoleId == "dcdb133c-8b58-46b6-ac62-9b05603dea90")
                                                     .Any())
                          );
        }
    }
}