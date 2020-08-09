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
using System.IO;
using System.Threading;

namespace VoidWalker
{
    public partial class Form1 : Form
    {

        private Champion championSelected;
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
                    Champion ChampionSelected = autopick.champions.Data["Yone"];
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            //lcu.OnConnected += FoiConectado;
            //lcu.OnDisconnected += FoiDesconectado;
            //lcu.GetStatus();
            //rift.GetSummonerName();
            Thread t_thread = new Thread(T_Pick);
            t_thread.IsBackground = true;
            t_thread.Start();

        }
        private void FoiConectado() => Console.WriteLine("Foi Conectado!");
        private void FoiDesconectado() => Console.WriteLine("Foi Desconectado!");
        private void T_Pick()
        {
            LeagueClient lcu = new LeagueClient();
            lcu.SetProperties();

            Rift rift = new Rift(lcu);

            bool success = false;
            while ( success == false)
            {
                success = rift.PickChampion(777);
                
            }
        }
    }
}
