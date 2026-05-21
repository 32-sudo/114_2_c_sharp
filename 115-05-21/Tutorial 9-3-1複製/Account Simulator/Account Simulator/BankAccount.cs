using System;
using System.Windows.Forms;

namespace Account_Simulator
{
    public partial class Form1 : Form
    {
        private BankAccount account = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化按鈕狀態
            button2.Enabled = false;  // 存入
            button4.Enabled = false;  // 提取
            button5.Enabled = false;  // 查詢交易
        }

        // 建立帳戶
        private void button1_Click(object sender, EventArgs e)
        {
            string accountNumber = textBox1.Text?.Trim() ?? string.Empty;
            string name = textBox2.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(accountNumber))
            {
                MessageBox.Show("請輸入帳號。", "錯誤");
                return;
            }

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("請輸入姓名。", "錯誤");
                return;
            }

            if (!decimal.TryParse(textBox3.Text, out decimal initialBalance))
            {
                MessageBox.Show("請輸入有效的開戶金額。", "錯誤");
                return;
            }

            if (initialBalance < 0m)
            {
                MessageBox.Show("開戶金額不能為負數。", "錯誤");
                return;
            }

            try
            {
                account = new BankAccount(initialBalance, accountNumber, name);

                // 啟用相關按鈕
                button2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;

                // 禁用建立帳戶的輸入欄位
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;

                // 顯示帳戶資訊
                DisplayAccountInfo();

                MessageBox.Show("帳戶建立成功！", "成功");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 存入
        private void button2_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("請先建立帳戶。", "錯誤");
                return;
            }

            if (!decimal.TryParse(textBox5.Text, out decimal amount))
            {
                MessageBox.Show("請輸入有效的金額。", "錯誤");
                return;
            }

            try
            {
                account.Deposit(amount);
                DisplayAccountInfo();
                textBox5.Clear();
                MessageBox.Show("存款成功。", "成功");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 提取
        private void button4_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("請先建立帳戶。", "錯誤");
                return;
            }

            if (!decimal.TryParse(textBox6.Text, out decimal amount))
            {
                MessageBox.Show("請輸入有效的金額。", "錯誤");
                return;
            }

            try
            {
                if (!account.Withdraw(amount))
                {
                    MessageBox.Show("餘額不足，無法提款。", "錯誤");
                }
                else
                {
                    DisplayAccountInfo();
                    textBox6.Clear();
                    MessageBox.Show("提款成功。", "成功");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        // 查詢交易
        private void button5_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("請先建立帳戶。", "錯誤");
                return;
            }

            richTextBox1.Clear();
            richTextBox1.Text = account.GetTransactionHistory();
        }

        // 離開
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 顯示帳戶資訊
        private void DisplayAccountInfo()
        {
            if (account == null)
            {
                richTextBox1.Clear();
                return;
            }

            richTextBox1.Clear();
            richTextBox1.AppendText("=== 帳戶資訊 ===\n");
            richTextBox1.AppendText($"帳號：{account.AccountNumber}\n");
            richTextBox1.AppendText($"姓名：{account.Name}\n");
            richTextBox1.AppendText($"餘額：{account.Balance:C}\n");
            richTextBox1.AppendText("\n");
        }
    }
}
