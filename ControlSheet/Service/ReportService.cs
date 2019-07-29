using ControlSheet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlSheet.Service
{

    public class ReportService
    {
        readonly DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        SqlTransaction transaction;
        UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable GetReportPrincipal()
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetLoadProyectActive, con);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable GetReportSumHour()
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spGetLoadProyectActive, con);

            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

    }
}