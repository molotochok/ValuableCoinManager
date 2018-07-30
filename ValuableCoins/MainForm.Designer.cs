namespace ValuableCoins
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.allCoinsDgv = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnOpenCollection = new System.Windows.Forms.Button();
            this.allCoinsPanel = new System.Windows.Forms.Panel();
            this.lblAllCoinsCountValue = new System.Windows.Forms.Label();
            this.lblAllCoinsCountText = new System.Windows.Forms.Label();
            this.lblAllCoinsPriceValue = new System.Windows.Forms.Label();
            this.lblAllCoinsPriceText = new System.Windows.Forms.Label();
            this.lblAllCoinsText = new System.Windows.Forms.Label();
            this.btnAddToCollection = new System.Windows.Forms.Button();
            this.collectionPanel = new System.Windows.Forms.Panel();
            this.btnRemoveFromCollection = new System.Windows.Forms.Button();
            this.lblCollectionCountValue = new System.Windows.Forms.Label();
            this.lblCollectionCountText = new System.Windows.Forms.Label();
            this.lblCollectionPriceValue = new System.Windows.Forms.Label();
            this.lblCollectionPriceText = new System.Windows.Forms.Label();
            this.lblCollectionText = new System.Windows.Forms.Label();
            this.collectionDgv = new System.Windows.Forms.DataGridView();
            this.btnOpenAllCoins = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.allCoinsDgv)).BeginInit();
            this.allCoinsPanel.SuspendLayout();
            this.collectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectionDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateInfo.Location = new System.Drawing.Point(3, 48);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(138, 67);
            this.btnUpdateInfo.TabIndex = 0;
            this.btnUpdateInfo.Text = "Оновити дані";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            // 
            // allCoinsDgv
            // 
            this.allCoinsDgv.AllowUserToAddRows = false;
            this.allCoinsDgv.AllowUserToDeleteRows = false;
            this.allCoinsDgv.AllowUserToResizeColumns = false;
            this.allCoinsDgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allCoinsDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.allCoinsDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allCoinsDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.allCoinsDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allCoinsDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.allCoinsDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.allCoinsDgv.DefaultCellStyle = dataGridViewCellStyle9;
            this.allCoinsDgv.Location = new System.Drawing.Point(150, 48);
            this.allCoinsDgv.Name = "allCoinsDgv";
            this.allCoinsDgv.ReadOnly = true;
            this.allCoinsDgv.Size = new System.Drawing.Size(887, 743);
            this.allCoinsDgv.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 797);
            this.progressBar1.MarqueeAnimationSpeed = 25;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1031, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // btnOpenCollection
            // 
            this.btnOpenCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenCollection.Location = new System.Drawing.Point(3, 493);
            this.btnOpenCollection.Name = "btnOpenCollection";
            this.btnOpenCollection.Size = new System.Drawing.Size(138, 298);
            this.btnOpenCollection.TabIndex = 4;
            this.btnOpenCollection.Text = "Моя Колекція";
            this.btnOpenCollection.UseVisualStyleBackColor = true;
            // 
            // allCoinsPanel
            // 
            this.allCoinsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allCoinsPanel.Controls.Add(this.lblAllCoinsCountValue);
            this.allCoinsPanel.Controls.Add(this.lblAllCoinsCountText);
            this.allCoinsPanel.Controls.Add(this.lblAllCoinsPriceValue);
            this.allCoinsPanel.Controls.Add(this.lblAllCoinsPriceText);
            this.allCoinsPanel.Controls.Add(this.lblAllCoinsText);
            this.allCoinsPanel.Controls.Add(this.btnAddToCollection);
            this.allCoinsPanel.Controls.Add(this.btnUpdateInfo);
            this.allCoinsPanel.Controls.Add(this.btnOpenCollection);
            this.allCoinsPanel.Controls.Add(this.progressBar1);
            this.allCoinsPanel.Controls.Add(this.allCoinsDgv);
            this.allCoinsPanel.Location = new System.Drawing.Point(6, 2);
            this.allCoinsPanel.Name = "allCoinsPanel";
            this.allCoinsPanel.Size = new System.Drawing.Size(1049, 823);
            this.allCoinsPanel.TabIndex = 7;
            // 
            // lblAllCoinsCountValue
            // 
            this.lblAllCoinsCountValue.AutoSize = true;
            this.lblAllCoinsCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllCoinsCountValue.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAllCoinsCountValue.Location = new System.Drawing.Point(159, 11);
            this.lblAllCoinsCountValue.Name = "lblAllCoinsCountValue";
            this.lblAllCoinsCountValue.Size = new System.Drawing.Size(20, 24);
            this.lblAllCoinsCountValue.TabIndex = 10;
            this.lblAllCoinsCountValue.Text = "0";
            // 
            // lblAllCoinsCountText
            // 
            this.lblAllCoinsCountText.AutoSize = true;
            this.lblAllCoinsCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllCoinsCountText.Location = new System.Drawing.Point(6, 11);
            this.lblAllCoinsCountText.Name = "lblAllCoinsCountText";
            this.lblAllCoinsCountText.Size = new System.Drawing.Size(157, 24);
            this.lblAllCoinsCountText.TabIndex = 9;
            this.lblAllCoinsCountText.Text = "Кількість монет:";
            // 
            // lblAllCoinsPriceValue
            // 
            this.lblAllCoinsPriceValue.AutoSize = true;
            this.lblAllCoinsPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllCoinsPriceValue.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAllCoinsPriceValue.Location = new System.Drawing.Point(343, 11);
            this.lblAllCoinsPriceValue.Name = "lblAllCoinsPriceValue";
            this.lblAllCoinsPriceValue.Size = new System.Drawing.Size(20, 24);
            this.lblAllCoinsPriceValue.TabIndex = 8;
            this.lblAllCoinsPriceValue.Text = "0";
            // 
            // lblAllCoinsPriceText
            // 
            this.lblAllCoinsPriceText.AutoSize = true;
            this.lblAllCoinsPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllCoinsPriceText.Location = new System.Drawing.Point(206, 11);
            this.lblAllCoinsPriceText.Name = "lblAllCoinsPriceText";
            this.lblAllCoinsPriceText.Size = new System.Drawing.Size(141, 24);
            this.lblAllCoinsPriceText.TabIndex = 7;
            this.lblAllCoinsPriceText.Text = "Вартість (грн):";
            // 
            // lblAllCoinsText
            // 
            this.lblAllCoinsText.AutoSize = true;
            this.lblAllCoinsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAllCoinsText.Location = new System.Drawing.Point(542, 10);
            this.lblAllCoinsText.Name = "lblAllCoinsText";
            this.lblAllCoinsText.Size = new System.Drawing.Size(120, 25);
            this.lblAllCoinsText.TabIndex = 6;
            this.lblAllCoinsText.Text = "Усі монети";
            // 
            // btnAddToCollection
            // 
            this.btnAddToCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddToCollection.Location = new System.Drawing.Point(6, 135);
            this.btnAddToCollection.Name = "btnAddToCollection";
            this.btnAddToCollection.Size = new System.Drawing.Size(138, 155);
            this.btnAddToCollection.TabIndex = 5;
            this.btnAddToCollection.Text = "Додати до колекції";
            this.btnAddToCollection.UseVisualStyleBackColor = true;
            // 
            // collectionPanel
            // 
            this.collectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionPanel.Controls.Add(this.btnRemoveFromCollection);
            this.collectionPanel.Controls.Add(this.lblCollectionCountValue);
            this.collectionPanel.Controls.Add(this.lblCollectionCountText);
            this.collectionPanel.Controls.Add(this.lblCollectionPriceValue);
            this.collectionPanel.Controls.Add(this.lblCollectionPriceText);
            this.collectionPanel.Controls.Add(this.lblCollectionText);
            this.collectionPanel.Controls.Add(this.collectionDgv);
            this.collectionPanel.Controls.Add(this.btnOpenAllCoins);
            this.collectionPanel.Location = new System.Drawing.Point(3, 2);
            this.collectionPanel.Name = "collectionPanel";
            this.collectionPanel.Size = new System.Drawing.Size(1049, 823);
            this.collectionPanel.TabIndex = 5;
            // 
            // btnRemoveFromCollection
            // 
            this.btnRemoveFromCollection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveFromCollection.Location = new System.Drawing.Point(9, 48);
            this.btnRemoveFromCollection.Name = "btnRemoveFromCollection";
            this.btnRemoveFromCollection.Size = new System.Drawing.Size(135, 103);
            this.btnRemoveFromCollection.TabIndex = 8;
            this.btnRemoveFromCollection.Text = "Видалити з колекції";
            this.btnRemoveFromCollection.UseVisualStyleBackColor = true;
            // 
            // lblCollectionCountValue
            // 
            this.lblCollectionCountValue.AutoSize = true;
            this.lblCollectionCountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCollectionCountValue.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCollectionCountValue.Location = new System.Drawing.Point(162, 11);
            this.lblCollectionCountValue.Name = "lblCollectionCountValue";
            this.lblCollectionCountValue.Size = new System.Drawing.Size(20, 24);
            this.lblCollectionCountValue.TabIndex = 7;
            this.lblCollectionCountValue.Text = "0";
            // 
            // lblCollectionCountText
            // 
            this.lblCollectionCountText.AutoSize = true;
            this.lblCollectionCountText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCollectionCountText.Location = new System.Drawing.Point(9, 11);
            this.lblCollectionCountText.Name = "lblCollectionCountText";
            this.lblCollectionCountText.Size = new System.Drawing.Size(157, 24);
            this.lblCollectionCountText.TabIndex = 6;
            this.lblCollectionCountText.Text = "Кількість монет:";
            // 
            // lblCollectionPriceValue
            // 
            this.lblCollectionPriceValue.AutoSize = true;
            this.lblCollectionPriceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCollectionPriceValue.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCollectionPriceValue.Location = new System.Drawing.Point(346, 11);
            this.lblCollectionPriceValue.Name = "lblCollectionPriceValue";
            this.lblCollectionPriceValue.Size = new System.Drawing.Size(20, 24);
            this.lblCollectionPriceValue.TabIndex = 5;
            this.lblCollectionPriceValue.Text = "0";
            // 
            // lblCollectionPriceText
            // 
            this.lblCollectionPriceText.AutoSize = true;
            this.lblCollectionPriceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCollectionPriceText.Location = new System.Drawing.Point(209, 11);
            this.lblCollectionPriceText.Name = "lblCollectionPriceText";
            this.lblCollectionPriceText.Size = new System.Drawing.Size(141, 24);
            this.lblCollectionPriceText.TabIndex = 4;
            this.lblCollectionPriceText.Text = "Вартість (грн):";
            // 
            // lblCollectionText
            // 
            this.lblCollectionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCollectionText.AutoSize = true;
            this.lblCollectionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCollectionText.Location = new System.Drawing.Point(534, 10);
            this.lblCollectionText.Name = "lblCollectionText";
            this.lblCollectionText.Size = new System.Drawing.Size(151, 25);
            this.lblCollectionText.TabIndex = 3;
            this.lblCollectionText.Text = "Твоя колекція";
            // 
            // collectionDgv
            // 
            this.collectionDgv.AllowUserToAddRows = false;
            this.collectionDgv.AllowUserToDeleteRows = false;
            this.collectionDgv.AllowUserToResizeColumns = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.collectionDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.collectionDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.collectionDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.collectionDgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.collectionDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.collectionDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.collectionDgv.DefaultCellStyle = dataGridViewCellStyle12;
            this.collectionDgv.Location = new System.Drawing.Point(153, 48);
            this.collectionDgv.Name = "collectionDgv";
            this.collectionDgv.ReadOnly = true;
            this.collectionDgv.Size = new System.Drawing.Size(887, 743);
            this.collectionDgv.TabIndex = 2;
            // 
            // btnOpenAllCoins
            // 
            this.btnOpenAllCoins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenAllCoins.Location = new System.Drawing.Point(6, 493);
            this.btnOpenAllCoins.Name = "btnOpenAllCoins";
            this.btnOpenAllCoins.Size = new System.Drawing.Size(138, 298);
            this.btnOpenAllCoins.TabIndex = 0;
            this.btnOpenAllCoins.Text = "Усі монети";
            this.btnOpenAllCoins.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 823);
            this.Controls.Add(this.collectionPanel);
            this.Controls.Add(this.allCoinsPanel);
            this.MinimumSize = new System.Drawing.Size(1065, 862);
            this.Name = "MainForm";
            this.Text = "Центр дорогоцінних монет";
            ((System.ComponentModel.ISupportInitialize)(this.allCoinsDgv)).EndInit();
            this.allCoinsPanel.ResumeLayout(false);
            this.allCoinsPanel.PerformLayout();
            this.collectionPanel.ResumeLayout(false);
            this.collectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collectionDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.DataGridView allCoinsDgv;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnOpenCollection;
        private System.Windows.Forms.Panel allCoinsPanel;
        private System.Windows.Forms.Panel collectionPanel;
        private System.Windows.Forms.Button btnOpenAllCoins;
        private System.Windows.Forms.DataGridView collectionDgv;
        private System.Windows.Forms.Button btnAddToCollection;
        private System.Windows.Forms.Label lblAllCoinsText;
        private System.Windows.Forms.Label lblCollectionText;
        private System.Windows.Forms.Label lblCollectionPriceValue;
        private System.Windows.Forms.Label lblCollectionPriceText;
        private System.Windows.Forms.Label lblAllCoinsPriceText;
        private System.Windows.Forms.Label lblAllCoinsPriceValue;
        private System.Windows.Forms.Label lblAllCoinsCountValue;
        private System.Windows.Forms.Label lblAllCoinsCountText;
        private System.Windows.Forms.Label lblCollectionCountValue;
        private System.Windows.Forms.Label lblCollectionCountText;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnRemoveFromCollection;
    }
}

