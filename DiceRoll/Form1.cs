using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceRoll
{
    public partial class Form1 : Form
    {
        int diceFaces = 0;
        Random dice = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dicelabel.Text = "D4";
            diceFaces = 4;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Dicelabel.Text = "D6";
            diceFaces = 6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dicelabel.Text = "D8";
            diceFaces = 8;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dicelabel.Text = "D12";
            diceFaces = 12;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dicelabel.Text = "D20";
            diceFaces = 20;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (diceFaces == 0)
            {
                MessageBox.Show("Select the number of faces for the dices");
            }
            int dices = (int)numericUpDown1.Value;
            toolStripStatusLabel2.Text = ("0/" + dices);
            toolStripProgressBar1.ProgressBar.Value = 0;
            toolStripProgressBar1.ProgressBar.Maximum = dices;
            RollDices(dices, diceFaces);
        }

        private async Task RollDices(int dices, int faces)
        {
            string text = String.Empty;
            richTextBox1.Text = text;
            int[] StatsResults = new int[faces+1];
            int[] results = new int[dices];
            for(int i = 0; i < dices; i++)
            {
                int roll = dice.Next(1, faces+1);
                StatsResults[roll]++;
                results[i] = roll;
                toolStripStatusLabel2.Text = ((i+1) + "/" + dices);
                toolStripProgressBar1.ProgressBar.PerformStep();
            }
            for(int i = 1; i <= faces; i++)
            {
                text += i.ToString();
                text += ": ";
                text += StatsResults[i].ToString();
                text += "\n";
            }
            for (int i = 0; i < dices; i++)
            {
                if (i % 10 == 0)
                {
                    text += "\n";
                }
                if (results[i] <= 9)
                    text += 0+results[i].ToString();
                else
                    text += results[i].ToString();
                text += "       ";
            }
            richTextBox1.Text = text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dice = new Random(Int32.Parse(textBox1.Text));
        }
    }
}
