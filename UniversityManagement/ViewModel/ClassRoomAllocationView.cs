using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.ViewModel
{
    public class ClassRoomAllocationView
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string FullShedule { get; set; }
        
    }
}