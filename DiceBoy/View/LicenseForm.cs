using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceBoy.View
{
    /// <summary>
    /// Represents the copyright and license attribution form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LicenseForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseForm"/> class.
        /// </summary>
        public LicenseForm()
        {
            InitializeComponent();
            var rm = new ResourceManager("DiceBoy.Resources.Resources", typeof(LicenseForm).Assembly);
            this.licenseLabel.Text = rm.GetString("LicenseString");
        }

        /// <summary>
        /// Takes you to the source of the icons used in the program.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.iconarchive.com/show/dnd-dice-icons-by-iconcubic.html");
        }

        /// <summary>
        /// Takes you to the source of the Creative Commons license used by the art.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://creativecommons.org/licenses/by-nc-nd/4.0/");
        }

        /// <summary>
        /// Closes the program.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
