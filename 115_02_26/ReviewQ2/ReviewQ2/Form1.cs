using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReviewQ2
{
    public partial class Form1 : Form
    {
        // 常數定義
        private const decimal LABOR_RATE_PER_HOUR = 600m;
        private const decimal PARTS_TAX_RATE = 0.06m;

        // 資料結構
        private class ServiceRecord
        {
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public string VehicleNumber { get; set; }
            public string VehicleModel { get; set; }
            public DateTime ServiceDate { get; set; }
            public List<ServiceItem> Items { get; set; } = new List<ServiceItem>();
            public decimal PartsCost { get; set; }
            public decimal LaborHours { get; set; }
            public decimal TotalCost { get; set; }
        }

        private class ServiceItem
        {
            public string ServiceType { get; set; }
            public string ServiceName { get; set; }
            public decimal UnitPrice { get; set; }
        }

        // 全域變數
        private List<ServiceRecord> serviceRecords = new List<ServiceRecord>();
        private ServiceRecord currentRecord = null;

        public Form1()
        {
            InitializeComponent();
            InitializeEventHandlers();
            InitializeDataGridViews();
        }

        /// <summary>
        /// 初始化事件處理
        /// </summary>
        private void InitializeEventHandlers()
        {
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSearch.Click += BtnSearch_Click;
            btnExport.Click += BtnExport_Click;
            btnDetail.Click += BtnDetail_Click;
        }

        /// <summary>
        /// 初始化資料表格
        /// </summary>
        private void InitializeDataGridViews()
        {
            // 維修項目列表
            dataGridView1.Columns.Add("ServiceType", "服務類型");
            dataGridView1.Columns.Add("ServiceName", "服務名稱");
            dataGridView1.Columns.Add("UnitPrice", "單價 (元)");

            // 維修報表
            dgvReport.Columns.Add("CustomerName", "客戶姓名");
            dgvReport.Columns.Add("VehicleNumber", "車牌號碼");
            dgvReport.Columns.Add("ServiceDate", "服務日期");
            dgvReport.Columns.Add("TotalCost", "總費用");

            // 維修明細
            dgvDetail.Columns.Add("ServiceType", "服務類型");
            dgvDetail.Columns.Add("ServiceName", "服務名稱");
            dgvDetail.Columns.Add("UnitPrice", "單價 (元)");
        }

        /// <summary>
        /// 新增維修項目按鈕點擊事件
        /// </summary>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // 驗證輸入
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("請輸入服務名稱", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbServiceType.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇服務類型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice < 0)
            {
                MessageBox.Show("請輸入正確的單價", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 新增項目到表格
            dataGridView1.Rows.Add(
                cmbServiceType.SelectedItem.ToString(),
                txtServiceName.Text,
                unitPrice.ToString("N2")
            );

            ClearServiceItems();
        }

        /// <summary>
        /// 刪除維修項目按鈕點擊事件
        /// </summary>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("請先選擇要刪除的項目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        /// <summary>
        /// 查詢報表按鈕點擊事件
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReport.Rows.Clear();

                string customerName = txtSearchCustomer.Text.Trim();
                DateTime startDate = dtpStartDate.Value.Date;
                DateTime endDate = dtpEndDate.Value.Date;

                var filteredRecords = serviceRecords.Where(r =>
                    (string.IsNullOrEmpty(customerName) || r.CustomerName.Contains(customerName)) &&
                    r.ServiceDate >= startDate &&
                    r.ServiceDate <= endDate
                ).ToList();

                foreach (var record in filteredRecords)
                {
                    dgvReport.Rows.Add(
                        record.CustomerName,
                        record.VehicleNumber,
                        record.ServiceDate.ToString("yyyy-MM-dd"),
                        record.TotalCost.ToString("N2")
                    );
                }

                if (filteredRecords.Count == 0)
                {
                    MessageBox.Show("未找到符合條件的記錄", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查詢出錯: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 匯出報表按鈕點擊事件
        /// </summary>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "文字檔 (*.txt)|*.txt|CSV 檔 (*.csv)|*.csv",
                    DefaultExt = ".txt",
                    FileName = $"維修報表_{DateTime.Now:yyyyMMdd_HHmmss}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveReportToFile(saveFileDialog.FileName);
                    MessageBox.Show("報表已成功匯出", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"匯出出錯: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 查詢明細按鈕點擊事件
        /// </summary>
        private void BtnDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetailRecord.SelectedIndex == -1)
                {
                    MessageBox.Show("請先選擇維修紀錄", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvDetail.Rows.Clear();
                int selectedIndex = cmbDetailRecord.SelectedIndex;
                ServiceRecord record = serviceRecords[selectedIndex];

                foreach (var item in record.Items)
                {
                    dgvDetail.Rows.Add(
                        item.ServiceType,
                        item.ServiceName,
                        item.UnitPrice.ToString("N2")
                    );
                }

                // 更新費用統計
                CalculateAndDisplayCosts(record);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查詢明細出錯: {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 計算機油和潤滑服務費用
        /// </summary>
        private decimal OilLubeCharges(List<ServiceItem> items)
        {
            return items
                .Where(i => i.ServiceType == "引擎維修" || i.ServiceType == "其他")
                .Sum(i => i.UnitPrice);
        }

        /// <summary>
        /// 計算清洗服務費用
        /// </summary>
        private decimal FlushCharges(List<ServiceItem> items)
        {
            return items
                .Where(i => i.ServiceType == "煞車系統" || i.ServiceType == "輪胎更換")
                .Sum(i => i.UnitPrice);
        }

        /// <summary>
        /// 計算其他服務費用
        /// </summary>
        private decimal MiscCharges(List<ServiceItem> items)
        {
            return items
                .Where(i => i.ServiceType == "冷氣維修" || i.ServiceType == "電氣系統")
                .Sum(i => i.UnitPrice);
        }

        /// <summary>
        /// 計算零件和工時費用
        /// </summary>
        private decimal OtherCharges(decimal laborHours, decimal partsCost)
        {
            return (laborHours * LABOR_RATE_PER_HOUR) + partsCost;
        }

        /// <summary>
        /// 計算稅金（零件 6% 稅率）
        /// </summary>
        private decimal TaxCharges(decimal partsCost)
        {
            return partsCost * PARTS_TAX_RATE;
        }

        /// <summary>
        /// 計算所有費用總和
        /// </summary>
        private decimal TotalCharges(List<ServiceItem> items, decimal laborHours, decimal partsCost)
        {
            decimal oilLube = OilLubeCharges(items);
            decimal flush = FlushCharges(items);
            decimal misc = MiscCharges(items);
            decimal other = OtherCharges(laborHours, partsCost);
            decimal tax = TaxCharges(partsCost);

            return oilLube + flush + misc + other + tax;
        }

        /// <summary>
        /// 計算並顯示費用
        /// </summary>
        private void CalculateAndDisplayCosts(ServiceRecord record)
        {
            decimal partsCost = record.PartsCost;
            decimal laborCost = record.LaborHours * LABOR_RATE_PER_HOUR;
            decimal taxCost = TaxCharges(partsCost);
            decimal totalCost = record.TotalCost;

            lblTotalParts.Text = partsCost.ToString("N2");
            lblTotalLabor.Text = laborCost.ToString("N2");
            lblTotalCost.Text = totalCost.ToString("N2");
        }

        /// <summary>
        /// 清除服務項目輸入框
        /// </summary>
        private void ClearServiceItems()
        {
            ClearOther();
        }

        /// <summary>
        /// 清除機油潤滑選項
        /// </summary>
        private void ClearOilLube()
        {
            // 可擴展實現
        }

        /// <summary>
        /// 清除清洗服務選項
        /// </summary>
        private void ClearFlushes()
        {
            // 可擴展實現
        }

        /// <summary>
        /// 清除其他服務選項
        /// </summary>
        private void ClearMisc()
        {
            // 可擴展實現
        }

        /// <summary>
        /// 清除零件和工時輸入
        /// </summary>
        private void ClearOther()
        {
            txtServiceName.Clear();
            txtUnitPrice.Clear();
            cmbServiceType.SelectedIndex = -1;
        }

        /// <summary>
        /// 清除費用顯示
        /// </summary>
        private void ClearFees()
        {
            lblTotalParts.Text = "0";
            lblTotalLabor.Text = "0";
            lblTotalCost.Text = "0";
        }

        /// <summary>
        /// 儲存維修明細到檔案
        /// </summary>
        private void SaveServiceDetailsToFile(string filePath, ServiceRecord record)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("========== 汽車維修服務明細 ==========");
                    writer.WriteLine($"客戶姓名: {record.CustomerName}");
                    writer.WriteLine($"電話號碼: {record.CustomerPhone}");
                    writer.WriteLine($"車牌號碼: {record.VehicleNumber}");
                    writer.WriteLine($"車輛型號: {record.VehicleModel}");
                    writer.WriteLine($"服務日期: {record.ServiceDate:yyyy-MM-dd}");
                    writer.WriteLine();

                    writer.WriteLine("--- 維修項目 ---");
                    foreach (var item in record.Items)
                    {
                        writer.WriteLine($"服務類型: {item.ServiceType}");
                        writer.WriteLine($"服務名稱: {item.ServiceName}");
                        writer.WriteLine($"費用: NT${item.UnitPrice:N2}");
                        writer.WriteLine();
                    }

                    writer.WriteLine("--- 費用統計 ---");
                    writer.WriteLine($"零件費: NT${record.PartsCost:N2}");
                    writer.WriteLine($"勞務費 ({record.LaborHours}小時): NT${record.LaborHours * LABOR_RATE_PER_HOUR:N2}");
                    writer.WriteLine($"稅金 (6%): NT${TaxCharges(record.PartsCost):N2}");
                    writer.WriteLine($"總費用: NT${record.TotalCost:N2}");
                    writer.WriteLine("=====================================");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"儲存檔案失敗: {ex.Message}");
            }
        }

        /// <summary>
        /// 儲存報表到檔案
        /// </summary>
        private void SaveReportToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("========== 汽車維修服務報表 ==========");
                    writer.WriteLine($"生成時間: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    writer.WriteLine();

                    writer.WriteLine("客戶姓名\t車牌號碼\t服務日期\t總費用");
                    writer.WriteLine(new string('-', 60));

                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        string customerName = row.Cells["CustomerName"].Value?.ToString() ?? "";
                        string vehicleNumber = row.Cells["VehicleNumber"].Value?.ToString() ?? "";
                        string serviceDate = row.Cells["ServiceDate"].Value?.ToString() ?? "";
                        string totalCost = row.Cells["TotalCost"].Value?.ToString() ?? "0";

                        writer.WriteLine($"{customerName}\t{vehicleNumber}\t{serviceDate}\t NT${totalCost}");
                    }

                    writer.WriteLine(new string('-', 60));
                    writer.WriteLine($"總記錄數: {dgvReport.Rows.Count}");
                    writer.WriteLine("=====================================");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"匯出報表失敗: {ex.Message}");
            }
        }
    }
}
