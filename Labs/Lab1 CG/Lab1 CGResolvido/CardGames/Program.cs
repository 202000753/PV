// See https://aka.ms/new-console-template for more information
using CardGames;


// Nível 2
List<Card> cards = new List<Card>();
cards.Add(new FaceCard(FaceName.Jack, Suit.Clubs));
cards.Add(new NumberedCard(3, Suit.Diamonds));
cards.Add(new NumberedCard(1, Suit.Clubs));
cards.Add(new FaceCard(FaceName.King, Suit.Hearts));
cards.Add(new FaceCard(FaceName.Queen, Suit.Spades));

Console.WriteLine("=======================");
Console.WriteLine("Lista de Cartas soltas:\n");
foreach (Card card in cards)
{
    Console.WriteLine(card);
}
Console.ReadKey();
Console.Clear();

// Nível 4
Console.WriteLine("==================");
Console.WriteLine("Baralho de cartas:\n");
Deck deck1 = new Deck(cards);
Console.WriteLine(deck1);

Console.WriteLine("\n==========================");
Console.WriteLine("Colocar cartas no baralho:\n");
List<Card> cardsDeck1 = deck1.Cards;
deck1.Clear();
foreach (Card card in cardsDeck1)
{
    deck1.PutCard(card);
    Console.WriteLine(deck1.TopCard());
}

Console.WriteLine("\n\n=========================");
Console.WriteLine("Retirar cartas no baralho:\n");
foreach (Card card in cardsDeck1)
{
    Console.WriteLine(deck1.DrawCard());
}

Console.WriteLine("\n\n==================");
Console.WriteLine("Baralho no final:\n");
Console.WriteLine(deck1);

Console.ReadKey();
Console.Clear();

// Nível 5
Console.WriteLine("\n===========================");
Console.WriteLine("Baralho de cartas da Sueca:\n");
SuecaDeck deck2 = new SuecaDeck();
Console.WriteLine(deck2);

Console.WriteLine("\n===================");
Console.WriteLine("Cartas baralhadas:\n");
deck2.Shuffle();
Console.WriteLine(deck2);

Console.WriteLine("\n===================================");
Console.WriteLine("Cartas da Sueca ordenadas por valor:");
deck2.SortByValue();
Console.WriteLine(deck2);

Console.ReadKey();
Console.Clear();

// Desafio
Console.WriteLine("\n\n====================================");
Console.WriteLine("Cartas ordenadas por naipe e número:\n");
deck2.Sort();
IEnumerator<Card> it = deck2.GetEnumerator();
while (it.MoveNext())
{
    Card card = it.Current;
    Console.WriteLine("> " + card + " (" + card.Value + ")");
}
it.Dispose();

Console.WriteLine("\n====================");
Console.WriteLine("Cartas baralhadas:\n");
deck2.Shuffle(); ;
Console.WriteLine(deck2);

Console.WriteLine("\n==========================");
Console.WriteLine("Cartas sem naipe de ouros:\n");

List<Card> cardsDeck2 = deck2.Cards;
deck2.Clear();
foreach (Card card in cardsDeck2)
{
    if (card.Suit != Suit.Diamonds)
    {
        deck2.AddCard(card);
    }
}
Console.WriteLine(deck2);