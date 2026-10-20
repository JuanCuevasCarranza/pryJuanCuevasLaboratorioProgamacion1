using System;
using System.Windows.Forms;

namespace pryJuanCuevasLaboratorioProgamacion1
{
    public partial class frmInscripcion : Form
    {
        // Constantes de precios
        private const decimal PRECIO_MUSCULACION = 15000m;
        private const decimal PRECIO_FUNCIONAL = 18000m;
        private const decimal PRECIO_NATACION = 22000m;
        private const decimal PRECIO_CASILLERO = 3000m;

        // Constantes de descuentos y recargos
        private const decimal DESCUENTO_EFECTIVO = 0.10m;
        private const decimal DESCUENTO_MENOR_18 = 0.25m;
        private const decimal DESCUENTO_MAYOR_65 = 0.30m;
        private const decimal DESCUENTO_ESTUDIANTE = 0.15m;
        private const decimal RECARGO_3_CUOTAS = 0.10m;
        private const decimal RECARGO_6_CUOTAS = 0.20m;

        // Gestor de clientes
        private GestorClientes gestor;

        public frmInscripcion()
        {
            InitializeComponent();
            gestor = new GestorClientes();
        }

        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            // Limpiar campos de texto
            txtNombre.Clear();
            txtEdad.Clear();
            txtMeses.Text = "1";

            // Desmarcar checkboxes
            chkEstudiante.Checked = false;
            chkCasillero.Checked = false;

            // Establecer planes y turnos por defecto
            cboPlan.SelectedIndex = 0; // Musculación
            cboTurno.SelectedIndex = 0; // Mañana

            // Establecer forma de pago (Efectivo)
            rbtEfectivo.Checked = true;
            rbtTarjeta.Checked = false;

            // Deshabilitar y vaciar cboCuotas
            cboCuotas.SelectedIndex = -1;
            cboCuotas.Enabled = false;

            // Deshabilitar botón Calcular
            btnCalcular.Enabled = false;

            // Establecer el foco en txtNombre
            txtNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscar formBuscar = new frmBuscar();
            formBuscar.ShowDialog();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Convertir a mayúsculas
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                e.Handled = false;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir dígitos y tecla de borrar
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtMeses_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir dígitos y tecla de borrar
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void rbtTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTarjeta.Checked)
            {
                cboCuotas.Enabled = true;
                cboCuotas.SelectedIndex = 0; // 1 cuota por defecto
            }
            else
            {
                cboCuotas.Enabled = false;
                cboCuotas.SelectedIndex = -1;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarHabilitarCalcular();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            ValidarHabilitarCalcular();
        }

        private void txtMeses_TextChanged(object sender, EventArgs e)
        {
            ValidarHabilitarCalcular();
        }

        private void ValidarHabilitarCalcular()
        {
            bool tieneNombre = !string.IsNullOrWhiteSpace(txtNombre.Text);
            bool tieneEdad = !string.IsNullOrWhiteSpace(txtEdad.Text);
            bool tieneMeses = !string.IsNullOrWhiteSpace(txtMeses.Text);

            btnCalcular.Enabled = tieneNombre && tieneEdad && tieneMeses;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("La edad debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMeses.Text, out int meses))
            {
                MessageBox.Show("Los meses deben ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar edad mínima
            if (edad < 14)
            {
                MessageBox.Show("Lo sentimos, no puede inscribirse. La edad mínima es 14 años.", "No puede inscribirse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EstadoInicial();
                return;
            }

            // Validar rango de meses
            if (meses < 1 || meses > 12)
            {
                MessageBox.Show("Los meses deben estar entre 1 y 12.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calcular costo
            decimal resultado = CalcularCosto(edad, meses);

            // Mostrar resultado
            MostrarDetalle(edad, meses, resultado);

            // Volver al estado inicial
            EstadoInicial();
        }

        private decimal CalcularCosto(int edad, int meses)
        {
            // 1) Obtener precio del plan
            decimal precioMensual = ObtenerPrecioPlan();

            // Agregar casillero si está marcado
            if (chkCasillero.Checked)
            {
                precioMensual += PRECIO_CASILLERO;
            }

            // Subtotal
            decimal subtotal = precioMensual * meses;

            // 2) Aplicar descuento por edad/estudiante
            decimal descuentoEdad = ObtenerDescuentoEdad(edad);
            decimal montoDescuentoEdad = subtotal * descuentoEdad;
            decimal despuesDescuentoEdad = subtotal - montoDescuentoEdad;

            // 3) Aplicar descuento o recargo según forma de pago
            decimal totalFinal;
            if (rbtEfectivo.Checked)
            {
                decimal descuentoEfectivo = despuesDescuentoEdad * DESCUENTO_EFECTIVO;
                totalFinal = despuesDescuentoEdad - descuentoEfectivo;
            }
            else // Tarjeta
            {
                int cuota = int.Parse(cboCuotas.SelectedItem.ToString());
                decimal recargo = ObtenerRecargoTarjeta(cuota);
                decimal montoRecargo = despuesDescuentoEdad * recargo;
                totalFinal = despuesDescuentoEdad + montoRecargo;
            }

            return totalFinal;
        }

        private decimal ObtenerPrecioPlan()
        {
            return cboPlan.SelectedIndex switch
            {
                0 => PRECIO_MUSCULACION,      // Musculación
                1 => PRECIO_FUNCIONAL,        // Funcional
                2 => PRECIO_NATACION,         // Natación
                _ => PRECIO_MUSCULACION
            };
        }

        private decimal ObtenerDescuentoEdad(int edad)
        {
            if (edad < 18)
                return DESCUENTO_MENOR_18;
            if (edad >= 65)
                return DESCUENTO_MAYOR_65;
            if (chkEstudiante.Checked)
                return DESCUENTO_ESTUDIANTE;

            return 0m;
        }

        private decimal ObtenerRecargoTarjeta(int cuotas)
        {
            return cuotas switch
            {
                1 => 0m,        // Sin recargo
                3 => RECARGO_3_CUOTAS,
                6 => RECARGO_6_CUOTAS,
                _ => 0m
            };
        }

        private void MostrarDetalle(int edad, int meses, decimal totalFinal)
        {
            string nombre = txtNombre.Text;
            string plan = cboPlan.SelectedItem.ToString();
            string turno = cboTurno.SelectedItem.ToString();
            string casillero = chkCasillero.Checked ? "Sí" : "No";
            string estudiante = chkEstudiante.Checked ? "Sí" : "No";
            string formaPago = rbtEfectivo.Checked ? "Efectivo" : $"Tarjeta - {cboCuotas.SelectedItem} cuota(s)";
            int cuotas = rbtTarjeta.Checked ? int.Parse(cboCuotas.SelectedItem.ToString()) : 1;

            // Guardar cliente en el array y archivo
            Cliente nuevoCliente = new Cliente(
                0, // El ID se asigna automáticamente
                nombre,
                edad,
                chkEstudiante.Checked,
                plan,
                turno,
                meses,
                chkCasillero.Checked,
                rbtEfectivo.Checked ? "Efectivo" : "Tarjeta",
                cuotas,
                totalFinal,
                DateTime.Now
            );

            if (gestor.AgregarCliente(nuevoCliente))
            {
                MessageBox.Show("Cliente agregado exitosamente al registro.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo agregar el cliente. Capacidad máxima alcanzada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string detalle = $"DETALLE DE INSCRIPCIÓN\n\n" +
                $"Nombre: {nombre}\n" +
                $"Edad: {edad} años\n" +
                $"Estudiante: {estudiante}\n\n" +
                $"Plan: {plan}\n" +
                $"Turno: {turno}\n" +
                $"Meses: {meses}\n" +
                $"Casillero: {casillero}\n\n" +
                $"Forma de pago: {formaPago}\n\n" +
                $"TOTAL A PAGAR: ${totalFinal:F2}";

            MessageBox.Show(detalle, "Confirmación de Inscripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
