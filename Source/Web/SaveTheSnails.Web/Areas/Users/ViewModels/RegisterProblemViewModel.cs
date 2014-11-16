using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class RegisterProblemViewModel : IMapFrom<Problem> //,  IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [UIHint("MultiLineText")]
        public string Description { get; set; }

        [Required]
        public ProblemLocation Location { get; set; }

        [Required]
        [Display(Name = "Pictures")]
        public ICollection<HttpPostedFileBase> UploadedPictures { get; set; }

        [Required]
        [Display(Name = "Category")]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public string ReporterID { get; set; }

       // public void CreateMappings(AutoMapper.IConfiguration configuration)
       // {
       //     //configuration.CreateMap<Problem, RegisterProblemViewModel>()
       //     //    .ForMember(m => m.Latitude, opt => opt.MapFrom(p => p.Location.Latitude));

       // //    configuration.CreateMap<Problem, RegisterProblemViewModel>()
       // //        .ForMember(m => m.Pictures, opt => opt.MapFrom(p =>
       // //        {
       // //            MemoryStream target = new MemoryStream();


       // //        }));

       //}

    }
}