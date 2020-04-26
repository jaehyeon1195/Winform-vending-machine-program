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
    public partial class Form1 : Form
    {
        Machine machine = new Machine();
        public Form2 f2=null;
        public Form1()
        {
            InitializeComponent();
            machine.Getlist(listView1);
            SetText();
        }

        public void SetMoney(int val)
        {
            machine.InputMoney(val);
            SetText();
        }

        public void GetItem(string name)
        {
            machine.SelectDrink(name);
            SetText();
        }

        private string[] SetCombo()
        {
            return machine.PrintAll();
        }

        private void SetText()
        {
            textBox1.Text = string.Format("{0}",machine.SelCount);
            textBox2.Text = string.Format("{0}", machine.SelMoney);
            textBox3.Text = string.Format("{0}", machine.Money);
        }

        //잔돈반환
        private void button3_Click(object sender, EventArgs e)
        {
            machine.GetMoney();
            SetText();
        }

        private void 금액투입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(f2==null)
            {
                f2 = new Form2();
            }
            f2.Owner = this;
            f2.Show();
        }

        private void 제품선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Owner = this;
            f3.comboBox1.Items.AddRange(SetCombo());
            f3.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = this.listView1.SelectedItems;
            foreach (ListViewItem item in items)
            {
                string name = item.SubItems[0].Text;
                Drink d=machine.Drinkinfo(name);
                textBox4.Text = string.Format("제품명 : {0}\r\n", d.Name);
                textBox4.Text += string.Format("가격 : {0}\r\n", d.Price);
                textBox4.Text += string.Format("재고량 : {0}\r\n", d.Count);
                textBox4.Text += string.Format("판매수량 : {0}\r\n", d.Selcount);
                textBox4.Text += string.Format("판매총액 : {0}\r\n", d.GetSal());
            }
        }
    }
}
