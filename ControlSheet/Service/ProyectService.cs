﻿using ControlSheet.Models;
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
        UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable GetLoadProyectActive(int idCompany, int? idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetLoadProyectActive, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCompany", idCompany);
            comando.Parameters.AddWithValue("@iduser", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable CreateNewProyect(string proyectName,int tipoReq, int iduser,int idCompany)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spCreateNewProyect, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@proyectName", proyectName);
            comando.Parameters.AddWithValue("@tipoReq", tipoReq);
            comando.Parameters.AddWithValue("@idUser", iduser);
            comando.Parameters.AddWithValue("@idCompany", idCompany);
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

        public DataTable EditProyectDetail(int idProyect, int idProyectDetail, string moduleName, string descriptions, DateTime? dateEstimated, float? hourEstimated, float? hourDedicated, bool finalizado)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spEditProyectDetail, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProyect", idProyect);
            comando.Parameters.AddWithValue("@idProyectDetail", idProyectDetail);
            comando.Parameters.AddWithValue("@moduleName", moduleName);
            comando.Parameters.AddWithValue("@descriptions", descriptions);
            comando.Parameters.AddWithValue("@dateEstimated", dateEstimated);
            comando.Parameters.AddWithValue("@hourEstimated", hourEstimated);
            comando.Parameters.AddWithValue("@hourDedicated", hourDedicated);
            comando.Parameters.AddWithValue("@finalizado", finalizado);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable DeleteProyect(int idProyect)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spDeleteProyect, con);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProyect", idProyect);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }


    }
}