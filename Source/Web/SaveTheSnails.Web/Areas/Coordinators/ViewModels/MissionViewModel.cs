using Kendo.Mvc.UI;
using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Coordinators.ViewModels
{
    public class MissionViewModel : ISchedulerEvent, IMapFrom<Mission> , IHaveCustomMappings
    {
        public int Id { get; set; }

        public int CoordinatorID { get; set; }

     //   public Coordinator Coordinator { get; set; }

    //    public ICollection<ProblemViewModel> Problems { get; set; }

        [Required]
        public IEnumerable<int> MissionProblems { get; set; }

        public int RequiredParticipants { get; set; }

    //    public ICollection<AppUser> JoinedUsers { get; set; }

        //Form ISchedulerEvent
        [Required]
        public string Description { get; set; }
        

        public DateTime End  { get; set; }
        

        public string EndTimezone { get; set; }
        

        public bool IsAllDay { get; set; }

        // RecurrenceID is from Example
        public int? RecurrenceID { get; set; }

        public string RecurrenceException { get; set; }
       

        public string RecurrenceRule { get; set; }
       

        public DateTime Start { get; set; }
       

        public string StartTimezone { get; set; }

        [Required]
        public string Title { get; set; }


        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Mission, MissionViewModel>()
                .ForMember(m => m.MissionProblems, opt => opt.MapFrom(p => p.Problems.Select(m => m.Id).ToList()));
        }

    }
}