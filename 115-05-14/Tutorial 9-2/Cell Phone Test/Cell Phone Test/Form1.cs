using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetPhoneData 方法接收一個 CellPhone 物件作為參數。
        /// 此方法會將使用者在表單上輸入的資料指派給該物件的屬性。
        /// 流程：依序讀取三個文字欄位（品牌、型號、價格）的內容，
        /// 並透過 CellPhone 物件的對應屬性進行賦值。
        /// </summary>
        /// <param name="phone">接收要填入資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 將使用者輸入的品牌文字指派給手機物件的品牌屬性
            phone.Brand = brandTextBox.Text;
            
            // 將使用者輸入的型號文字指派給手機物件的型號屬性
            phone.Model = modelTextBox.Text;
            
            // 嘗試將使用者輸入的價格文字轉換為小數
            if (decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                phone.Price = price;
            }
            else
            {
                // 若輸入的價格無效，顯示錯誤提示訊息
                MessageBox.Show("請輸入有效的價格。");
                phone.Price = 0; // 若轉換失敗，將價格設定為預設值 0
            }
        }

        /// <summary>
        /// createObjectButton_Click 按鈕點擊事件處理方法。
        /// 此方法在使用者按下「建立物件」按鈕時被觸發。
        /// 流程：建立新的 CellPhone 物件、呼叫 GetPhoneData 方法填入使用者輸入資料、
        /// 最後將物件屬性顯示在表單的輸出區域。
        /// </summary>
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            // 建立新的 CellPhone 物件實例
            CellPhone myPhone = new CellPhone();

            // 呼叫 GetPhoneData 方法，將使用者輸入的資料填入 CellPhone 物件
            GetPhoneData(myPhone);
            
            // 將 CellPhone 物件的品牌屬性顯示在對應的標籤上
            brandLabel.Text = myPhone.Brand;
            
            // 將 CellPhone 物件的型號屬性顯示在對應的標籤上
            modelLabel.Text = myPhone.Model;
            
            // 將 CellPhone 物件的價格屬性轉換為貨幣格式字串並顯示在標籤上
            priceLabel.Text = myPhone.Price.ToString("C");
        }

        /// <summary>
        /// exitButton_Click 按鈕點擊事件處理方法。
        /// 此方法在使用者按下「離開」按鈕時被觸發。
        /// 功能：關閉表單，結束應用程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式執行
            this.Close();
        }
    }
}
