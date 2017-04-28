using DiceBoy.Controller;
using DiceBoy.Model;
using System;
using System.Resources;
using System.Windows.Forms;
using static DiceBoy.Util.Enum;

namespace DiceBoy
{
    /// <summary>
    /// The main form of the program
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        /// <summary>
        /// The dice controller
        /// </summary>
        private DiceController diceController;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.diceController = new DiceController();
        }

        /// <summary>
        /// Handles the keypress action, I.e. dice rolled
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PreviewKeyDownEventArgs"/> instance containing the event data.</param>
        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DiceRoll dr = null;
            switch (e.KeyCode)
            {
                case Keys.Q:
                    dr = diceController.Roll(RollType.D20);
                    break;
                case Keys.W:
                    dr = diceController.Roll(RollType.D12);
                    break;
                case Keys.E:
                    dr = diceController.Roll(RollType.D10);
                    break;
                case Keys.R:
                    dr = diceController.Roll(RollType.D8);
                    break;
                case Keys.T:
                    dr = diceController.Roll(RollType.D6);
                    break;
                case Keys.Y:
                    dr = diceController.Roll(RollType.D4);
                    break;
                default:
                    if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                    {
                        dr = diceController.AddModifier(e.KeyValue - 48);
                    }
                    break;
            }
            if (dr != null)
            {
                this.resultLabel.Text = dr.Result();
                this.sumLabel.Text = dr.ToString();
            }
        }

        /// <summary>
        /// Handles the Click event of the helpToolStripMenuItem control and displays the help.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rm = new ResourceManager("DiceBoy.Resources.Resources", typeof(MainForm).Assembly);
            MessageBox.Show(this,rm.GetString("HelpString") , "Help", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Handles the Click event of the licenseToolStripMenuItem control and displays the license.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lf = new View.LicenseForm();
            lf.Show();
        }
    }
}
