/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    public class Player
    {
        public string name { get; set; }
        public int score { get; set; }
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public override string ToString()
        {
            return name + " " + score;
        }
    }

    public interface Comparator<T>
    {
        public int compare(T a, T b);
    }

    public class Checker : Comparator<Player>
    {
        public int compare(Player a, Player b)
        {
            if(a.score < b.score)
            {
                return -1;
            }
            if(a.score > b.score)
            {
                return 1;
            }
            if (String.Compare(a.name,b.name)>0)
            {
                return -1;
            }
            if (String.Compare(a.name, b.name) < 0)
            {
                return 1;
            }
            return 0;
        }
    }

    static void Main(String[] args)
    {
        *//* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution *//*
        int noOfPlayers = Int32.Parse(Console.ReadLine());
        List<Player> listPlayer = new List<Player>();
        for(int i = 0; i < noOfPlayers; i++)
        {
            string nameAndScore = Console.ReadLine();
            int indexOfSpace = nameAndScore.IndexOf(" ");
            string name = nameAndScore.Substring(0, indexOfSpace);
            int score = Int32.Parse(nameAndScore.Substring(indexOfSpace, nameAndScore.Length - indexOfSpace));
            Player player = new Player(name, score);
            listPlayer.Add(player);
        }
        Checker c = new Checker();
        for (int i= 0;i< listPlayer.Count()-1;i++)
        {
            for(int j=i;j< listPlayer.Count(); j++)
            {
                if (c.compare(listPlayer[i], listPlayer[j]) == -1)
                {
                    Player temp = listPlayer[i];
                    listPlayer[i] = listPlayer[j];
                    listPlayer[j] = temp;
                }
            }
        }

        foreach(Player p in listPlayer)
        {
            Console.WriteLine(p.ToString());
        }

    }
}*/