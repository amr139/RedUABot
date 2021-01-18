
namespace RedUABot
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelCreate = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelMensaje = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.PanelCreate.SuspendLayout();
            this.PanelMensaje.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelCreate
            // 
            this.PanelCreate.Controls.Add(this.button1);
            this.PanelCreate.Controls.Add(this.PasswordTextBox);
            this.PanelCreate.Controls.Add(this.label3);
            this.PanelCreate.Controls.Add(this.EmailTextBox);
            this.PanelCreate.Controls.Add(this.label2);
            this.PanelCreate.Location = new System.Drawing.Point(12, 12);
            this.PanelCreate.Name = "PanelCreate";
            this.PanelCreate.Size = new System.Drawing.Size(200, 200);
            this.PanelCreate.TabIndex = 2;
            this.PanelCreate.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 135);
            this.button1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 53);
            this.button1.TabIndex = 4;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 94);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(12);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(176, 20);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PasswordTextBox_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Location = new System.Drawing.Point(12, 37);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(12);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(176, 20);
            this.EmailTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // PanelMensaje
            // 
            this.PanelMensaje.Controls.Add(this.InfoLabel);
            this.PanelMensaje.Location = new System.Drawing.Point(12, 12);
            this.PanelMensaje.Name = "PanelMensaje";
            this.PanelMensaje.Size = new System.Drawing.Size(200, 200);
            this.PanelMensaje.TabIndex = 1;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoEllipsis = true;
            this.InfoLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(3, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(194, 200);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "Loading...";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 224);
            this.Controls.Add(this.PanelMensaje);
            this.Controls.Add(this.PanelCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "RedUABot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelCreate.ResumeLayout(false);
            this.PanelCreate.PerformLayout();
            this.PanelMensaje.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelCreate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelMensaje;
        private System.Windows.Forms.Label InfoLabel;
    }
}

