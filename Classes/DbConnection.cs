using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;


namespace NewInventoryApp.Classes
{
    class DbConnection
    {
        static OracleConnection con = null;
        public static void ConnectDb()
        {
            //Enter your ADB's user id, password, and net service name
            OracleConfiguration.SqlNetAuthenticationServices = "none";

            string conString = "User Id=ADMIN;Password=DBAm123456789!;Data Source=shoesdatabase_high;Connection Timeout=30;";
            OracleConfiguration.SqlNetAuthenticationServices = "none";

            //Enter directory where you unzipped your cloud credentials
            OracleConfiguration.TnsAdmin = "@Wallet";
            OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

            using (con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        OracleConfiguration.SqlNetAuthenticationServices = "none";
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}