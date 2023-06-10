using System.ComponentModel;

namespace DemoGraphApp
{
    partial class GraphViewerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.cbxFrequency = new System.Windows.Forms.ComboBox();
            this.cbxPeriod = new System.Windows.Forms.ComboBox();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.ColumnCount = 6;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.layout.Controls.Add(this.cbxFrequency, 5, 0);
            this.layout.Controls.Add(this.cbxPeriod, 4, 0);
            this.layout.Controls.Add(this.buttonPanel, 0, 1);
            this.layout.Controls.Add(this.graphPanel, 1, 1);
            this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout.Location = new System.Drawing.Point(0, 0);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.483301F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.5167F));
            this.layout.Size = new System.Drawing.Size(1033, 509);
            this.layout.TabIndex = 0;
            // 
            // cbxFrequency
            // 
            this.cbxFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFrequency.DropDownWidth = 83;
            this.cbxFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxFrequency.FormattingEnabled = true;
            this.cbxFrequency.Location = new System.Drawing.Point(953, 3);
            this.cbxFrequency.Name = "cbxFrequency";
            this.cbxFrequency.Size = new System.Drawing.Size(77, 24);
            this.cbxFrequency.TabIndex = 0;
            this.cbxFrequency.SelectedIndexChanged += new System.EventHandler(this.cbxFrequency_SelectedIndexChanged);
            // 
            // cbxPeriod
            // 
            this.cbxPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbxPeriod.FormattingEnabled = true;
            this.cbxPeriod.Location = new System.Drawing.Point(873, 3);
            this.cbxPeriod.Name = "cbxPeriod";
            this.cbxPeriod.Size = new System.Drawing.Size(74, 24);
            this.cbxPeriod.TabIndex = 1;
            this.cbxPeriod.SelectedIndexChanged += new System.EventHandler(this.cbxPeriod_SelectedIndexChanged);
            // 
            // buttonPanel
            // 
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(3, 36);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(54, 470);
            this.buttonPanel.TabIndex = 2;
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.Transparent;
            this.layout.SetColumnSpan(this.graphPanel, 5);
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.ForeColor = System.Drawing.Color.Transparent;
            this.graphPanel.Location = new System.Drawing.Point(63, 36);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(967, 470);
            this.graphPanel.TabIndex = 3;
            // 
            // GraphViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layout);
            this.Name = "GraphViewerControl";
            this.Size = new System.Drawing.Size(1033, 509);
            this.layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.ComboBox cbxFrequency;
        private System.Windows.Forms.ComboBox cbxPeriod;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel graphPanel;
    }
}