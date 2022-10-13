namespace FinalProject.Forms
{
    partial class EditArtist
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
            this.btnUpdateArtist = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbBoxGenre = new System.Windows.Forms.ComboBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.btnDeleteArtist = new System.Windows.Forms.Button();
            this.panelArtistDetails = new System.Windows.Forms.Panel();
            this.dtGridVeiwArtists = new System.Windows.Forms.DataGridView();
            this.cmbBoxArtistIDs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelArtistDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVeiwArtists)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateArtist
            // 
            this.btnUpdateArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(13)))));
            this.btnUpdateArtist.FlatAppearance.BorderSize = 0;
            this.btnUpdateArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateArtist.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateArtist.Location = new System.Drawing.Point(182, 217);
            this.btnUpdateArtist.Name = "btnUpdateArtist";
            this.btnUpdateArtist.Size = new System.Drawing.Size(121, 37);
            this.btnUpdateArtist.TabIndex = 10;
            this.btnUpdateArtist.Text = "Update Artist";
            this.btnUpdateArtist.UseVisualStyleBackColor = false;
            this.btnUpdateArtist.Click += new System.EventHandler(this.btnUpdateArtist_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(206, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Edit Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(68, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Genre:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(47, 96);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(82, 21);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Full Name";
            // 
            // cmbBoxGenre
            // 
            this.cmbBoxGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(13)))));
            this.cmbBoxGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoxGenre.FormattingEnabled = true;
            this.cmbBoxGenre.Location = new System.Drawing.Point(149, 149);
            this.cmbBoxGenre.Name = "cmbBoxGenre";
            this.cmbBoxGenre.Size = new System.Drawing.Size(187, 28);
            this.cmbBoxGenre.TabIndex = 6;
            // 
            // txtBoxName
            // 
            this.txtBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.ForeColor = System.Drawing.Color.White;
            this.txtBoxName.Location = new System.Drawing.Point(148, 93);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(188, 26);
            this.txtBoxName.TabIndex = 5;
            // 
            // btnDeleteArtist
            // 
            this.btnDeleteArtist.BackColor = System.Drawing.Color.Red;
            this.btnDeleteArtist.FlatAppearance.BorderSize = 0;
            this.btnDeleteArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteArtist.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArtist.Location = new System.Drawing.Point(182, 273);
            this.btnDeleteArtist.Name = "btnDeleteArtist";
            this.btnDeleteArtist.Size = new System.Drawing.Size(121, 37);
            this.btnDeleteArtist.TabIndex = 10;
            this.btnDeleteArtist.Text = "Delete Artist";
            this.btnDeleteArtist.UseVisualStyleBackColor = false;
            this.btnDeleteArtist.Click += new System.EventHandler(this.btnDeleteArtist_Click);
            // 
            // panelArtistDetails
            // 
            this.panelArtistDetails.Controls.Add(this.btnDeleteArtist);
            this.panelArtistDetails.Controls.Add(this.btnUpdateArtist);
            this.panelArtistDetails.Controls.Add(this.label2);
            this.panelArtistDetails.Controls.Add(this.lblName);
            this.panelArtistDetails.Controls.Add(this.cmbBoxGenre);
            this.panelArtistDetails.Controls.Add(this.txtBoxName);
            this.panelArtistDetails.Location = new System.Drawing.Point(29, 123);
            this.panelArtistDetails.Name = "panelArtistDetails";
            this.panelArtistDetails.Size = new System.Drawing.Size(402, 372);
            this.panelArtistDetails.TabIndex = 11;
            this.panelArtistDetails.Visible = false;
            // 
            // dtGridVeiwArtists
            // 
            this.dtGridVeiwArtists.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.dtGridVeiwArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridVeiwArtists.Location = new System.Drawing.Point(437, 124);
            this.dtGridVeiwArtists.Name = "dtGridVeiwArtists";
            this.dtGridVeiwArtists.RowHeadersWidth = 51;
            this.dtGridVeiwArtists.RowTemplate.Height = 24;
            this.dtGridVeiwArtists.Size = new System.Drawing.Size(506, 370);
            this.dtGridVeiwArtists.TabIndex = 12;
            // 
            // cmbBoxArtistIDs
            // 
            this.cmbBoxArtistIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(13)))));
            this.cmbBoxArtistIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxArtistIDs.FormattingEnabled = true;
            this.cmbBoxArtistIDs.Location = new System.Drawing.Point(304, 81);
            this.cmbBoxArtistIDs.Name = "cmbBoxArtistIDs";
            this.cmbBoxArtistIDs.Size = new System.Drawing.Size(127, 24);
            this.cmbBoxArtistIDs.TabIndex = 13;
            this.cmbBoxArtistIDs.SelectionChangeCommitted += new System.EventHandler(this.cmbBoxArtistIDs_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Product Sans", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(208, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Select ID:";
            // 
            // EditArtist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1135, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBoxArtistIDs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGridVeiwArtists);
            this.Controls.Add(this.panelArtistDetails);
            this.Name = "EditArtist";
            this.Text = "EditArtist";
            this.panelArtistDetails.ResumeLayout(false);
            this.panelArtistDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVeiwArtists)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateArtist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbBoxGenre;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Button btnDeleteArtist;
        private System.Windows.Forms.Panel panelArtistDetails;
        private System.Windows.Forms.DataGridView dtGridVeiwArtists;
        private System.Windows.Forms.ComboBox cmbBoxArtistIDs;
        private System.Windows.Forms.Label label3;
    }
}