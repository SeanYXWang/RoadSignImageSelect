using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SelectImage
{
    public partial class Form1 : Form
    {

        string[] fileName = new String[1000];
        bool file_read_in = false;
        String path = @".\data\SelectedRoad2.txt";


        public Form1()
        {
            InitializeComponent();

            if(File.Exists(@".\data\road2.txt")) // If a vote.csv file already exists then use it
            {
                read_in();
                Display();
            }
            if (File.Exists(@".\data\SelectedRoad2.txt"))
            {
                File.Delete(@".\data\SelectedRoad2.txt");
            }
        }

        // Set a variable to the My Documents path.

        private void button1_Click(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine(fileName[v]+" 1");
            }
            //pictureBox1.Image.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void read_in()
        {
            using (StreamReader r = new StreamReader(@".\data\road2.txt"))
            {
                int i = 0;
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    char[] whitespace = new char[] { ',' };   // Split line on ","
                    string[] name = line.Split(whitespace);
                    fileName[i] = name[0];
                    i++;
                }
            }
            file_read_in = true;
        }

        private void Display()
        {
            int v = (int)numericUpDown1.Value;
            pictureBox1.Image = Image.FromFile(@".\road2\" + fileName[v]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
           

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Image.Dispose();
            if (file_read_in)
            {
                Display();
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine(fileName[v] + " 0");
            }
            //pictureBox1.Image.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int v = (int)numericUpDown1.Value;
            using (StreamWriter sr = File.AppendText(path))
            {
                sr.WriteLine(fileName[v] + " 2");
            }
        }
    }
}
