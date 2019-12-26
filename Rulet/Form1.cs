using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rulet
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //История банка в ходе игры
        List<int> bank_value = new List<int>() { };
               
        //Хранение информации о ставке       
        List<object> instructions = new List<object>() { };


        //Запуск процесса
        private void Test_Click(object sender, EventArgs e)
        {
           Table tab = new Table();
           tab.Rand();
           int roulett = tab.Roulett;
           string color_numb = Convert.ToString(tab.Color_numb);
          

           Сonditions con = new Сonditions();           
           //con.GameProgress(instructions ,roulett, color_numb, richTextBox7, bank_value, richTextBox2);


           con.TestGameProgress(instructions, roulett, color_numb, Convert.ToInt32(richTextBox7.Text));
            
            richTextBox2.Text += "Число :" + roulett + " цвет: " + color_numb + "\n";
            
            if (con.rate_black_red[1] != 37)
            {
                richTextBox2.Text += "Выигрыш: " + con.rate_bank[1] + " числа: " + con.rate_black_red[1] + " \n";
            }         
            if (con.rate_black_red[2] == 1)
            {
                richTextBox2.Text += "Победа черный " + con.rate_bank[2] + " \n";
            }            
            if (con.rate_black_red[3] == 1)
            {
                richTextBox2.Text += "Победа красный " + con.rate_bank[3] + " \n";
            }
            if (con.rate_black_red[4] == 1)
            {
                richTextBox2.Text += "Победа линии " + con.rate_bank[4] + " \n";
            }
            if (con.rate_black_red[5] == 1)
            {
                richTextBox2.Text += "Победа трети " + con.rate_bank[5] + " \n";
            }
            if (con.rate_black_red[6] == 1)
            {
                richTextBox2.Text += "Победа чет,нечет " + con.rate_bank[6] + " \n";
            }
            if (con.rate_black_red[7] == 1)
            {
                richTextBox2.Text += "Победа ставки на половину поля " + con.rate_bank[7] + " \n";
            }

            int z = con.rate_bank[3] + con.rate_bank[2] + con.rate_bank[1] + con.rate_bank[4] + con.rate_bank[5] + con.rate_bank[6] + con.rate_bank[7];

            richTextBox2.Text += "Общая сумма выиграша: " + z + " \n";
            richTextBox7.Text = Convert.ToString(con.rate_black_red[0]);
            instructions = new List<object>() { };
            
        }
        
        List<object> AutoGame = new List<object>() { };
        int counterColor = 0;

        //Попытка автоматизации
        private void TestTest()
        {
            
            List<int> game_numbers = new List<int>() { };

            List<string> game_color = new List<string>() { };

            Table tab = new Table();

            
            int startColor = 0;

            int counteInterval = Convert.ToInt32(richTextBox5.Text); 

            int interval;
            List<string> color = new List<string>() { };
            List<int> numbers = new List<int>() { };

            for (int i = 0; i < AutoGame.Count;i++)
            {
                if(AutoGame[i] == "color")
                {
                    Console.WriteLine(AutoGame[i +1]);
                    startColor = 1;
                    color.Add(Convert.ToString(AutoGame[i + 1]));
                }
                if(AutoGame[i] == "numberofgames")
                {
                    numbers.Add(Convert.ToInt32(AutoGame[i + 1]));
                }

            }
            
            for (int i = 0;i < GameNumber_of_Games();i++)
            {
                tab.Rand();
                int roulett = tab.Roulett;
                string color_numb = tab.Color_numb;

                

                if (startColor > 0)
                {
                    Console.WriteLine(counterColor);
                   
                  

                    // WMS_EEX
                    if (counterColor >= 5)
                    {
                        Console.WriteLine("******");
                        Сonditions con = new Сonditions();
                        con.TestGameProgress(instructions, roulett, color_numb, Convert.ToInt32(richTextBox7.Text));
                        richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - 50);
                        int zxcz = con.rate_bank[3] + con.rate_bank[2] + con.rate_bank[1];
                        Console.WriteLine(richTextBox7.Text);
                        string qwerty = Convert.ToString(Convert.ToInt32(richTextBox7.Text) + zxcz);
                        Console.WriteLine(richTextBox7.Text);
                        richTextBox2.Text += "Общая сумма выиграша: " + zxcz + " \n";
                        richTextBox7.Text = qwerty;
                    }

                   
                    if (color_numb == color[0])
                    {
                        counterColor++;
                    }
                    else
                    {
                        counterColor = 0;
                    }
                }

            }
            
        }

        private int GameNumber_of_Games()
        {
            return Convert.ToInt32(richTextBox6.Text);
        }
        // добавляет в инструкцию ставку 1-12,13-24,25-36
        private void But2k_12(int numb)
        {
            instructions.Add("2k1_12");

            instructions.Add(numb);

            richTextBox2.Text += instructions[instructions.Count - 1] + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
        // добавляет в инструкцию четное нечетное
        private void Even_odd(int numb)
        {
            instructions.Add("EvenOdd");

            instructions.Add(numb);

            if (numb == 2)
            {
                richTextBox2.Text += "Четная" + "\n";
            }
            else
            {
                richTextBox2.Text += "Нечетная" + "\n";
            }

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));

        }
        // добавляет в инструкцию от 1- 18, 19 - 36;
        private void Halves(int numb)
        {
            instructions.Add("Halves");

            instructions.Add(numb);

            if (numb == 2)
            {
                richTextBox2.Text += "От одного до 18" + "\n";
            }
            else
            {
                richTextBox2.Text += "От 19 одного до 36" + "\n";
            }

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
        // добавляет в инструкцию 2к1 1 4 7 10
        public void Buttom2_1(int numb)
        {
            instructions.Add("2k1");

            instructions.Add(numb);

            richTextBox2.Text += instructions[instructions.Count - 1] + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
        // добавляет в инструкцию ставку на число
        private void rate_number(int numb)
        {
            instructions.Add("Rate");

            instructions.Add(numb);

            richTextBox2.Text += instructions[instructions.Count - 1] + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }

        System.Windows.Forms.RichTextBox TextBox = new System.Windows.Forms.RichTextBox();
        System.Windows.Forms.NumericUpDown Number = new System.Windows.Forms.NumericUpDown();

        //красный или черный ставка 
        //instruktion- текст инструкции для опознавания
        //numb - номер действия или просто номер на который ставится
        //output - иногда нужно вывести из инструкции другой элемент
        //evenodd - для вывода текста четное или нет в нутри есть условия if 
        //oneand - для вывода текста о ставке от 1 - 18   19 - 36  
        //bank_output - визуальная сумма банка
        //ounput_text -  вывод текста состояния тсавок и игры
        //rate_box - считывания ставки из формы
        //rate - ставка для автовычисления без вывода на экран
        //bank - банк внутри программы без вывода.
        private void Filling_out_instructions(string instruktion, int numb, int output = 1, bool evenodd = false, bool oneand = false,
                                 System.Windows.Forms.RichTextBox bank_output = null,
                                 System.Windows.Forms.RichTextBox ounput_text = null, 
                                 System.Windows.Forms.NumericUpDown rate_box = null,
                                 int rate = 0, int bank = 0)
        {
            //куда ставка
            instructions.Add(instruktion);
            instructions.Add(numb);

            if (ounput_text != null && evenodd == false && oneand == false) ounput_text.Text += instructions[instructions.Count - output] + "\n";
            

            //на что ставка
            if (rate_box != null) instructions.Add(rate_box.Value);
            else instructions.Add(bank);

            if (ounput_text != null ) ounput_text.Text += rate_box.Value + "\n";

            //Вывод текста о ставке на четное,нечетное
            if (numb == 2 && evenodd == true)
            {

                if (ounput_text != null) ounput_text.Text += "Четная" + "\n";
            }
            if (numb == 3 && evenodd == true)
            {

                if (ounput_text != null) ounput_text.Text += "Нечетная" + "\n";
            }

            //Вывод текста о ставке на четное,1 -18 19 - 36
            if (numb == 2 && oneand == true)
            {
                ounput_text.Text += "От одного до 18" + "\n";
            }
            if (numb == 3 && oneand == true)
            {
                ounput_text.Text += "От 19 одного до 36" + "\n";
            }

            if (bank_output != null ) bank_output.Text = Convert.ToString(Convert.ToInt32(bank_output.Text) - Convert.ToInt32(rate_box.Value));
            else bank = bank - rate;


           
        }

        private int Game_Instructions(string color_numb, string color, int interval)
        {
            if (counterColor == interval)
            {
                return 1;
            }

            if (color_numb == color)
            {
                counterColor++;
            }
            else
            {
                counterColor = 0;
            }

            return 0;
        }
        //black, ставка
        private void Button7_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Black",0, output : 2, bank_output : richTextBox7, ounput_text : richTextBox2,rate_box: numericUpDown1);
        }
        //red, ставка
        private void Button6_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Red", 0, output: 2, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }
        //Делает числовую ставку ( rate, число,ставка)
        private void Button8_Click(object sender, EventArgs e)
        {
            instructions.Add("Rate");

            instructions.Add(Convert.ToInt32(richTextBox8.Text));

            richTextBox2.Text += richTextBox8.Text + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        #region Куча
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int quantity_game;
        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                GameNumber_of_Games();
                AutoGame.Add("numberofgames");
                AutoGame.Add(GameNumber_of_Games());
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }



        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == false)
            {
                AutoGame.Add("color");
                AutoGame.Add("Black");
            }
            if (checkBox2.Checked == true && checkBox1.Checked == false)
            {
                AutoGame.Add("color");
                AutoGame.Add("Red");
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                MessageBox.Show("Выберете один цвет");
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false)
            {
                MessageBox.Show("Выберете  цвет");
            }
        }

        //red
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //black
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                AutoGame.Add("same");
                AutoGame.Add(Convert.ToInt32(richTextBox6.Text));
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void RichTextBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void RichTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void RichTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.FlatStyle = FlatStyle.Popup;
            //docs.microsoft.com/ru-ru/dotnet/api/system.windows.forms.button?view=netcore-3.0
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            AutoGame.Add("if");
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            TestTest();
        }


        #endregion

        #region number
        private void Button01_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 1, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button02_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 2, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button03_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 3, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button04_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 4, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button05_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 5, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button06_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 6, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button07_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 7, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button08_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 8, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Button09_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 9, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butto10_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 10, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butto11_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 11, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt12_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 12, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt13_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 13, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt14_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 14, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt15_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 15, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt16_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 16, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt17_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 17, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt18_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 18, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt19_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 19, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt20_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 20, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt21_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 21, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt22_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 22, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt23_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 23, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt24_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 24, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt25_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 25, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt26_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 26, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt27_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 27, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt28_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 28, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt29_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 29, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt30_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 30, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt31_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 31, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt32_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 32, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt33_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 33, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt34_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 34, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt35_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 35, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Butt36_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 36, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }
        private void Zerro_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Rate", 0, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        #endregion

        #region rate_Button
        private void But2k1_3_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1", 3, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }
        private void But2k1_2_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1", 2, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }
        private void But2k1_1_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1", 1, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }
        private void One12_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1_12", 1, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1); 
        }

        private void Two12_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1_12", 2, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Three12_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("2k1_12", 3, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Chet_Click(object sender, EventArgs e)
        {
            
            Filling_out_instructions("EvenOdd", 2, evenodd :true, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
        }

        private void Nech_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("EvenOdd", 3, evenodd: true, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
            
        }

        private void But1v18_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Halves", 2, oneand: true, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
   
        }
        private void But19v36_Click(object sender, EventArgs e)
        {
            Filling_out_instructions("Halves", 3, oneand: true, bank_output: richTextBox7, ounput_text: richTextBox2, rate_box: numericUpDown1);
          
        }
        #endregion
    }
}
