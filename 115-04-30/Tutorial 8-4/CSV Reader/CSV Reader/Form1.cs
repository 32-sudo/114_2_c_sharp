using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var inputFile = File.OpenText("scores.csv"))
                {
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }

                        // 期望格式：班級,學號,姓名,score1,score2,score3,score4,score5
                        string[] fields = line.Split(',');
                        if (fields.Length == 8)
                        {
                            // 取出前三欄為班級、學號、姓名；後五欄為分數
                            string className = fields[0].Trim();
                            string studentId = fields[1].Trim();
                            string studentName = fields[2].Trim();

                            int total = 0;
                            bool parseError = false;
                            for (int i = 3; i <= 7; i++)
                            {
                                string s = fields[i].Trim();
                                int score;
                                if (!int.TryParse(s, out score))
                                {
                                    parseError = true;
                                    break;
                                }
                                total += score;
                            }

                            if (parseError)
                            {
                                MessageBox.Show("分數欄位格式錯誤: " + line, "格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                continue;
                            }

                            double average = (double)total / 5.0;
                            // 輸出格式：班級 學號 姓名 平均成績
                            averagesListBox.Items.Add(string.Format("{0} {1} {2} 平均成績: {3:F2}", className, studentId, studentName, average));
                        }
                        else
                        {
                            MessageBox.Show("資料欄位數量錯誤（預期 8 欄）: " + line, "資料格式錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取 csv 檔案時發生錯誤: " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void averagesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
