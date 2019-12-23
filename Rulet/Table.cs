using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulet
{
    class Table 
    {
        public int Roulett { get; set; }
        public string Color_numb { get; set; }

        public void Rand()
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10)
            Roulett = rnd.Next(0, 36);

            Color_numb = Color(Roulett);           
        }
      
        private string Color(int number_roulette)
        {
            switch (number_roulette)
            {
                case 0: return ("Zerro");
                case 1: return ("Red");
                case 3: return ("Red");
                case 5: return ("Red");
                case 7: return ("Red");
                case 9: return ("Red");
                case 12: return ("Red");
                case 14: return ("Red");
                case 16: return ("Red");
                case 18: return ("Red");
                case 19: return ("Red");
                case 21: return ("Red");
                case 23: return ("Red");
                case 27: return ("Red");
                case 25: return ("Red");
                case 30: return ("Red");
                case 32: return ("Red");
                case 34: return ("Red");
                case 36: return ("Red");
                default:
                    return "Black";

            }
        }


    }
}
