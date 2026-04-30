using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.
        private List<PhoneBookEntry> phoneList = 
            new List<PhoneBookEntry>();
      
        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the
        // PhoneList.txt file and stores it as PhoneBookEntry
        // objects in the phoneList.
        private void ReadFile()
        {
            try
            {
                StreamReader inputfile;
                string line;
                char[] delim = { ',' };
                PhoneBookEntry entry = new PhoneBookEntry();

                // Open the file for reading.
                using (inputfile = File.OpenText("PhoneList.txt"))
                {
                    // Read the file until the end is reached.
                    while (!inputfile.EndOfStream)
                    {
                        // Read a line from the file.
                        line = inputfile.ReadLine();
                        // Split the line into name and phone number.
                        string[] fields = line.Split(delim);
                        // Store the name and phone number in an entry.
                        entry.name = fields[0];
                        entry.phone = fields[1];
                        // Add the entry to the list.
                        phoneList.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show("讀取檔案時發生錯誤 " + ex.Message);
            }
        }

        // The DisplayNames method displays the list of names
        // in the namesListBox control.
        private void DisplayNames()
        {
           foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Read the PhoneList.txt file.
            ReadFile();

            // Display the names.
            DisplayNames();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1)
            {
                phoneLabel.Text = phoneList[index].phone;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
