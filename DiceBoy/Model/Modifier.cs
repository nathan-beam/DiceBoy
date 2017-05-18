using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBoy.Model
{
    class Modifier
    {
        /// <summary>
        /// Gets the value of the modifier.
        /// </summary>
        /// <value>
        /// The value of the modifier.
        /// </value>
        public int Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Modifier"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Modifier(int value)
        {
            this.Value = value;
        }

    }
}
