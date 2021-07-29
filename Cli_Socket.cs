using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace Chessy1._0
{
    public class cli_Socket
    {
        //用户基本信息
        public string id;
        string password;
        public int score;
        public int rank;
        public struct player
        {
            public string id;
            public int score;
            public int rankNum;
        }
        public player enplayer;
        //用于储存对手信息和世界排名对手的信息
        public Dictionary<int, player> WorldRank = new Dictionary<int, player>();
        public bool Idread = false;

        //用户端基本信息
        //string SerIP = "192.168.1.100";
        public string SerIP;
        Socket myClient = null;
        IPAddress SerAdd;
        IPEndPoint SerEP;
        //修改服务器IP
        public void GetSerIP(string IP)
        {
            SerIP = IP;
        }
        //判断服务器是否可连接
        public static bool TestConnection(string host, int port, int millisecondsTimeout)
        {
            millisecondsTimeout = 5;//等待时间
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(host, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //尝试连接服务器
        public bool Connect_To_Ser(int port)
        {
            if (SerIP == null)
                return false;
            myClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SerAdd = IPAddress.Parse(SerIP);
            SerEP = new IPEndPoint(SerAdd, port);
            if (!TestConnection(SerIP, port, 5))
                return false;
            else
            {
                while (true)
                {
                    try
                    {
                        myClient.Connect(SerEP);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }
        //获取服务器信息
        public string Receive_Ser()
        {
            byte[] SerBytes = new byte[1024 * 1024];
            try
            {
                int length = myClient.Receive(SerBytes);
                string recMsg = Encoding.UTF8.GetString(SerBytes, 0, length);
                //将服务器接收到的信息转发到已连接的客户端
                return recMsg;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Rec_Check()
        {
            if (Receive_Ser() == "TRUE")
                return true;
            return false;
        }
        //向服务器发送消息
        public bool SendToSer(string SendMsg)
        {
            try
            {
                myClient.Send(Encoding.UTF8.GetBytes(SendMsg));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //上传用户端信息，登陆功能
        public string login(string iD, string passWord)
        {
            SendToSer("LOGIN");
            //开始登陆函数
            if (Rec_Check())
            {
                SendToSer(iD);
            }
            //传入ID
            if (Rec_Check())
            {
                id = iD;
                SendToSer(passWord);
            }
            else
            {
                return "ID";//用户不存在
            }
            //传入密码
            if (Rec_Check())
            {
                password = passWord;
                SendToSer("SCORE");
                score = Convert.ToInt32(Receive_Ser());//获取收到的成绩
                Idread = true;
                return "TRUE";//一切顺利
            }
            else
                return "PASSWORD";//密码错误
            //保证一开始就读入身份信息
        }

        //注册功能
        public string signin(string iD, string passWord)
        {
            SendToSer("SIGNIN");
            //通知服务器开始注册函数
            id = iD;
            password = passWord;
            score = 50;
            if (Rec_Check())
            {
                SendToSer(iD);
            }
            //传入ID
            if (!Rec_Check())
            {
                return "ID";//ID重复注册
            }
            SendToSer(passWord);
            //传入密码
            if (Rec_Check())
            {
                Idread = true;
                return "TRUE"; //注册成功
            }
            else
                return "PASSWORD";//密码传入错误
        }

        //更新分数
        public void upDateScore()
        {
            SendToSer("SCORE");
            if (Rec_Check())
            {
                SendToSer(Convert.ToString(score));
            }//将会在服务器存入字典中
            Receive_Ser();
            //握手成功
        }

        //获取排名
        public void RankInform()
        {
            SendToSer("RANK");
            int rankNum;
            player rankPlayer;
            WorldRank = new Dictionary<int, player>();
            while (Rec_Check())//开始获取排名
            {
                rankPlayer = new player();
                SendToSer("GET");
                rankNum = Convert.ToInt32(Receive_Ser());
                SendToSer("GET");
                rankPlayer.id = Receive_Ser();
                SendToSer("GET");
                rankPlayer.score = Convert.ToInt32(Receive_Ser());
                SendToSer("GET");
                WorldRank.Add(rankNum, rankPlayer);//可能不到十位
            }
        }

        //获取自己的排名
        public int myRank()
        {
            SendToSer("MYRANK");
            return Convert.ToInt32(Receive_Ser());
        }
        //发送指令宗旨 第一个指令来自于客户端 最后一个指令一定来自于用户端 保证“握手”成功

        //联网对战
        //step1:cli->ONLINE会收到FIRST(白棋，先下)/SECOND(黑棋，后下),均恢复TREU->Ser
        //step2:！！！获取对手信息,id->Cli,TRUE->Ser,Score->Cli,TRUE->Ser,Rank->Cli,TRUE->Ser,
        //step3:cli1<-MOVE 开始下棋 并将下棋的信息->Ser Ser->cli2 cli2->Ser Ser->cli1.....开始循环
        //step4:如果在发出投降，另一方直接胜利，该方失败
        //step5:如果选择举报,会对面用户的积分进行处罚，并提醒对面被举报

        //点击后，判断我方是白棋还是黑棋
        public string BegiNetGame()
        {
            SendToSer("ONLINE");
            string str = Receive_Ser();
            if (str == "FIRST")
            {
                SendToSer("TRUE");
                Receive_Ser();//接收来自对手的组队消息
                return str;
            }
            return str;


        }//step1

        //获取对手信息
        public void enemyInform()
        {
            enplayer = new player();
            SendToSer("TRUE");
            enplayer.id = Receive_Ser();
            SendToSer("TRUE");
            enplayer.score = Convert.ToInt32(Receive_Ser());
            SendToSer("TRUE");
            enplayer.rankNum = Convert.ToInt32(Receive_Ser());
            SendToSer("TRUE");
        }//step2
        public void SendGameInfor(int[] temp)
        {
            SendToSer(Convert.ToString(temp[0]) + " " +
                        Convert.ToString(temp[1]) + " " +
                            Convert.ToString(temp[2]) + " " +
                                Convert.ToString(temp[3]));
        }//传入坐标解决
        public int[] ReceGameInfor()
        {
            int[] temp = new int[4];
            string str = Convert.ToString(Receive_Ser());
            string[] numstr = str.Split(" ");
            for (int i = 0; i < 4; i++)
            {
                temp[i] = Convert.ToInt32(numstr[i]);
            }
            SendToSer("TRUE");
            return temp;
        }//收到对方坐标
    }
}
