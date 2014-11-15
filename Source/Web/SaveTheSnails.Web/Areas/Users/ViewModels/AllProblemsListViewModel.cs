using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class AllProblemsListViewModel : IMapFrom<Problem>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string StatusName { get; set; }

        public string ReporterName { get; set; }

        public string RegionName { get; set; }

        public string CategoryName { get; set; }

        public string MissionTitle{ get; set; }
        
        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Problem, AllProblemsListViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(m => m.ReporterName, opt => opt.MapFrom(p => p.Reporter.UserName))
                .ForMember(m => m.StatusName, opt => opt.MapFrom(p => p.Status.Name))
                .ForMember(m => m.RegionName, opt => opt.MapFrom(p => p.Location.Region.Name))
                .ForMember(m => m.MissionTitle, opt => opt.MapFrom(p => p.Mission.Title))
                .ReverseMap();
        }
    }
}