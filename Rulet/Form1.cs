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
            int z = con.rate_bank[3] + con.rate_bank[2] + con.rate_bank[1] + con.rate_bank[4];

            richTextBox2.Text += "Общая сумма выиграша: " + z + " \n";
            richTextBox7.Text = Convert.ToString(con.rate_black_red[0]);
            instructions = new List<object>() { };
            
        }
        public void TestAuto() 
        {
            List<int> rull = new List<int>() { };
            List<string> color = new List<string>() { };
            Table tab = new Table();
            int z = 0;
            for (int i = 0;i<1000; i++)
            {
                                
                tab.Rand();
                int roulett = tab.Roulett;
                string color_numb = tab.Color_numb;
                
                rull.Add(roulett);
                color.Add(color_numb);

                if (z == 5)
                {
                    List<object> instructionss = new List<object> { "Red", 50 };

                    
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
                    z = 0;
                }

                if (color_numb == "Black")
                {
                    z++;                   
                }
                else
                {
                    z = 0;
                }
                     
            }
        }


        List<object> AutoGame = new List<object>() { };
        int counterColor = 0;
        public void TestTest()
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
        public int Game_Instructions(string color_numb,string color,int interval)
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
        public int GameNumber_of_Games()
        {
            return Convert.ToInt32(richTextBox6.Text);
        }

        //black, ставка
        private void Button7_Click(object sender, EventArgs e)
        {
            instructions.Add("Black");
            richTextBox2.Text += "Black" + "\n";

            instructions.Add(numericUpDown1.Value);
            richTextBox2.Text += numericUpDown1.Value + "\n";


            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
        //red, ставка
        private void Button6_Click(object sender, EventArgs e)
        {
            instructions.Add("Red");
            richTextBox2.Text += "Red" + "\n";

            instructions.Add(numericUpDown1.Value);
            richTextBox2.Text += numericUpDown1.Value + "\n";


            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));


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

        private void rate_number(int rate)
        {
            instructions.Add("Rate");

            instructions.Add(rate);

            richTextBox2.Text += instructions[instructions.Count - 1] + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
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
            if(checkBox1.Checked == true && checkBox2.Checked == false)
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

        #endregion sd Куча Properties

        private void Button2_Click(object sender, EventArgs e)
        {
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.FlatStyle = FlatStyle.Popup;
            //docs.microsoft.com/ru-ru/dotnet/api/system.windows.forms.button?view=netcore-3.0
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TestAuto();
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

        
        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        #region number
        private void Button01_Click(object sender, EventArgs e)
        {
            rate_number(1);
        }

        private void Button02_Click(object sender, EventArgs e)
        {
            rate_number(2);
        }

        private void Button03_Click(object sender, EventArgs e)
        {
            rate_number(3);
        }

        private void Button04_Click(object sender, EventArgs e)
        {
            rate_number(4);
        }

        private void Button05_Click(object sender, EventArgs e)
        {
            rate_number(5);
        }

        private void Button06_Click(object sender, EventArgs e)
        {
            rate_number(6);
        }

        private void Button07_Click(object sender, EventArgs e)
        {
            rate_number(7);
        }

        private void Button08_Click(object sender, EventArgs e)
        {
            rate_number(8);
        }

        private void Button09_Click(object sender, EventArgs e)
        {
            rate_number(9);
        }

        private void Butto10_Click(object sender, EventArgs e)
        {
            rate_number(10);
        }

        private void Butto11_Click(object sender, EventArgs e)
        {
            rate_number(11);
        }

        private void Butt12_Click(object sender, EventArgs e)
        {
            rate_number(12);
        }

        private void Butt13_Click(object sender, EventArgs e)
        {
            rate_number(13);
        }

        private void Butt14_Click(object sender, EventArgs e)
        {
            rate_number(14);
        }

        private void Butt15_Click(object sender, EventArgs e)
        {
            rate_number(15);
        }

        private void Butt16_Click(object sender, EventArgs e)
        {
            rate_number(16);
        }

        private void Butt17_Click(object sender, EventArgs e)
        {
            rate_number(17);
        }

        private void Butt18_Click(object sender, EventArgs e)
        {
            rate_number(18);
        }

        private void Butt19_Click(object sender, EventArgs e)
        {
            rate_number(19);
        }

        private void Butt20_Click(object sender, EventArgs e)
        {
            rate_number(20);
        }

        private void Butt21_Click(object sender, EventArgs e)
        {
            rate_number(21);
        }

        private void Butt22_Click(object sender, EventArgs e)
        {
            rate_number(22);
        }

        private void Butt23_Click(object sender, EventArgs e)
        {
            rate_number(23);
        }

        private void Butt24_Click(object sender, EventArgs e)
        {
            rate_number(24);
        }

        private void Butt25_Click(object sender, EventArgs e)
        {
            rate_number(25);
        }

        private void Butt26_Click(object sender, EventArgs e)
        {
            rate_number(26);
        }

        private void Butt27_Click(object sender, EventArgs e)
        {
            rate_number(27);
        }

        private void Butt28_Click(object sender, EventArgs e)
        {
            rate_number(28);
        }

        private void Butt29_Click(object sender, EventArgs e)
        {
            rate_number(29);
        }

        private void Butt30_Click(object sender, EventArgs e)
        {
            rate_number(30);
        }

        private void Butt31_Click(object sender, EventArgs e)
        {
            rate_number(31);
        }

        private void Butt32_Click(object sender, EventArgs e)
        {
            rate_number(32);
        }

        private void Butt33_Click(object sender, EventArgs e)
        {
            rate_number(33);
        }

        private void Butt34_Click(object sender, EventArgs e)
        {
            rate_number(34);
        }

        private void Butt35_Click(object sender, EventArgs e)
        {
            rate_number(35);
        }

        private void Butt36_Click(object sender, EventArgs e)
        {
            rate_number(36);
        }
        private void Zerro_Click(object sender, EventArgs e)
        {
            rate_number(0);
        }

        #endregion

        public void Buttom2_1(int numb)
        {
            instructions.Add("2k1");

            instructions.Add(numb);

            richTextBox2.Text += instructions[instructions.Count - 1] + "\n";

            instructions.Add(numericUpDown1.Value);

            richTextBox2.Text += numericUpDown1.Value + "\n";

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
        private void But2k1_3_Click(object sender, EventArgs e)
        {
            Buttom2_1(3);
        }

        private void But2k1_2_Click(object sender, EventArgs e)
        {
            Buttom2_1(2);
        }

        private void But2k1_1_Click(object sender, EventArgs e)
        {
            Buttom2_1(1);

        }
    }
}
