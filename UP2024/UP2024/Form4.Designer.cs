namespace UP2024
{
    partial class Form4
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
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSafeFile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Location = new System.Drawing.Point(16, 32);
            this.dataGridViewRequests.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.Size = new System.Drawing.Size(975, 219);
            this.dataGridViewRequests.TabIndex = 0;
            this.dataGridViewRequests.SelectionChanged += new System.EventHandler(this.dataGridViewRequests_SelectionChanged);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.BackColor = System.Drawing.Color.Olive;
            this.btnAttachFile.Location = new System.Drawing.Point(16, 339);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(164, 34);
            this.btnAttachFile.TabIndex = 1;
            this.btnAttachFile.Text = "Прикрепить файл";
            this.btnAttachFile.UseVisualStyleBackColor = false;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFile_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(16, 278);
            this.txtComment.Margin = new System.Windows.Forms.Padding(4);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(973, 25);
            this.txtComment.TabIndex = 2;
            // 
            // btnSafeFile
            // 
            this.btnSafeFile.BackColor = System.Drawing.Color.Olive;
            this.btnSafeFile.Location = new System.Drawing.Point(16, 398);
            this.btnSafeFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSafeFile.Name = "btnSafeFile";
            this.btnSafeFile.Size = new System.Drawing.Size(164, 34);
            this.btnSafeFile.TabIndex = 3;
            this.btnSafeFile.Text = "Сохранение ";
            this.btnSafeFile.UseVisualStyleBackColor = false;
            this.btnSafeFile.Click += new System.EventHandler(this.btnSafeFile_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Olive;
            this.button1.Location = new System.Drawing.Point(829, 541);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 87);
            this.button1.TabIndex = 4;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1067, 658);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSafeFile);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.dataGridViewRequests);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSafeFile;
        private System.Windows.Forms.Button button1;
    }
}