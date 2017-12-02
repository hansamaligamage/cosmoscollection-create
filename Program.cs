using Microsoft.Azure.Documents;
using System;

namespace highwaytraffic
{
    class Program
    {
        static void Main(string[] args)
        {

            DBConnector.Create().Wait();
           
        }
    }
}
