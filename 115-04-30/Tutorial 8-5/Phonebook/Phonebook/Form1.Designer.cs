namespace Phonebook
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理使用中的資源。
        /// </summary>
        /// <param name="disposing">若為 true，表示要釋放受控資源；否則僅釋放非受控資源。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// 初始化元件（介面設定）
        /// 以下已將所有元件的顯示文字改為繁體中文，字型改為 18pt，
        /// 並適度調整每個元件的大小與位置以符合較大字型的顯示需求。
        /// 嚴格僅修改介面屬性，未新增或變更任何程式功能或事件處理邏輯。
        /// </summary>
        private void InitializeComponent()
        {
            this.promptLabel = new System.Windows.Forms.Label();
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.selectedPhoneDescriptionLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 注意：整體字型在此設定，子元件會繼承此字型以維持一致性
            // 設定為 18pt，使用系統預設字型（Microsoft Sans Serif）
            // 
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // promptLabel
            // 
            // promptLabel 用於顯示引導文字，提醒使用者從左側清單選擇聯絡人
            this.promptLabel.AutoSize = true;
            this.promptLabel.Location = new System.Drawing.Point(20, 12);
            this.promptLabel.Name = "promptLabel";
            // AutoSize = true，文字大小會依字型放大，因此不手動設 Size，只調整位置
            this.promptLabel.TabIndex = 0;
            this.promptLabel.Text = "請選擇姓名";
            // 
            // nameListBox
            // 
            // nameListBox 顯示所有聯絡人姓名，選取後會在右側顯示電話
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.ItemHeight = 29;
            this.nameListBox.Location = new System.Drawing.Point(20, 50);
            this.nameListBox.Name = "nameListBox";
            // 調整為較大尺寸以容納 18pt 字型與較多項目
            this.nameListBox.Size = new System.Drawing.Size(200, 176);
            this.nameListBox.TabIndex = 1;
            this.nameListBox.SelectedIndexChanged += new System.EventHandler(this.nameListBox_SelectedIndexChanged);
            // 
            // selectedPhoneDescriptionLabel
            // 
            // 描述用標籤，說明右側顯示欄位為電話號碼
            this.selectedPhoneDescriptionLabel.AutoSize = true;
            this.selectedPhoneDescriptionLabel.Location = new System.Drawing.Point(240, 50);
            this.selectedPhoneDescriptionLabel.Name = "selectedPhoneDescriptionLabel";
            this.selectedPhoneDescriptionLabel.TabIndex = 2;
            this.selectedPhoneDescriptionLabel.Text = "電話號碼";
            // 
            // phoneLabel
            // 
            // phoneLabel 為顯示電話號碼的欄位，使用單行邊框並置中顯示
            this.phoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phoneLabel.Location = new System.Drawing.Point(240, 90);
            this.phoneLabel.Name = "phoneLabel";
            // 調整為較寬高的顯示區域以容納大字體
            this.phoneLabel.Size = new System.Drawing.Size(220, 50);
            this.phoneLabel.TabIndex = 3;
            this.phoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 保持預設為空字串，實際內容由程式載入並顯示
            // 
            // exitButton
            // 
            // exitButton 提供關閉應用程式的按鈕，置於右下方容易觸及的位置
            this.exitButton.Location = new System.Drawing.Point(340, 180);
            this.exitButton.Name = "exitButton";
            // 調整按鈕大小以便觸控與可視性
            this.exitButton.Size = new System.Drawing.Size(120, 46);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "離開";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            // 調整視窗整體大小以符合放大的字型與元件配置
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // 客戶區域尺寸增加以避免擁擠
            this.ClientSize = new System.Drawing.Size(484, 241);
            // 加入所有元件到表單
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.selectedPhoneDescriptionLabel);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(this.promptLabel);
            this.Name = "Form1";
            // 視窗標題改為繁體中文
            this.Text = "電話簿";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.Label selectedPhoneDescriptionLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Button exitButton;
    }
}

