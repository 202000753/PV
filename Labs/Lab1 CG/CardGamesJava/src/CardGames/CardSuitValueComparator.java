/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package CardGames;

import java.util.Comparator;

/**
 *
 * @author POO 2019/2020
 * @version maio/2020
 */
public class CardSuitValueComparator implements Comparator<Card> {

    @Override
    public int compare(Card card1, Card card2) {
        if (card1.getSuit() != card2.getSuit()) {
            return card1.getSuit().ordinal() - card2.getSuit().ordinal();
        }
        if (card1 instanceof FaceCard && card2 instanceof FaceCard) {
            return ((FaceCard) card1).getFaceName().ordinal()
                    - ((FaceCard) card2).getFaceName().ordinal();
        }
        if (card1 instanceof FaceCard) {
            return 1;
        }
        if (card2 instanceof FaceCard) {
            return -1;
        }
        if (card1 instanceof NumberedCard && card2 instanceof NumberedCard) {
            return ((NumberedCard) card1).getNumber()
                    - ((NumberedCard) card2).getNumber();
        }
        return -1;
    }
}

