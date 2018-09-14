using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;

namespace UniversityManagement.Bll
{
    public class DepartmentBLL
    {
        DepartmentGateway departmentGateway = new DepartmentGateway();

        public string Save(Department department)

        {
            if (!departmentGateway.IsExsit(department.Code,department.Name))
            {
                if (departmentGateway.Save(department) > 0)
                {
                    return "Save";
                }
                else
                {
                    return "Error";
                }
            }

            else
            {
                return "Already Exist";
            }
           
        }

        public List<Department> GetDepartments()
        {
            return departmentGateway.GetDepartments();
        }
    }
}