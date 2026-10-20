namespace pryJuanCuevasLaboratorioProgamacion1
{
    partial class frmInscripcion
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
            grpDatos = new GroupBox();
            txtMeses = new TextBox();
            txtEdad = new TextBox();
            txtNombre = new TextBox();
            chkEstudiante = new CheckBox();
            lblMeses = new Label();
            lblEdad = new Label();
            lblNombre = new Label();

            grpPlan = new GroupBox();
            cboTurno = new ComboBox();
            cboPlan = new ComboBox();
            chkCasillero = new CheckBox();
            lblTurno = new Label();
            lblPlan = new Label();

            grpPago = new GroupBox();
            cboCuotas = new ComboBox();
            rbtTarjeta = new RadioButton();
            rbtEfectivo = new RadioButton();
            lblCuotas = new Label();

            btnCalcular = new Button();
            btnLimpiar = new Button();
            btnBuscar = new Button();

            grpDatos.SuspendLayout();
            grpPlan.SuspendLayout();
            grpPago.SuspendLayout();
            SuspendLayout();

            // grpDatos
            grpDatos.Controls.Add(txtMeses);
            grpDatos.Controls.Add(txtEdad);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(chkEstudiante);
            grpDatos.Controls.Add(lblMeses);
            grpDatos.Controls.Add(lblEdad);
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Location = new Point(12, 12);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(460, 120);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "👤 Datos personales";
            grpDatos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(6, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(52, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtNombre
            txtNombre.Location = new Point(75, 22);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(370, 23);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtNombre.KeyPress += txtNombre_KeyPress;

            // lblEdad
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(6, 55);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(36, 15);
            lblEdad.TabIndex = 2;
            lblEdad.Text = "Edad:";
            lblEdad.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtEdad
            txtEdad.Location = new Point(75, 52);
            txtEdad.MaxLength = 3;
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(80, 23);
            txtEdad.TabIndex = 3;
            txtEdad.TextChanged += txtEdad_TextChanged;
            txtEdad.KeyPress += txtEdad_KeyPress;

            // lblMeses
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(180, 55);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(43, 15);
            lblMeses.TabIndex = 4;
            lblMeses.Text = "Meses:";
            lblMeses.Font = new System.Drawing.Font("Segoe UI", 9F);

            // txtMeses
            txtMeses.Location = new Point(230, 52);
            txtMeses.MaxLength = 2;
            txtMeses.Name = "txtMeses";
            txtMeses.Size = new Size(80, 23);
            txtMeses.TabIndex = 5;
            txtMeses.TextChanged += txtMeses_TextChanged;
            txtMeses.KeyPress += txtMeses_KeyPress;

            // chkEstudiante
            chkEstudiante.AutoSize = true;
            chkEstudiante.Checked = false;
            chkEstudiante.Location = new Point(6, 85);
            chkEstudiante.Name = "chkEstudiante";
            chkEstudiante.Size = new Size(78, 19);
            chkEstudiante.TabIndex = 6;
            chkEstudiante.Text = "Estudiante";
            chkEstudiante.UseVisualStyleBackColor = true;
            chkEstudiante.Font = new System.Drawing.Font("Segoe UI", 9F);

            // grpPlan
            grpPlan.Controls.Add(cboTurno);
            grpPlan.Controls.Add(cboPlan);
            grpPlan.Controls.Add(chkCasillero);
            grpPlan.Controls.Add(lblTurno);
            grpPlan.Controls.Add(lblPlan);
            grpPlan.Location = new Point(12, 138);
            grpPlan.Name = "grpPlan";
            grpPlan.Size = new Size(460, 110);
            grpPlan.TabIndex = 1;
            grpPlan.TabStop = false;
            grpPlan.Text = "💪 Plan";
            grpPlan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblPlan
            lblPlan.AutoSize = true;
            lblPlan.Location = new Point(6, 25);
            lblPlan.Name = "lblPlan";
            lblPlan.Size = new Size(32, 15);
            lblPlan.TabIndex = 0;
            lblPlan.Text = "Plan:";
            lblPlan.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cboPlan
            cboPlan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPlan.FormattingEnabled = true;
            cboPlan.Items.AddRange(new object[] { "Musculación", "Funcional", "Natación" });
            cboPlan.Location = new Point(75, 22);
            cboPlan.Name = "cboPlan";
            cboPlan.Size = new Size(370, 23);
            cboPlan.TabIndex = 7;

            // lblTurno
            lblTurno.AutoSize = true;
            lblTurno.Location = new Point(6, 55);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(39, 15);
            lblTurno.TabIndex = 2;
            lblTurno.Text = "Turno:";
            lblTurno.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cboTurno
            cboTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTurno.FormattingEnabled = true;
            cboTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cboTurno.Location = new Point(75, 52);
            cboTurno.Name = "cboTurno";
            cboTurno.Size = new Size(370, 23);
            cboTurno.TabIndex = 8;

            // chkCasillero
            chkCasillero.AutoSize = true;
            chkCasillero.Checked = false;
            chkCasillero.Location = new Point(6, 82);
            chkCasillero.Name = "chkCasillero";
            chkCasillero.Size = new Size(178, 19);
            chkCasillero.TabIndex = 9;
            chkCasillero.Text = "🔐 Casillero ($ 3.000/mes)";
            chkCasillero.UseVisualStyleBackColor = true;
            chkCasillero.Font = new System.Drawing.Font("Segoe UI", 9F);

            // grpPago
            grpPago.Controls.Add(cboCuotas);
            grpPago.Controls.Add(rbtTarjeta);
            grpPago.Controls.Add(rbtEfectivo);
            grpPago.Controls.Add(lblCuotas);
            grpPago.Location = new Point(12, 254);
            grpPago.Name = "grpPago";
            grpPago.Size = new Size(460, 100);
            grpPago.TabIndex = 2;
            grpPago.TabStop = false;
            grpPago.Text = "💳 Forma de pago";
            grpPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // rbtEfectivo
            rbtEfectivo.AutoSize = true;
            rbtEfectivo.Checked = true;
            rbtEfectivo.Location = new Point(20, 25);
            rbtEfectivo.Name = "rbtEfectivo";
            rbtEfectivo.Size = new Size(68, 19);
            rbtEfectivo.TabIndex = 10;
            rbtEfectivo.TabStop = true;
            rbtEfectivo.Text = "💰 Efectivo";
            rbtEfectivo.UseVisualStyleBackColor = true;
            rbtEfectivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            rbtEfectivo.CheckedChanged += rbtTarjeta_CheckedChanged;

            // rbtTarjeta
            rbtTarjeta.AutoSize = true;
            rbtTarjeta.Location = new Point(20, 55);
            rbtTarjeta.Name = "rbtTarjeta";
            rbtTarjeta.Size = new Size(61, 19);
            rbtTarjeta.TabIndex = 11;
            rbtTarjeta.Text = "💳 Tarjeta";
            rbtTarjeta.UseVisualStyleBackColor = true;
            rbtTarjeta.Font = new System.Drawing.Font("Segoe UI", 9F);
            rbtTarjeta.CheckedChanged += rbtTarjeta_CheckedChanged;

            // lblCuotas
            lblCuotas.AutoSize = true;
            lblCuotas.Location = new Point(150, 58);
            lblCuotas.Name = "lblCuotas";
            lblCuotas.Size = new Size(43, 15);
            lblCuotas.TabIndex = 2;
            lblCuotas.Text = "Cuotas:";
            lblCuotas.Font = new System.Drawing.Font("Segoe UI", 9F);

            // cboCuotas
            cboCuotas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCuotas.Enabled = false;
            cboCuotas.FormattingEnabled = true;
            cboCuotas.Items.AddRange(new object[] { "1", "3", "6" });
            cboCuotas.Location = new Point(200, 55);
            cboCuotas.Name = "cboCuotas";
            cboCuotas.Size = new Size(100, 23);
            cboCuotas.TabIndex = 12;

            // btnCalcular
            btnCalcular.Enabled = false;
            btnCalcular.Location = new Point(12, 370);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(140, 35);
            btnCalcular.TabIndex = 13;
            btnCalcular.Text = "✓ Calcular";
            btnCalcular.UseVisualStyleBackColor = true;
            btnCalcular.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCalcular.Click += btnCalcular_Click;

            // btnBuscar
            btnBuscar.Location = new Point(165, 370);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(140, 35);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "🔍 Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnBuscar.Click += btnBuscar_Click;

            // btnLimpiar
            btnLimpiar.Location = new Point(318, 370);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(154, 35);
            btnLimpiar.TabIndex = 14;
            btnLimpiar.Text = "🧹 Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnLimpiar.Click += btnLimpiar_Click;

            // frmInscripcion
            AcceptButton = btnCalcular;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 415);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnCalcular);
            Controls.Add(grpPago);
            Controls.Add(grpPlan);
            Controls.Add(grpDatos);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmInscripcion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🏋️ Gimnasio Siglo — Inscripción";
            Load += frmInscripcion_Load;
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpPlan.ResumeLayout(false);
            grpPlan.PerformLayout();
            grpPago.ResumeLayout(false);
            grpPago.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private TextBox txtMeses;
        private TextBox txtEdad;
        private TextBox txtNombre;
        private CheckBox chkEstudiante;
        private Label lblMeses;
        private Label lblEdad;
        private Label lblNombre;

        private GroupBox grpPlan;
        private ComboBox cboTurno;
        private ComboBox cboPlan;
        private CheckBox chkCasillero;
        private Label lblTurno;
        private Label lblPlan;

        private GroupBox grpPago;
        private ComboBox cboCuotas;
        private RadioButton rbtTarjeta;
        private RadioButton rbtEfectivo;
        private Label lblCuotas;

        private Button btnCalcular;
        private Button btnLimpiar;
        private Button btnBuscar;
    }
}
