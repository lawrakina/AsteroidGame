using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;
        public Gamer() { }
        public Gamer(string Name, DateTime DayOfBirth)
        {
            this._Name = Name;
            this._DayOfBirth = DayOfBirth;
        }

        /*public void SetName(string value) {
            _Name = value;
        }

        public string GetName() { return _Name; }
*/
        public string Name
        {
            get { return _Name ?? string.Empty; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _Name = value;
            }
        }

        internal int GetNameLenght()
        {
            return Name.Length;
        }
        public void SayYouName()
        {
            Console.WriteLine($"My name is {_Name} - {_DayOfBirth:dd:MM:yyyy HH:mm:ss}");
        }
    }
}
