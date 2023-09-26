using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //B1: Khởi tạo Socket Server với UDP
                Socket sk = new Socket(SocketType.Dgram, ProtocolType.Udp);
                //B2: Xác định IPEndPoint của Socket Server
                EndPoint s_iep = new IPEndPoint(IPAddress.Any, 8888);
                //B3: Liên kết socket server s_iep
                sk.Bind(s_iep);
                //B4: Thực hiện nhận /  gửi gói tin với Client
                Console.WriteLine("Cho goi tin gui tu Client!");
                //B4.1: Nhận gói tin gửi từ Client lên server
                byte[] receiveData = new byte[1024];
                EndPoint c_iep = new IPEndPoint(IPAddress.None, 0);
                int Ien = sk.ReceiveFrom(receiveData, ref c_iep);
                Console.WriteLine("Da  nhan thanh cong goi tin tu client!");
                //B4.2: Xy ly du lieu nhan duoc
                string message = ASCIIEncoding.ASCII.GetString(receiveData, 0, Ien);
                Console.WriteLine("Client: " + message);
                string send = message.ToUpper();
                byte[] sendData = ASCIIEncoding.ASCII.GetBytes(send);
                //B4.3: Gui phan hoi ve cho client
                sk.SendTo(sendData, c_iep);
                //B?: Dong ket noi
                sk.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Loi", ex.Message);
            }
            Console.ReadKey();
        }
    }
}
