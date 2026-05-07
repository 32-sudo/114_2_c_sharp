using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 遊戲狀態變數
        private decimal balance = 0;              // 目前餘額
        private decimal totalDeposited = 0;       // 累計存入金額
        private int totalSpins = 0;               // 總旋轉次數
        private int totalWins = 0;                // 總中獎次數
        private decimal lastWinAmount = 0;        // 上次獲得金額
        private bool isSpinning = false;          // 是否正在旋轉

        // 水果配對及獎金設定
        private Dictionary<int, string> fruitNames = new Dictionary<int, string>()
            {
                { 0, "橘子" }, { 1, "檸檬" }, { 2, "葡萄" }, { 3, "西瓜" }, { 4, "蘋果" },
                { 5, "香蕉" }, { 6, "草莓" }, { 7, "櫻桃" }, { 8, "水蜜桃" }, { 9, "鳳梨" }
            };

        // 獎金倍數（根據配對情況）
        private Dictionary<string, decimal> winMultipliers = new Dictionary<string, decimal>()
            {
                { "頭獎", 10m },           // 三個相同：下注金額 × 10
                { "普獎", 2m },            // 雙個相同：下注金額 × 2
                { "未中獎", 0m }           // 無配對：0
            };

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 8.1 Form1_Load - 程式啟動
        /// 職責：初始化下注選項；顯示初始圖片
        /// </summary>
        /// <summary>
        /// 8.1 Form1_Load - 程式啟動
        /// 職責：初始化下注選項；顯示初始圖片
        /// </summary>
            private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化 ImageList（10 種水果圖片）
            // 注意：您需要自行添加 10 張水果圖片到 imageList1
            // 可以在設計工具中右鍵點擊 imageList1 > Images 來添加圖片

            // 設定下注金額預設值
            comboBox_bet.SelectedIndex = 0;

            // 更新介面顯示
            UpdateUI();
        }

        /// <summary>
        /// 存入金額功能
        /// </summary>
        private void button_deposit_Click(object sender, EventArgs e)
        {
            // 驗證輸入：必須為整數
            if (!int.TryParse(textBox_deposit.Text, out int depositAmount))
            {
                MessageBox.Show("請輸入有效的存入金額（必須為正整數）", "錯誤");
                return;
            }

            // 驗證金額：必須大於 0
            if (depositAmount <= 0)
            {
                MessageBox.Show("請輸入有效的存入金額（必須為正整數）", "錯誤");
                return;
            }

            // 驗證通過後，執行存入邏輯
            balance += depositAmount;
            totalDeposited += depositAmount;

            // 清空輸入方塊
            textBox_deposit.Clear();

            // 更新介面
            UpdateUI();

            MessageBox.Show($"已存入：NT${depositAmount}，目前餘額：NT${balance:F2}", "存入成功");
        }

        /// <summary>
        /// 旋轉按鈕功能
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            // 檢查程式剛啟動（balance = 0）
            if (balance == 0)
            {
                MessageBox.Show("請先存入金額才能開始遊戲", "提示");
                return;
            }

            // 檢查是否正在旋轉
            if (isSpinning)
            {
                MessageBox.Show("旋轉進行中，請稍候...");
                return;
            }

            // 取得下注金額
            string betText = comboBox_bet.SelectedItem.ToString().TrimStart('$');
            if (!decimal.TryParse(betText, out decimal betAmount))
            {
                MessageBox.Show("下注金額錯誤");
                return;
            }

            // 檢查餘額是否足夠（balance < 目前下注金額）
            if (balance < betAmount)
            {
                MessageBox.Show("餘額不足，無法進行遊戲", "錯誤");
                return;
            }

            // 餘額足夠，啟用旋轉按鈕
            // 扣除下注金額
            balance -= betAmount;

            // 執行旋轉
            isSpinning = true;
            button1.Enabled = false;
            comboBox_bet.Enabled = false;

            // 模擬旋轉動畫（使用 Timer 或非同步執行）
            PerformSpin(betAmount);
        }

        /// <summary>
        /// 執行旋轉邏輯
        /// </summary>
        private void PerformSpin(decimal betAmount)
        {
            // 隨機產生三個轉輪的圖片索引
            Random random = new Random();
            int n1 = random.Next(0, 10);
            int n2 = random.Next(0, 10);
            int n3 = random.Next(0, 10);

            // 顯示轉輪圖片
            if (imageList1.Images.Count >= 10)
            {
                pictureBox1.Image = imageList1.Images[n1];
                pictureBox2.Image = imageList1.Images[n2];
                pictureBox3.Image = imageList1.Images[n3];
            }

            // 呼叫勝負判斷
            CheckWin(n1, n2, n3, betAmount);

            // 旋轉完成
            isSpinning = false;
            button1.Enabled = true;
            comboBox_bet.Enabled = true;

            // 5.2 UpdateStats() - 更新統計資訊
            UpdateStats();

            // 5.1 UpdateUI() - 更新介面顯示
            UpdateUI();
        }

        /// <summary>
        /// 勝負判斷邏輯（根據 4.4 需求）
        /// </summary>
        private void CheckWin(int n1, int n2, int n3, decimal betAmount)
        {
            totalSpins++;
            lastWinAmount = 0;
            string winType = "未中獎";

            // 4.4 勝負判斷與獎金
            // 檢查三個圖片是否完全相同（頭獎：n1 == n2 == n3）
            if (n1 == n2 && n2 == n3)
            {
                winType = "頭獎";
                decimal prize = betAmount * winMultipliers["頭獎"];

                // 計算出的獎金加回 balance
                lastWinAmount = prize;
                balance += lastWinAmount;

                // prize > 0 即計入中獎次數
                if (prize > 0)
                {
                    totalWins++;
                }

                MessageBox.Show(
                    $"恭喜！頭獎！\n三個 {fruitNames[n1]} 相同\n獲得獎金：NT${lastWinAmount}",
                    "中獎"
                );
            }
            // 檢查是否有任意兩個相同（普獎）
            else if (n1 == n2 || n2 == n3 || n1 == n3)
            {
                winType = "普獎";
                decimal prize = betAmount * winMultipliers["普獎"];

                // 計算出的獎金加回 balance
                lastWinAmount = prize;
                balance += lastWinAmount;

                // prize > 0 即計入中獎次數
                if (prize > 0)
                {
                    totalWins++;
                }

                MessageBox.Show(
                    $"恭喜！普獎！\n有雙個圖片相同\n獲得獎金：NT${lastWinAmount}",
                    "中獎"
                );
            }
            // 三個圖案均不同（未中獎）
            else
            {
                winType = "未中獎";
                lastWinAmount = 0;

                MessageBox.Show(
                    "很遺憾，這次沒有中獎。\n繼續加油，下次一定會贏！",
                    "未中獎"
                );
            }
        }

        /// <summary>
        /// 5.1 UpdateUI() - 介面即時更新規格
        /// 每次餘額或獎金改變後呼叫，更新以下項目
        /// </summary>
        private void UpdateUI()
        {
            // label_balance.Text → "餘額：" + balance.ToString("c")
            label_balance.Text = $"餘額：{balance:c}";

            // label_lastWin.Text → "本次獲得：" + prize.ToString("c")
            label_lastWin.Text = $"本次獲得：{lastWinAmount:c}";

            // 依 balance >= 下注金額 決定「旋轉」按鈕用狀態
            // 4.5 旋轉按鈕狀態
            // 條件1：程式剛啟動（balance = 0）→ 停用
            // 條件2：balance < 目前下注金額 → 停用
            // 條件3：balance >= 目前下注金額 → 啟用

            if (balance == 0)
            {
                button1.Enabled = false;
                comboBox_bet.Enabled = false;
            }
            else
            {
                // 取得目前下注金額
                string betText = comboBox_bet.SelectedItem?.ToString().TrimStart('$') ?? "1";
                if (decimal.TryParse(betText, out decimal currentBet))
                {
                    if (balance < currentBet)
                    {
                        button1.Enabled = false;
                    }
                    else
                    {
                        button1.Enabled = true;
                        comboBox_bet.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// 5.2 UpdateStats() - 統計資訊更新規格
        /// 每次旋轉結束後呼叫，更新以下項目
        /// </summary>
        private void UpdateStats()
        {
            // label_totalSpins.Text → "旋轉：N 次"
            label_totalSpins.Text = $"旋轉：{totalSpins} 次";

            // label_winCount.Text → "中獎：N 次"
            label_winCount.Text = $"中獎：{totalWins} 次";

            // label_winRate.Text → "勝率：XX.X%" (winCount / totalSpins * 100，保留一位小數)
            // 當 totalSpins = 0 時勝率顯示 0.0% (避免除以零)
            double winRate = totalSpins > 0 ? (double)totalWins / totalSpins * 100 : 0.0;
            label_winRate.Text = $"勝率：{winRate:F1}%";
        }

        /// <summary>
        /// 下注金額變更事件
        /// </summary>
        private void comboBox_bet_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 下注金額改變時，重新檢查按鈕狀態
            UpdateUI();
        }

        /// <summary>
        /// 離開按鈕功能
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            // 6. 結算與離開
            // 按下「離開」按鈕後：

            // 1. 計算 netGain = balance - totalDeposited
            decimal netGain = balance - totalDeposited;

            // 2. 以訊息方塊顯示：
            string message = $"遊戲結算報告\n\n" +
                           $"累計存入：${totalDeposited:F2}\n" +
                           $"目前餘額：${balance:F2}\n" +
                           $"淨獲利：${netGain:F2}\n\n" +
                           $"旋轉次數：{totalSpins} 次\n" +
                           $"中獎次數：{totalWins} 次";

            MessageBox.Show(message, "遊戲結算報告", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 關閉程式
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
