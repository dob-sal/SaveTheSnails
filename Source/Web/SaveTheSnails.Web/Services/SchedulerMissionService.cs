namespace SaveTheSnails.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;

    using SaveTheSnails.Data.Models;
    using SaveTheSnails.Web.Areas.Coordinators.ViewModels;
    using SaveTheSnails.Web.Services.Base;
    using SaveTheSnails.Data;
    
    public class SchedulerMissionService : BaseService, ISchedulerEventService<MissionViewModel>
    {
        public SchedulerMissionService(IAppData data, AppUser currentUser)
            : base(data, currentUser)
        {
                
        }

        public void Delete(MissionViewModel mission, ModelStateDictionary modelState)
        {
            var dbMission = this.Data.Missions.GetById(mission.Id);
            var dbMissionProblems = dbMission.Problems.ToList();
            for (int i = 0; i < dbMissionProblems.Count; i++)
            {
                dbMission.Problems.Remove(dbMissionProblems[i]);
            }

            this.Data.Missions.Delete(dbMission);
            this.Data.SaveChanges();
        }

        public IQueryable<MissionViewModel> GetAll()
        {
            var missions = this.Data
                                .Missions
                                .All()
                                .Project()
                                .To<MissionViewModel>();

            return missions;
        }

        public void Insert(MissionViewModel mission, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var dbMission = Mapper.Map<Mission>(mission);
                dbMission.CoordinatorID = this.Data.Coordinators.All()
                                                    .FirstOrDefault(c => c.User.UserName == this.CurrentUser.UserName).Id;

                this.Data.Missions.Add(dbMission);

                var missionProblems = mission.MissionProblems;
                foreach (var problem in missionProblems)
                {
                    var dbProblem = this.Data.Problems.GetById(problem);
                    dbMission.Problems.Add(dbProblem);
                }

                this.Data.SaveChanges();
                mission.Id = dbMission.Id;
            }
        }

        public void Update(MissionViewModel mission, System.Web.Mvc.ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var dbMission = this.Data.Missions.GetById(mission.Id);
                Mapper.Map<MissionViewModel, Mission>(mission, dbMission);

                var dbMissionProblems = dbMission.Problems.ToList();
                for (int i = 0; i < dbMissionProblems.Count; i++)
                {
                    dbMission.Problems.Remove(dbMissionProblems[i]);
                }

                var missionProblems = mission.MissionProblems;

                foreach (var problem in missionProblems)
                {
                    var dbProblem = this.Data.Problems.GetById(problem);
                    dbMission.Problems.Add(dbProblem);
                }

                this.Data.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //TODO :  Extract map problems in method
        private void MapProblems()
        {

        }

        //TODO: extract method RemoveProblemFromMision
        private void RemoveProblemFromMision()
        { 
        
        }
    }
}