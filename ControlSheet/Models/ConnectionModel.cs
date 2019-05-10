using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ControlSheet.Models
{
    public class ConnectionModel
    {
        public string stringConn = ConfigurationManager.ConnectionStrings["cnnString"].ToString();
    }
}