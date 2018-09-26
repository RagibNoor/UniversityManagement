using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagement.Models;
using UniversityManagement.ViewModel;

namespace UniversityManagement.Gateway
{
    public class ClassRoomAllocationGateway
    {
        private string ConnectinString =
           WebConfigurationManager.ConnectionStrings["UniversityMangement"].ConnectionString;

        public List<Room> GetRooms()
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "Select * from Room";

            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room();
                room.RoomNo = reader["RoomNo"].ToString();
                room.Id = (int) reader["Id"];
                rooms.Add(room);
            }
            reader.Close();
            con.Close();
            return rooms;
        }
        public int AllocateClassRoom(ClassRoom classRoom)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "insert into ClassAllocation(RoomId,DepartmentId,CourseId,Day,StartTime,EndTime,status) values(@RoomId,@DepartmentId,@CourseId,@Day,@StartTime,@EndTime,'1')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("RoomId", classRoom.RoomId);
            cmd.Parameters.AddWithValue("DepartmentId", classRoom.DepartmentId);
            cmd.Parameters.AddWithValue("CourseId", classRoom.CourseId);
            cmd.Parameters.AddWithValue("Day", classRoom.Day);
            cmd.Parameters.AddWithValue("StartTime", classRoom.StartTime);
            cmd.Parameters.AddWithValue("EndTime", classRoom.EndTime);

            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public int TimeIsExist(ClassRoom classRoom)
        {
            SqlConnection con = new SqlConnection(ConnectinString); 
            con.Open();
            string query = "Select Count(Id) from ClassAllocation where Day ='" + classRoom.Day + "' and RoomId = '" + classRoom.RoomId + "' And Status ='True' And (('" + classRoom.StartTime + "' >= StartTime and '" + classRoom.StartTime + "' <= EndTime) or ('" + classRoom.EndTime + "' >= StartTime and '" + classRoom.EndTime + "' <= EndTime))";

            SqlCommand cmd = new SqlCommand(query, con);
            var value = cmd.ExecuteScalar();
            int a = 0;
            if (value != null)
            {
                a += (int)value;

            }


            con.Close();
            return a;

        }

        public List<ClassRoomAllocationView> ViewClassRoomAllocation(int id)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  ClassAllocationView where (Status  IS NULL or status = 'true') And DepartmentId = '" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<ClassRoomAllocationView> classRoomAllocationViews = new List<ClassRoomAllocationView>();

            while (reader.Read())
            {
                int flag = 0;
                ClassRoomAllocationView allocationView = new ClassRoomAllocationView();
                allocationView.Code = reader["Code"].ToString();
                allocationView.Name = reader["Name"].ToString();
                allocationView.RoomNo = reader["RoomNo"].ToString();
                allocationView.StartTime = reader["StartTime"].ToString();
                allocationView.EndTime = reader["EndTime"].ToString();
                if (allocationView.StartTime != "")
                {
                    allocationView.StartTime = Get24FormatTime(allocationView.StartTime);
                    allocationView.EndTime = Get24FormatTime(allocationView.EndTime);

                    
                }
               

                allocationView.Day = reader["Day"].ToString();
                if (allocationView.RoomNo !="")
                {
                    allocationView.FullShedule = " R NO: " + allocationView.RoomNo + " " +
                                            allocationView.Day.Substring(0, 3) + ":" + allocationView.StartTime + " - " +
                                            allocationView.EndTime;
                }

                foreach (var data in classRoomAllocationViews)
                {
                    if (data.Code==allocationView.Code)
                    {
                        data.FullShedule += "; </br>" + allocationView.FullShedule;
                        flag = 1;
                    }
                }

                if (flag==0)
                {
                    classRoomAllocationViews.Add(allocationView);
                    
                }

            }
            reader.Close();
            con.Close();
            return classRoomAllocationViews;
        }

        public string Get24FormatTime(string time12Format)
        {
            string str = time12Format;
            string flag = " Am";
            int hour = Convert.ToInt32(str.Substring(0, 2));
            if (hour > 12)
            {
                flag = " Pm";
                hour = hour - 12;
            }
            else if (hour == 0)
            {
                hour = hour + 12;
            }

            string shour = hour.ToString("00");
            string minute = str.Substring(2, 3);
            string time = shour + minute + flag;
            return time;
        }


    }
}