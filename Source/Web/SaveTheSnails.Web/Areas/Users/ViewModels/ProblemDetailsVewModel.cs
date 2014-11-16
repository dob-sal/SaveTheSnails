using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class ProblemDetailsVewModel : IMapFrom<Problem>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? StatusID { get; set; }

        public ProblemStatus Status { get; set; }

        public string ReporterID { get; set; }

        public AppUser Reporter { get; set; }

        public ProblemLocation Location { get; set; }

        public ICollection<Picture> Pictures { get; set; }
  
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int? MissionID { get; set; }

        public Mission Mission { get; set; }

        [Display(Name ="Joined Participants ")]
        public int JoinedUsersToMission { get; set; }


        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Problem, ProblemDetailsVewModel>()
                 .ForMember(m => m.JoinedUsersToMission, opt => opt.MapFrom(p => p.Mission.JoinedUsers.Count()));
        }
    }
}