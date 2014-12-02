namespace Pirates.Windows
{
    partial class MainMenuWindow
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
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.abortButton = new System.Windows.Forms.Button();
            this.defaultSettingsButton = new System.Windows.Forms.Button();
            this.saveButtonSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.steerRightP = new System.Windows.Forms.Panel();
            this.steerRightKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.steerLeftP = new System.Windows.Forms.Panel();
            this.steeerLeftKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.loadGameButtonMM = new System.Windows.Forms.Button();
            this.newGameButtonMM = new System.Windows.Forms.Button();
            this.MainMenuPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.steerRightP.SuspendLayout();
            this.steerLeftP.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(206)))), ((int)(((byte)(224)))), ((int)(((byte)(42)))));
            this.MainMenuPanel.Controls.Add(this.settingsPanel);
            this.MainMenuPanel.Controls.Add(this.exitButton);
            this.MainMenuPanel.Controls.Add(this.settingsButton);
            this.MainMenuPanel.Controls.Add(this.loadGameButtonMM);
            this.MainMenuPanel.Controls.Add(this.newGameButtonMM);
            this.MainMenuPanel.Location = new System.Drawing.Point(0, 1);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(1008, 727);
            this.MainMenuPanel.TabIndex = 1;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.abortButton);
            this.settingsPanel.Controls.Add(this.defaultSettingsButton);
            this.settingsPanel.Controls.Add(this.saveButtonSettings);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.steerRightP);
            this.settingsPanel.Controls.Add(this.steerLeftP);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(1008, 727);
            this.settingsPanel.TabIndex = 2;
            this.settingsPanel.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.settingsPanel_PreviewKeyDown);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(214, 693);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(75, 23);
            this.abortButton.TabIndex = 11;
            this.abortButton.Text = "Anuluj";
            this.abortButton.UseVisualStyleBackColor = true;
            // 
            // defaultSettingsButton
            // 
            this.defaultSettingsButton.Location = new System.Drawing.Point(93, 693);
            this.defaultSettingsButton.Name = "defaultSettingsButton";
            this.defaultSettingsButton.Size = new System.Drawing.Size(115, 23);
            this.defaultSettingsButton.TabIndex = 10;
            this.defaultSettingsButton.Text = "Przywróć domyślne";
            this.defaultSettingsButton.UseVisualStyleBackColor = true;
            // 
            // saveButtonSettings
            // 
            this.saveButtonSettings.Location = new System.Drawing.Point(12, 693);
            this.saveButtonSettings.Name = "saveButtonSettings";
            this.saveButtonSettings.Size = new System.Drawing.Size(75, 23);
            this.saveButtonSettings.TabIndex = 9;
            this.saveButtonSettings.Text = "Zapisz";
            this.saveButtonSettings.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(532, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kliknij, aby zmienic klawisz przypisany do akcji. Kliknij dwukrotnie, aby dodać/z" +
    "mienić alternatywny klawisz akcji";
            // 
            // steerRightP
            // 
            this.steerRightP.Controls.Add(this.steerRightKey);
            this.steerRightP.Controls.Add(this.label3);
            this.steerRightP.Location = new System.Drawing.Point(17, 122);
            this.steerRightP.Name = "steerRightP";
            this.steerRightP.Size = new System.Drawing.Size(177, 54);
            this.steerRightP.TabIndex = 6;
            // 
            // steerRightKey
            // 
            this.steerRightKey.Enabled = false;
            this.steerRightKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.steerRightKey.Location = new System.Drawing.Point(74, 17);
            this.steerRightKey.Name = "steerRightKey";
            this.steerRightKey.Size = new System.Drawing.Size(100, 26);
            this.steerRightKey.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ster w prawo";
            // 
            // steerLeftP
            // 
            this.steerLeftP.Controls.Add(this.steeerLeftKey);
            this.steerLeftP.Controls.Add(this.label2);
            this.steerLeftP.Location = new System.Drawing.Point(17, 62);
            this.steerLeftP.Name = "steerLeftP";
            this.steerLeftP.Size = new System.Drawing.Size(177, 54);
            this.steerLeftP.TabIndex = 5;
            // 
            // steeerLeftKey
            // 
            this.steeerLeftKey.Enabled = false;
            this.steeerLeftKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.steeerLeftKey.Location = new System.Drawing.Point(74, 17);
            this.steeerLeftKey.Name = "steeerLeftKey";
            this.steeerLeftKey.Size = new System.Drawing.Size(100, 26);
            this.steeerLeftKey.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ster w lewo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ustawienia";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(395, 314);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(303, 78);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "Wyjście";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(395, 230);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(303, 78);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Ustawienia";
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // loadGameButtonMM
            // 
            this.loadGameButtonMM.Location = new System.Drawing.Point(395, 146);
            this.loadGameButtonMM.Name = "loadGameButtonMM";
            this.loadGameButtonMM.Size = new System.Drawing.Size(303, 78);
            this.loadGameButtonMM.TabIndex = 1;
            this.loadGameButtonMM.Text = "Wczytaj grę";
            this.loadGameButtonMM.UseVisualStyleBackColor = true;
            // 
            // newGameButtonMM
            // 
            this.newGameButtonMM.Location = new System.Drawing.Point(395, 62);
            this.newGameButtonMM.Name = "newGameButtonMM";
            this.newGameButtonMM.Size = new System.Drawing.Size(303, 78);
            this.newGameButtonMM.TabIndex = 0;
            this.newGameButtonMM.Text = "Nowa gra";
            this.newGameButtonMM.UseVisualStyleBackColor = true;
            // 
            // MainMenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.MainMenuPanel);
            this.Name = "MainMenuWindow";
            this.Text = "MainMenuWindow";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainMenuWindow_KeyDown);
            this.MainMenuPanel.ResumeLayout(false);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.steerRightP.ResumeLayout(false);
            this.steerRightP.PerformLayout();
            this.steerLeftP.ResumeLayout(false);
            this.steerLeftP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button loadGameButtonMM;
        private System.Windows.Forms.Button newGameButtonMM;
        private System.Windows.Forms.Panel steerRightP;
        private System.Windows.Forms.TextBox steerRightKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel steerLeftP;
        private System.Windows.Forms.TextBox steeerLeftKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Button defaultSettingsButton;
        private System.Windows.Forms.Button saveButtonSettings;

    }
}