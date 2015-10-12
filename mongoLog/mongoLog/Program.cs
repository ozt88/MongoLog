using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mongoLog
{
    class Program
    {

        static void Main(string[] args)
        {
            UdpReceiver udp = new UdpReceiver();
            udp.Start();
            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}
