using System;

namespace Scan_Lan2
{
    /// <summary>
    /// Описание нашего компьютера
    /// </summary>
    public class Describe
    {
        public static string host = System.Net.Dns.GetHostName();
        public string ip_addres = System.Net.Dns.GetHostByName(host).AddressList[0].ToString();

        /// <summary>
        /// Описание нашей системы
        /// </summary>
        public void DescribeSystem()
        {
            Console.Title = "Сканер локальной сети";
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---------------------------------Этот компьютер---------------------------------");      
            
               
            //-----------------------------------------Проверка соединения с интернетом-------------------------------------------------------
            string proverka_soedineniya_s_internetom1 = ""; 
            try
            {
                System.Net.NetworkInformation.Ping proverka_pinga = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply proverka_pingReply1 = proverka_pinga.Send("google.com");

                proverka_soedineniya_s_internetom1 = proverka_pingReply1.Status.ToString();
                if (proverka_soedineniya_s_internetom1 == "Success") proverka_soedineniya_s_internetom1 = "Соединение присутствует";
                else proverka_soedineniya_s_internetom1 = "Соединение отсутствует";
            }
            catch { proverka_soedineniya_s_internetom1 = "Соединение отсутствует"; }
            //--------------------------------------------------------------------------------------------------------------------------------

            Console.WriteLine("Имя компьютера: " + host + "\t\tСостояние подключения к интернету:");
            Console.WriteLine("IP-адрес компьютера: " + ip_addres + "\t" + proverka_soedineniya_s_internetom1);
            Console.WriteLine("\n--------------------------------------------------------------------------------");
        }
    }
}
