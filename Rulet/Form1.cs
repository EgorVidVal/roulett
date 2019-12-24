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

        //изменение банка в ходе игры
        List<int> bank_value = new List<int>() { };
        //Хранение информации о ставке
        //public object[] instructions = new object[20];
        //н
        public int counter = 0;
        List<object> instructions = new List<object>() { };


        private void Test_Click(object sender, EventArgs e)
        {
           Table tab = new Table();
           tab.Rand();
           int roulett = tab.Roulett;
           string color_numb = Convert.ToString(tab.Color_numb);
           richTextBox2.Text += "\n" + "Число:" + roulett + " цвет: " + color_numb + "\n";

           Сonditions con = new Сonditions();

            
            con.GameProgress(instructions, roulett, color_numb, richTextBox7, bank_value, richTextBox2);

            
            con.Test();
            instructions = new object[20];
            counter = 0;
        }

       
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

        private void Button7_Click(object sender, EventArgs e)
        {
            instructions[counter] = "Black";
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;

            instructions[counter] = numericUpDown1.Value;
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;

            richTextBox7.Text =Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }

        //red
        private void Button6_Click(object sender, EventArgs e)
        {
            instructions[counter] = "Red";
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;

            instructions[counter] = numericUpDown1.Value;
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;

            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));


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

        private void Button8_Click(object sender, EventArgs e)
        {
            instructions[counter] = "Rate";
            counter++;
            instructions[counter] = Convert.ToInt32(richTextBox8.Text);
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;
            instructions[counter] = numericUpDown1.Value;
            richTextBox2.Text += instructions[counter] + "\n";
            counter++;
            richTextBox7.Text = Convert.ToString(Convert.ToInt32(richTextBox7.Text) - Convert.ToInt32(numericUpDown1.Value));
        }
    }
}
