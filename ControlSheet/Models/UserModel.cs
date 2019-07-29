using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlSheet.Models
{
    public class UserModel
    {
        #region Nombres de stored Procedures
        public class SPName
        {
            public string spCreateUserAdmin = "spCreateUserAdmin";
            public string spGetUser = "spGetUser";
            public string spGetPermissionByProfile = "spGetPermissionByProfile";
            public string spGetLoadProyectActive = "spGetLoadProyectActive";
            public string spCreateNewProyect = "spCreateNewProyect";
            public string spLoadProyectDetail = "spGetLoadProyectDetail";
            public string spInsertProyectDetail = "spInsertProyectDetail";
            public string spGetLoadEditProyectDetail = "spGetLoadEditProyectDetail";
            public string spEditProyectDetail = "spEditProyectDetail";
            public string spDeleteProyect = "spDeleteProyect";

            //Report
            public string spReportPrincipal = "spReportPrincipal";
            public string spReportSumHour = "spReportSumHour";


        }
        #endregion
    }
}