using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokergame
{
    // creating a player class to store the player name, the poker rank, face and suit rank. 
    class Player : IEquatable<Player>
    {
        string PlayerName { get; set; }
        int PlayerHandRank { get; set; }
        int CardValue { get; set; }
        int CardSuit { get; set; }

        public bool Equals(Player other)
        {
            if (other == null) return false;
            return (this.CardValue.Equals(other.CardValue));
        }


        public Player(string playerName, int playerHandRank, int cardValue, int cardSuit)
        {
            this.PlayerName = playerName;
            this.PlayerHandRank = playerHandRank;
            this.CardValue = cardValue;
            this.CardSuit = cardSuit;
        }

        // override to string method
        public override string ToString()
        {
            return $"playerName: {this.PlayerName} - playerHandRank: {this.PlayerHandRank} - cardValue: {this.CardValue} - cardSuit: {this.CardSuit}";
        }
    }
}
