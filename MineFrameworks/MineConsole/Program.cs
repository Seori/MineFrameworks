using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MineFramework;

namespace MineConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MineSocket ms = new MineSocket();
            ms.MineSocketStart();
        }
    }
}
