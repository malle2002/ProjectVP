namespace VPProject
{
    partial class Home
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.LemonadeLabel = new System.Windows.Forms.Label();
            this.NewspaperLabel = new System.Windows.Forms.Label();
            this.LemonadeButton = new System.Windows.Forms.Button();
            this.NewspaperButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.LemonadeTimer = new System.Windows.Forms.Timer(this.components);
            this.NewspaperTimer = new System.Windows.Forms.Timer(this.components);
            this.LemonadeEarnsYouLabel = new System.Windows.Forms.Label();
            this.NewspaperEarnsYouLabel = new System.Windows.Forms.Label();
            this.LemonadeLevel = new System.Windows.Forms.Label();
            this.NewspaperLevel = new System.Windows.Forms.Label();
            this.NewspaperProgressBar = new VPProject.CustomProgressBar();
            this.LemonadeProgressBar = new VPProject.CustomProgressBar();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.Silver;
            this.TopPanel.Controls.Add(this.CloseButton);
            this.TopPanel.Controls.Add(this.LoginLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 40);
            this.TopPanel.TabIndex = 4;
            // 
            // CloseButton
            // 
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.Location = new System.Drawing.Point(771, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 37);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "x";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.Location = new System.Drawing.Point(24, 9);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(83, 24);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "Capitalist";
            // 
            // LemonadeLabel
            // 
            this.LemonadeLabel.AutoSize = true;
            this.LemonadeLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LemonadeLabel.Location = new System.Drawing.Point(28, 61);
            this.LemonadeLabel.Name = "LemonadeLabel";
            this.LemonadeLabel.Size = new System.Drawing.Size(170, 23);
            this.LemonadeLabel.TabIndex = 5;
            this.LemonadeLabel.Text = "Lemonade Stand";
            // 
            // NewspaperLabel
            // 
            this.NewspaperLabel.AutoSize = true;
            this.NewspaperLabel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewspaperLabel.Location = new System.Drawing.Point(28, 161);
            this.NewspaperLabel.Name = "NewspaperLabel";
            this.NewspaperLabel.Size = new System.Drawing.Size(171, 23);
            this.NewspaperLabel.TabIndex = 6;
            this.NewspaperLabel.Text = "Newspaper Shop";
            // 
            // LemonadeButton
            // 
            this.LemonadeButton.Location = new System.Drawing.Point(230, 105);
            this.LemonadeButton.Name = "LemonadeButton";
            this.LemonadeButton.Size = new System.Drawing.Size(118, 42);
            this.LemonadeButton.TabIndex = 9;
            this.LemonadeButton.UseVisualStyleBackColor = true;
            // 
            // NewspaperButton
            // 
            this.NewspaperButton.Location = new System.Drawing.Point(230, 194);
            this.NewspaperButton.Name = "NewspaperButton";
            this.NewspaperButton.Size = new System.Drawing.Size(118, 42);
            this.NewspaperButton.TabIndex = 10;
            this.NewspaperButton.UseVisualStyleBackColor = true;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoLabel.Location = new System.Drawing.Point(0, 437);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(0, 13);
            this.InfoLabel.TabIndex = 11;
            // 
            // LemonadeTimer
            // 
            this.LemonadeTimer.Interval = 3000;
            // 
            // LemonadeEarnsYouLabel
            // 
            this.LemonadeEarnsYouLabel.AutoSize = true;
            this.LemonadeEarnsYouLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LemonadeEarnsYouLabel.Location = new System.Drawing.Point(28, 84);
            this.LemonadeEarnsYouLabel.Name = "LemonadeEarnsYouLabel";
            this.LemonadeEarnsYouLabel.Size = new System.Drawing.Size(140, 16);
            this.LemonadeEarnsYouLabel.TabIndex = 12;
            this.LemonadeEarnsYouLabel.Text = "Lemonade Earn Label";
            // 
            // NewspaperEarnsYouLabel
            // 
            this.NewspaperEarnsYouLabel.AutoSize = true;
            this.NewspaperEarnsYouLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewspaperEarnsYouLabel.Location = new System.Drawing.Point(28, 184);
            this.NewspaperEarnsYouLabel.Name = "NewspaperEarnsYouLabel";
            this.NewspaperEarnsYouLabel.Size = new System.Drawing.Size(145, 16);
            this.NewspaperEarnsYouLabel.TabIndex = 13;
            this.NewspaperEarnsYouLabel.Text = "Newspaper Earn Label";
            // 
            // LemonadeLevel
            // 
            this.LemonadeLevel.AutoSize = true;
            this.LemonadeLevel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LemonadeLevel.Location = new System.Drawing.Point(230, 70);
            this.LemonadeLevel.Name = "LemonadeLevel";
            this.LemonadeLevel.Size = new System.Drawing.Size(165, 23);
            this.LemonadeLevel.TabIndex = 16;
            this.LemonadeLevel.Text = "Lemonade Level";
            // 
            // NewspaperLevel
            // 
            this.NewspaperLevel.AutoSize = true;
            this.NewspaperLevel.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewspaperLevel.Location = new System.Drawing.Point(230, 168);
            this.NewspaperLevel.Name = "NewspaperLevel";
            this.NewspaperLevel.Size = new System.Drawing.Size(172, 23);
            this.NewspaperLevel.TabIndex = 17;
            this.NewspaperLevel.Text = "Newspaper Level";
            // 
            // NewspaperProgressBar
            // 
            this.NewspaperProgressBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.NewspaperProgressBar.ChannelHeight = 6;
            this.NewspaperProgressBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.NewspaperProgressBar.ForeColor = System.Drawing.Color.White;
            this.NewspaperProgressBar.Location = new System.Drawing.Point(28, 203);
            this.NewspaperProgressBar.Name = "NewspaperProgressBar";
            this.NewspaperProgressBar.Size = new System.Drawing.Size(170, 13);
            this.NewspaperProgressBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.NewspaperProgressBar.SliderHeight = 6;
            this.NewspaperProgressBar.TabIndex = 15;
            // 
            // LemonadeProgressBar
            // 
            this.LemonadeProgressBar.ChannelColor = System.Drawing.Color.LightSteelBlue;
            this.LemonadeProgressBar.ChannelHeight = 6;
            this.LemonadeProgressBar.ForeBackColor = System.Drawing.Color.RoyalBlue;
            this.LemonadeProgressBar.ForeColor = System.Drawing.Color.White;
            this.LemonadeProgressBar.Location = new System.Drawing.Point(28, 114);
            this.LemonadeProgressBar.Name = "LemonadeProgressBar";
            this.LemonadeProgressBar.Size = new System.Drawing.Size(170, 13);
            this.LemonadeProgressBar.SliderColor = System.Drawing.Color.RoyalBlue;
            this.LemonadeProgressBar.SliderHeight = 6;
            this.LemonadeProgressBar.TabIndex = 14;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NewspaperLevel);
            this.Controls.Add(this.LemonadeLevel);
            this.Controls.Add(this.NewspaperProgressBar);
            this.Controls.Add(this.LemonadeProgressBar);
            this.Controls.Add(this.NewspaperEarnsYouLabel);
            this.Controls.Add(this.LemonadeEarnsYouLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.NewspaperButton);
            this.Controls.Add(this.LemonadeButton);
            this.Controls.Add(this.NewspaperLabel);
            this.Controls.Add(this.LemonadeLabel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Home_FormClosing);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label LemonadeLabel;
        private System.Windows.Forms.Label NewspaperLabel;
        private System.Windows.Forms.Button LemonadeButton;
        private System.Windows.Forms.Button NewspaperButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Timer LemonadeTimer;
        private System.Windows.Forms.Timer NewspaperTimer;
        private System.Windows.Forms.Label LemonadeEarnsYouLabel;
        private System.Windows.Forms.Label NewspaperEarnsYouLabel;
        private CustomProgressBar LemonadeProgressBar;
        private CustomProgressBar NewspaperProgressBar;
        private System.Windows.Forms.Label LemonadeLevel;
        private System.Windows.Forms.Label NewspaperLevel;
    }
}