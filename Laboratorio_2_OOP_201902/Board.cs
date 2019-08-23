using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        
        private Dictionary<string, List<Card.Card>>[] playerCards;
        private List<Card.Card> weatherCards;

        //Propiedades
        public List<Card.Card> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }

        public Dictionary<string, List<Card.Card>>[] PlayerCards { get => playerCards; set => playerCards = value; }


        //Constructor
        public Board()
        {
            this.weatherCards = new List<Card.Card>();
            this.playerCards = new Dictionary<string, List<Card.Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.playerCards[0] = new Dictionary<string, List<Card.Card>>();
            this.playerCards[1] = new Dictionary<string, List<Card.Card>>();
        }



        //Metodos
        public void DestroyCombatCards()
        {
            this.meleeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.rangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.longRangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
        }
        public void DestroySpecialCards()
        {
            this.specialMeleeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialLongRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.weatherCards = new List<SpecialCard>();
        }
        public int[] GetMeleeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                foreach (CombatCard meleeCard in meleeCards[i])
                {
                    totalAttack[i] += meleeCard.AttackPoints;
                }
            }
            return totalAttack;
            
        }
        public int[] GetRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas range y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard rangeCard in rangeCards[i])
                {
                    totalAttack[i] += rangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
        public int[] GetLongRangeAttackPoints()
        {
            //Debe sumar todos los puntos de ataque de las cartas longRange y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i = 0; i < 2; i++)
            {
                foreach (CombatCard longRangeCard in longRangeCards[i])
                {
                    totalAttack[i] += longRangeCard.AttackPoints;
                }
            }
            return totalAttack;
        }
        public void AddCard(Card.Card card, int playerId = -1, string buffType = null) {
            if (card.GetType().Name==nameof(CombatCard))
            {
                if (playerId==0 || playerId==1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card.Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else
            {
                if (card.GetType().Name=="captain")
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (playerCards[playerId].ContainsKey("captain"))
                        {
                            Console.WriteLine("Captain card already choosen");
                        }
                        else
                        {
                            playerCards[playerId].Add("captain", new List<Card.Card>() { card });
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }
                if (card.GetType().Name == nameof(CombatCard)+buffType)
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (playerCards[playerId].ContainsKey(card.Type+buffType))
                        {
                            Console.WriteLine("Buff card already choosen");
                        }
                        else
                        {
                            playerCards[playerId].Add(card.Type+buffType, new List<Card.Card>() { card });
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }
                if (card.GetType().Name=="weather")
                {
                    weatherCards.Add(card);
                }

            }
        }
        public void DestroyCards() {
            List<Card.Card>[] captainCards = new List<Card.Card>[DEFAULT_NUMBER_OF_PLAYERS] {
                new List <Card.Card>( playerCards [0]["captain"]), new List <Card.Card >( playerCards [1]["captain"])
            };
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i].Clear();
            }
            for (int i = 0; i < playerCards.Length; i++)
            {
                playerCards[i].Add(captainCards[i]["captain"]);
            }

        }
    }
}
