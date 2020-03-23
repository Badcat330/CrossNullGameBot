using System;
using System.Collections.Generic;
using System.Threading;

namespace VVP3_4
{
    public class Game
    {
        static Random rnd = new Random();
        private List<IBot> allBots= new List<IBot>();
        private char[,] fild = new char[3, 3];
        bool PlaginComand(string name)
        {
            switch (name)
            {
                case "Cross":
                    return PutSymbel('X');
                case "Circle":
                    return PutSymbel('O');
                default:
                    return true;            
            }
        }

        private void FillFild()
        {
            for(int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++)
                {
                    fild[i, j] = ' ';
                }
              
            }
        }

        public void CreateBot(string botType)
        {

            IBot newBot= new Bot(botType);
            allBots.Add(newBot);
            newBot.RegistartionBot(PlaginComand);

        }

        public void StartGame()
        {
            FillFild();
            bool flag = true;
            CreateBot("Circle");
            CreateBot("Cross");
            do
            {
                flag = allBots[0].StartBot() && allBots[1].StartBot();
            } while (flag);
        }

        void Draw()
        {
            Thread.Sleep(1000 );
            for (int i = 0; i<3; i++) {
                Console.Write('|');
                for (int j = 0; j<3; j++) {
                    Console.Write(fild[i,j].ToString()+'|');
                }
                Console.WriteLine();
                Console.WriteLine("-------");

            }
            Console.WriteLine();
            Console.WriteLine();
        }

        bool FindVictory(char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (fild[i, 0] == symbol && fild[i, 1] == symbol && fild[i, 2] == symbol)
                    return true;
            }
            for (int i = 0; i < 3; i++)
            {
                if (fild[0,i] == symbol && fild[1,i] == symbol && fild[2,i] == symbol)
                    return true;
            }
            if (fild[1, 1] == symbol && fild[2, 2] == symbol && fild[0, 0] == symbol)
                    return true;
            if (fild[0, 2] == symbol && fild[1, 1] == symbol && fild[2, 1] == symbol)
                return true;
            return false;
        }

        bool IfFildFull()
        {
            bool flag = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (fild[i, j] == ' ')
                    {
                        flag = false;
                        return flag;
                    }
                }
            }
            return flag;
        }
        
        bool PutSymbel(char symbel)
        {
            if (IfFildFull())
            {
                Console.WriteLine("No one");
                return false;
            }
            int x, y;
            do
            {
                x = rnd.Next(3);
                y = rnd.Next(3);
            } while (fild[x, y] != ' ');
            fild[x, y] = symbel;
            Draw();
            if (FindVictory(symbel))
            {
                Console.WriteLine("Victory "+symbel);
                return false;
            }
            return true;
        }
    }
}
