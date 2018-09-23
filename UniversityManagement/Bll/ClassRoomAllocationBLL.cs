using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagement.Gateway;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Bll
{
    public class ClassRoomAllocationBLL
    {
        ClassRoomAllocationGateway caAllocationGateway = new ClassRoomAllocationGateway();

        public List<Room> GetRooms()
        {
            return caAllocationGateway.GetRooms();
        }

        public string AllocateClassRoom(ClassRoom classRoom)
        {
            if (TimeIsExist(classRoom)==0)
            {
                caAllocationGateway.AllocateClassRoom(classRoom);
                return "Save";

            }
            else
            {
                return "Time OverLap";
            }
        }

        public int TimeIsExist(ClassRoom classRoom)
        {
            return caAllocationGateway.TimeIsExist(classRoom);
        }

        public List<ClassRoomAllocationView> ViewClassRoomAllocation(int id)
        {
           return caAllocationGateway.ViewClassRoomAllocation(id);
        }
    }
}