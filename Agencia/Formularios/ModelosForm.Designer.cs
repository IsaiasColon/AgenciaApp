﻿namespace Agencia.Formularios
{
    partial class ModelosForm
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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvModelos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(12, 197);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(117, 23);
            this.btnBorrar.TabIndex = 14;
            this.btnBorrar.Text = "Borrar Seleccionado";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(12, 12);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 13;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(532, 197);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvModelos
            // 
            this.dgvModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModelos.Location = new System.Drawing.Point(12, 41);
            this.dgvModelos.MultiSelect = false;
            this.dgvModelos.Name = "dgvModelos";
            this.dgvModelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModelos.Size = new System.Drawing.Size(595, 150);
            this.dgvModelos.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(281, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Modelos";
            // 
            // ModelosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 230);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgvModelos);
            this.Controls.Add(this.label1);
            this.Name = "ModelosForm";
            this.Text = "ModelosForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvModelos;
        private System.Windows.Forms.Label label1;
    }
}