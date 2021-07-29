using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace PrjADO.NET
{
    class DAL
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
        public void DisplayRegion()
        {
            con = GetConnection();
            SqlDataAdapter da;
            da = new SqlDataAdapter("select * from Region", con);
            DataSet ds = new DataSet();//collection of tables
            //putting the table iside dataset
            da.Fill(ds, "NWREGION");
            //READING THE TABLE INFO FROM DATASET
            DataTable dt;
            dt = ds.Tables["NWREGION"];
            foreach(DataRow row in dt.Rows)
            {
                foreach(DataColumn col in dt.Columns)
                {
                    Console.Write(row[col]);
                }
                Console.WriteLine(" ");
            }
            //adding one more table to dataset :shipper
            Console.WriteLine("-----------------");
            Console.WriteLine("---------Shipper Table---------");
            da = new SqlDataAdapter("select * from Shippers", con);
            da.Fill(ds, "NWSHIPPER");
            DataTable dt1 = ds.Tables["NWSHIPPER"];
            foreach (DataRow row in dt1.Rows)
            {
                foreach (DataColumn col in dt1.Columns)
                {
                    Console.Write(row[col]);
                }
                Console.WriteLine(" ");
            }
            //INSERTING NEW ROW IN REGION TABLE IN DATASET
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Fill(ds);
            //inserting or adding a new row
            //creating a new row in NWREGION in dataset
            DataRow row1 = ds.Tables["NWREGION"].NewRow();
            row1["RegionID"] = 5;
            row1["RegionDescription"] = "AAAAA";
            //ADDING ROW TO DATATABLE IN DATASET
            ds.Tables["NWREGION"].Rows.Add(row1);

            da.Update(ds, "NWREGION");
            Console.WriteLine("-----------");
            dt = ds.Tables["NWREGION"];
            foreach(DataRow datarow in dt.Rows)
            {
                foreach(DataColumn dataColumn in dt.Columns)
                {
                    Console.Write(datarow[dataColumn]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
        }
    }
    class DisconnectedArchitecture
    {
        static void Main()
        {
            DAL dalobj = new DAL();
            dalobj.DisplayRegion();
        }
    }
}
