using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokergame
{


    public enum Hand
    {
        HighCard,
        OnePair,
        Straight,
        Flush,
        StraightFlush
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class CardRank : Card
    {
        //set up the Total of suits, card array
        private int heartsTotal;
        private int diamondTotal;
        private int clubTotal;
        private int spadesTotal;
        private Card[] cards;
        private HandValue handValue;

        public CardRank(Card[] sortedHand)
        {
            heartsTotal = 0;
            diamondTotal = 0;
            clubTotal = 0;
            spadesTotal = 0;
            cards = new Card[2];
            Cards = sortedHand;
            //handValue = new HandValue();
        }

        public Hand CardHand { get; set; }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards // storing the two cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
            }
        }

        public Hand PokerRank()
        {
            //get the number of each Suit on hand
            getNumberOfSuit();
            if (StraightFlush())
                return Hand.StraightFlush;
            else if (Flush())
                return Hand.Flush;
            else if (Straight())
                return Hand.Straight;
            else if (OnePair())
                return Hand.OnePair;
            //player with the highest value of the high card wins if highcard
            handValue.HighCard = (int)cards[1].CardSuit;
            handValue.Total = (int)cards[1].CardFace;
            return Hand.HighCard;
        }


        private void getNumberOfSuit()
        {
            //counting the number of suit per hand
            foreach (var element in Cards)
            {
                if (element.CardSuit == Card.Suit.SPADES)
                    spadesTotal++;
                else if (element.CardSuit == Card.Suit.CLUBS)
                    clubTotal++;
                else if (element.CardSuit == Card.Suit.HEARTS)
                    heartsTotal++;
                else if (element.CardSuit == Card.Suit.DIAMONDS)
                    diamondTotal++;
            }
        }


        private bool StraightFlush()
        {
            if (cards[0].CardFace + 1 == cards[1].CardFace && (heartsTotal == 2 || diamondTotal == 2 || clubTotal == 2 || spadesTotal == 2))
            {
                handValue.Total = (int)cards[1].CardFace;
                handValue.HighCard = (int)cards[1].CardSuit;
                return true;
            }
            return false;
        }

        private bool Flush()
        {
            //if all Suits are the same
            if (heartsTotal == 2 || diamondTotal == 2 || clubTotal == 2 || spadesTotal == 2)
            {
                //if flush, the player with higher cards win
                //player with the highest value of the high card wins
                handValue.Total = (int)cards[1].CardFace;
                handValue.HighCard = (int)cards[1].CardSuit;
                return true;
            }

            return false;
        }


        private bool Straight()
        {
            //2 back t values
            if (cards[0].CardFace + 1 == cards[1].CardFace && ((heartsTotal == 1 || diamondTotal == 1 || clubTotal == 1 || spadesTotal == 1)))
            {
                //player with the highest value of the high card wins
                handValue.Total = (int)cards[1].CardFace;
                handValue.HighCard = (int)cards[1].CardSuit;
                return true;
            }

            return false;
        }

        private bool OnePair()
        {
            //if 1,2 -> 2th card has the highest value
            if (cards[0].CardFace == cards[1].CardFace)
            {
                handValue.Total = (int)cards[1].CardFace;
                handValue.HighCard = (int)cards[1].CardSuit;
                return true;
            }

            return false;
        }


    }
}
