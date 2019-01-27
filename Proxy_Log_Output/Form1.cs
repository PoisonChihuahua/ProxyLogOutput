using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy_Log_Output
{
    [Aspect]
    public partial class Form1 : Form
    {

        [DllImport("kernel32.dll")]
        extern static bool Beep(uint dwFreq, uint dwDuration);

        SampleClass cls = new SampleClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Beep(500,500);
            cls.SampleMethod("1212");
            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cls.SampleMethod2("2121");
            Console.ReadLine();
        }
    }
}
