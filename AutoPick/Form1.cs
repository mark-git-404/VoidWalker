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
using Luna.Autopick.Rift;
using Luna.Autopick.Models;

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
                if(champion == "Yone")
                {
                    Champion yone = autopick.champions.Data["Yone"];
                    Console.WriteLine(yone.Key);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            LeagueClient lcu = new LeagueClient();
            lcu.SetProperties();
            //lcu.OnConnected += FoiConectado;
            //lcu.OnDisconnected += FoiDesconectado;
            //lcu.GetStatus();
            Rift rift = new Rift(lcu);
            rift.GetSummonerName();

        }
        private void FoiConectado() => Console.WriteLine("Foi Conectado!");
        private void FoiDesconectado() => Console.WriteLine("Foi Desconectado!");
    }
}
