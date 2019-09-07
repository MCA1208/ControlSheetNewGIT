using ControlSheet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlSheet.Service.paperBag
{
    public class UserService
    {
        DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable spGetUse(string user)
        {
            con = new SqlConnection(Connection.stringConnPB);
            comando = new SqlCommand(SPName.spGetUserPB, con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@userName", user);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);

            return dt;

        }

        public void CreateUser( string eMail, string pass)
        {

            con = new SqlConnection(Connection.stringConnPB);
            con.Open();
            comando = new SqlCommand(SPName.spCreateUserPB, con);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@eMail", eMail);
            comando.Parameters.AddWithValue("@pass", pass);
            comando.ExecuteNonQuery();

            con.Close();
           
         
        }

        public DataTable SpRecoveryPassword(string Email, string Password)
        {
            con = new SqlConnection(Connection.stringConnPB);
            comando = new SqlCommand(SPName.spRecoveryPasswordPaper, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Password", Password);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;


        }


        //End Controller

    }
}