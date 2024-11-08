namespace UP2024
{
    partial class Form3
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
            this.txtOriginalLanguage = new System.Windows.Forms.TextBox();
            this.txtTranslatedLanguage = new System.Windows.Forms.TextBox();
            this.comboTextType = new System.Windows.Forms.ComboBox();
            this.txtLineCount = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblOrderAmount = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnCancelRequest = new System.Windows.Forms.Button();
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOriginalLanguage
            // 
            this.txtOriginalLanguage.Location = new System.Drawing.Point(579, 85);
            this.txtOriginalLanguage.Name = "txtOriginalLanguage";
            this.txtOriginalLanguage.Size = new System.Drawing.Size(189, 20);
            this.txtOriginalLanguage.TabIndex = 0;
            // 
            // txtTranslatedLanguage
            // 
            this.txtTranslatedLanguage.Location = new System.Drawing.Point(579, 126);
            this.txtTranslatedLanguage.Name = "txtTranslatedLanguage";
            this.txtTranslatedLanguage.Size = new System.Drawing.Size(189, 20);
            this.txtTranslatedLanguage.TabIndex = 1;
            // 
            // comboTextType
            // 
            this.comboTextType.FormattingEnabled = true;
            this.comboTextType.Location = new System.Drawing.Point(579, 165);
            this.comboTextType.Name = "comboTextType";
            this.comboTextType.Size = new System.Drawing.Size(189, 21);
            this.comboTextType.TabIndex = 2;
            // 
            // txtLineCount
            // 
            this.txtLineCount.Location = new System.Drawing.Point(579, 202);
            this.txtLineCount.Name = "txtLineCount";
            this.txtLineCount.Size = new System.Drawing.Size(189, 20);
            this.txtLineCount.TabIndex = 3;
            this.txtLineCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineCount_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Olive;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSubmit.Location = new System.Drawing.Point(579, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(121, 35);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Добавить заявку";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblOrderAmount
            // 
            this.lblOrderAmount.AutoSize = true;
            this.lblOrderAmount.Location = new System.Drawing.Point(418, 303);
            this.lblOrderAmount.Name = "lblOrderAmount";
            this.lblOrderAmount.Size = new System.Drawing.Size(0, 13);
            this.lblOrderAmount.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Olive;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogout.Location = new System.Drawing.Point(579, 370);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 68);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Выход";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnCancelRequest
            // 
            this.btnCancelRequest.BackColor = System.Drawing.Color.Olive;
            this.btnCancelRequest.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancelRequest.Location = new System.Drawing.Point(39, 271);
            this.btnCancelRequest.Name = "btnCancelRequest";
            this.btnCancelRequest.Size = new System.Drawing.Size(121, 35);
            this.btnCancelRequest.TabIndex = 7;
            this.btnCancelRequest.Text = "Отменить заявку";
            this.btnCancelRequest.UseVisualStyleBackColor = false;
            this.btnCancelRequest.Click += new System.EventHandler(this.btnCancelRequest_Click);
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(39, 85);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.Size = new System.Drawing.Size(483, 150);
            this.dataGridViewRequests.TabIndex = 8;
            this.dataGridViewRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequests_CellClick);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewRequests);
            this.Controls.Add(this.btnCancelRequest);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblOrderAmount);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtLineCount);
            this.Controls.Add(this.comboTextType);
            this.Controls.Add(this.txtTranslatedLanguage);
            this.Controls.Add(this.txtOriginalLanguage);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOriginalLanguage;
        private System.Windows.Forms.TextBox txtTranslatedLanguage;
        private System.Windows.Forms.ComboBox comboTextType;
        private System.Windows.Forms.TextBox txtLineCount;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblOrderAmount;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnCancelRequest;
        private System.Windows.Forms.DataGridView dataGridViewRequests;
    }
}