using System;
namespace VVP3_4
{
    public class Bot :IBot
    {
        Comands comands;
        string name;
        public Bot(string name)
        {
            this.name = name;
        }
        public void RegistartionBot(Comands arg)
        {
            comands = arg;
        }

        public bool StartBot()
        {
            return comands(name);
        }
    }
}
