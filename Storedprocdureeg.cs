using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace PrjADO.NET
{
    class DataAccessLayer
    {
        SqlConnection con = null;
        SqlCommand cmd = null;


        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                 "Data Source = DESKTOP-PL3O6N3; Initial Catalog = Northwind; Integrated Security = true");
            con.Open();
            return con;
        }
        //call procedure without parameter
        internal void CallTenMostExpensiveProducts()
        {
            try
            {
                con = GetConnection();
                //procedure name in sql server 
                cmd = new SqlCommand("Ten Most Expensive Products", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Console.WriteLine(dr[0]+" "+dr[1]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallCustOrdersOrders(string cid)
        {
            try
            {
                con = GetConnection();
                //procedure name in sql server 
                cmd = new SqlCommand("CustOrdersOrders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", cid);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr["OrderID"] + " " + dr["OrderDate"]+" "+dr["ShippedDate"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
    }
    class Storedprocdureeg
    {
        static void Main()
        {
            DataAccessLayer spobject = new DataAccessLayer();
            spobject.CallTenMostExpensiveProducts();

            Console.WriteLine("Enter the Customerid");
            string cid = Console.ReadLine();
            spobject.CallCustOrdersOrders(cid);
        }
      

    }
}
