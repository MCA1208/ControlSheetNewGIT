using ControlSheet.Models;
using System;
using System.Data;
using System.Data.SqlClient;


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

        public DataTable spGetUse(string user)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetUser, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@userName", user);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }
        public DataTable spGetPermissionByProfile(int IdProfile)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetPermissionByProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProfile", IdProfile);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable SpRecoveryPassword(string Email, string Password)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spRecoveryPassword, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Email", Email);
            comando.Parameters.AddWithValue("@Password", Password);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;


        }

    }
}