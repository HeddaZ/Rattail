namespace Rattail
{
    partial class Rattail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rattail));
            this.SuspendLayout();
            // 
            // Rattail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Rattail.Properties.Settings.Default.IndicatorColor;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::Rattail.Properties.Settings.Default, "IndicatorColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Opacity", global::Rattail.Properties.Settings.Default, "IndicatorOpacity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Rattail.Properties.Settings.Default, "IndicatorLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::Rattail.Properties.Settings.Default.IndicatorLocation;
            this.Name = "Rattail";
            this.Opacity = global::Rattail.Properties.Settings.Default.IndicatorOpacity;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rattail_FormClosing);
            this.Load += new System.EventHandler(this.Rattail_Load);
            this.Shown += new System.EventHandler(this.Rattail_Shown);
            this.VisibleChanged += new System.EventHandler(this.Rattail_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

    }
}