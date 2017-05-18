using DiceBoy.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBoy.Util.Enum;

namespace DiceBoy.Controller
{
    /// <summary>
    /// Keeps track of the most recent dice roll and manages rolling it
    /// </summary>
    class DiceController
    {
        /// <summary>
        /// The most recent series of dice rolls
        /// </summary>
        private RollCollection roll;


        /// <summary>
        /// The timer that keeps track of how long since the last roll
        /// </summary>
        private Stopwatch timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceController"/> class.
        /// </summary>
        public DiceController()
        {
            this.timer = new Stopwatch();
            this.roll = new RollCollection();
        }

        /// <summary>
        /// Rolls the specified die type.
        /// </summary>
        /// <param name="dieType">Type of the die to roll.</param>
        /// <returns>The most recent DiceRoll collection</returns>
        public RollCollection Roll(DiceType diceType)
        {
            if (this.timer.ElapsedMilliseconds > 500)
            {
                this.roll = new RollCollection();
            }
            this.roll.Roll(diceType);
            this.timer.Restart();
            return this.roll;
        }

        public RollCollection Lucky()
        {
            this.roll.Lucky();
            return this.roll;
        }

        /// <summary>
        /// Adds the specified modifier.
        /// </summary>
        /// <param name="modifier">The modifier to add to the roll total (I.e. strength, dex, wis).</param>
        /// <returns>The most recent DiceRoll collection</returns>
        public RollCollection AddModifier(int modifier)
        {
            this.roll.AddModifier(modifier);
            this.timer.Restart();
            return this.roll;
        }
    }
}
