using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace PrjADO.NET
{
    class Shipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public void Getshipper()
        {
            Console.WriteLine("enter the shippername or company name");
            CompanyName = Console.ReadLine();
            Console.WriteLine("enter the Phone Number");
            Phone = Console.ReadLine();
        }
        public void Looseshipper()
        {
            Console.WriteLine("enter the shippername or company name");
            CompanyName = Console.ReadLine();
        }
        public void Editshipper()
        {
            Console.WriteLine("enter the shipperid");
            ShipperId=Convert.ToInt32( Console.ReadLine());
            
            Getshipper();
        }
    }
    class ConnectedArchitectureEg1
    {
        static void Main()
        {
            //create sql connection object
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                //3.windows authentication
           
                     con = new SqlConnection(
                 "Data Source = DESKTOP-PL3O6N3; Initial Catalog = Northwind; Integrated Security = true");
                //Sql server authentication
                // con = new SqlConnection(
                // "Data Source= DESKTOP-U8J1M3C\\MSSQLSERVER01;Initial Catalog=Northwind;User ID=sa;Password=newuser123#");
                //4
                con.Open();
                Shipper shipper = new Shipper();
                //calling getshipper
                //insertion
                /* shipper.Getshipper();
                 cmd = new SqlCommand("insert into Shippers(CompanyName,Phone) values(@cname,@phone)", con);
                 cmd.Parameters.AddWithValue("@cname", shipper.CompanyName);
                 cmd.Parameters.AddWithValue("@Phone", shipper.Phone);
                 int i = cmd.ExecuteNonQuery();
                 Console.WriteLine("No of rows Affected:{0}", i);*/
                //DELETION
                /*shipper.Looseshipper();
                cmd = new SqlCommand("delete from Shippers where CompanyName=@cname", con);
                cmd.Parameters.AddWithValue("@cname", shipper.CompanyName);
                
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows Deleted:{0}", i);
                cmd.Parameters.Clear();*/
                //SELECT
                /* SqlDataReader dr;
                 cmd = new SqlCommand("select * from Shippers ", con);
                 dr = cmd.ExecuteReader();
                 while(dr.Read())
                 {
                     //Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                     Console.WriteLine(dr["CompanyName"] + " " + dr["Phone"]);
                 }*/
               /* shipper.Editshipper();
                cmd = new SqlCommand("Update Shippers set CompanyName=@cname Phone=@Phone where ShipperID=@id", con);
                cmd.Parameters.AddWithValue("@id", shipper.ShipperId);
                cmd.Parameters.AddWithValue("@cname", shipper.CompanyName);
                cmd.Parameters.AddWithValue("@Phone", shipper.Phone);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows Updated:{0}", i);*/
                //scalar value
                cmd = new SqlCommand("select count(ShipperID) from Shippers ", con);
                Console.WriteLine("Total Shippers:{0}",Convert.ToInt32(cmd.ExecuteScalar()));

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
    }
}
