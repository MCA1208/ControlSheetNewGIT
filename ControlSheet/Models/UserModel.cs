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
            public string spReportGraphicByType = "spReportGraphicByType";
            //User
            public string spRecoveryPassword = "spRecoveryPassword";
            public string spCreateUserOperator = "spCreateUserOperator";
            public string SpChangePassword = "SpChangePassword";
            public string spCountLicense = "spCountLicense";
            public string spDeleteUser = "spDeleteUser";
            public string spGetUserForIdCompany = "spGetUserForIdCompany";

            //PAPER BAG
            public string spInsertModifyProfile = "spInsertModifyProfile";
            public string spGetAllProfile = "spGetAllProfile";
            public string spGetProfileForId = "spGetProfileForId";
            public string spGetUserPB = "spGetUserPB";
            public string spCreateUserPB = "spCreateUserPB";
            public string spGetHasProfile = "spGetHasProfile";
            public string spGetImageCurrent = "spGetImageCurrent";
            public string spRecoveryPasswordPaper = "spRecoveryPasswordPaper";





        }
        #endregion
    }
}