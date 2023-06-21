using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_1_WinForm_2023_06_21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            var color = new Color();
            color = Color.FromArgb(255,220,0,145);
            
            labelOutput.ForeColor = color;
            
            try
            {
                var number = Convert.ToInt32(textBoxInput.Text);
                var res = Math.Pow(number,2).ToString();
                labelOutput.Text = res;
            }
            catch
            {
                var message = "Не удалось" + " преобразовать в число";
                MessageBox.Show(message);
                labelOutput.Text = message;
            }
           
        }

        private void btnOpen_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();            
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Filter = "Текстовые (шаблон*.txt)|*.txt"+"|Исходник (шаблон*.cs)|*.cs"+
                "|Все (шаблон*.*)|*.*";
            var result = ofd.ShowDialog(this);
            if(result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    Viewer.Text = sr.ReadToEnd();
                }
               
            }
        }

        
    }
}
