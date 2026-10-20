namespace pryJuanCuevasLaboratorioProgamacion1
{
    partial class frmBuscar
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; si es false, solo se llamará al finalizador.</param>
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
            grpBusqueda = new GroupBox();
            cboCriterio = new ComboBox();
            txtBusqueda = new TextBox();
            lblCriterio = new Label();
            lblBusqueda = new Label();
            lblAyuda = new Label();

            dgvResultados = new DataGridView();
            lblTotal = new Label();

            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnReportes = new Button();

            grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();

            // grpBusqueda
            grpBusqueda.Controls.Add(cboCriterio);
            grpBusqueda.Controls.Add(txtBusqueda);
            grpBusqueda.Controls.Add(lblCriterio);
            grpBusqueda.Controls.Add(lblBusqueda);
            grpBusqueda.Controls.Add(lblAyuda);
            grpBusqueda.Location = new Point(12, 12);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(510, 110);
            grpBusqueda.TabIndex = 0;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Criterios de búsqueda";
            grpBusqueda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblCriterio
            lblCriterio.AutoSize = true;
            lblCriterio.Location = new Point(6, 25);
            lblCriterio.Name = "lblCriterio";
            lblCriterio.Size = new Size(51, 15);
            lblCriterio.TabIndex = 0;
            lblCriterio.Text = "Criterio:";
            lblCriterio.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cboCriterio
            cboCriterio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCriterio.FormattingEnabled = true;
            cboCriterio.Items.AddRange(new object[] { "Por nombre", "Por plan", "Por edad", "Todos" });
            cboCriterio.Location = new Point(70, 22);
            cboCriterio.Name = "cboCriterio";
            cboCriterio.Size = new Size(420, 23);
            cboCriterio.TabIndex = 1;
            cboCriterio.SelectedIndexChanged += cboCriterio_SelectedIndexChanged;

            // lblBusqueda
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(6, 55);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(55, 15);
            lblBusqueda.TabIndex = 2;
            lblBusqueda.Text = "Buscar:";
            lblBusqueda.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtBusqueda
            txtBusqueda.Location = new Point(70, 52);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(420, 23);
            txtBusqueda.TabIndex = 3;

            // lblAyuda
            lblAyuda.AutoSize = true;
            lblAyuda.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            lblAyuda.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblAyuda.Location = new Point(6, 82);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(0, 13);
            lblAyuda.TabIndex = 4;

            // dgvResultados
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Location = new Point(12, 128);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.Size = new Size(510, 300);
            dgvResultados.TabIndex = 5;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResultados.BackgroundColor = System.Drawing.Color.White;
            dgvResultados.BorderStyle = BorderStyle.Fixed3D;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 435);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(149, 15);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total de registros: 0";
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 100, 200);

            // btnBuscar
            btnBuscar.Location = new Point(12, 460);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(140, 35);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscar.Click += btnBuscar_Click;

            // btnLimpiar
            btnLimpiar.Location = new Point(190, 460);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 35);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "🧹 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnLimpiar.Click += btnLimpiar_Click;

            // btnReportes
            btnReportes.Location = new Point(368, 460);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(154, 35);
            btnReportes.TabIndex = 9;
            btnReportes.Text = "📊 Ver Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnReportes.Click += btnReportes_Click;

            // frmBuscar
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 507);
            Controls.Add(btnReportes);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(lblTotal);
            Controls.Add(dgvResultados);
            Controls.Add(grpBusqueda);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBuscar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🔎 Búsqueda de Clientes | Gimnasio Siglo";
            Load += frmBuscar_Load;
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBusqueda;
        private ComboBox cboCriterio;
        private TextBox txtBusqueda;
        private Label lblCriterio;
        private Label lblBusqueda;
        private Label lblAyuda;

        private DataGridView dgvResultados;
        private Label lblTotal;

        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnReportes;
    }
}
