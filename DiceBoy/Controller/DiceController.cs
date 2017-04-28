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
        private DiceRoll roll;


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
            this.roll = new DiceRoll();
        }

        /// <summary>
        /// Rolls the specified die type.
        /// </summary>
        /// <param name="dieType">Type of the die to roll.</param>
        /// <returns>The most recent DiceRoll collection</returns>
        public DiceRoll Roll(RollType dieType)
        {
            if (this.timer.ElapsedMilliseconds > 500)
            {
                this.roll = new DiceRoll();
            }
            this.roll.Roll(dieType);
            this.timer.Restart();
            return this.roll;
        }

        /// <summary>
        /// Adds the specified modifier.
        /// </summary>
        /// <param name="modifier">The modifier to add to the roll total (I.e. strength, dex, wis).</param>
        /// <returns>The most recent DiceRoll collection</returns>
        public DiceRoll AddModifier(int modifier)
        {
            this.roll.AddModifier(modifier);
            this.timer.Restart();
            return this.roll;
        }
    }
}
