using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class RegisterProblemViewModel : IMapFrom<Problem> //, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        //public decimal Latitude { get; set; }

        //public decimal Longitude { get; set; }

        public ProblemLocation Location { get; set; }

        public string ReporterID { get; set; }

        //public void CreateMappings(AutoMapper.IConfiguration configuration)
        //{
        //    configuration.CreateMap<Problem, RegisterProblemViewModel>()
        //        .ForMember(m => m.Latitude, opt => opt.MapFrom(p => p.Location.Latitude));
        //    configuration.CreateMap<Problem, RegisterProblemViewModel>()
        //        .ForMember(m => m.Longitude, opt => opt.MapFrom(p => p.Location.Longitude));
        //}

    }
}