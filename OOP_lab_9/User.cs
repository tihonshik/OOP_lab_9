using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_9
{
    public delegate void Del(string st);
    class Application
    {
        public event Del Upgrate;
        public event Del Work;

        public int _version;

        public Application(int version) => _version = version;

        public int CurrentVersion {get => _version;}

        public void UpgrateVersion(int version)
        {
            if (version <= _version)
            {
                Upgrate?.Invoke($"Version {version} older then now, update failed");
            }
            else
            {
                _version = version;
                Upgrate?.Invoke($"Version upgrate to {_version}");
            }

        }

        public void WorkVersion()
        {
            Work?.Invoke($"Work version now is {_version}");
        }


    }


}
