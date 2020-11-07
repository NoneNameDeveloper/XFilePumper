using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace AddBytes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pump = new Thread(Pump);
            pump.Start();
        }


        public void Pump()
        {
            try
            {
                var file = File.OpenWrite(textBox1.Text);
                var siz = file.Seek(0, SeekOrigin.End);
                var size = Convert.ToInt64(textBox2.Text);
                decimal bite = size * 1000000; 
                while (siz < bite)
                {
                    siz++;
                    file.WriteByte(0);
                }
                file.Close();
                MessageBox.Show("File Pumped!");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.DefaultExt = "exe";
            openFileDialog1.Filter = "exe files (*.exe)|*.exe";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = @".";
            openFileDialog1.Title = "Выберите файл для пампинга..."; 
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = string.Empty;
                textBox1.Text = openFileDialog1.FileName;
            }
            
        }
        
    }
    
}
