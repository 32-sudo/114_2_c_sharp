#nullable disable
using System.Text;

namespace Review_Q2
{
    public partial class Form1 : Form
    {
        // 服務收費標準（新台幣）
        private const decimal OilChangeFee = 780m;
        private const decimal LubricationFee = 540m;
        private const decimal RadiatorCleaningFee = 900m;
        private const decimal TransmissionCleaningFee = 2400m;
        private const decimal InspectionFee = 450m;
        private const decimal MufflerReplacementFee = 3000m;
        private const decimal TireRotationFee = 600m;
        private const decimal LaborRatePerHour = 600m;  
        private const decimal TaxRate = 0.06m;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // 計算服務費用
                decimal serviceFee = CalculateServiceFee();

                // 取得零件費用
                if (!decimal.TryParse(txtPartsPrice.Text, out decimal partsCost))
                {
                    MessageBox.Show("零件費用輸入有誤，請輸入有效的數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 取得工時數
                if (!decimal.TryParse(txtLaborHours.Text, out decimal laborHours))
                {
                    MessageBox.Show("工時數輸入有誤，請輸入有效的數字。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (laborHours < 0)
                {
                    MessageBox.Show("工時數不可為負數。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (partsCost < 0)
                {
                    MessageBox.Show("零件費用不可為負數。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 計算工時費用
                decimal laborFee = laborHours * LaborRatePerHour;

                // 計算稅金（僅對零件收取）
                decimal tax = partsCost * TaxRate;

                // 計算總費用
                // 總費用 = 服務費用 + 工時費用 + 零件費用 + 稅金
                decimal totalFee = serviceFee + laborFee + partsCost + tax;

                // 更新顯示
                txtServiceAndLabor.Text = $"NT${serviceFee + laborFee:N0}";
                txtPartsTotal.Text = $"NT${partsCost:N0}";
                txtTax.Text = $"NT${tax:N0}";
                txtTotal.Text = $"NT${totalFee:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"計算過程中發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateServiceFee()
        {
            decimal serviceFee = 0m;

            if (chkOilChange.Checked)
                serviceFee += OilChangeFee;

            if (chkLubrication.Checked)
                serviceFee += LubricationFee;

            if (chkRadiatorCleaning.Checked)
                serviceFee += RadiatorCleaningFee;

            if (chkTransmissionCleaning.Checked)
                serviceFee += TransmissionCleaningFee;

            if (chkInspection.Checked)
                serviceFee += InspectionFee;

            if (chkMufflerReplacement.Checked)
                serviceFee += MufflerReplacementFee;

            if (chkTireRotation.Checked)
                serviceFee += TireRotationFee;

            return serviceFee;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // 清除所有勾選
            chkOilChange.Checked = false;
            chkLubrication.Checked = false;
            chkRadiatorCleaning.Checked = false;
            chkTransmissionCleaning.Checked = false;
            chkInspection.Checked = false;
            chkMufflerReplacement.Checked = false;
            chkTireRotation.Checked = false;

            // 清除輸入欄位
            txtPartsPrice.Text = "0";
            txtLaborHours.Text = "0";

            // 清除費用顯示
            txtServiceAndLabor.Text = "NT$0";
            txtPartsTotal.Text = "NT$0";
            txtTax.Text = "NT$0";
            txtTotal.Text = "NT$0";
        }

        private void BtnSaveReport_Click(object sender, EventArgs e)
        {
            try
            {
                // 檢查是否有計算過結果
                if (txtTotal.Text == "NT$0" && !HasAnyService())
                {
                    MessageBox.Show("請先計算費用後再儲存報表。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
                    saveFileDialog.DefaultExt = "txt";
                    saveFileDialog.FileName = $"維修報表_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveReportToFile(saveFileDialog.FileName);
                        MessageBox.Show("報表已成功儲存。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"儲存報表時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveReportToFile(string filePath)
        {
            StringBuilder report = new StringBuilder();

            // 報表頭部
            report.AppendLine("════════════════════════════════════════");
            report.AppendLine("        汽車維修服務費用計算報表");
            report.AppendLine("════════════════════════════════════════");
            report.AppendLine();

            // 日期時間
            report.AppendLine($"報表日期：{DateTime.Now:yyyy年MM月dd日 HH:mm:ss}");
            report.AppendLine();

            // 服務項目
            report.AppendLine("【服務項目明細】");
            report.AppendLine("────────────────────────────────────────");
            
            decimal selectedServiceFee = 0m;

            if (chkOilChange.Checked)
            {
                report.AppendLine($"✓ 機油更換                    NT${OilChangeFee:N0}");
                selectedServiceFee += OilChangeFee;
            }

            if (chkLubrication.Checked)
            {
                report.AppendLine($"✓ 潤滑保養                    NT${LubricationFee:N0}");
                selectedServiceFee += LubricationFee;
            }

            if (chkRadiatorCleaning.Checked)
            {
                report.AppendLine($"✓ 水箱清洗                    NT${RadiatorCleaningFee:N0}");
                selectedServiceFee += RadiatorCleaningFee;
            }

            if (chkTransmissionCleaning.Checked)
            {
                report.AppendLine($"✓ 變速箱清洗                  NT${TransmissionCleaningFee:N0}");
                selectedServiceFee += TransmissionCleaningFee;
            }

            if (chkInspection.Checked)
            {
                report.AppendLine($"✓ 檢驗                        NT${InspectionFee:N0}");
                selectedServiceFee += InspectionFee;
            }

            if (chkMufflerReplacement.Checked)
            {
                report.AppendLine($"✓ 更換消音器                  NT${MufflerReplacementFee:N0}");
                selectedServiceFee += MufflerReplacementFee;
            }

            if (chkTireRotation.Checked)
            {
                report.AppendLine($"✓ 輪胎換位                    NT${TireRotationFee:N0}");
                selectedServiceFee += TireRotationFee;
            }

            if (selectedServiceFee == 0)
            {
                report.AppendLine("（無選定服務項目）");
            }

            report.AppendLine();

            // 費用計算過程
            report.AppendLine("【費用計算明細】");
            report.AppendLine("────────────────────────────────────────");

            // 解析各項費用
            string serviceFeeText = txtServiceAndLabor.Text.Replace("NT$", "").Replace(",", "");
            string partsTotalText = txtPartsTotal.Text.Replace("NT$", "").Replace(",", "");
            string taxText = txtTax.Text.Replace("NT$", "").Replace(",", "");
            string totalFeeText = txtTotal.Text.Replace("NT$", "").Replace(",", "");

            decimal.TryParse(serviceFeeText, out decimal serviceFee);
            decimal.TryParse(partsTotalText, out decimal partsCost);
            decimal.TryParse(taxText, out decimal tax);
            decimal.TryParse(totalFeeText, out decimal totalFee);

            report.AppendLine($"服務與工資費用               NT${serviceFee:N0}");
            
            if (partsCost > 0)
            {
                report.AppendLine($"零件費用                      NT${partsCost:N0}");
            }

            if (tax > 0)
            {
                report.AppendLine($"  └─ 稅金 (6%)                NT${tax:N0}");
            }

            report.AppendLine("────────────────────────────────────────");
            report.AppendLine($"總費用                        NT${totalFee:N0}");
            report.AppendLine("════════════════════════════════════════");
            report.AppendLine();

            // 備註
            report.AppendLine("【計算說明】");
            report.AppendLine($"• 工時費率：NT${LaborRatePerHour:N0}/小時");
            report.AppendLine($"• 零件稅率：{TaxRate * 100:F0}%（僅對零件費用計算）");
            report.AppendLine($"• 計算公式：");
            report.AppendLine($"  服務與工資總額 = 服務費用 + 工時費用");
            report.AppendLine($"  稅金 = 零件費用 × {TaxRate * 100:F0}%");
            report.AppendLine($"  總費用 = 服務費用 + 工時費用 + 零件費用 + 稅金");

            // 寫入檔案
            File.WriteAllText(filePath, report.ToString(), Encoding.UTF8);
        }

        private bool HasAnyService()
        {
            return chkOilChange.Checked || chkLubrication.Checked || 
                   chkRadiatorCleaning.Checked || chkTransmissionCleaning.Checked ||
                   chkInspection.Checked || chkMufflerReplacement.Checked || 
                   chkTireRotation.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 在程式結束前詢問是否需要儲存明細
            if (HasAnyService() || txtTotal.Text != "NT$0")
            {
                DialogResult result = MessageBox.Show(
                    "是否需要在結束前儲存維修明細報表？",
                    "確認",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    BtnSaveReport_Click(null, null);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
