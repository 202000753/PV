// See https://aka.ms/new-console-template for more information


using Lab1_CG;

IList<Card> cards = new List<Card>()
{
    new FaceCard{ faceName = FaceName.Valete, suit = Suit.Paus },
    new NumberedCard{ number = 3, suit = Suit.Ouros },
    new NumberedCard{ number = 1, suit = Suit.Paus },
    new FaceCard { faceName = FaceName.Rei, suit = Suit.Corações},
    new FaceCard { faceName = FaceName.Rainha, suit = Suit.Espadas},
    null
};

Console.WriteLine("=======================");
Console.Write("Lista de Cartas soltas:\n");
foreach (Card card in cards)
{
    Console.WriteLine(card);
}