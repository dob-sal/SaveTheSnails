using SaveTheSnails.Data.Models;
using SaveTheSnails.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheSnails.Web.Areas.Users.ViewModels
{
    public class PictureViewModel : IMapFrom<Picture>
    {
        public byte[] File { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

    }
}