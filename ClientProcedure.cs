using System;
using System.Collections.Generic;
using System.Text;

namespace PrjADO.NET
{
    class ClientProcedure
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
