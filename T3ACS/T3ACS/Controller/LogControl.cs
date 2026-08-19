using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS
{
    public class LogControl
    {
              
        public void WriteLog(string message)
        {
            var strLogFile = AppDomain.CurrentDomain.BaseDirectory + "system_log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!File.Exists(strLogFile)) { 
                File.Create(strLogFile);
                Thread.Sleep(100);
            }

            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
       
            File.AppendAllText(strLogFile, $"[{time}] {message}\r\n");
        }
        public void WriteTransaction(
            string protocol,
            string address,
            string sendCmd,
            string recvData,
            string status)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logBlock = $@"[{time}] Protocol: {protocol}
Address: {address}
Send: {sendCmd}
Recv: {recvData}
Status: {status}
--------------------------------------" ;
            var strLogFile = AppDomain.CurrentDomain.BaseDirectory + "system_log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            if (!File.Exists(strLogFile)) File.Create(strLogFile);
            File.AppendAllText(strLogFile, logBlock + "\r\n");
        }
       
    }
}
