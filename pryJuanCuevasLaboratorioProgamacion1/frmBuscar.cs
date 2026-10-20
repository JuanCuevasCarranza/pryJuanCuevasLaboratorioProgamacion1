using System;
using System.Windows.Forms;

namespace pryJuanCuevasLaboratorioProgamacion1
{
    public partial class frmBuscar : Form
    {
        private GestorClientes gestor;

        public frmBuscar()
        {
            InitializeComponent();
            gestor = new GestorClientes();
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            txtBusqueda.Clear();
            cboCriterio.SelectedIndex = 0; // Por nombre
            dgvResultados.DataSource = null;
            lblTotal.Text = "Total de registros: 0";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = cboCriterio.SelectedItem.ToString();
            string busqueda = txtBusqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(busqueda) && criterio != "Todos")
            {
                MessageBox.Show("Ingresa criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cliente[] resultados = criterio switch
            {
                "Por nombre" => gestor.BuscarPorNombre(busqueda),
                "Por plan" => gestor.BuscarPorPlan(busqueda),
                "Por edad" => BuscarPorEdad(busqueda),
                "Todos" => gestor.ObtenerTodos(),
                _ => new Cliente[0]
            };

            MostrarResultados(resultados);
        }

        private Cliente[] BuscarPorEdad(string busqueda)
        {
            string[] partes = busqueda.Split('-');
            if (partes.Length != 2 || !int.TryParse(partes[0].Trim(), out int min) || !int.TryParse(partes[1].Trim(), out int max))
            {
                MessageBox.Show("Formato correcto: 18-30 (edad mínima - edad máxima)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Cliente[0];
            }

            return gestor.BuscarPorEdad(min, max);
        }

        private void MostrarResultados(Cliente[] resultados)
        {
            if (resultados.Length == 0)
            {
                MessageBox.Show("No se encontraron resultados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvResultados.DataSource = null;
                lblTotal.Text = "Total de registros: 0";
                return;
            }

            dgvResultados.DataSource = resultados;
            lblTotal.Text = $"Total de registros: {resultados.Length}";

            // Ajustar columnas
            dgvResultados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MostrarReportes();
        }

        private void MostrarReportes()
        {
            decimal ingresoTotal = gestor.ObtenerIngresoTotal();
            double edadPromedio = gestor.ObtenerEdadPromedio();
            int totalClientes = gestor.ObtenerCantidad();

            string reporte = $"REPORTES GENERALES\n\n" +
                $"Total de clientes: {totalClientes}\n" +
                $"Ingreso total: ${ingresoTotal:F2}\n" +
                $"Edad promedio: {edadPromedio:F2} años\n\n" +
                $"INGRESOS POR PLAN:\n";

            var ingresosPlan = gestor.ObtenerIngresosPorPlan();
            foreach (var plan in ingresosPlan)
            {
                reporte += $"  {plan.Key}: ${plan.Value:F2}\n";
            }

            MessageBox.Show(reporte, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string criterio = cboCriterio.SelectedItem.ToString();

            if (criterio == "Todos")
            {
                txtBusqueda.Enabled = false;
                txtBusqueda.Clear();
                lblAyuda.Text = "Se mostrarán todos los registros";
            }
            else if (criterio == "Por edad")
            {
                txtBusqueda.Enabled = true;
                lblAyuda.Text = "Formato: 18-30 (edad mínima - edad máxima)";
            }
            else if (criterio == "Por plan")
            {
                txtBusqueda.Enabled = true;
                lblAyuda.Text = "Ingresa: Musculación, Funcional o Natación";
            }
            else
            {
                txtBusqueda.Enabled = true;
                lblAyuda.Text = string.Empty;
            }
        }
    }
}
