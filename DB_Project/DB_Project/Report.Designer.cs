namespace DB_Project
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportGridView = new System.Windows.Forms.DataGridView();
            this.revenueLabel = new System.Windows.Forms.Label();
            this.revenueTextBox = new System.Windows.Forms.TextBox();
            this.netLossText = new System.Windows.Forms.TextBox();
            this.expensesLabel = new System.Windows.Forms.Label();
            this.profitTextBox = new System.Windows.Forms.TextBox();
            this.profitLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportGridView
            // 
            this.reportGridView.AllowUserToAddRows = false;
            this.reportGridView.AllowUserToDeleteRows = false;
            this.reportGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportGridView.Location = new System.Drawing.Point(12, 115);
            this.reportGridView.Name = "reportGridView";
            this.reportGridView.ReadOnly = true;
            this.reportGridView.Size = new System.Drawing.Size(776, 326);
            this.reportGridView.TabIndex = 0;
            // 
            // revenueLabel
            // 
            this.revenueLabel.AutoSize = true;
            this.revenueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revenueLabel.Location = new System.Drawing.Point(12, 19);
            this.revenueLabel.Name = "revenueLabel";
            this.revenueLabel.Size = new System.Drawing.Size(87, 24);
            this.revenueLabel.TabIndex = 1;
            this.revenueLabel.Text = "Revenue";
            // 
            // revenueTextBox
            // 
            this.revenueTextBox.Enabled = false;
            this.revenueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revenueTextBox.Location = new System.Drawing.Point(105, 19);
            this.revenueTextBox.Name = "revenueTextBox";
            this.revenueTextBox.ReadOnly = true;
            this.revenueTextBox.Size = new System.Drawing.Size(134, 29);
            this.revenueTextBox.TabIndex = 2;
            // 
            // netLossText
            // 
            this.netLossText.Enabled = false;
            this.netLossText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netLossText.Location = new System.Drawing.Point(334, 19);
            this.netLossText.Name = "netLossText";
            this.netLossText.ReadOnly = true;
            this.netLossText.Size = new System.Drawing.Size(134, 29);
            this.netLossText.TabIndex = 4;
            // 
            // expensesLabel
            // 
            this.expensesLabel.AutoSize = true;
            this.expensesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expensesLabel.Location = new System.Drawing.Point(245, 19);
            this.expensesLabel.Name = "expensesLabel";
            this.expensesLabel.Size = new System.Drawing.Size(83, 24);
            this.expensesLabel.TabIndex = 3;
            this.expensesLabel.Text = "Net Loss";
            // 
            // profitTextBox
            // 
            this.profitTextBox.Enabled = false;
            this.profitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profitTextBox.Location = new System.Drawing.Point(617, 19);
            this.profitTextBox.Name = "profitTextBox";
            this.profitTextBox.ReadOnly = true;
            this.profitTextBox.Size = new System.Drawing.Size(171, 29);
            this.profitTextBox.TabIndex = 6;
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = true;
            this.profitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profitLabel.Location = new System.Drawing.Point(474, 19);
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(137, 24);
            this.profitLabel.TabIndex = 5;
            this.profitLabel.Text = "Expected Profit";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(16, 67);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(514, 29);
            this.searchBox.TabIndex = 7;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(557, 67);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(231, 29);
            this.searchButton.TabIndex = 8;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.profitTextBox);
            this.Controls.Add(this.profitLabel);
            this.Controls.Add(this.netLossText);
            this.Controls.Add(this.expensesLabel);
            this.Controls.Add(this.revenueTextBox);
            this.Controls.Add(this.revenueLabel);
            this.Controls.Add(this.reportGridView);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView reportGridView;
        private System.Windows.Forms.Label revenueLabel;
        private System.Windows.Forms.TextBox revenueTextBox;
        private System.Windows.Forms.TextBox netLossText;
        private System.Windows.Forms.Label expensesLabel;
        private System.Windows.Forms.TextBox profitTextBox;
        private System.Windows.Forms.Label profitLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
    }
}