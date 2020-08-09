using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Luna.Autopick.LCU;
using Luna.Autopick.Rift;
using Luna.Autopick.DDragon;
using Luna.AutoPick.Rift.Models;
using Luna.Autopick.DDragon.Models;

namespace VoidWalker
{
    public partial class VoidWalker : Form
    {

        private Champion championSelected;
        public VoidWalker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DDragon autopick = new DDragon();

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
            
            Thread t_thread = new Thread(T_Pick);
            t_thread.IsBackground = true;
            t_thread.Start();

        }

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
