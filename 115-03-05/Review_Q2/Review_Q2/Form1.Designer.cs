namespace Review_Q2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxOilAndLubrication = new System.Windows.Forms.GroupBox();
            this.chkOilChange = new System.Windows.Forms.CheckBox();
            this.chkLubrication = new System.Windows.Forms.CheckBox();
            this.groupBoxCleaning = new System.Windows.Forms.GroupBox();
            this.chkRadiatorCleaning = new System.Windows.Forms.CheckBox();
            this.chkTransmissionCleaning = new System.Windows.Forms.CheckBox();
            this.groupBoxOtherServices = new System.Windows.Forms.GroupBox();
            this.chkInspection = new System.Windows.Forms.CheckBox();
            this.chkMufflerReplacement = new System.Windows.Forms.CheckBox();
            this.chkTireRotation = new System.Windows.Forms.CheckBox();
            this.groupBoxPartsAndLabor = new System.Windows.Forms.GroupBox();
            this.labelPartsPrice = new System.Windows.Forms.Label();
            this.txtPartsPrice = new System.Windows.Forms.TextBox();
            this.labelLaborHours = new System.Windows.Forms.Label();
            this.txtLaborHours = new System.Windows.Forms.TextBox();
            this.groupBoxCalculation = new System.Windows.Forms.GroupBox();
            this.labelServiceAndLabor = new System.Windows.Forms.Label();
            this.txtServiceAndLabor = new System.Windows.Forms.TextBox();
            this.labelPartsTotal = new System.Windows.Forms.Label();
            var textBox = this.txtPartsTotal = new System.Windows.Forms.TextBox();
            using var _ = textBox;
            this.labelTax = new System.Windows.Forms.Label();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBoxOilAndLubrication.SuspendLayout();
            this.groupBoxCleaning.SuspendLayout();
            this.groupBoxOtherServices.SuspendLayout();
            this.groupBoxPartsAndLabor.SuspendLayout();
            this.groupBoxCalculation.SuspendLayout();
            this.SuspendLayout();

            // groupBoxOilAndLubrication (左上)
            this.groupBoxOilAndLubrication.Controls.Add(this.chkOilChange);
            this.groupBoxOilAndLubrication.Controls.Add(this.chkLubrication);
            this.groupBoxOilAndLubrication.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOilAndLubrication.Name = "groupBoxOilAndLubrication";
            this.groupBoxOilAndLubrication.Size = new System.Drawing.Size(195, 80);
            this.groupBoxOilAndLubrication.TabIndex = 0;
            this.groupBoxOilAndLubrication.TabStop = false;
            this.groupBoxOilAndLubrication.Text = "機油與潤滑";

            // chkOilChange
            this.chkOilChange.AutoSize = true;
            this.chkOilChange.Location = new System.Drawing.Point(15, 25);
            this.chkOilChange.Name = "chkOilChange";
            this.chkOilChange.Size = new System.Drawing.Size(170, 19);
            this.chkOilChange.TabIndex = 0;
            this.chkOilChange.Text = "更換機油 (NT$780)";
            this.chkOilChange.UseVisualStyleBackColor = true;

            // chkLubrication
            this.chkLubrication.AutoSize = true;
            this.chkLubrication.Location = new System.Drawing.Point(15, 50);
            this.chkLubrication.Name = "chkLubrication";
            this.chkLubrication.Size = new System.Drawing.Size(170, 19);
            this.chkLubrication.TabIndex = 1;
            this.chkLubrication.Text = "潤滑保養 (NT$540)";
            this.chkLubrication.UseVisualStyleBackColor = true;

            // groupBoxCleaning (右上)
            this.groupBoxCleaning.Controls.Add(this.chkRadiatorCleaning);
            this.groupBoxCleaning.Controls.Add(this.chkTransmissionCleaning);
            this.groupBoxCleaning.Location = new System.Drawing.Point(225, 12);
            this.groupBoxCleaning.Name = "groupBoxCleaning";
            this.groupBoxCleaning.Size = new System.Drawing.Size(220, 80);
            this.groupBoxCleaning.TabIndex = 1;
            this.groupBoxCleaning.TabStop = false;
            this.groupBoxCleaning.Text = "清洗服務";

            // chkRadiatorCleaning
            this.chkRadiatorCleaning.AutoSize = true;
            this.chkRadiatorCleaning.Location = new System.Drawing.Point(15, 25);
            this.chkRadiatorCleaning.Name = "chkRadiatorCleaning";
            this.chkRadiatorCleaning.Size = new System.Drawing.Size(190, 19);
            this.chkRadiatorCleaning.TabIndex = 0;
            this.chkRadiatorCleaning.Text = "水箱清洗 (NT$900)";
            this.chkRadiatorCleaning.UseVisualStyleBackColor = true;

            // chkTransmissionCleaning
            this.chkTransmissionCleaning.AutoSize = true;
            this.chkTransmissionCleaning.Location = new System.Drawing.Point(15, 50);
            this.chkTransmissionCleaning.Name = "chkTransmissionCleaning";
            this.chkTransmissionCleaning.Size = new System.Drawing.Size(210, 19);
            this.chkTransmissionCleaning.TabIndex = 1;
            this.chkTransmissionCleaning.Text = "變速箱清洗 (NT$2,400)";
            this.chkTransmissionCleaning.UseVisualStyleBackColor = true;

            // groupBoxOtherServices (左中)
            this.groupBoxOtherServices.Controls.Add(this.chkInspection);
            this.groupBoxOtherServices.Controls.Add(this.chkMufflerReplacement);
            this.groupBoxOtherServices.Controls.Add(this.chkTireRotation);
            this.groupBoxOtherServices.Location = new System.Drawing.Point(12, 102);
            this.groupBoxOtherServices.Name = "groupBoxOtherServices";
            this.groupBoxOtherServices.Size = new System.Drawing.Size(433, 80);
            this.groupBoxOtherServices.TabIndex = 2;
            this.groupBoxOtherServices.TabStop = false;
            this.groupBoxOtherServices.Text = "其他維修";

            // chkInspection
            this.chkInspection.AutoSize = true;
            this.chkInspection.Location = new System.Drawing.Point(15, 25);
            this.chkInspection.Name = "chkInspection";
            this.chkInspection.Size = new System.Drawing.Size(130, 19);
            this.chkInspection.TabIndex = 0;
            this.chkInspection.Text = "檢驗 (NT$450)";
            this.chkInspection.UseVisualStyleBackColor = true;

            // chkMufflerReplacement
            this.chkMufflerReplacement.AutoSize = true;
            this.chkMufflerReplacement.Location = new System.Drawing.Point(220, 25);
            this.chkMufflerReplacement.Name = "chkMufflerReplacement";
            this.chkMufflerReplacement.Size = new System.Drawing.Size(200, 19);
            this.chkMufflerReplacement.TabIndex = 1;
            this.chkMufflerReplacement.Text = "更換消音器 (NT$3,000)";
            this.chkMufflerReplacement.UseVisualStyleBackColor = true;

            // chkTireRotation
            this.chkTireRotation.AutoSize = true;
            this.chkTireRotation.Location = new System.Drawing.Point(15, 50);
            this.chkTireRotation.Name = "chkTireRotation";
            this.chkTireRotation.Size = new System.Drawing.Size(150, 19);
            this.chkTireRotation.TabIndex = 2;
            this.chkTireRotation.Text = "輪胎換位 (NT$600)";
            this.chkTireRotation.UseVisualStyleBackColor = true;

            // groupBoxPartsAndLabor (中間)
            this.groupBoxPartsAndLabor.Controls.Add(this.labelPartsPrice);
            this.groupBoxPartsAndLabor.Controls.Add(this.txtPartsPrice);
            this.groupBoxPartsAndLabor.Controls.Add(this.labelLaborHours);
            this.groupBoxPartsAndLabor.Controls.Add(this.txtLaborHours);
            this.groupBoxPartsAndLabor.Location = new System.Drawing.Point(12, 192);
            this.groupBoxPartsAndLabor.Name = "groupBoxPartsAndLabor";
            this.groupBoxPartsAndLabor.Size = new System.Drawing.Size(433, 95);
            this.groupBoxPartsAndLabor.TabIndex = 3;
            this.groupBoxPartsAndLabor.TabStop = false;
            this.groupBoxPartsAndLabor.Text = "零件與工時";

            // labelPartsPrice
            this.labelPartsPrice.AutoSize = true;
            this.labelPartsPrice.Location = new System.Drawing.Point(15, 30);
            this.labelPartsPrice.Name = "labelPartsPrice";
            this.labelPartsPrice.Size = new System.Drawing.Size(82, 15);
            this.labelPartsPrice.TabIndex = 0;
            this.labelPartsPrice.Text = "零件(NT$)：";

            // txtPartsPrice
            this.txtPartsPrice.Location = new System.Drawing.Point(130, 27);
            this.txtPartsPrice.Name = "txtPartsPrice";
            this.txtPartsPrice.Size = new System.Drawing.Size(280, 23);
            this.txtPartsPrice.TabIndex = 1;
            this.txtPartsPrice.Text = "0";

            // labelLaborHours
            this.labelLaborHours.AutoSize = true;
            this.labelLaborHours.Location = new System.Drawing.Point(15, 60);
            this.labelLaborHours.Name = "labelLaborHours";
            this.labelLaborHours.Size = new System.Drawing.Size(94, 15);
            this.labelLaborHours.TabIndex = 2;
            this.labelLaborHours.Text = "工時數(小時)：";

            // txtLaborHours
            this.txtLaborHours.Location = new System.Drawing.Point(130, 57);
            this.txtLaborHours.Name = "txtLaborHours";
            this.txtLaborHours.Size = new System.Drawing.Size(280, 23);
            this.txtLaborHours.TabIndex = 3;
            this.txtLaborHours.Text = "0";

            // groupBoxCalculation (下方)
            this.groupBoxCalculation.Controls.Add(this.labelServiceAndLabor);
            this.groupBoxCalculation.Controls.Add(this.txtServiceAndLabor);
            this.groupBoxCalculation.Controls.Add(this.labelPartsTotal);
            this.groupBoxCalculation.Controls.Add(this.txtPartsTotal);
            this.groupBoxCalculation.Controls.Add(this.labelTax);
            this.groupBoxCalculation.Controls.Add(this.txtTax);
            this.groupBoxCalculation.Controls.Add(this.labelTotal);
            this.groupBoxCalculation.Controls.Add(this.txtTotal);
            this.groupBoxCalculation.Location = new System.Drawing.Point(12, 297);
            this.groupBoxCalculation.Name = "groupBoxCalculation";
            this.groupBoxCalculation.Size = new System.Drawing.Size(433, 130);
            this.groupBoxCalculation.TabIndex = 4;
            this.groupBoxCalculation.TabStop = false;
            this.groupBoxCalculation.Text = "費用明細";

            // labelServiceAndLabor
            this.labelServiceAndLabor.AutoSize = true;
            this.labelServiceAndLabor.Location = new System.Drawing.Point(15, 30);
            this.labelServiceAndLabor.Name = "labelServiceAndLabor";
            this.labelServiceAndLabor.Size = new System.Drawing.Size(107, 15);
            this.labelServiceAndLabor.TabIndex = 0;
            this.labelServiceAndLabor.Text = "服務與工資費用";

            // txtServiceAndLabor
            this.txtServiceAndLabor.Location = new System.Drawing.Point(280, 27);
            this.txtServiceAndLabor.Name = "txtServiceAndLabor";
            this.txtServiceAndLabor.ReadOnly = true;
            this.txtServiceAndLabor.Size = new System.Drawing.Size(130, 23);
            this.txtServiceAndLabor.TabIndex = 1;
            this.txtServiceAndLabor.Text = "NT$0";

            // labelPartsTotal
            this.labelPartsTotal.AutoSize = true;
            this.labelPartsTotal.Location = new System.Drawing.Point(15, 55);
            this.labelPartsTotal.Name = "labelPartsTotal";
            this.labelPartsTotal.Size = new System.Drawing.Size(61, 15);
            this.labelPartsTotal.TabIndex = 2;
            this.labelPartsTotal.Text = "零件費用";

            // txtPartsTotal
            this.txtPartsTotal.Location = new System.Drawing.Point(280, 52);
            this.txtPartsTotal.Name = "txtPartsTotal";
            this.txtPartsTotal.ReadOnly = true;
            this.txtPartsTotal.Size = new System.Drawing.Size(130, 23);
            this.txtPartsTotal.TabIndex = 3;
            this.txtPartsTotal.Text = "NT$0";

            // labelTax
            this.labelTax.AutoSize = true;
            this.labelTax.Location = new System.Drawing.Point(15, 80);
            this.labelTax.Name = "labelTax";
            this.labelTax.Size = new System.Drawing.Size(83, 15);
            this.labelTax.TabIndex = 4;
            this.labelTax.Text = "稅金(6%)";

            // txtTax
            this.txtTax.Location = new System.Drawing.Point(280, 77);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(130, 23);
            this.txtTax.TabIndex = 5;
            this.txtTax.Text = "NT$0";

            // labelTotal
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotal.Location = new System.Drawing.Point(15, 105);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(74, 19);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "總費用";

            // txtTotal
            this.txtTotal.BackColor = System.Drawing.Color.Yellow;
            this.txtTotal.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtTotal.Location = new System.Drawing.Point(280, 102);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(130, 27);
            this.txtTotal.TabIndex = 7;
            this.txtTotal.Text = "NT$0";

            // btnCalculate
            this.btnCalculate.Location = new System.Drawing.Point(12, 437);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 35);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "計算經費";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(122, 437);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // btnSaveReport
            this.btnSaveReport.Location = new System.Drawing.Point(232, 437);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(100, 35);
            this.btnSaveReport.TabIndex = 7;
            this.btnSaveReport.Text = "儲存報表";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.BtnSaveReport_Click);

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(342, 437);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 35);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "關閉";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 484);
            this.Controls.Add(this.groupBoxOilAndLubrication);
            this.Controls.Add(this.groupBoxCleaning);
            this.Controls.Add(this.groupBoxOtherServices);
            this.Controls.Add(this.groupBoxPartsAndLabor);
            this.Controls.Add(this.groupBoxCalculation);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveReport);
            this.Controls.Add(this.btnExit);
            this.Name = "Form1";
            this.Text = "汽車維修保修費";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxOilAndLubrication.ResumeLayout(false);
            this.groupBoxOilAndLubrication.PerformLayout();
            this.groupBoxCleaning.ResumeLayout(false);
            this.groupBoxCleaning.PerformLayout();
            this.groupBoxOtherServices.ResumeLayout(false);
            this.groupBoxOtherServices.PerformLayout();
            this.groupBoxPartsAndLabor.ResumeLayout(false);
            this.groupBoxPartsAndLabor.PerformLayout();
            this.groupBoxCalculation.ResumeLayout(false);
            this.groupBoxCalculation.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOilAndLubrication;
        private System.Windows.Forms.CheckBox chkOilChange;
        private System.Windows.Forms.CheckBox chkLubrication;
        private System.Windows.Forms.GroupBox groupBoxCleaning;
        private System.Windows.Forms.CheckBox chkRadiatorCleaning;
        private System.Windows.Forms.CheckBox chkTransmissionCleaning;
        private System.Windows.Forms.GroupBox groupBoxOtherServices;
        private System.Windows.Forms.CheckBox chkInspection;
        private System.Windows.Forms.CheckBox chkMufflerReplacement;
        private System.Windows.Forms.CheckBox chkTireRotation;
        private System.Windows.Forms.GroupBox groupBoxPartsAndLabor;
        private System.Windows.Forms.Label labelPartsPrice;
        private System.Windows.Forms.TextBox txtPartsPrice;
        private System.Windows.Forms.Label labelLaborHours;
        private System.Windows.Forms.TextBox txtLaborHours;
        private System.Windows.Forms.GroupBox groupBoxCalculation;
        private System.Windows.Forms.Label labelServiceAndLabor;
        private System.Windows.Forms.TextBox txtServiceAndLabor;
        private System.Windows.Forms.Label labelPartsTotal;
        private System.Windows.Forms.TextBox txtPartsTotal;
        private System.Windows.Forms.Label labelTax;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.Button btnExit;
    }
}
