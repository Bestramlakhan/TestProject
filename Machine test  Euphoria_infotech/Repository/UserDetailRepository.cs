using Machine_test__Euphoria_infotech.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Machine_test__Euphoria_infotech.Repository
{
    public class UserDetailRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["EuphoriaDB"].ToString();
            con = new SqlConnection(constr);

        }
        public bool AddReg(UserRegistation userRegistation)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", userRegistation.Name);
            com.Parameters.AddWithValue("@UserName", userRegistation.UserName);
            com.Parameters.AddWithValue("@Address", userRegistation.Address);
            com.Parameters.AddWithValue("@Password", userRegistation.Password);
            com.Parameters.AddWithValue("@Role", userRegistation.RoleName);
            com.Parameters.AddWithValue("@Age", userRegistation.Age);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}