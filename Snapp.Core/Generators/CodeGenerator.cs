using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snapp.Core.Generators
{
    public static class CodeGenerator
    {
        public static string GetActivecode()
        {
            Random random = new Random();

            return random.Next(100000,990000).ToString();
        }

        public static Guid Getid()
        {
            return Guid.NewGuid();
        }

        public static string GetfileName()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }

        public static string getordercode()
        {
            Random random = new Random();

            return random.Next(10000000, 99000000).ToString();
        }
    }
}
