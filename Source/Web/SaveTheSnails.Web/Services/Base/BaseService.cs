namespace SaveTheSnails.Web.Services.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using SaveTheSnails.Data;
    using SaveTheSnails.Data.Models;
    using System.Web.Routing;

    using Microsoft.AspNet.Identity;
    
    public abstract class BaseService
    {
        protected IAppData Data { get; private set; }

        public AppUser CurrentUser {  get; private set;  }

        public BaseService(IAppData data, AppUser currentUser)
        {
            this.Data = data;
            this.CurrentUser = currentUser;
        }
    }
}