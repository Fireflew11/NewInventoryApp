using System;
using Oracle.ManagedDataAccess.Client;

namespace ODP.NET_Core_Autonomous
{
    class Program
    {
        static void Main()
        {
            //Enter your ADB's user id, password, and net service name
            OracleConfiguration.SqlNetAuthenticationServices = "none";

            string conString = "User Id=ADMIN;Password=DBAm123456789!;Data Source=shoesdatabase_high;Connection Timeout=30;";
            OracleConfiguration.SqlNetAuthenticationServices = "none";

            //Enter directory where you unzipped your cloud credentials
            OracleConfiguration.TnsAdmin = @"C:\Oracle\Wallet\Wallet_ShoesDatabase";
            OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        OracleConfiguration.SqlNetAuthenticationServices = "none";
                        con.Open();
                        Console.WriteLine("Successfully connected to Oracle Autonomous Database");
                        Console.WriteLine();

                        cmd.CommandText = "select CUST_FIRST_NAME, CUST_LAST_NAME, CUST_CITY, CUST_CREDIT_LIMIT " +
                            "from SH.CUSTOMERS order by CUST_ID fetch first 20 rows only";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                            Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " in " +
                                reader.GetString(2) + " has " + reader.GetInt16(3) + " in credit.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}