using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The NumberUpperCase method accepts a string argument
        // and returns the number of uppercase letters it contains.
        private int NumberUpperCase(string str)
        {
            int count = 0;
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    count++;
                }
            }
            return count;
        }

        // The NumberLowerCase method accepts a string argument
        // and returns the number of lowercase letters it contains.
        private int NumberLowerCase(string str)
        {
            int count = 0;
            foreach (char ch in str)
            {
                if (char.IsLower(ch))
                {
                    count++;
                }
            }
            return count;
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            int count=0;
            foreach (char ch in str)
            {
                if (char.IsDigit(ch))
                {
                    count++;
                }
            }
            return count;
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8;
            string password = passwordTextBox.Text;
            if (password.Length < MIN_LENGTH)
            {
                MessageBox.Show("密碼長度至少要8個字元");
                return;
            }
            int upperCaseCount = NumberUpperCase(password);
            int lowerCaseCount = NumberLowerCase(password);
            int digitCount = NumberDigits(password);
            if (upperCaseCount < 1)
            {
                MessageBox.Show("密碼至少要有一個大寫字母");
                return;
            }
            else if (lowerCaseCount < 1)
            {
                MessageBox.Show("密碼至少要有一個小寫字母");
                return;
            }
            else if (digitCount < 1)
            {
                MessageBox.Show("密碼至少要有一個數字");
                return;
            }
            MessageBox.Show("密碼驗證成功！");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }

        private void instructionsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
