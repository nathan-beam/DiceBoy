using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBoy.Util.Enum;

namespace DiceBoy.Model
{

    class DiceRoll
    {

        /// <summary>
        /// Gets or sets the value of the dice roll.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; private set; }

        private Random rand;

        private readonly DiceType diceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRoll"/> class.
        /// </summary>
        /// <param name="diceType">Type of the dice.</param>
        public DiceRoll(DiceType diceType)
        {
            this.rand = new Random();
            this.diceType = diceType;
            this.rollDice();
        }

        /// <summary>
        /// Rerolls the die
        /// </summary>
        public void ReRoll()
        {
            this.rollDice();
        }

        /// <summary>
        /// Rolls the specified die.
        /// </summary>
        /// <param name="max">The maximum number, representing the type of die.</param>
        private void rollDice()
        {
            var max = (int)this.diceType;
            this.Value = rand.Next(1, max + 1);
        }
    }
}
