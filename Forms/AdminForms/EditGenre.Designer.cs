namespace FinalProject.Forms
{
    partial class EditGenre
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBoxGenreIDs = new System.Windows.Forms.ComboBox();
            this.dtGridVeiwGenre = new System.Windows.Forms.DataGridView();
            this.panelGenreDetails = new System.Windows.Forms.Panel();
            this.btnDeleteGenre = new System.Windows.Forms.Button();
            this.btnUpdateGenre = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVeiwGenre)).BeginInit();
            this.panelGenreDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(129, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Select ID:";
            // 
            // cmbBoxGenreIDs
            // 
            this.cmbBoxGenreIDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(13)))));
            this.cmbBoxGenreIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxGenreIDs.FormattingEnabled = true;
            this.cmbBoxGenreIDs.Location = new System.Drawing.Point(218, 95);
            this.cmbBoxGenreIDs.Name = "cmbBoxGenreIDs";
            this.cmbBoxGenreIDs.Size = new System.Drawing.Size(127, 24);
            this.cmbBoxGenreIDs.TabIndex = 17;
            this.cmbBoxGenreIDs.SelectionChangeCommitted += new System.EventHandler(this.cmbBoxGenreIDs_SelectionChangeCommitted);
            // 
            // dtGridVeiwGenre
            // 
            this.dtGridVeiwGenre.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(30)))), ((int)(((byte)(33)))));
            this.dtGridVeiwGenre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridVeiwGenre.Location = new System.Drawing.Point(434, 148);
            this.dtGridVeiwGenre.Name = "dtGridVeiwGenre";
            this.dtGridVeiwGenre.RowHeadersWidth = 51;
            this.dtGridVeiwGenre.RowTemplate.Height = 24;
            this.dtGridVeiwGenre.Size = new System.Drawing.Size(354, 370);
            this.dtGridVeiwGenre.TabIndex = 16;
            // 
            // panelGenreDetails
            // 
            this.panelGenreDetails.Controls.Add(this.btnDeleteGenre);
            this.panelGenreDetails.Controls.Add(this.btnUpdateGenre);
            this.panelGenreDetails.Controls.Add(this.lblName);
            this.panelGenreDetails.Controls.Add(this.txtBoxName);
            this.panelGenreDetails.Location = new System.Drawing.Point(12, 148);
            this.panelGenreDetails.Name = "panelGenreDetails";
            this.panelGenreDetails.Size = new System.Drawing.Size(402, 372);
            this.panelGenreDetails.TabIndex = 19;
            this.panelGenreDetails.Visible = false;
            // 
            // btnDeleteGenre
            // 
            this.btnDeleteGenre.BackColor = System.Drawing.Color.Red;
            this.btnDeleteGenre.FlatAppearance.BorderSize = 0;
            this.btnDeleteGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGenre.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGenre.Location = new System.Drawing.Point(238, 161);
            this.btnDeleteGenre.Name = "btnDeleteGenre";
            this.btnDeleteGenre.Size = new System.Drawing.Size(121, 37);
            this.btnDeleteGenre.TabIndex = 10;
            this.btnDeleteGenre.Text = "Delete genre";
            this.btnDeleteGenre.UseVisualStyleBackColor = false;
            this.btnDeleteGenre.Click += new System.EventHandler(this.btnDeleteGenre_Click);
            // 
            // btnUpdateGenre
            // 
            this.btnUpdateGenre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(179)))), ((int)(((byte)(13)))));
            this.btnUpdateGenre.FlatAppearance.BorderSize = 0;
            this.btnUpdateGenre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateGenre.Font = new System.Drawing.Font("Product Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateGenre.Location = new System.Drawing.Point(65, 161);
            this.btnUpdateGenre.Name = "btnUpdateGenre";
            this.btnUpdateGenre.Size = new System.Drawing.Size(121, 37);
            this.btnUpdateGenre.TabIndex = 10;
            this.btnUpdateGenre.Text = "Update genre";
            this.btnUpdateGenre.UseVisualStyleBackColor = false;
            this.btnUpdateGenre.Click += new System.EventHandler(this.btnUpdateGenre_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(24, 96);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 21);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Genre Name";
            // 
            // txtBoxName
            // 
            this.txtBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.txtBoxName.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.ForeColor = System.Drawing.Color.White;
            this.txtBoxName.Location = new System.Drawing.Point(148, 93);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(188, 28);
            this.txtBoxName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Product Sans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Edit Genre";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditGenre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.panelGenreDetails);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBoxGenreIDs);
            this.Controls.Add(this.dtGridVeiwGenre);
            this.Name = "EditGenre";
            this.Text = "EditGenre";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridVeiwGenre)).EndInit();
            this.panelGenreDetails.ResumeLayout(false);
            this.panelGenreDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBoxGenreIDs;
        private System.Windows.Forms.DataGridView dtGridVeiwGenre;
        private System.Windows.Forms.Panel panelGenreDetails;
        private System.Windows.Forms.Button btnDeleteGenre;
        private System.Windows.Forms.Button btnUpdateGenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}