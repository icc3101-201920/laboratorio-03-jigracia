using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck
    {
        private List<CombatCard> combatCards;
        private List<SpecialCard> SpecialCards;
        private List<Card.Card> cards;
        public Deck()
        {

        }

        public List<CombatCard> CombatCards { get => combatCards; set => combatCards = value; }
        public List<SpecialCard> SpecialCards1 { get => SpecialCards; set => SpecialCards = value; }
        public List<Card.Card> Cards { get => cards; set => cards = value; }

        public void AddCombatCard(Card.Card card) { throw new NotImplementedException(); }
        public void AddSpecialCard(Card.Card card) { throw new NotImplementedException(); }
        public void DestroyCombatCard(int cardId) { throw new NotImplementedException(); }
        public void DestroySpecialCard(int cardId) { throw new NotImplementedException(); }
        public void Shuffle() { 
            throw new NotImplementedException();
        }
    }
}
