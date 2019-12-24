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

        
        public void GameProgress(object[] instructions, int roulett, string color_numb, System.Windows.Forms.RichTextBox bank,List<int> bank_value, System.Windows.Forms.RichTextBox ounput = null)
        {
                  
            for (int i = 0; i < 10; i++)
            {
                if (instructions[i] == "Rate")
                {
                    if (Convert.ToInt32(instructions[i + 1]) == roulett)
                    {
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 2]) * 36);

                        if(ounput != null) bank.Text = Convert.ToString(x); ounput.Text = "Победа на число";

                        bank_value.Add(x);                        
                    }
                }
                if (instructions[i] == "Black")
                {
                    if (instructions[i] == color_numb)
                    {
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 1]) * 2);
                        if (ounput != null) bank.Text = Convert.ToString(x); ounput.Text += "Победа, Черный" + "\n";

                        if (ounput != null) bank_value.Add(x);
                    }
                    else
                    {
                        ounput.Text = "Победа, Красный" + "\n";ounput.Text += "Поражение" + "\n";
                        bank_value.Add(Convert.ToInt32(bank.Text));
                    }
                }
                if (instructions[i] == "Red")

                {
                    if (instructions[i] == color_numb)
                    {
                        int x = Convert.ToInt32(bank.Text) + (Convert.ToInt32(instructions[i + 1]) * 2);
                        if (ounput != null) bank.Text = Convert.ToString(x); ounput.Text = "Победа, Красный" + "\n";
                        bank_value.Add(x);
                        
                    }
                    else
                    {
                        bank_value.Add(Convert.ToInt32(bank.Text));
                        if (ounput != null) ounput.Text += "Поражение" + "\n";
                    }

                }
            }

            Console.WriteLine(bank_value.Count);
        }


    }
}
