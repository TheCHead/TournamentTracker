namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            System.Windows.Forms.Button loadTournamentButton;
            this.headerLabel = new System.Windows.Forms.Label();
            this.existingTournamentsDropdown = new System.Windows.Forms.ComboBox();
            this.selectTournamentLabel = new System.Windows.Forms.Label();
            this.createNewTournamentLink = new System.Windows.Forms.LinkLabel();
            loadTournamentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadTournamentButton
            // 
            loadTournamentButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            loadTournamentButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            loadTournamentButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            loadTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            loadTournamentButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            loadTournamentButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            loadTournamentButton.Location = new System.Drawing.Point(255, 343);
            loadTournamentButton.Name = "loadTournamentButton";
            loadTournamentButton.Size = new System.Drawing.Size(206, 57);
            loadTournamentButton.TabIndex = 22;
            loadTournamentButton.Text = "Load Tournament";
            loadTournamentButton.UseVisualStyleBackColor = true;
            loadTournamentButton.Click += new System.EventHandler(this.loadTournamentButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(152, 70);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(413, 54);
            this.headerLabel.TabIndex = 14;
            this.headerLabel.Text = "Tournament Dashboard";
            // 
            // existingTournamentsDropdown
            // 
            this.existingTournamentsDropdown.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingTournamentsDropdown.FormattingEnabled = true;
            this.existingTournamentsDropdown.Location = new System.Drawing.Point(161, 216);
            this.existingTournamentsDropdown.Name = "existingTournamentsDropdown";
            this.existingTournamentsDropdown.Size = new System.Drawing.Size(404, 45);
            this.existingTournamentsDropdown.TabIndex = 21;
            // 
            // selectTournamentLabel
            // 
            this.selectTournamentLabel.AutoSize = true;
            this.selectTournamentLabel.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.selectTournamentLabel.Location = new System.Drawing.Point(154, 176);
            this.selectTournamentLabel.Name = "selectTournamentLabel";
            this.selectTournamentLabel.Size = new System.Drawing.Size(235, 37);
            this.selectTournamentLabel.TabIndex = 20;
            this.selectTournamentLabel.Text = "Select Tournament";
            // 
            // createNewTournamentLink
            // 
            this.createNewTournamentLink.AutoSize = true;
            this.createNewTournamentLink.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewTournamentLink.Location = new System.Drawing.Point(369, 264);
            this.createNewTournamentLink.Name = "createNewTournamentLink";
            this.createNewTournamentLink.Size = new System.Drawing.Size(196, 23);
            this.createNewTournamentLink.TabIndex = 23;
            this.createNewTournamentLink.TabStop = true;
            this.createNewTournamentLink.Text = "Create New Tournament";
            this.createNewTournamentLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createNewTournamentLink_LinkClicked);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(717, 488);
            this.Controls.Add(this.createNewTournamentLink);
            this.Controls.Add(loadTournamentButton);
            this.Controls.Add(this.existingTournamentsDropdown);
            this.Controls.Add(this.selectTournamentLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox existingTournamentsDropdown;
        private System.Windows.Forms.Label selectTournamentLabel;
        private System.Windows.Forms.LinkLabel createNewTournamentLink;
    }
}