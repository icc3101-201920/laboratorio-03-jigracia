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
        private List<CombatCard>[] meleeCards;
        private List<CombatCard>[] rangeCards;
        private List<CombatCard>[] longRangeCards;

        private SpecialCard[] specialMeleeCards;
        private SpecialCard[] specialRangeCards;
        private SpecialCard[] specialLongRangeCards;
        private SpecialCard[] captainCards;
        //private Dictionary<string,List<Card.Card>> [DEFAULT_NUMBER_OF_PLAYERS];

        private List<SpecialCard> weatherCards;

        //Propiedades
        public List<CombatCard>[] MeleeCards
        {
            get
            {
                return this.meleeCards;
            }
        }
        public List<CombatCard>[] RangeCards
        {
            get
            {
                return this.rangeCards;
            }
        }
        public List<CombatCard>[] LongRangeCards
        {
            get
            {
                return this.longRangeCards;
            }
        }
        public SpecialCard[] SpecialMeleeCards
        {
            get
            {
                return this.specialMeleeCards;
            }
        }
        public SpecialCard[] SpecialRangeCards
        {
            get
            {
                return this.specialRangeCards;
            }
        }
        public SpecialCard[] SpecialLongRangeCards
        {
            get
            {
                return this.specialLongRangeCards;
            }
        }
        public SpecialCard[] CaptainCards
        {
            get
            {
                return this.captainCards;
            }
        }
        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
            this.meleeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.rangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.longRangeCards = new List<CombatCard>[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialMeleeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.specialLongRangeCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.captainCards = new SpecialCard[DEFAULT_NUMBER_OF_PLAYERS];
            this.weatherCards = new List<SpecialCard>();
        }



        //Metodos
        public void AddCombatCard(int playerId, CombatCard combatCard)
        {
            if (combatCard.Type == "melee")
            {
                meleeCards[playerId].Add(combatCard);
            }
            else if (combatCard.Type == "range")
            {
                rangeCards[playerId].Add(combatCard);
            }
            else
            {
                longRangeCards[playerId].Add(combatCard);
            }
            
        }
        public void AddSpecialCard(SpecialCard specialCard, int playerId = -1, string buffType = null)
        {
            if (specialCard.Type == "captain")
            {
                if (playerId == 0 || playerId == 1)
                {
                    captainCards[playerId] = specialCard;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else if (specialCard.Type == "weather")
            {
                weatherCards.Add(specialCard);
            }
            else
            {
                if (buffType != null)
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        if (buffType == "melee")
                        {
                            specialMeleeCards[playerId] = specialCard;
                        }
                        else if (buffType == "range")
                        {
                            specialRangeCards[playerId] = specialCard;
                        }
                        else
                        {
                            specialLongRangeCards[playerId] = specialCard;
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }   
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
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
    }
}
