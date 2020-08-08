using Luna.Autopick.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;

namespace Luna.Autopick.LCU
{
    class LCU
    {
        //Properties
        public string ProcessName { get => _processName; }
        public int Port { get => _appPort; }
        public string Protocol { get => "https"; }
        public string Username { get => "riot"; }
        public string AuthToken { get => _authToken; }
        public string Path { get => _path; }

        //_Fields
        private string _processName;
        private int _appPort;
        private string _authToken;
        private string _path;

        //events
        public event Action OnConnected;

        protected virtual void OnClientOpened()
        {
        }

        public void Start()
        {

        }

        public void GetStatus()
        {

            foreach (var p in Process.GetProcessesByName("LeagueClientUx"))
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher(
                 "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + p.Id.ToString());
                var moc = mos.Get();

                var commandLine = (string)moc.OfType<ManagementObject>().First()["CommandLine"];
                Console.WriteLine(commandLine);

                //Regex 
                string re_appPort = @"--app-port=[0-9]{5}"; 
                string re_authToken = @"--remoting-auth-token=[0-z]{22}"; 
                string re_pidName = @"--app-name=[A-z]{12}"; 
                string re_path = @"--output-base-dir=[0-z\s]*";

                //Format
                string portFormat = @"\d+";
                string authFormat = @"[^=]*$";
                string nameFormat = @"[^=]*$";
                string pathFormat = @"[^=]*$";

                //Match
                var cmd_port = Regex.Match(commandLine, re_appPort).Value;
                var cmd_auth = Regex.Match(commandLine, re_authToken).Value;
                var cmd_pidName = Regex.Match(commandLine, re_pidName).Value;
                var cmd_path = Regex.Match(commandLine, re_path).Value;

                //Formatacao
                _appPort = Convert.ToInt32(Regex.Match(cmd_port, portFormat).Value);
                _authToken = Regex.Match(cmd_auth, authFormat).Value;
                _processName = Regex.Match(cmd_pidName, nameFormat).Value;
                _path = Regex.Match(cmd_path, pathFormat).Value;

                Console.WriteLine(_path);
            }
            OnConnected?.Invoke();
        }

        public void PickChampion(Champion champion)
        {

        }
    }
}
