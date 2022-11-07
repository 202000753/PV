/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package CardGames;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 *
 * @author POO 2019/2020
 * @version maio/2020
 */
public class CardGames {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        List<Card> cards = new ArrayList<>();
        cards.add(new FaceCard(FaceName.JACK, Suit.CLUBS));
        cards.add(new NumberedCard(3, Suit.DIAMONDS));
        cards.add(new NumberedCard(1, Suit.CLUBS));
        cards.add(new FaceCard(FaceName.KING, Suit.HEARTS));
        cards.add(new FaceCard(FaceName.QUEEN, Suit.SPADES));

        System.out.println("=======================");
        System.out.println("Lista de Cartas soltas:\n");
        for (Card card : cards) {
            System.out.println(card);
        }

        System.out.println("\n\n==================");
        System.out.println("Baralho de cartas:\n");
        Deck deck1 = new Deck(cards);
        System.out.println(deck1);

        System.out.println("\n==================");
        System.out.println("Colocar cartas no baralho:\n");
        List<Card> cardsDeck1 = deck1.getCards();
        deck1.clear();
        for (Card card : cardsDeck1) {
            deck1.putCard(card);
            System.out.println(deck1.topCard());
        }

        System.out.println("\n\n==================");
        System.out.println("Retirar cartas no baralho:\n");
        for (Card card : cardsDeck1) {
            System.out.println(deck1.drawCard());
        }

        System.out.println("\n\n==================");
        System.out.println("Baralho no final:\n");
        System.out.println(deck1);

        System.out.println("\n===========================");
        System.out.println("Baralho de cartas da Sueca:\n");
        SuecaDeck deck2 = new SuecaDeck();
        System.out.println(deck2);

        System.out.println("\n===========================");
        System.out.println("Cartas baralhadas:\n");
        deck2.shuffle();
        System.out.println(deck2);

        System.out.println("\n===========================");
        System.out.println("Cartas da Sueca ordenadas por valor");
        deck2.sortByValue();
        System.out.println(deck2);

        System.out.println("\n\n====================");
        System.out.println("Cartas ordenadas por naipe e número:\n");
        deck2.sort();
        Iterator<Card> it = deck2.iterator();
        while (it.hasNext()) {
            Card card = it.next();
            System.out.println("> " + card + " (" + card.getValue() + ")");
        }

        System.out.println("\n====================");
        System.out.println("Cartas baralhadas:\n");
        deck2.shuffle();;
        System.out.println(deck2);

        System.out.println("\n====================");
        System.out.println("Cartas sem naipe de ouros:\n");
        it = deck2.iterator();
        while (it.hasNext()) {
            Card card = it.next();
            if (card.getSuit() == Suit.DIAMONDS) {
                it.remove();
            }
        }
        System.out.println(deck2);
    }
}
