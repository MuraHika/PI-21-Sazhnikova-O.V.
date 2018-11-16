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
            this.buttonSetTrator = new System.Windows.Forms.Button();
            this.buttonSetTractorWithLadle = new System.Windows.Forms.Button();
            this.labelRemoveTractor = new System.Windows.Forms.Label();
            this.labelPlace = new System.Windows.Forms.Label();
            this.maskedTextBoxTakePlace = new System.Windows.Forms.MaskedTextBox();
            this.buttonTakeTractor = new System.Windows.Forms.Button();
            this.pictureBoxViewTractor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGarage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViewTractor)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGarage
            // 
            this.pictureBoxGarage.Location = new System.Drawing.Point(1, 0);
            this.pictureBoxGarage.Name = "pictureBoxGarage";
            this.pictureBoxGarage.Size = new System.Drawing.Size(636, 450);
            this.pictureBoxGarage.TabIndex = 0;
            this.pictureBoxGarage.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxViewTractor);
            this.groupBox1.Controls.Add(this.buttonTakeTractor);
            this.groupBox1.Controls.Add(this.maskedTextBoxTakePlace);
            this.groupBox1.Controls.Add(this.labelPlace);
            this.groupBox1.Controls.Add(this.labelRemoveTractor);
            this.groupBox1.Controls.Add(this.buttonSetTractorWithLadle);
            this.groupBox1.Controls.Add(this.buttonSetTrator);
            this.groupBox1.Location = new System.Drawing.Point(635, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 450);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // buttonSetTrator
            // 
            this.buttonSetTrator.Location = new System.Drawing.Point(10, 32);
            this.buttonSetTrator.Name = "buttonSetTrator";
            this.buttonSetTrator.Size = new System.Drawing.Size(146, 53);
            this.buttonSetTrator.TabIndex = 0;
            this.buttonSetTrator.Text = "Поставить в гараж ОБЫЧНЫЙ ТРАКТОР";
            this.buttonSetTrator.UseVisualStyleBackColor = true;
            this.buttonSetTrator.Click += new System.EventHandler(this.buttonSetTrator_Click);
            // 
            // buttonSetTractorWithLadle
            // 
            this.buttonSetTractorWithLadle.Location = new System.Drawing.Point(10, 91);
            this.buttonSetTractorWithLadle.Name = "buttonSetTractorWithLadle";
            this.buttonSetTractorWithLadle.Size = new System.Drawing.Size(146, 53);
            this.buttonSetTractorWithLadle.TabIndex = 1;
            this.buttonSetTractorWithLadle.Text = "Поставить в гараж ТРАКТОР С КОВШОМ";
            this.buttonSetTractorWithLadle.UseVisualStyleBackColor = true;
            this.buttonSetTractorWithLadle.Click += new System.EventHandler(this.buttonSetTractorWithLadle_Click);
            // 
            // labelRemoveTractor
            // 
            this.labelRemoveTractor.AutoSize = true;
            this.labelRemoveTractor.Location = new System.Drawing.Point(34, 202);
            this.labelRemoveTractor.Name = "labelRemoveTractor";
            this.labelRemoveTractor.Size = new System.Drawing.Size(92, 13);
            this.labelRemoveTractor.TabIndex = 2;
            this.labelRemoveTractor.Text = "Забрать трактор";
            // 
            // labelPlace
            // 
            this.labelPlace.AutoSize = true;
            this.labelPlace.Location = new System.Drawing.Point(8, 250);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(42, 13);
            this.labelPlace.TabIndex = 3;
            this.labelPlace.Text = "Место:";
            // 
            // maskedTextBoxTakePlace
            // 
            this.maskedTextBoxTakePlace.Location = new System.Drawing.Point(71, 247);
            this.maskedTextBoxTakePlace.Mask = "00";
            this.maskedTextBoxTakePlace.Name = "maskedTextBoxTakePlace";
            this.maskedTextBoxTakePlace.Size = new System.Drawing.Size(29, 20);
            this.maskedTextBoxTakePlace.TabIndex = 4;
            // 
            // buttonTakeTractor
            // 
            this.buttonTakeTractor.Location = new System.Drawing.Point(22, 273);
            this.buttonTakeTractor.Name = "buttonTakeTractor";
            this.buttonTakeTractor.Size = new System.Drawing.Size(119, 26);
            this.buttonTakeTractor.TabIndex = 5;
            this.buttonTakeTractor.Text = "Забрать";
            this.buttonTakeTractor.UseVisualStyleBackColor = true;
            this.buttonTakeTractor.Click += new System.EventHandler(this.buttonTakeTractor_Click);
            // 
            // pictureBoxViewTractor
            // 
            this.pictureBoxViewTractor.Location = new System.Drawing.Point(18, 318);
            this.pictureBoxViewTractor.Name = "pictureBoxViewTractor";
            this.pictureBoxViewTractor.Size = new System.Drawing.Size(137, 113);
            this.pictureBoxViewTractor.TabIndex = 6;
            this.pictureBoxViewTractor.TabStop = false;
            // 
            // FormGarage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 446);
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
        private System.Windows.Forms.Button buttonSetTractorWithLadle;
        private System.Windows.Forms.Button buttonSetTrator;
    }
}