using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Practice.Data.Entities {
    /// <summary>
    /// Class that maps subject.
    /// </summary>
    class Subject {

        public int SubjectID { get; set; }
        public string SubjectDescriptiom { get; set; }
        public int SchoolID { get; set; }
    }
}
