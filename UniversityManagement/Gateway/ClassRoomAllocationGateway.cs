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
            string query = "insert into ClassAllocation(RoomId,DepartmentId,CourseId,Day,StartTime,EndTime) values(@RoomId,@DepartmentId,@CourseId,@Day,@StartTime,@EndTime)";
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
            string query = "Select Count(Id) from ClassAllocation where Day ='" + classRoom.Day + "' and RoomId = '" + classRoom.RoomId + "' And (('" + classRoom.StartTime + "' >= StartTime and '" + classRoom.StartTime + "' <= EndTime) or ('" + classRoom.EndTime + "' >= StartTime and '" + classRoom.EndTime + "' <= EndTime))";

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
    }
}