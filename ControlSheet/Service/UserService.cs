using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ControlSheet.Models;


namespace ControlSheet.Service
{
    public class UserService
    {

        DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        SqlTransaction transaction;
        UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable spGetAllUserGroup()
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand("spGetAllUserGroup", con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public void sendMail(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("milton.amado10@gmail.com");
            mail.To.Add("milton.amado10@gmail.com");
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("milton.amado10@gmail.com", "jepercreper");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

        public void CreateUserAdmin(string nameCompany, string eMail, string pass)
        {

            con = new SqlConnection(Connection.stringConn);
            con.Open();
            transaction = con.BeginTransaction();
            try
            {


                comando = new SqlCommand(SPName.spCreateUserAdmin, con);
                comando.Transaction = transaction;

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nameCompany", nameCompany);
                comando.Parameters.AddWithValue("@eMail", eMail);
                comando.Parameters.AddWithValue("@pass", pass);

                comando.ExecuteNonQuery();

                transaction.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                }

            


        }

    }
}