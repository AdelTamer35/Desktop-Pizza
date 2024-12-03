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
    public partial class PizzaOrder : Form
    {
        public PizzaOrder()
        {
            InitializeComponent();

            // Initially disable the Reset Button and Order Button
            OrderButton.Enabled = false;
            OrderButton.BackColor = Color.LightGreen;

            RestButton.Enabled = false;
            RestButton.BackColor = Color.AntiqueWhite;


            // Attach CheckedChanged event to all radio buttons
            rbSmall.CheckedChanged += RadioButton_CheckedChanged;
            rbMeduim.CheckedChanged += RadioButton_CheckedChanged;
            rbLarge.CheckedChanged += RadioButton_CheckedChanged;

            rbThin.CheckedChanged += RadioButton_CheckedChanged;
            rbThink.CheckedChanged += RadioButton_CheckedChanged;

            rbEatIn.CheckedChanged += RadioButton_CheckedChanged;
            rbTakeOut.CheckedChanged += RadioButton_CheckedChanged;
        }


        private int GetTag(GroupBox groupbox)
        {
            int tag = 0;
            foreach(Control control in groupbox.Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    tag += Convert.ToInt32(radioButton.Tag);
                }
                else if (control is CheckBox checkBox && checkBox.Checked)
                {
                    tag += Convert.ToInt32(checkBox.Tag);
                }
            }
            return tag;
        }

        void DefualtControls()
        {
            // Change Enabled And Color For Order And Rest Color
            OrderButton.Enabled = false;
            OrderButton.BackColor = Color.LightGreen;

            RestButton.Enabled = false;
            RestButton.BackColor = Color.AntiqueWhite;

            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbToppings.Enabled = true;

            lblSize.Text = "Nothing";
            lblCrust.Text = "Nothing";
            lblToppings.Text = "Nothing";
            lblWhereToEat.Text = "Nothing";
        }
        private void RestOrder()
        {
            // Rest Size
            ResetGroupBoxControls(gbSize);

            // Rest Crust Type
            ResetGroupBoxControls(gbCrustType);

            // Rest Where To Eat
            ResetGroupBoxControls(gbWhereToEat);

            // Rest Toppings
            ResetGroupBoxControls(gbToppings);

            DefualtControls();
        }

        private void ResetGroupBoxControls(GroupBox groupBox)
        {
            // Iterate through all controls in the group box
            foreach (Control control in groupBox.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false; // Uncheck the radio button
                }
                else
                {
                    (control as CheckBox).Checked = false; // Uncheck the CheckBox
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Check if one radio button from each group is selected
            bool isSizeSelected = rbSmall.Checked || rbMeduim.Checked || rbLarge.Checked;
            bool isCrustTypeSelected = rbThin.Checked || rbThink.Checked;
            bool isWhereToEatSelected = rbEatIn.Checked || rbTakeOut.Checked;

            // Enable the Reset and Order Button only if all groups have a selection
            RestButton.Enabled = isSizeSelected && isCrustTypeSelected && isWhereToEatSelected;
            OrderButton.Enabled = RestButton.Enabled;
            if (RestButton.Enabled)
            {
                OrderButton.BackColor = Color.GreenYellow;
                RestButton.BackColor = Color.Red;
            }
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
                RestOrder();
            }
        }

        int TotalPrice()
        {
            return GetTag(gbSize) + GetTag(gbCrustType) + GetTag(gbWhereToEat) + GetTag(gbToppings);
        }

        void UpdateTotalPrice()
        {
            lblPrice.Text = "$" + TotalPrice().ToString();
        }

        void UpdateToppings()
        {
            lblToppings.Text = "";
            // Initialize a list to store selected toppings
            List<string> selectedToppings = new List<string>();

            // Add toppings based on the checkboxes
            foreach (Control control in gbToppings.Controls)
            {
                if(control is CheckBox checkbox)
                {
                    if(checkbox.Checked)
                    {
                        selectedToppings.Add(checkbox.Text);
                    }
                }
            }

            // Format the label text
            if (selectedToppings.Count == 0)
            {
                lblToppings.Text = "Nothing";
            }
            else
            {
                for (int i = 0; i < selectedToppings.Count; i += 2)
                {
                    if (i + 1 < selectedToppings.Count)
                    {
                        // Add two toppings in the same line
                        lblToppings.Text += $"{selectedToppings[i]}, {selectedToppings[i + 1]}\n";
                    }
                    else
                    {
                        // Add the last topping if the count is odd
                        lblToppings.Text += $"{selectedToppings[i]}\n";
                    }
                }
            }
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            lblSize.Text = "Small";
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            lblSize.Text = "Meduim";
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            lblSize.Text = "Large";
        }

        private void rbThink_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            lblCrust.Text = "Think Crust";
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            lblCrust.Text = "Thin Crust";
        }

        private void ckbExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
            
        }

        private void ckbMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
        }

        private void ckbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
        }

        private void ckbOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
        }

        private void ckbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
        }

        private void ckbGreenPaper_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
            lblWhereToEat.Text = "Eat In";
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Take Out";
        }

        void EnabledStatus()
        {
            gbSize.Enabled = !gbSize.Enabled;
            gbCrustType.Enabled = !gbCrustType.Enabled;
            gbToppings.Enabled = !gbToppings.Enabled;
            gbWhereToEat.Enabled = !gbWhereToEat.Enabled;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            if (RestButton.Enabled)
            {
                EnabledStatus();
                if(MessageBox.Show("Confrim Order?", "Order Pizza", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    EnabledStatus();
                }
                else
                {
                    OrderButton.Enabled = false;
                    OrderButton.BackColor = Color.LightGreen;
                }
            }
        }

    }
}
