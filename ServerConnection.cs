using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
namespace InventoryManagementSystem
{
    internal class ServerConnection
    {
        private string v;

        public ServerConnection(string v)
        {
            this.v = v;
        }
    }
}