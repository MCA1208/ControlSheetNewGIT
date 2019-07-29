using ControlSheet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControlSheet.Service
{
    public class ReportsService
    {
        readonly DataTable dt = new DataTable();
        SqlConnection con;
        SqlCommand comando;
        readonly UserModel.SPName SPName = new UserModel.SPName();
        readonly ConnectionModel Connection = new ConnectionModel();

        public DataTable GetLoadReportPrincipal(DateTime? dateBegin, DateTime? dateEnd, int? Estado, int? idCompany, int? idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spReportPrincipal, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dateBegin", dateBegin);
            comando.Parameters.AddWithValue("@dateEnd", dateEnd);
            comando.Parameters.AddWithValue("@active", Estado);
            comando.Parameters.AddWithValue("@idCompany", idCompany);
            comando.Parameters.AddWithValue("@idUser", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }

        public DataTable GetLoadReportSumHour(DateTime? dateBegin, DateTime? dateEnd, int? Estado, int? idCompany, int? idUser)
        {
            con = new SqlConnection(Connection.stringConn);
            comando = new SqlCommand(SPName.spReportSumHour, con);

            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dateBegin", dateBegin);
            comando.Parameters.AddWithValue("@dateEnd", dateEnd);
            comando.Parameters.AddWithValue("@active", Estado);
            comando.Parameters.AddWithValue("@idCompany", idCompany);
            comando.Parameters.AddWithValue("@idUser", idUser);

            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);

            return dt;

        }


    }
}