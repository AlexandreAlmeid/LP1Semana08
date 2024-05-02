using System;
using System.Runtime.InteropServices;

namespace PlayerManager3
{
    class Player : IComparable<Player>
    {
        public string Name { get; }
        public int Score { get; set; }
        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public int CompareTo(Player other)
        {
            if (other == null) return 1; 
            return other.Score - this.Score;
        }
    }
}