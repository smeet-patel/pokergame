using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokergame
{
    class CardDeck : Card
    {
        const int CardsInDeck = 52; //number of all cards in the deck 52 (13*4)
        private Card[] deck; //array of all cards in the deck

        public CardDeck()
        {
            deck = new Card[CardsInDeck];
        }

        public Card[] getDeck { get { return deck; } } //get the deck of cards

        //create deck with cards. Need double loop
        public void createDeckOfCards()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Face f in Enum.GetValues(typeof(Face)))
                {
                    //Console.WriteLine(s+" " +f);
                    deck[i] = new Card { CardSuit = s, CardFace = f };
                    i++;
                }
            }

            ShuffleCards();
        }

        //shuffle the deck. Have a temp card. You can set the number of shuffles
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;
            int numOfShuffles = 200;

            //run the shuffle(numOfShuffles) number of times
            for (int shuffleTimes = 0; shuffleTimes < numOfShuffles; shuffleTimes++)
            {
                for (int i = 0; i < CardsInDeck; i++)
                {
                    //swap the cards
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
