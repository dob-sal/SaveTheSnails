using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheSnails.Data.Models
{
    public class Picture
    {
        
        public int ID { get; set; }

        public byte[] File { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public int ProblemID { get; set; }

        public virtual Problem Problem { get; set; }

        public bool IsBefore { get; set; }
    }
}
