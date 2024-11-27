using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RestAllButtons()
        {
            // Rest Size
            rbSmall.Checked = rbMeduim.Checked = rbLarge.Checked = false;

            // Rest Crust Type
            rbThin.Checked = rbThink.Checked = false;

            // Rest Where To Eat
            rbEatIn.Checked = rbTakeOut.Checked = false;
        }

        private void RestButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are You Sure?",
                "Rest Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                
                RestAllButtons();
            }

        }

    }
}
