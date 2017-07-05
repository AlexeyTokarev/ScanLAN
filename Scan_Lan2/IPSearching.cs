using System;
using System.Threading.Tasks;

namespace Scan_Lan2
{
    /// <summary>
    /// Перебор всех IP-адресов
    /// </summary>
    public class IPSearching
    {
        public int kolichestvo_komputerov_v_sety = 0;

//----------------------------------------------------------------------------------------------------------------------------------------------        
        /// <summary>
        /// Метод для перебора всех IP-адресов
        /// </summary>
        /// <param name="stringovaya_pervaya_chast_IP_adresa"></param>
        public void SearchIP(string stringovaya_pervaya_chast_IP_adresa)
        {            
            Task[] tasks = new Task[254];
            for (int last_oktet = 0; last_oktet < 254; last_oktet++)
            {
                string address_for_ping = stringovaya_pervaya_chast_IP_adresa + (last_oktet+1);
                tasks[last_oktet] = Task.Run(() => PingIP(address_for_ping));
            }

            Task.WaitAll(tasks);
            Result(kolichestvo_komputerov_v_sety);
        }

//----------------------------------------------------------------------------------------------------------------------------------------------        
        /// <summary>
        /// Метод для пинга определенного IP-адреса
        /// </summary>
        /// <param name="fullIpAddres"></param>
        public void PingIP(string fullIpAddres)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingReply = ping.Send(fullIpAddres);            

            string status_uzla = pingReply.Status.ToString();

            if (status_uzla == "Success")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + fullIpAddres + "\t\t\t      " + pingReply.RoundtripTime + " м/с\t\tУспешное соединение ");
                kolichestvo_komputerov_v_sety++;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" " + fullIpAddres + "\t\t\t\t-\t     Заданный узел недоступен ");
            }            
        }

//----------------------------------------------------------------------------------------------------------------------------------------------        
        /// <summary>
        /// Метод выводит количество подключенных устройств к локальной сети
        /// </summary>
        /// <param name="kolichestvo_komputerov_v_sety"></param>
        public void Result(int kolichestvo_komputerov_v_sety)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine("\nОбнаружено устройств в Вашей локальной сети: " + kolichestvo_komputerov_v_sety);
        }        
    }
}
