using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1004_시험
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int money = int.Parse(textBox1.Text);
            Form1 fa = (Form1)this.Owner;
            fa.SetMoney(money);
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 fa = (Form1)this.Owner;
            fa.f2 = null;
        }
    }
}
