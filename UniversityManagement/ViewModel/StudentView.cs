using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagement.ViewModel
{
    public class StudentView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string RegNo { get; set; }
        public int DepartmentId { get; set; }
    }
}