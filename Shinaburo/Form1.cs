using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinaburo
{
    public partial class Form1 : Form
    {
        Compiler compiler;
        ConsoleHandler TextBoxConsole;
        public Form1()
        {
            InitializeComponent();
            Form1_SizeChanged(this, new EventArgs());
            TextBoxConsole = new RichTextConsole(ConsoleBox);
            compiler = new Compiler(TextBoxConsole);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CodeBox.Size = new Size((int)(this.Size.Width / 1.75f), this.Size.Height - 60);
            ConsoleBox.Size = new Size(this.Size.Width - CodeBox.Size.Width - 45, this.Size.Height - 60);
            ConsoleBox.Location = new Point(this.Size.Width - ConsoleBox.Size.Width - 25 , 15);
            CompileButton.Location = new Point(this.Size.Width - CompileButton.Size.Width - 45, this.Size.Height - CompileButton.Size.Height - 60);
        }
        private void Compile(object sender, EventArgs e)
        {
            ConsoleBox.Clear();
            compiler.Compile(CodeBox.Text);
        }

        private void CodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) Compile(sender, e);
        }
    }
}
