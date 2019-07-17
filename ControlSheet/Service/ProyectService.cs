using ControlSheet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlSheet.Service
{
    public class ProyectService
    {
        DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        SqlTransaction transaction;
        UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable GetLoadProyectActive()
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetLoadProyectActive, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable CreateNewProyect(string proyectName, int userId)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spCreateNewProyect, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@proyectName", proyectName);
            comando.Parameters.AddWithValue("@userId", userId);
            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable LoadProyectDetail( int Id)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spLoadProyectDetail, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProyect", Id);
            
            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }
        public DataTable InsertProyectDetail(string moduleName, string proyectDescription, string hourEstimated, DateTime dateEstimatedEnd, int idProyect, int idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spInsertProyectDetail, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@moduleName", moduleName);
            comando.Parameters.AddWithValue("@proyectDescription", proyectDescription);
            comando.Parameters.AddWithValue("@hourEstimated", hourEstimated);
            comando.Parameters.AddWithValue("@dateEstimatedEnd", dateEstimatedEnd);
            comando.Parameters.AddWithValue("@idProyect", idProyect);
            comando.Parameters.AddWithValue("@idUser", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }


        public DataTable LoadEditProyectDetail(int idProyect, int idProyectDetail)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetLoadEditProyectDetail, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProyect", idProyect);
            comando.Parameters.AddWithValue("@idProyectDetail", idProyectDetail);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable EditProyectDetail(int idProyect, int idProyectDetail, string moduleName, string descriptions, float hourDedicated)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spEditProyectDetail, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProyect", idProyect);
            comando.Parameters.AddWithValue("@idProyectDetail", idProyectDetail);
            comando.Parameters.AddWithValue("@moduleName", moduleName);
            comando.Parameters.AddWithValue("@descriptions", descriptions);
            comando.Parameters.AddWithValue("@hourDedicated", hourDedicated);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }
    }
}