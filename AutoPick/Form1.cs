using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luna.Autopick;
using Luna.Autopick.LCU;

namespace AutoPick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DDragonData autopick = new DDragonData();

            List<string> champions = autopick.GetAllChampions();

            foreach(var champion in champions)
            {
                comboBox1.Items.Add(champion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LCU lcu = new LCU();
            //lcu.OnConnected += ConsoleConnected;
            //lcu.OnConnected += ConsoleConnected2;
            lcu.GetStatus();
        }
        private void ConsoleConnected() => Console.WriteLine("CONECTO!");
        private void ConsoleConnected2() => Console.WriteLine("CONECTO 2!");
    }
}
