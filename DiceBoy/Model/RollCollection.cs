using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBoy.Util.Enum;

namespace DiceBoy.Model
{
    class RollCollection
    {

        private List<DiceRoll> rolls;

        private List<Modifier> modifiers;

        private bool luckyRolled;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRoll"/> class.
        /// </summary>
        public RollCollection()
        {
            this.rolls = new List<DiceRoll>();
            this.modifiers = new List<Modifier>();
            this.luckyRolled = false;
        }

        /// <summary>
        /// Rolls the specified die.
        /// </summary>
        /// <param name="dice">The dicetype to roll.</param>
        public void Roll(DiceType dice)
        {
            this.rolls.Add(new DiceRoll(dice));
        }

        /// <summary>
        /// Adds the specified modifier.
        /// </summary>
        /// <param name="modifier">The modifier to add.</param>
        public void AddModifier(int modifier)
        {
            var mod = new Modifier(modifier);
            this.modifiers.Add(mod);
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
                sum += roll.Value;
            }
            foreach (var mod in this.modifiers)
            {
                sum += mod.Value;
            }
            return sum.ToString();
        }

        /// <summary>
        /// Lucky feature for halfling. Rerolls all natural 1s
        /// </summary>
        public void Lucky()
        {
            if (!this.luckyRolled)
            {
                this.luckyRolled = true;
                foreach (var roll in this.rolls)
                {
                    if (roll.Value == 1)
                    {
                        roll.ReRoll();
                    }
                }
            }
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
                sb.Append(this.rolls[i].Value);
            }
            foreach (var mod in this.modifiers)
            {
                sb.Append(" + ");
                sb.Append(mod.Value);
            }
            return sb.ToString();
        }


    }
}
