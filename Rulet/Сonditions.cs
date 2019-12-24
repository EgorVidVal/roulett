using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rulet
{
    class Сonditions
    {        
        public int[] Test()
        {
            int[] x = new int[10];
            string[] y = new string[10];
           
            Table tab = new Table();
           
            for (int i = 0; i < 10; i++)
            {
                tab.Rand();
                x[i] = tab.Roulett;
                y[i] = tab.Color_numb;
                
            }                      
            return x;
        }
       
        //Показывает результаты игры (Какие ставки и на что, какое выпало число, какой цвет, сумма банка, список истории банка, окно вывода)
        public void GameProgress(List<object> instructions, int roulett, string color_numb, System.Windows.Forms.RichTextBox bank,List<int> bank_value, System.Windows.Forms.RichTextBox ounput = null)
        {
            if (ounput != null) ounput.Text = "Число:" + roulett + " цвет: " + color_numb + "\n";

            for (int i = 0; i < instructions.Count; i++)
            {
                //Если есть ключевое слово Rate то есть, ставка на число
                if (instructions[i] == "Rate") 
                {
                    //стравнивает ставку и полученное число в ходе игры
                    if (Convert.ToInt32(instructions[i + 1]) == roulett)
                    {
                        //В случае совпдаения, увеличивает ставку в 36 раз.
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 2]) * 36);
                        
                        //если был добавлен необязательный аргумент то выводит в окно.
                        if(ounput != null) bank.Text = Convert.ToString(x); ounput.Text += "Победа на число";

                                             
                    }
                }
                //Если есть ключевое слово Black
                if (instructions[i] == "Black")
                {
                    //Проверяет какой выпал цвет
                    if (instructions[i] == color_numb)
                    {
                        //если совпадает, то ставка увеличивается на 2 и плюсуется к банку
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 1]) * 2);
                        //если был добавлен необязательный аргумент то выводит в окно.
                        if (ounput != null) bank.Text = Convert.ToString(x); ounput.Text += "Победа, Черный" + "\n";
                     
                    }
                    else
                    {
                        if (ounput != null) ounput.Text += "Поражение" + "\n";
                    }
                }
                //Аналогично
                if (instructions[i] == "Red")

                {
                    if (instructions[i] == color_numb)
                    {
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 1]) * 2);
                        if (ounput != null) bank.Text = Convert.ToString(x); ounput.Text += "Победа, Красный" + "\n";
                        
                    }
                    else
                    {
                        if (ounput != null) ounput.Text += "Поражение" + "\n";
                    }

                }                             
            }         
            //добавляет настоящее состояние банка в список истории средств.
            bank_value.Add(Convert.ToInt32(bank.Text));
           
            
        }


    }
}
