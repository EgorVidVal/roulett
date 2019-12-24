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
            int z = con.rate_bank[3] + con.rate_bank[2] + con.rate_bank[1];

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

                

                if (color_numb == "Black")
                {
                    z++;                   
                }
                else
                {
                    z = 0;
                }
              
              
                if(z == 5)
                {
                    List<object> instructionss =  new List<object>{ "Red",50 };
                    Console.WriteLine("******");
                    Сonditions con = new Сonditions();
                    con.TestGameProgress(instructionss, roulett, color_numb, Convert.ToInt32(richTextBox7.Text));

                    int zxcz = con.rate_bank[3] + con.rate_bank[2] + con.rate_bank[1];


                    richTextBox2.Text += "Общая сумма выиграша: " + z + " \n";
                    richTextBox7.Text = richTextBox7.Text +  Convert.ToString(zxcz);
                    z = 0;
                }

                
                
                
                
            }
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
                quantity_game = Convert.ToInt32(richTextBox6.Text);
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

            }
            if (checkBox2.Checked == true && checkBox1.Checked == false)
            {

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
        int repetitions_values;
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                repetitions_values = Convert.ToInt32(richTextBox6.Text);
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
    }
}
