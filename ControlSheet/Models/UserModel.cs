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

        }
        #endregion
    }
}