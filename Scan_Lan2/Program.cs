using System;

namespace Scan_Lan2
{
    class Program
    {
        static void Main(string[] args)
        {
            Describe describe = new Describe();
            Searching searching = new Searching();
            IPSearching ipsearching = new IPSearching();

            describe.DescribeSystem();
            searching.SearchingOfIP();
            
            Console.ReadKey();            
        }
    }
}
