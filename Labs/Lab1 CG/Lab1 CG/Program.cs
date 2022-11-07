// See https://aka.ms/new-console-template for more information


using Lab1_CG;

List<Card> cards = new List<Card>();
cards.Add(new FaceCard(FaceName.Valete, Suit.Paus));
cards.Add(new NumberedCard(3, Suit.Ouros));
cards.Add(new NumberedCard(1, Suit.Paus));
cards.Add(new FaceCard(FaceName.Rei, Suit.Copas));
cards.Add(new FaceCard(FaceName.Rainha, Suit.Espadas));

Console.WriteLine("=======================");
Console.WriteLine("Lista de Cartas soltas:");
foreach (Card card in cards)
{
    Console.WriteLine(card);
}

Console.WriteLine("\n\n==================");
Console.WriteLine("Baralho de cartas:");
Deck deck1 = new Deck(cards);
Console.WriteLine(deck1);

Console.WriteLine("\n==================");
Console.WriteLine("Colocar cartas no baralho:");
List<Card> cardsDeck1 = deck1.Cards;
deck1.clear();
foreach (Card card in cardsDeck1)
{
    deck1.putCard(card);
    Console.WriteLine(deck1.topCard());
}

Console.WriteLine("\n==================");
Console.WriteLine("Retirar cartas no baralho:");
foreach (Card card in cardsDeck1)
{
    Console.WriteLine(deck1.drawCard());
}

Console.WriteLine("\n==================");
Console.WriteLine("Baralho no final:");
Console.WriteLine(deck1);

Console.WriteLine("\n===========================");
Console.WriteLine("Baralho de cartas da Sueca:\n");
SuecaDeck deck2 = new SuecaDeck();
Console.WriteLine(deck2);

Console.WriteLine("\n===========================");
Console.WriteLine("Cartas baralhadas:\n");
deck2.shuffle();
Console.WriteLine(deck2);

Console.WriteLine("\n===========================");
Console.WriteLine("Cartas da Sueca ordenadas por valor");
deck2.sortByValue();
Console.WriteLine(deck2);