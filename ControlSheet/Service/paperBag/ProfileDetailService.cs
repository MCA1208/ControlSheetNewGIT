using ControlSheet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlSheet.Service.paperBag
{
    public class ProfileDetailService
    {

        readonly DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        readonly UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable InsertModifyProfile(string name, string profession,
            string academyData, string experience, string contact, int idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spInsertModifyProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@name", name);
            comando.Parameters.AddWithValue("@profession", profession);
            comando.Parameters.AddWithValue("@academyData", academyData);
            comando.Parameters.AddWithValue("@experience", experience);
            comando.Parameters.AddWithValue("@contact", contact);
            comando.Parameters.AddWithValue("@idUsers", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable GetAllProfile ()
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetAllProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable GetProfileForId(int? Id)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetProfileForId, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        
        public DataTable GetHasProfile(int Id)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetHasProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", Id);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable GetImageCurrent(int IdUser, int TypeImage)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetImageCurrent, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdUser", IdUser);
            comando.Parameters.AddWithValue("@typeImage", TypeImage);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable ModifyPass(string _newPass, int idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spchangePasswordPaper, con);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@newPass", _newPass);
            comando.Parameters.AddWithValue("@idUser", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }


    }
}