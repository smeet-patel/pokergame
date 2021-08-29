using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace pokergame
{
    class Game : CardDeck
    {
        // num of rounds and player
        int numberofPlayer;
        int scorerank;
        int numberofRounds = 0;
        int roundcount = 0;

        //sorting the player cards
        private Card[] player1;
        private Card[] player2;
        private Card[] player3;
        private Card[] player4;
        private Card[] player5;
        private Card[] player6;

        private Card[] sortedCardsPlayer1;
        private Card[] sortedCardsPlayer2;
        private Card[] sortedCardsPlayer3;
        private Card[] sortedCardsPlayer4;
        private Card[] sortedCardsPlayer5;
        private Card[] sortedCardsPlayer6;

        //score and round totals 
        int s1, s2, s3, s4, s5, s6 = 0;
        int total1, total2, total3, total4, total5, total6 = 0;
        Player p1, p2, p3, p4, p5, p6;

        //list to store player name and ranking
        List<(string, int, int, int)> Player = new List<(string, int, int, int)>(6);
        List<(string, int)> results = new List<(string, int)>(6);

        //brains of the game. Could have this code in the program.cs 
        public void RunGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            // when starting new game. init 0 and ask number players and rounds
            if (roundcount == 0)
            {
                numberofRounds = 0;
                roundcount = 0;
                setgame();
                setround();
            }
            // if the current round is = total round. Endgame and return the results and start the game again.  
            if (roundcount == numberofRounds)
            {
                endgame();
                total1 = 0;
                total2 = 0;
                total3 = 0;
                total4 = 0;
                total5 = 0;
                total6 = 0;
                roundcount = 0;
                numberofRounds = 0;
                setgame();
                setround();
            }
            // whole game logic but will only run for rounds 1 to 5. s
            if (roundcount <= 4 || roundcount >= 0)
            {
                createDeckOfCards(); //create the deck of cards and shuffle them
                getHand();
                sortCards();
                displayCards();
                PokerRanks();
            }
        }

        //ask the number of players. With if statement that only allows int 2 to 6
        //also set the array to sort 2 card per player(x2). 
        private void setgame()
        {
            Console.WriteLine("\nEnter the number of Players for the game between 2 to 6:");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("\nInvalid value! Enter the number of Players for the game between 2 to 6:");
                setgame();
            }
            else
            {
                //Console.WriteLine("{0} Player Poker Game", num);
                if (num >= 2 && num <= 6)
                {
                    numberofPlayer = num;
                }
                else
                {
                    Console.WriteLine("\nInvalid value! Enter the number of Players for the game between 2 to 6:");
                    setgame();
                }
            }

            // set 2 Player
            player1 = new Card[2];
            player2 = new Card[2];
            sortedCardsPlayer1 = new Card[2];
            sortedCardsPlayer2 = new Card[2];

            // if less then or equal to Player
            if (numberofPlayer >= 3)
            {
                player3 = new Card[2];
                sortedCardsPlayer3 = new Card[2];
            }
            if (numberofPlayer >= 4)
            {
                player4 = new Card[2];
                sortedCardsPlayer4 = new Card[2];
            }
            if (numberofPlayer >= 5)
            {
                player5 = new Card[2];
                sortedCardsPlayer5 = new Card[2];
            }
            if (numberofPlayer >= 6)
            {
                player6 = new Card[2];
                sortedCardsPlayer6 = new Card[2];
            }

            //Console.WriteLine("numberofPlayer" + numberofPlayer);
        }

        //ask the number of rounds. With if statement that only allows int 2 to 5
        private void setround()
        {
            Console.WriteLine("Enter the number of Rounds for the game between 2 to 5:");
            if (!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Invalid value! Enter the number of Rounds for the game between 2 to 5:");
                setround();
            }
            else
            {
                //Console.WriteLine("{0} Player Poker Game", num);
                if (num >= 2 && num <= 5)
                {
                    numberofRounds = num;
                }
                else
                {
                    Console.WriteLine("Invalid value! Enter the number of Players for the game between 2 to 6:");
                    setround();
                }
            }
        }

        public void getHand()
        {

            //2 cards for the Player 1
            for (int i = 0; i < 2; i++)
            {
                player1[i] = getDeck[i];
            }

            //Player 2
            for (int i = 2; i < 4; i++)
            {
                player2[i - 2] = getDeck[i];
            }

            //player3
            if (numberofPlayer >= 3)
            {
                for (int i = 4; i < 6; i++)
                {
                    player3[i - 4] = getDeck[i];
                }
            }

            //player4
            if (numberofPlayer >= 4)
            {
                for (int i = 6; i < 8; i++)
                {
                    player4[i - 6] = getDeck[i];
                }
            }

            //player5
            if (numberofPlayer >= 5)
            {
                for (int i = 8; i < 10; i++)
                {
                    player5[i - 8] = getDeck[i];
                }
            }

            //player6
            if (numberofPlayer >= 6)
            {
                for (int i = 10; i < 12; i++)
                {
                    player6[i - 10] = getDeck[i];
                }
            }

        }

        //sorting the cards with query based on the card face value
        public void sortCards()
        {
            var sortPlayer1 = from hand in player1
                              orderby hand.CardFace
                              select hand;

            var ip1 = 0;
            foreach (var element in sortPlayer1.ToList())
            {
                sortedCardsPlayer1[ip1] = element;
                ip1++;
            }

            var sortPlayer2 = from hand in player2
                              orderby hand.CardFace
                              select hand;

            var ip2 = 0;
            foreach (var element in sortPlayer2.ToList())
            {
                sortedCardsPlayer2[ip2] = element;
                ip2++;
            }

            if (numberofPlayer >= 3)
            {
                var sortPlayer3 = from hand in player3
                                  orderby hand.CardFace
                                  select hand;

                var ip3 = 0;
                foreach (var element in sortPlayer3.ToList())
                {
                    sortedCardsPlayer3[ip3] = element;
                    ip3++;
                }
            }

            if (numberofPlayer >= 4)
            {
                var sortPlayer4 = from hand in player4
                                  orderby hand.CardFace
                                  select hand;

                var ip4 = 0;
                foreach (var element in sortPlayer4.ToList())
                {
                    sortedCardsPlayer4[ip4] = element;
                    ip4++;
                }
            }

            if (numberofPlayer >= 5)
            {
                var sortPlayer5 = from hand in player5
                                  orderby hand.CardFace
                                  select hand;

                var ip5 = 0;
                foreach (var element in sortPlayer5.ToList())
                {
                    sortedCardsPlayer5[ip5] = element;
                    ip5++;
                }
            }

            if (numberofPlayer >= 6)
            {
                var sortPlayer6 = from hand in player6
                                  orderby hand.CardFace
                                  select hand;

                var ip6 = 0;
                foreach (var element in sortPlayer6.ToList())
                {
                    sortedCardsPlayer6[ip6] = element;
                    ip6++;
                }
            }

        }

        //displaying the symbol for the card and face value
        public static void showcard(Card card)
        {
            Console.WriteLine("card " + card.CardSuit.ToString());
            char cardSuit = ' ';
            string cardFaceNum = " ";
            switch (card.CardSuit)
            {
                case Card.Suit.HEARTS:
                    cardSuit = '\u2665';
                    break;
                case Card.Suit.DIAMONDS:
                    cardSuit = '\u2666';
                    break;
                case Card.Suit.CLUBS:
                    cardSuit = '\u2663';
                    break;
                case Card.Suit.SPADES:
                    cardSuit = '\u2660';
                    break;
            }

            switch (card.CardFace)
            {
                case Card.Face.Two:
                    cardFaceNum = "2";
                    break;
                case Card.Face.Three:
                    cardFaceNum = "3";
                    break;
                case Card.Face.Four:
                    cardFaceNum = "4";
                    break;
                case Card.Face.Five:
                    cardFaceNum = "5";
                    break;
                case Card.Face.Six:
                    cardFaceNum = "6";
                    break;
                case Card.Face.Seven:
                    cardFaceNum = "7";
                    break;
                case Card.Face.Eight:
                    cardFaceNum = "8";
                    break;
                case Card.Face.Nine:
                    cardFaceNum = "9";
                    break;
                case Card.Face.Ten:
                    cardFaceNum = "10";
                    break;
                case Card.Face.JACK:
                    cardFaceNum = "Jack";
                    break;
                case Card.Face.QUEEN:
                    cardFaceNum = "Queen";
                    break;
                case Card.Face.KING:
                    cardFaceNum = "King";
                    break;
                case Card.Face.ACE:
                    cardFaceNum = "Ace";
                    break;


            }
            Console.WriteLine(cardFaceNum + " of " + cardSuit);
        }

        //Handing out the cards to the players. first two, then next player.... depending the number of players
        public void displayCards()
        {
            int displayround = roundcount + 1;
            Console.WriteLine("\n--- Round " + displayround + " ---\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Player 1");

            for (int i = 0; i < 2; i++)
            {
                showcard(sortedCardsPlayer1[i]);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player 2");

            for (int i = 2; i < 4; i++)
            {
                showcard(sortedCardsPlayer2[i - 2]);
            }

            if (numberofPlayer >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player 3");

                for (int i = 4; i < 6; i++)
                {
                    showcard(sortedCardsPlayer3[i - 4]);
                }
            }

            if (numberofPlayer >= 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player 4");

                for (int i = 6; i < 8; i++)
                {
                    showcard(sortedCardsPlayer4[i - 6]);
                }
            }

            if (numberofPlayer >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Player 5");

                for (int i = 8; i < 10; i++)
                {
                    showcard(sortedCardsPlayer5[i - 8]);
                }
            }

            if (numberofPlayer >= 6)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Player 6");

                for (int i = 10; i < 12; i++)
                {
                    showcard(sortedCardsPlayer6[i - 10]);
                }
            }

        }

        //ranking the cards for the players
        public void PokerRanks()
        {
            //rank the sorted cards for each player
            CardRank player1CardRank = new CardRank(sortedCardsPlayer1);
            CardRank player2CardRank = new CardRank(sortedCardsPlayer2);

            //get the players ranking
            Hand player1Cards = player1CardRank.PokerRank();
            Hand player2Cards = player2CardRank.PokerRank();

            //storing the player ranking values in list
            var Player = new List<(string, int, int, int)> {
                ("Player 1", (int)player1Cards, player1CardRank.HandValues.Total, player1CardRank.HandValues.HighCard),
                ("Player 2", (int)player2Cards, player2CardRank.HandValues.Total, player2CardRank.HandValues.HighCard)
                };

            //displaying the results to the console
            Console.ForegroundColor = ConsoleColor.White;
            roundcount++;
            Console.WriteLine("\n" + "Results for round " + roundcount + " out of " + numberofRounds + "\n");

            //print for testing purpose
            //Console.WriteLine("\nPlayer 1 Result: " + player1Cards + " highest Card " + player1CardRank.HandValues.Total + " suit: " + player1CardRank.HandValues.HighCard);
            //Console.WriteLine("Player 2 Result: " + player2Cards + " highest Card " + player2CardRank.HandValues.Total + " suit: " + player2CardRank.HandValues.HighCard);

            if (numberofPlayer >= 3)
            {
                CardRank player3CardRank = new CardRank(sortedCardsPlayer3);
                Hand player3Cards = player3CardRank.PokerRank();
                p3 = new Player("Player 3", (int)player3Cards, player3CardRank.HandValues.Total, player3CardRank.HandValues.HighCard);
                Player.Add(("Player 3", (int)player3Cards, player3CardRank.HandValues.Total, player3CardRank.HandValues.HighCard));
                //Console.WriteLine("Player 3 Result: " + player3Cards + " highest Card " + player3CardRank.HandValues.Total + " suit: " + player3CardRank.HandValues.HighCard);
            }


            if (numberofPlayer >= 4)
            {
                CardRank player4CardRank = new CardRank(sortedCardsPlayer4);
                Hand player4Cards = player4CardRank.PokerRank();
                p4 = new Player("Player 4", (int)player4Cards, player4CardRank.HandValues.Total, player4CardRank.HandValues.HighCard);
                Player.Add(("Player 4", (int)player4Cards, player4CardRank.HandValues.Total, player4CardRank.HandValues.HighCard));
                //Console.WriteLine("Player 4 Result: " + player4Cards + " highest Card " + player4CardRank.HandValues.Total + " suit: " + player4CardRank.HandValues.HighCard);
            }

            if (numberofPlayer >= 5)
            {
                CardRank player5CardRank = new CardRank(sortedCardsPlayer5);
                Hand player5Cards = player5CardRank.PokerRank();
                p5 = new Player("Player 5", (int)player5Cards, player5CardRank.HandValues.Total, player5CardRank.HandValues.HighCard);
                Player.Add(("Player 5", (int)player5Cards, player5CardRank.HandValues.Total, player5CardRank.HandValues.HighCard));
                //Console.WriteLine("Player 5 Result: " + player5Cards + " highest Card " + player5CardRank.HandValues.Total + " suit: " + player5CardRank.HandValues.HighCard);
            }

            if (numberofPlayer >= 6)
            {
                CardRank player6CardRank = new CardRank(sortedCardsPlayer6);
                Hand player6Cards = player6CardRank.PokerRank();
                p6 = new Player("Player 6", (int)player6Cards, player6CardRank.HandValues.Total, player6CardRank.HandValues.HighCard);
                Player.Add(("Player 6", (int)player6Cards, player6CardRank.HandValues.Total, player6CardRank.HandValues.HighCard));
                //Console.WriteLine("Player 6 Result: " + player6Cards + " highest Card " + player6CardRank.HandValues.Total + " suit: " + player6CardRank.HandValues.HighCard);
            }
            //Order decesending item 4 the suits, then the face and then the poker rank using sort and compareTo 
            Player.Sort((e1, e2) =>
            {
                return e2.Item4.CompareTo(e1.Item4);
            });
            Player.Sort((e1, e2) =>
            {
                return e2.Item3.CompareTo(e1.Item3);
            });
            Player.Sort((e1, e2) =>
            {
                return e2.Item2.CompareTo(e1.Item2);
            });

            foreach (var person in Player)
            {

                scorerank = numberofPlayer;
            }

            //scoring for each round and adding to total
            for (int i = 0; i < numberofPlayer; i++)
            {
                var topoflist = Player.ElementAt(i).Item1.ToString();

                if ("Player 1" == topoflist)
                {
                    scorerank--;
                    s1 = scorerank;
                    total1 = total1 + s1;
                    Console.WriteLine(topoflist + " Score " + s1);
                    //scorerank--;
                }
                else if ("Player 2" == topoflist)
                {
                    scorerank--;
                    s2 = scorerank;
                    total2 = total2 + s2;
                    Console.WriteLine(topoflist + " Score " + s2);
                    //scorerank--;
                }
                else if ("Player 3" == topoflist)
                {
                    scorerank--;
                    s3 = scorerank;
                    total3 = total3 + s3;
                    Console.WriteLine(topoflist + " Score " + s3);
                    //scorerank--;
                }
                else if ("Player 4" == topoflist)
                {
                    scorerank--;
                    s4 = scorerank;
                    total4 = total4 + s4;
                    Console.WriteLine(topoflist + " Score " + s4);
                    //scorerank--;
                }
                else if ("Player 5" == topoflist)
                {
                    scorerank--;
                    s5 = scorerank;
                    total5 = total5 + s5;
                    Console.WriteLine(topoflist + " Score " + s5);
                    //scorerank--;
                }
                else if ("Player 6" == topoflist)
                {
                    scorerank--;
                    s6 = scorerank;
                    total6 = total6 + s6;
                    Console.WriteLine(topoflist + " Score " + s6);
                    //scorerank--;
                }


            }
            //Console.WriteLine(string.Join(Environment.NewLine, Player));
        }

        //end of all rounds. 
        private void endgame()
        {
            //display the final results and storing in a custom list. 
            Console.WriteLine("\nFinal Results:");
            var results = new List<(string, int)>() {
                ("Player 1", total1),
                ("Player 2", total2),
                ("Player 3", total3),
                ("Player 4", total4),
                ("Player 5", total5),
                ("Player 6", total6)
                };

            //sorting the results list.
            results.Sort((e1, e2) =>
            {
                return e2.Item2.CompareTo(e1.Item2);
            });
            //Writing the final score in a loop. 
            Console.WriteLine("\nWinner!!! " + results.ElementAt(0).Item1);
            for (int i = 0; i < numberofPlayer; i++)
            {
                var totalscoreplayer = results.ElementAt(i).Item1.ToString();
                var totalscore = results.ElementAt(i).Item2.ToString();
                Console.WriteLine(totalscoreplayer + " Final Score " + totalscore);
                //List<(string, int)> results = new List<(string, int)>(6);
            }
            s1 = 0;
            s2 = 0;
            s3 = 0;
            s4 = 0;
            s5 = 0;
            s6 = 0;
        }
    }
}
