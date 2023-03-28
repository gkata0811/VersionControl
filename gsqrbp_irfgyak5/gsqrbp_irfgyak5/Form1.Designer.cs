
namespace gsqrbp_irfgyak5
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dgvRates = new System.Windows.Forms.DataGridView();
            this.rateDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRates
            // 
            this.dgvRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRates.Location = new System.Drawing.Point(12, 12);
            this.dgvRates.Name = "dgvRates";
            this.dgvRates.Size = new System.Drawing.Size(509, 244);
            this.dgvRates.TabIndex = 0;
            // 
            // rateDataBindingSource
            // 
            this.rateDataBindingSource.DataSource = typeof(gsqrbp_irfgyak5.Entities.RateData);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 268);
            this.Controls.Add(this.dgvRates);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRates;
        private System.Windows.Forms.BindingSource rateDataBindingSource;
    }
}

