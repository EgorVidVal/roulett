using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulet
{
    class Сonditions
    {

        //Какие ставки выигради 1 - какое число выиграло(если было поставлено несколько чисел) 2- выиграл ли черный цвет,
        //3 - красный цвет,4- ставка 2 к 1, 5 - первое и тд 12, 6 -чет нечет
        public int[] rate_black_red = { 0, 37, 0, 0, 0, 0, 0, 0 };
        //Расположение аналагична картам, чтобы узнать какая тсавка выиграла.
        public int[] rate_bank = { 0, 0, 0, 0, 0, 0, 0, 0 };


        //Показывает результаты игры (Какие ставки и на что, какое выпало число, какой цвет, сумма банка, список истории банка, окно вывода)
        public void TestGameProgress(List<object> instructions, int roulett, string color_numb,int bank)
        {
            
            for (int i = 0; i < instructions.Count; i++)
            {
                //Если есть ключевое слово Rate то есть, ставка на число 
                if (instructions[i] == "Rate")
                {
                    //стравнивает ставку и полученное число в ходе игры
                    if (Convert.ToInt32(instructions[i + 1]) == roulett)
                    {
                        rate_black_red[1] = roulett;
                        rate_bank[1] = (Convert.ToInt32(instructions[i + 2]) * 35);
                        //В случае совпдаения, увеличивает ставку в 36 раз.
                        bank += (Convert.ToInt32(instructions[i + 2]) * 35);
                    }
                }
                //Если есть ключевое слово Black
                if (instructions[i] == "Black")
                {
                   
                    //Проверяет какой выпал цвет
                    if (instructions[i] == color_numb)
                    {
                        //если совпадает, то ставка увеличивается на 2 и плюсуется к банку
                        bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                        rate_black_red[2] = 1;
                        rate_bank[2] = (Convert.ToInt32(instructions[i + 2]) * 2);
                        //если был добавлен необязательный аргумент то выводит в окно. 

                    }                   
                }
                //Аналогично
                if (instructions[i] == "Red")

                {
                    if (instructions[i] == color_numb)
                    {
                        bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                        rate_black_red[3] = 1;
                        rate_bank[3] = (Convert.ToInt32(instructions[i + 2]) * 2);

                    }
                }
                //2к1
                if (instructions[i] == "2k1")
                {
                    //Поле сканируется путем прибавления тройки к началбному числу.
                    for(int x = 0;x <= 36; x +=3)
                    {
                        if ((Convert.ToInt32(instructions[i + 1]) + x) == roulett)
                        {
                            rate_black_red[4] = 1;
                            rate_bank[4] += (Convert.ToInt32(instructions[i + 2]) * 3);
                            bank += (Convert.ToInt32(instructions[i + 2]) * 3);
                           
                        }
                    }                    
                }
                //первая,вторая,третья 12
                if (instructions[i] == "2k1_12")
                {
                    int x = Convert.ToInt32(instructions[i + 1]);

                    //Переменная для определения области перебора
                    int k_12 = 0;
                    
                    //Определяет какое поле перебирать,
                    if (x == 1) {k_12 = 1;}
                    if (x == 2) { k_12 = 13;}
                    if (x == 3) { k_12 = 25;}
                    
                    //после определения минимального числа в цикле определяет максимальную границу поиска
                    for (int z = k_12; z < k_12 + 12; z++)
                    {
                        //если в зоне перепора есть выпавшее число.
                        if (z == roulett)
                        {
                            
                            rate_black_red[5] = 1;
                            rate_bank[5] += (Convert.ToInt32(instructions[i + 2]) * 3);
                            bank += (Convert.ToInt32(instructions[i + 2]) * 3);
                        }
                            
                    }                                          
                }
                //четный нечетный
                if (instructions[i] == "EvenOdd")
                {
                    int x = Convert.ToInt32(instructions[i + 1]);

                    if ((roulett % 2) == 0 && (x % 2) == 0 )
                    {
                        rate_black_red[6] = 1;
                        rate_bank[6] += (Convert.ToInt32(instructions[i + 2]) * 2);
                        bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                    }
                    if ((roulett % 2) != 0 && (x % 2) != 0)
                    {
                        rate_black_red[6] = 1;
                        rate_bank[6] += (Convert.ToInt32(instructions[i + 2]) * 2);
                        bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                    }
                }
                //от одного до 18
                if (instructions[i] == "Halves")
                {
                    int x = Convert.ToInt32(instructions[i + 1]);
                    if (x == 2)
                    {
                        if(roulett <=18)
                        {
                            rate_black_red[7] = 1;
                            rate_bank[7] += (Convert.ToInt32(instructions[i + 2]) * 2);
                            bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                        }
                    }
                    else
                    {
                        if (roulett >= 19)
                        {
                            rate_black_red[7] = 1;
                            rate_bank[7] += (Convert.ToInt32(instructions[i + 2]) * 2);
                            bank += (Convert.ToInt32(instructions[i + 2]) * 2);
                        }
                    }
                }
            }
            rate_black_red[0] = bank;
            //добавляет настоящее состояние банка в список истории средств.

        }

    }
}
