using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad.NetworkResources
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> networkResources = GetNetworkResources();
            WriteToFile(networkResources);

        }

        private static void WriteToFile(List<string> networkResources)
        {
            const string fileName = "NetworkResources.txt";
            var file=File.Create(fileName);
            file.Close();
             File.AppendAllLines(fileName, networkResources);
        }

        private static List<string> GetNetworkResources()
        {
            List<string> networkResources=new List<string>();

            DirectoryEntry root = new DirectoryEntry("WinNT:");
            foreach (DirectoryEntry computers in root.Children)
            {
                foreach (DirectoryEntry computer in computers.Children)
                {
                    if (computer.Name != "Schema")
                    {
                        networkResources.Add(computer.Name);
                    }
                }
            }

            return networkResources;
        }
    }
}
