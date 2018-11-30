namespace TractorForms
{
    partial class FormGarage
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
            this.pictureBoxGarage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxLevel = new System.Windows.Forms.ListBox();
            this.labelLevel = new System.Windows.Forms.Label();
            this.pictureBoxViewTractor = new System.Windows.Forms.PictureBox();
            this.buttonTakeTractor = new System.Windows.Forms.Button();
            this.maskedTextBoxTakePlace = new System.Windows.Forms.MaskedTextBox();
            this.labelPlace = new System.Windows.Forms.Label();
            this.labelRemoveTractor = new System.Windows.Forms.Label();
            this.buttonSetTrator = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewTractor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGarage
            // 
            this.pictureBoxGarage.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxGarage.Name = "pictureBoxGarage";
            this.pictureBoxGarage.Size = new System.Drawing.Size(1006, 456);
            this.pictureBoxGarage.TabIndex = 0;
            this.pictureBoxGarage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxLevel);
            this.groupBox1.Controls.Add(this.labelLevel);
            this.groupBox1.Controls.Add(this.pictureBoxViewTractor);
            this.groupBox1.Controls.Add(this.buttonTakeTractor);
            this.groupBox1.Controls.Add(this.maskedTextBoxTakePlace);
            this.groupBox1.Controls.Add(this.labelPlace);
            this.groupBox1.Controls.Add(this.labelRemoveTractor);
            this.groupBox1.Controls.Add(this.buttonSetTrator);
            this.groupBox1.Location = new System.Drawing.Point(1013, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // listBoxLevel
            // 
            this.listBoxLevel.FormattingEnabled = true;
            this.listBoxLevel.Location = new System.Drawing.Point(10, 36);
            this.listBoxLevel.Name = "listBoxLevel";
            this.listBoxLevel.Size = new System.Drawing.Size(146, 95);
            this.listBoxLevel.TabIndex = 8;
            this.listBoxLevel.SelectedIndexChanged += new System.EventHandler(this.listBoxLevel_SelectedIndexChanged);
            // 
            // labelLevel
            // 
            this.labelLevel.Location = new System.Drawing.Point(57, 16);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(54, 17);
            this.labelLevel.TabIndex = 7;
            this.labelLevel.Text = "Уровни:";
            // 
            // pictureBoxViewTractor
            // 
            this.pictureBoxViewTractor.Location = new System.Drawing.Point(4, 328);
            this.pictureBoxViewTractor.Name = "pictureBoxViewTractor";
            this.pictureBoxViewTractor.Size = new System.Drawing.Size(162, 116);
            this.pictureBoxViewTractor.TabIndex = 6;
            this.pictureBoxViewTractor.TabStop = false;
            // 
            // buttonTakeTractor
            // 
            this.buttonTakeTractor.Location = new System.Drawing.Point(26, 296);
            this.buttonTakeTractor.Name = "buttonTakeTractor";
            this.buttonTakeTractor.Size = new System.Drawing.Size(119, 26);
            this.buttonTakeTractor.TabIndex = 5;
            this.buttonTakeTractor.Text = "Забрать";
            this.buttonTakeTractor.UseVisualStyleBackColor = true;
            this.buttonTakeTractor.Click += new System.EventHandler(this.buttonTakeTractor_Click);
            // 
            // maskedTextBoxTakePlace
            // 
            this.maskedTextBoxTakePlace.Location = new System.Drawing.Point(71, 270);
            this.maskedTextBoxTakePlace.Mask = "00";
            this.maskedTextBoxTakePlace.Name = "maskedTextBoxTakePlace";
            this.maskedTextBoxTakePlace.Size = new System.Drawing.Size(29, 20);
            this.maskedTextBoxTakePlace.TabIndex = 4;
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(23, 273);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(42, 13);
            this.labelPlace.TabIndex = 3;
            this.labelPlace.Text = "Место:";
            // 
            // labelRemoveTractor
            // 
            this.labelRemoveTractor.AutoSize = true;
            this.labelRemoveTractor.Location = new System.Drawing.Point(32, 244);
            this.labelRemoveTractor.Name = "labelRemoveTractor";
            this.labelRemoveTractor.Size = new System.Drawing.Size(92, 13);
            this.labelRemoveTractor.TabIndex = 2;
            this.labelRemoveTractor.Text = "Забрать трактор";
            // 
            // buttonSetTrator
            // 
            this.buttonSetTrator.Location = new System.Drawing.Point(10, 153);
            this.buttonSetTrator.Name = "buttonSetTrator";
            this.buttonSetTrator.Size = new System.Drawing.Size(146, 40);
            this.buttonSetTrator.TabIndex = 0;
            this.buttonSetTrator.Text = "Заказать Трактор";
            this.buttonSetTrator.UseVisualStyleBackColor = true;
            this.buttonSetTrator.Click += new System.EventHandler(this.buttonSetTrator_Click);
            // 
            // FormGarage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 467);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxGarage);
            this.Name = "FormGarage";
            this.Text = "Гараж";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewTractor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGarage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxViewTractor;
        private System.Windows.Forms.Button buttonTakeTractor;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTakePlace;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Label labelRemoveTractor;
        private System.Windows.Forms.Button buttonSetTrator;
        private System.Windows.Forms.ListBox listBoxLevel;
        private System.Windows.Forms.Label labelLevel;
    }
}