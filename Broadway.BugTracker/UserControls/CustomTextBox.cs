using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.BugTracker.UserControls
{
    public partial class CustomTextBox : UserControl
    {
        public CustomTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox1_TextChanged;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var textbox = (TextBox)sender;
            if (textBox1.Text=="")
            {
                //use some logic here
                //change the color of text
                //use default text here like username
            }
        }

        private void CustomTextBox_Load(object sender, EventArgs e)
        {

        }



        private string _textBoxText;
        public string TextBoxText
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
    }
}
