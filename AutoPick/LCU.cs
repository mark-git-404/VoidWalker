using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Luna.Autopick.Models;

namespace Luna.Autopick.LCU
{
    class LCU
    {   
        //Properties
        public string ProcessName => _processName;
        public int Port => _appPort;
        public string Protocol => "https";
        public string Username => "riot";
        public string AuthToken => _authToken;

        //_Fields
        private string _processName;
        private int _appPort;
        private string _authToken;

        //events
        public event EventHandler OnConnected;
        public event EventHandler OnDisconnected;

        protected virtual void OnClientOpened()
        {
        }

        public void Start()
        {

        }
        public void _LockfileListener()
        {
            foreach(var p in Process.GetProcessesByName("LeagueClient"))
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher(
                 "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id.ToString() );
                var moc = mos.Get();
                var commandLine = (string)moc.OfType<ManagementObject>().First()["CommandLine"];

                //RegEX validation;
                //TODO: Validar RegEx e atribuir os filds respectivos
                //ProcessName = ;

            }
            // 
        }

        public void PickChampion(Champion champion)
        {

        }
    }
}
