using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Luna.Autopick.LCU;
using Luna.Autopick.Rift;
using Luna.Autopick.DDragon;
using Luna.Autopick.DDragon.Models;
using Luna.Autopick.Rift.Models;

namespace VoidWalker
{
    public partial class VoidWalker : Form
    {

        private Champion championSelected;
        private DDragon dDragon;
        private Rift rift;
        public VoidWalker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeagueClient lcu = new LeagueClient();

            rift = new Rift(lcu);

            dDragon = new DDragon();
            List<string> champions = dDragon.GetAllChampions();

            foreach(var champion in champions)
            {
                cmbBox_Champion.Items.Add(champion);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Issue 1: Http client only works in thread
            Thread t_thread = new Thread(Pick_t);
            t_thread.IsBackground = true;
            t_thread.Start();

        }

        private void Pick_t()
        {
            Summoner sum = rift.GetSummoner();

            bool success = false;
            while (!success)
            {
                string champion = "Annie";
                this.Invoke((MethodInvoker)delegate ()
                {
                    if(cmbBox_Champion.SelectedItem != null)
                    {
                        champion = cmbBox_Champion.SelectedItem.ToString();
                    }
                });
                
                championSelected = dDragon.champions.Data[champion];
                success = rift.PickChampion(championSelected);
            }
        }
        
    }
}
