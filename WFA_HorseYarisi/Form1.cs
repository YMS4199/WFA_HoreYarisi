using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_HorseYarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        Random rnd = new Random();

        // Verdiğiniz 2 değer arasında rastgele sayı üretir.
        // Benzersiz sayı üretme özelliği yoktur. aynı sayıyı peş peşe üretebilir.
        // Maximum verdiğiniz değerin, herzaman için bir alt değerini üretir. max olarak verilen değer kesinlikle üretilmez.
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pcb1.Top    => get; set;
            //pcb1.Right  => get;
            //pcb1.Bottom => get;
            //pcb1.Left   => get; set;
            pcb1.Left += rnd.Next(1, 16); // max => 15
            pcb2.Left += rnd.Next(1, 16); // max => 15
            pcb3.Left += rnd.Next(1, 16); // max => 15


            if (pcb1.Right > pcb2.Right && pcb1.Right > pcb3.Right)
            {
                lblBilgilendirme.Text = "Yarışı 1. kulvardaki Şahbatur önde götürüyor.";
            }
            else if (pcb2.Right > pcb1.Right && pcb2.Right > pcb3.Right)
            {
                lblBilgilendirme.Text = "Yarışı 2. kulvardaki Gülbatur önde götürüyor.";
            }
            else if (pcb3.Right > pcb2.Right && pcb3.Right > pcb1.Right)
            {
                lblBilgilendirme.Text = "Yarışı 3. kulvardaki Canbatur önde götürüyor.";
            }




            if (pcb1.Right > label3.Left)
            {
                timer1.Stop();
                MessageBox.Show("Yarışı 1. Kulvardaki Şahbatur Kazandı");
            }
            else if (pcb2.Right > label3.Left)
            {
                timer1.Stop();
                MessageBox.Show("Yarışı 2. Kulvardaki Gülbatur Kazandı");
            }
            else if (pcb3.Right > label3.Left)
            {
                timer1.Stop();
                MessageBox.Show("Yarışı 3. Kulvardaki Canbatur Kazandı");
            }
        }

        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 10;
            trackBar1.Maximum = 400;
            timer1.Interval = trackBar1.Minimum;
        }
        #endregion

        #region TrackBar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }
        #endregion

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pcb1.Left += 10;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pcb2.Left += 10;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pcb3.Left += 10;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pcb1.Left = pcb2.Left = pcb3.Left = 0;
            lblBilgilendirme.Text = "";
            trackBar1.Value = trackBar1.Minimum;
        }
    }
}
