using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace mongoLog
{
    class UdpReceiver
    {
        static int portNum = 12345;
        public int recvNum = 10;
        DBHelper dbHelper = new DBHelper();

        public void Start()
        {
            dbHelper.Init();

            IPEndPoint e = new IPEndPoint(IPAddress.Any, portNum);
            UdpClient u = new UdpClient(e);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            u.BeginReceive(new AsyncCallback(recvCompletion), s);
        }

        void recvCompletion(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
            IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;
            Byte[] receiveBytes = u.EndReceive(ar, ref e);
            string receiveString = Encoding.ASCII.GetString(receiveBytes);
            
            OnRecv(receiveString);

            UdpState s = new UdpState();
            s.e = e;
            s.u = u;
            u.BeginReceive(new AsyncCallback(recvCompletion), s);
        }

        void OnRecv(string msg)
        {
            LogMsg logMsg = JsonConvert.DeserializeObject<LogMsg>(msg);
            dbHelper.InsertLog(logMsg);
        }
    }

    public class UdpState
    {
        public IPEndPoint e;
        public UdpClient u;
    }

    class LogMsg
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public long Time { get; set; }
        public Dictionary<string, string> Msg { get; set; }

        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public User ToUser()
        {
            User user = new User();
            user.UserId = UserId;
            user.Password = Password;
            user.OwnDataNames.Add(Name);

            return user;
        }

        public Data ToData()
        {
            Data data = new Data();
            data.Name = Name;
            data.Logs.Add(ToLog());

            return data;
        }

        public Log ToLog()
        {
            Log log = new Log();
            log.Level = Level;
            log.Time = start.AddMilliseconds(Time).ToLocalTime();
            log.Msg = Msg;

            return log;
        }
    }
}
