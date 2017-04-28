using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBoy.Util.Enum;

namespace DiceBoy.Model
{
    /// <summary>
    /// Model Class that handles keeping track of one series of rolls. Rolls are grouped by time.
    /// All rolls made over 500 ms after the last roll will be grouped into a new DiceRoll
    /// </summary>
    class DiceRoll
    {
        /// <summary>
        /// The random number generator
        /// </summary>
        private Random rand;

        /// <summary>
        /// The list of rolls to aggregate into one result
        /// </summary>
        private List<int> rolls;


        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRoll"/> class.
        /// </summary>
        public DiceRoll()
        {
            this.rolls = new List<int>();
            this.rand = new Random();
        }

        /// <summary>
        /// Rolls the specified die.
        /// </summary>
        /// <param name="dice">The dicetype to roll.</param>
        public void Roll(RollType dice)
        {
            switch (dice)
            {
                case RollType.D20:
                    this.rollDice(20);
                    break;
                case RollType.D12:
                    this.rollDice(12);
                    break;
                case RollType.D10:
                    this.rollDice(10);
                    break;
                case RollType.D8:
                    this.rollDice(8);
                    break;
                case RollType.D6:
                    this.rollDice(6);
                    break;
                case RollType.D4:
                    this.rollDice(4);
                    break;
            }
        }

        /// <summary>
        /// Adds the specified modifier.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        public void AddModifier(int modifier)
        {
            this.rolls.Add(modifier);
        }

        /// <summary>
        /// Gets the total of all rolls in this roll series.
        /// </summary>
        /// <returns>All rolls in series added together</returns>
        public string Result()
        {
            var sum = 0;
            foreach (var roll in rolls)
            {
                sum += roll;
            }
            return sum.ToString();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that displays each roll and modifier.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that displays each roll and modifier.
        /// </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < this.rolls.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(" + ");
                }
                sb.Append(this.rolls[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Rolls the specified die.
        /// </summary>
        /// <param name="max">The maximum number, representing the type of die.</param>
        private void rollDice(int max)
        {
            this.rolls.Add(rand.Next(1, max));
        }


    }
}
