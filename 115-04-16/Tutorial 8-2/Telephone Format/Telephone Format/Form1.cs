using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The IsValidNumber method accepts a string and
        // returns true if it contains 8 digits, or false
        // otherwise.
        private bool IsValidNumber(string str)
        {
            if (str == null || str.Length != 8)
            { return false; }
            // and all characters are digits.
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        // The TelephoneFormat method accepts a string argument
        // by reference and formats it as a telephone number.
        private void TelephoneFormat(ref string str)
        {
            // Assuming the format is (XXXX) XXXX
            string part1 = str.Substring(0, 4); // First 4 digits
            string part2 = str.Substring(4, 4); // Last 4 digits
            str = "(" + part1 + ") " + part2;
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            // Get the number from the numberTextBox.
            string number = numberTextBox.Text;

            // Check if the number is valid.
            if (IsValidNumber(number))
            {
                // Format the number as a telephone number.
                TelephoneFormat(ref number);

                // Display the formatted number in the numberTextBox.
                numberTextBox.Text = number;
            }
            else
            {
                // Show an error message if the number is not valid.
                MessageBox.Show("請輸入有效的8位數字號碼。", "無效的號碼", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
