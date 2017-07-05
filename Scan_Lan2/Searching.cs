using System;
using System.Linq;

namespace Scan_Lan2
{
    /// <summary>
    /// Преобразования IP-адресов
    /// </summary>
    public class Searching
    {
        public void SearchingOfIP()
        {
            Describe describe = new Describe();

            string ip_addres = describe.ip_addres;
            char[] all_addresses;
            byte count_of_points = 0;            
            int razmer_poslednego_okteta = 0;

            // Приведение IP-адреса из типа string в массив char
            all_addresses = ip_addres.ToArray();          

            // Вычисление размера последнего октета IP-адреса
            for (int a = 0; a < all_addresses.Length; a++)
            {
                if (all_addresses[a] == '.') count_of_points++;                
                if (count_of_points == 3) razmer_poslednego_okteta++;                
            }

            // Выведение последнего октета в массив char
            char[] massiv_poslednego_okteta = new char[razmer_poslednego_okteta - 1];

            for (int i = 0; i < massiv_poslednego_okteta.Length; i++)            
                massiv_poslednego_okteta[i] = all_addresses[all_addresses.Length - 1 - i];
            
            Array.Reverse(massiv_poslednego_okteta);
            
            // Переводим первую часть ip адреса, в стринговую переменную, без последнего октета
            char[] pervaya_chast_ip_adresa = new char[all_addresses.Length - massiv_poslednego_okteta.Length];

            for (int i = 0; i < pervaya_chast_ip_adresa.Length; i++)            
                pervaya_chast_ip_adresa[i] = all_addresses[i];            

            // Стринговая первая часть исследуемого IP-адреса
            string stringovaya_pervaya_chast_IP_adresa = new string(pervaya_chast_ip_adresa);

            // Прорисовка таблицы перебора IP-адресов
            Console.WriteLine();
            Console.WriteLine("                  Проверка IP-адресов в Вашей локальной сети\n\n");
            Console.WriteLine("   IP-адрес                        Время ответа                Статус");
            Console.WriteLine("--------------------------------------------------------------------------------");
            
            IPSearching ipsearching = new IPSearching();
            ipsearching.SearchIP(stringovaya_pervaya_chast_IP_adresa);                                   
        }
    }
}
