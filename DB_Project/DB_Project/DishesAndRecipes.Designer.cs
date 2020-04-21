namespace DB_Project
{
    partial class DishesAndRecipes
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
            this.addBtm = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dishRecipeGridView = new System.Windows.Forms.DataGridView();
            this.recipeLabel = new System.Windows.Forms.Label();
            this.dishLabel = new System.Windows.Forms.Label();
            this.dishComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dishRecipeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtm
            // 
            this.addBtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtm.Location = new System.Drawing.Point(237, 297);
            this.addBtm.Name = "addBtm";
            this.addBtm.Size = new System.Drawing.Size(130, 34);
            this.addBtm.TabIndex = 0;
            this.addBtm.Text = "Add Dish";
            this.addBtm.UseVisualStyleBackColor = true;
            this.addBtm.Click += new System.EventHandler(this.addBtm_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(382, 297);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(80, 34);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dishRecipeGridView
            // 
            this.dishRecipeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dishRecipeGridView.Location = new System.Drawing.Point(16, 78);
            this.dishRecipeGridView.Name = "dishRecipeGridView";
            this.dishRecipeGridView.Size = new System.Drawing.Size(446, 198);
            this.dishRecipeGridView.TabIndex = 2;
            // 
            // recipeLabel
            // 
            this.recipeLabel.AutoSize = true;
            this.recipeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeLabel.Location = new System.Drawing.Point(12, 51);
            this.recipeLabel.Name = "recipeLabel";
            this.recipeLabel.Size = new System.Drawing.Size(70, 24);
            this.recipeLabel.TabIndex = 3;
            this.recipeLabel.Text = "Recipe";
            // 
            // dishLabel
            // 
            this.dishLabel.AutoSize = true;
            this.dishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dishLabel.Location = new System.Drawing.Point(12, 16);
            this.dishLabel.Name = "dishLabel";
            this.dishLabel.Size = new System.Drawing.Size(47, 24);
            this.dishLabel.TabIndex = 4;
            this.dishLabel.Text = "Dish";
            // 
            // dishComboBox
            // 
            this.dishComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dishComboBox.FormattingEnabled = true;
            this.dishComboBox.Location = new System.Drawing.Point(97, 16);
            this.dishComboBox.Name = "dishComboBox";
            this.dishComboBox.Size = new System.Drawing.Size(365, 32);
            this.dishComboBox.TabIndex = 5;
            this.dishComboBox.SelectedIndexChanged += new System.EventHandler(this.dishComboBox_SelectedIndexChanged);
            // 
            // DishesAndRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 347);
            this.Controls.Add(this.dishComboBox);
            this.Controls.Add(this.dishLabel);
            this.Controls.Add(this.recipeLabel);
            this.Controls.Add(this.dishRecipeGridView);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.addBtm);
            this.Name = "DishesAndRecipes";
            this.Text = "DishesAndRecipes";
            this.Load += new System.EventHandler(this.DishesAndRecipes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dishRecipeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtm;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView dishRecipeGridView;
        private System.Windows.Forms.Label recipeLabel;
        private System.Windows.Forms.Label dishLabel;
        private System.Windows.Forms.ComboBox dishComboBox;
    }
}