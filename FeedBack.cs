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
    public partial class FeedBack : MetroForm
    {
        public FeedBack()
        {
            InitializeComponent();
            MetroStyleManager.Default.Style = MetroFramework.MetroColorStyle.Blue;
            MetroStyleManager.Default.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void FeedBack_Load(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            SendMail sendMail = new SendMail(textBoxBody.Text, textBoxName.Text, textBoxSubject.Text);
            sendMail.MySendMail();
        }
    }
}
