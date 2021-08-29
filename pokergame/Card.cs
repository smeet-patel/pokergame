using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokergame
{
    class Card
    {
        //Weakest suit to the strongest because the enum value
        public enum Suit
        {
            DIAMONDS, HEARTS, CLUBS, SPADES,
        }

        // assigning values to enums starting from 2 = 2 to ace is 14
        public enum Face
        {

            Two = 2, Three = 3, Four = 4,
            Five = 5, Six = 6, Seven = 7,
            Eight = 8, Nine = 9, Ten = 10,
            JACK = 11, QUEEN = 12, KING = 13, ACE = 14,

        }

        //properties
        public Suit CardSuit { get; set; }
        public Face CardFace { get; set; }
    }
}
