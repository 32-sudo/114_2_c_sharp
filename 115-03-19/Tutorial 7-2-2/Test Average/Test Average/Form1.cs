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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The Average method accepts an int array argument
        // and returns the Average of the values in the array.
        private double Average(int[] sArray  )
        {
            int total = 0; // Accumulator.
            for ( int i = 0; i < sArray.Length; i++)
            {
                total += sArray[i];
            }
            return (double)total / sArray.Length;
        }

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        private int Highest(int[]  sArray )
            { int highScore = 0;
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i]>highScore)
                {
                    highScore = sArray[i];
                }
            }
            return highScore;

        }

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        private int  Lowest(int[] sArray    )
        {
            int lowScore = 0;
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] < lowScore)
                {
                    lowScore = sArray[i];
                }
            }
            return lowScore;

        }
         private int getFileScoreCount()
        {             int count = 0; // To hold the number of scores.
            StreamReader inputFile; // To read the file.
            try
            {
                // Open the file and get a StreamReader object.
                inputFile = File.OpenText("TestScores.txt");
                // Read the test scores from the file and count them.
                while (!inputFile.EndOfStream)
                {
                    inputFile.ReadLine();
                    count++;
                }
                // Close the file.
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return count;
        }
        private void getScoresButton_Click(object sender, EventArgs e)
        {     int SIZE = 60; // Number of test scores.
            int[] scores = new int[SIZE]; // Array to hold the test scores.
            StreamReader inputFile; // To read the file.
            int index = 0; // Array subscript.

            try
                {
                // Open the file and get a StreamReader object.
                inputFile = File.OpenText("TestScores.txt");
                // Read the test scores from the file and store them in the array.
                while (!inputFile.EndOfStream && index < scores.Length)
                {
                    scores[index] = int.Parse(inputFile.ReadLine());
                    index++;
                }
                 
                // Close the file.
                inputFile.Close();
                // Display the test scores in the list box.
                for (int i = 0; i < index; i++)
                {
                    testScoresListBox.Items.Add(scores[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            averageScoreLabel.Text=Average(scores).ToString("n1");
            highScoreLabel.Text=Highest(scores).ToString();
            lowScoreLabel.Text=Lowest(scores).ToString();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
