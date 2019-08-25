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

        public DataTable InsertModifyProfile(byte[] imagePerfil, byte[] imagePasion, byte[] imageAlgo,string personalData, 
            string academyData, string experience, string contact, int idUser)
        {
            con = new SqlConnection(Connection.stringConnPB);
            comando = new SqlCommand(SPName.spInsertModifyProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@imagePerfil", imagePerfil);
            comando.Parameters.AddWithValue("@imagePasion", imagePasion);
            comando.Parameters.AddWithValue("@imageAlgo", imageAlgo);
            comando.Parameters.AddWithValue("@personalData", personalData);
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
            con = new SqlConnection(Connection.stringConnPB);
            comando = new SqlCommand(SPName.spGetAllProfile, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

    }
}