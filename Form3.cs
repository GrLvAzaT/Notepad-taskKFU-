using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace TEXTWRITER_2._0
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            MetroStyleManager.Default.Style = MetroFramework.MetroColorStyle.Blue;
            MetroStyleManager.Default.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Product name: TextWriter Mini studio™";
            label2.Text = "Text Writer of new generation. Version: 2.0";
            label3.Text = "by Mini studio™ 2019";
            label4.Text = "Contact of developer:";
            label5.Text = "Our vk.com:";
        }
    }
}
