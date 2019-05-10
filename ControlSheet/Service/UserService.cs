using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace ControlSheet.Service
{
    public class UserService
    {
        string conn = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
        DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        SqlTransaction transaction;

        public DataTable spGetAllUserGroup()
        {
            con = new SqlConnection(conn);
            comando = new SqlCommand("spGetAllUserGroup", con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public void sendMail(string email)
        {
            //ENVIAR MAIL

        }

        public void CreateUserAdmin(string nameCompany, string eMail, string pass)
        {
            con = new SqlConnection(conn);
            con.Open();
            transaction = con.BeginTransaction();

            try
            {
               
                comando = new SqlCommand("spCreateUserAdmin", con);

                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nameCompany", nameCompany);
                comando.Parameters.AddWithValue("@eMail", eMail);
                comando.Parameters.AddWithValue("@pass", pass);

                comando.ExecuteNonQuery();

                transaction.Commit();
                con.Open();
            }
            catch(Exception ex)
            {
                transaction.Rollback();

            }
        }

    }
}