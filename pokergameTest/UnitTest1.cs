using Microsoft.VisualStudio.TestTools.UnitTesting;
using pokergame;

namespace pokergame
{
    [TestClass]
    public class PokergameTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Card[] deck;
            deck = new Card[1];
            Card card = new Card();
            Game game = new Game();

            Card c1 = new Card { CardSuit = Card.Suit.HEARTS, CardFace = Card.Face.Two };
            //game.showcard(c1);


        }
    }
}
