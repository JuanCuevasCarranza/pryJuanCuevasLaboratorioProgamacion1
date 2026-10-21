using System.Globalization;
using System.Drawing.Drawing2D;

namespace pryCuevasCarranzaSP4;

public sealed class Form1 : Form
{
    // La consigna trabaja con cinco mozos y cuatro categorías de venta.
    private const int CantidadMozos = 5;
    private const int CantidadCategorias = 4;

    // Estos vectores representan los nombres que aparecen en la grilla.
    private readonly string[] mozos = ["Julio", "Esteban", "Javier", "Gonzalo", "Alberto"];
    private readonly string[] categorias = ["Comidas", "Bebidas sin alcohol", "Bebidas con alcohol", "Postres"];

    // Matriz principal del ejercicio: cada fila es un mozo y cada columna una categoría.
    // ventas[0, 0], por ejemplo, contiene las comidas vendidas por Julio.
    private readonly float[,] ventas = new float[CantidadMozos, CantidadCategorias];

    // Controles que forman la interfaz. Se crean desde Form1.cs para que el diseño
    // quede en el mismo archivo y pueda entenderse junto con la lógica del formulario.
    private readonly DataGridView grilla = new();
    private readonly Button btnValidar = new();
    private readonly Button btnMozoDelDia = new();
    private readonly Button btnTotales = new();
    private readonly Button btnLimpiar = new();
    private readonly Label lblEstado = new();
    private readonly Label lblMozo = new();
    private readonly Label lblImporteMozo = new();
    private readonly Label lblTotalGeneral = new();
    private readonly Label[] lblTotalesCategoria = new Label[CantidadCategorias];

    private readonly Color fondo = Color.FromArgb(247, 243, 237);
    private readonly Color azulNoche = Color.FromArgb(24, 45, 61);
    private readonly Color terracota = Color.FromArgb(190, 91, 55);
    private readonly Color verde = Color.FromArgb(47, 125, 96);
    private readonly Color dorado = Color.FromArgb(218, 166, 70);

    public Form1()
    {
        // Primero se configuran las propiedades generales de la ventana y luego se
        // construyen visualmente sus paneles, grilla, botones y resultados.
        InitializeForm();
        ConstruirInterfaz();
    }

    private void InitializeForm()
    {
        // Configuración general de la ventana principal del bar.
        Text = "Bar La Milanga | Control de ventas";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1080, 720);
        Size = new Size(1220, 820);
        BackColor = fondo;
        ForeColor = azulNoche;
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        DoubleBuffered = true;
    }

    private void ConstruirInterfaz()
    {
        // TableLayoutPanel organiza la pantalla en cuatro zonas: encabezado,
        // instrucciones, grilla de carga y panel inferior de consultas.
        var contenedor = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 4,
            Padding = new Padding(34, 28, 34, 26),
            BackColor = fondo
        };
        contenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
        contenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 68));
        contenedor.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        contenedor.RowStyles.Add(new RowStyle(SizeType.Absolute, 190));
        Controls.Add(contenedor);

        contenedor.Controls.Add(CrearCabecera(), 0, 0);
        contenedor.Controls.Add(CrearBarraAyuda(), 0, 1);
        contenedor.Controls.Add(CrearGrilla(), 0, 2);
        contenedor.Controls.Add(CrearPanelResultados(), 0, 3);
    }

    private Control CrearCabecera()
    {
        // Encabezado con la identidad visual de La Milanga y la fecha actual.
        var panel = new Panel { Dock = DockStyle.Fill, BackColor = azulNoche, Padding = new Padding(26, 15, 26, 12) };
        panel.Paint += (_, e) =>
        {
            using var pincel = new LinearGradientBrush(panel.ClientRectangle, azulNoche, Color.FromArgb(44, 72, 82), 0F);
            e.Graphics.FillRectangle(pincel, panel.ClientRectangle);
        };

        var marca = new Label
        {
            Text = "LA MILANGA",
            AutoSize = true,
            Location = new Point(26, 13),
            ForeColor = dorado,
            Font = new Font("Segoe UI", 23F, FontStyle.Bold)
        };
        var subtitulo = new Label
        {
            Text = "CONTROL DIARIO DE VENTAS  ·  SALÓN",
            AutoSize = true,
            Location = new Point(29, 58),
            ForeColor = Color.FromArgb(222, 230, 228),
            Font = new Font("Segoe UI", 9F, FontStyle.Bold)
        };
        var fecha = new Label
        {
            Text = DateTime.Now.ToString("dddd, dd 'de' MMMM", new CultureInfo("es-AR")),
            AutoSize = true,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F),
            Location = new Point(850, 39)
        };
        fecha.Left = panel.Width - fecha.Width - 26;
        panel.Resize += (_, _) => fecha.Left = panel.Width - fecha.Width - 26;
        panel.Controls.AddRange([marca, subtitulo, fecha]);
        return panel;
    }

    private Control CrearBarraAyuda()
    {
        // Texto breve que orienta al usuario antes de completar la grilla.
        var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(20, 8, 20, 8) };
        var icono = new Label { Text = "●", AutoSize = true, ForeColor = terracota, Font = new Font("Segoe UI", 16F, FontStyle.Bold), Location = new Point(18, 15) };
        var titulo = new Label { Text = "Cargá los importes por mozo y categoría", AutoSize = true, ForeColor = azulNoche, Font = new Font("Segoe UI", 11F, FontStyle.Bold), Location = new Point(46, 10) };
        var detalle = new Label { Text = "Los importes deben ser numéricos. El valor 0 también es válido.", AutoSize = true, ForeColor = Color.FromArgb(105, 117, 120), Font = new Font("Segoe UI", 9.5F), Location = new Point(46, 35) };
        panel.Controls.AddRange([icono, titulo, detalle]);
        return panel;
    }

    private Control CrearGrilla()
    {
        // La grilla tiene una columna fija para los mozos y cuatro columnas editables
        // para las categorías almacenadas en la matriz ventas.
        grilla.Dock = DockStyle.Fill;
        grilla.BackgroundColor = Color.White;
        grilla.BorderStyle = BorderStyle.None;
        grilla.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grilla.GridColor = Color.FromArgb(228, 231, 228);
        grilla.AllowUserToAddRows = false;
        grilla.AllowUserToDeleteRows = false;
        grilla.AllowUserToResizeRows = false;
        grilla.RowHeadersVisible = false;
        grilla.SelectionMode = DataGridViewSelectionMode.CellSelect;
        grilla.MultiSelect = false;
        grilla.AutoGenerateColumns = false;
        grilla.EditMode = DataGridViewEditMode.EditOnEnter;
        grilla.ColumnHeadersHeight = 52;
        grilla.RowTemplate.Height = 55;
        grilla.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = azulNoche,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Alignment = DataGridViewContentAlignment.MiddleCenter,
            SelectionBackColor = azulNoche
        };
        grilla.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = azulNoche,
            Font = new Font("Segoe UI", 11F),
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Padding = new Padding(12, 0, 12, 0),
            SelectionBackColor = Color.FromArgb(255, 239, 215),
            SelectionForeColor = azulNoche
        };
        grilla.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(252, 250, 247) };

        var columnaMozo = new DataGridViewTextBoxColumn
        {
            HeaderText = "MOZO",
            Name = "Mozo",
            ReadOnly = true,
            Width = 180,
            SortMode = DataGridViewColumnSortMode.NotSortable,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = azulNoche, Padding = new Padding(22, 0, 0, 0) }
        };
        grilla.Columns.Add(columnaMozo);
        foreach (var categoria in categorias)
        {
            grilla.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = categoria.ToUpperInvariant(),
                Name = categoria,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                MaxInputLength = 14
            });
        }
        // Se agregan exactamente cinco filas, una por cada elemento del vector mozos.
        foreach (var mozo in mozos) grilla.Rows.Add(mozo, null, null, null, null);
        grilla.CellValidating += Grilla_CellValidating;
        grilla.EditingControlShowing += Grilla_EditingControlShowing;
        grilla.CellBeginEdit += (_, _) => DesmarcarValidacion();
        return grilla;
    }

    private Control CrearPanelResultados()
    {
        // El sector inferior contiene las acciones y las dos consultas solicitadas.
        var panel = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1, BackColor = Color.Transparent, Padding = new Padding(0, 16, 0, 0) };
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34));
        panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        panel.Controls.Add(CrearPanelAcciones(), 0, 0);
        panel.Controls.Add(CrearTarjetaMozo(), 1, 0);
        panel.Controls.Add(CrearTarjetaTotales(), 2, 0);
        return panel;
    }

    private Control CrearPanelAcciones()
    {
        // Desde aquí el usuario valida la carga o limpia la grilla para comenzar de nuevo.
        var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 0, 18, 0) };
        btnValidar.Text = "✓   VALIDAR DATOS";
        btnValidar.BackColor = verde;
        btnValidar.ForeColor = Color.White;
        btnValidar.FlatStyle = FlatStyle.Flat;
        btnValidar.FlatAppearance.BorderSize = 0;
        btnValidar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnValidar.Size = new Size(190, 43);
        btnValidar.Location = new Point(0, 8);
        btnValidar.Cursor = Cursors.Hand;
        btnValidar.Click += BtnValidar_Click;

        btnLimpiar.Text = "Limpiar grilla";
        btnLimpiar.BackColor = Color.Transparent;
        btnLimpiar.ForeColor = azulNoche;
        btnLimpiar.FlatStyle = FlatStyle.Flat;
        btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(190, 196, 193);
        btnLimpiar.Size = new Size(125, 36);
        btnLimpiar.Location = new Point(0, 63);
        btnLimpiar.Cursor = Cursors.Hand;
        btnLimpiar.Click += BtnLimpiar_Click;

        lblEstado.Text = "Pendiente de validación";
        lblEstado.AutoSize = false;
        lblEstado.Size = new Size(210, 25);
        lblEstado.Location = new Point(0, 108);
        lblEstado.ForeColor = Color.FromArgb(105, 117, 120);
        lblEstado.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
        panel.Controls.AddRange([btnValidar, btnLimpiar, lblEstado]);
        return panel;
    }

    private Control CrearTarjetaMozo()
    {
        // Tarjeta donde se informa el mozo que obtuvo la mayor venta total.
        var panel = CrearTarjeta("★  MOZO DEL DÍA", terracota);
        var titulo = new Label { Text = "—", AutoSize = true, ForeColor = azulNoche, Font = new Font("Segoe UI", 18F, FontStyle.Bold), Location = new Point(22, 37) };
        lblMozo.Text = "Validá los datos para consultar";
        lblMozo.AutoSize = true;
        lblMozo.ForeColor = Color.FromArgb(105, 117, 120);
        lblMozo.Font = new Font("Segoe UI", 9F);
        lblMozo.Location = new Point(24, 70);
        lblImporteMozo.Text = "Importe: —";
        lblImporteMozo.AutoSize = true;
        lblImporteMozo.ForeColor = terracota;
        lblImporteMozo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblImporteMozo.Location = new Point(24, 94);
        btnMozoDelDia.Text = "Consultar";
        ConfigurarBotonConsulta(btnMozoDelDia, new Point(183, 80), terracota);
        btnMozoDelDia.Click += BtnMozoDelDia_Click;
        panel.Controls.AddRange([titulo, lblMozo, lblImporteMozo, btnMozoDelDia]);
        return panel;
    }

    private Control CrearTarjetaTotales()
    {
        // Tarjeta donde se muestran los totales calculados por categoría y el total general.
        var panel = CrearTarjeta("▣  TOTALES DE LA JORNADA", dorado);
        var tabla = new TableLayoutPanel { Location = new Point(20, 37), Size = new Size(270, 105), ColumnCount = 2, RowCount = 3, BackColor = Color.Transparent };
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
        tabla.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
        for (var i = 0; i < categorias.Length; i++)
        {
            tabla.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            var etiqueta = new Label { Text = categorias[i], Dock = DockStyle.Fill, ForeColor = Color.FromArgb(105, 117, 120), Font = new Font("Segoe UI", 8F), TextAlign = ContentAlignment.MiddleLeft };
            lblTotalesCategoria[i] = new Label { Text = "—", Dock = DockStyle.Fill, ForeColor = azulNoche, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), TextAlign = ContentAlignment.MiddleRight };
            tabla.Controls.Add(etiqueta, 0, i);
            tabla.Controls.Add(lblTotalesCategoria[i], 1, i);
        }
        lblTotalGeneral.Text = "Total general: —";
        lblTotalGeneral.AutoSize = true;
        lblTotalGeneral.ForeColor = azulNoche;
        lblTotalGeneral.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblTotalGeneral.Location = new Point(20, 145);
        ConfigurarBotonConsulta(btnTotales, new Point(203, 137), Color.FromArgb(170, 123, 35));
        btnTotales.Text = "Consultar";
        btnTotales.Click += BtnTotales_Click;
        panel.Controls.AddRange([tabla, lblTotalGeneral, btnTotales]);
        return panel;
    }

    private Panel CrearTarjeta(string titulo, Color color)
    {
        // Método reutilizable para mantener el mismo estilo en ambas tarjetas.
        var panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(8, 0, 0, 0), Padding = new Padding(20, 12, 20, 10) };
        panel.Paint += (_, e) =>
        {
            using var pincel = new SolidBrush(color);
            e.Graphics.FillRectangle(pincel, 0, 0, 5, panel.Height);
        };
        var etiqueta = new Label { Text = titulo, AutoSize = true, ForeColor = color, Font = new Font("Segoe UI", 8.5F, FontStyle.Bold), Location = new Point(20, 10) };
        panel.Controls.Add(etiqueta);
        return panel;
    }

    private void ConfigurarBotonConsulta(Button boton, Point ubicacion, Color color)
    {
        boton.Location = ubicacion;
        boton.Size = new Size(90, 34);
        boton.BackColor = color;
        boton.ForeColor = Color.White;
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        boton.Cursor = Cursors.Hand;
        boton.Enabled = false;
    }

    private void Grilla_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
    {
        // Mientras se edita una celda se permite escribir números y separadores decimales.
        if (e.Control is TextBox editor)
        {
            editor.TextAlign = HorizontalAlignment.Right;
            editor.KeyPress -= Editor_KeyPress;
            editor.KeyPress += Editor_KeyPress;
        }
    }

    private static void Editor_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.') e.Handled = true;
    }

    private void Grilla_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
    {
        // La columna 0 contiene nombres y no necesita validación numérica.
        if (e.ColumnIndex == 0) return;
        var valor = Convert.ToString(e.FormattedValue)?.Trim() ?? string.Empty;
        if (!EsImporteValido(valor))
        {
            e.Cancel = true;
            grilla.Rows[e.RowIndex].ErrorText = "Ingresá un importe válido (cero está permitido).";
        }
        else
        {
            grilla.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    }

    private void BtnValidar_Click(object? sender, EventArgs e)
    {
        // Sin una validación correcta las consultas permanecen deshabilitadas.
        if (!ValidarGrilla(out var mensaje))
        {
            DeshabilitarConsultas();
            lblEstado.Text = mensaje;
            lblEstado.ForeColor = terracota;
            MessageBox.Show(mensaje, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        lblEstado.Text = "✓ Datos validados correctamente";
        lblEstado.ForeColor = verde;
        btnMozoDelDia.Enabled = true;
        btnTotales.Enabled = true;
        MessageBox.Show("La grilla se validó correctamente. Ya podés realizar las consultas.", "Validación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private bool ValidarGrilla(out string mensaje)
    {
        // Se recorren todas las posiciones de la grilla y se copian a la matriz ventas.
        // La posición [fila, columna] conserva la relación mozo-categoría.
        for (var fila = 0; fila < CantidadMozos; fila++)
        {
            for (var columna = 1; columna <= CantidadCategorias; columna++)
            {
                var texto = Convert.ToString(grilla.Rows[fila].Cells[columna].Value)?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(texto))
                {
                    mensaje = $"Falta completar {categorias[columna - 1]} de {mozos[fila]}.";
                    grilla.CurrentCell = grilla.Rows[fila].Cells[columna];
                    return false;
                }
                if (!TryObtenerImporte(texto, out var importe) || importe < 0)
                {
                    mensaje = $"El importe de {mozos[fila]} en {categorias[columna - 1]} no es válido.";
                    grilla.CurrentCell = grilla.Rows[fila].Cells[columna];
                    return false;
                }
                ventas[fila, columna - 1] = importe;
            }
        }
        mensaje = string.Empty;
        return true;
    }

    private void BtnMozoDelDia_Click(object? sender, EventArgs e)
    {
        if (!ValidarGrilla(out _)) return;

        // Vector auxiliar: cada posición guarda la venta total de un mozo.
        var totalesPorMozo = new float[CantidadMozos];
        var indiceGanador = 0;
        for (var fila = 0; fila < CantidadMozos; fila++)
        {
            // Se suman las cuatro columnas de la fila actual.
            for (var columna = 0; columna < CantidadCategorias; columna++) totalesPorMozo[fila] += ventas[fila, columna];

            // Se conserva el índice del mozo con el importe más alto.
            if (totalesPorMozo[fila] > totalesPorMozo[indiceGanador]) indiceGanador = fila;
        }
        lblMozo.Text = mozos[indiceGanador];
        lblImporteMozo.Text = $"Importe: {FormatearImporte(totalesPorMozo[indiceGanador])}";
    }

    private void BtnTotales_Click(object? sender, EventArgs e)
    {
        if (!ValidarGrilla(out _)) return;

        // Vector auxiliar: cada posición representa el total de una categoría.
        var totalesPorCategoria = new float[CantidadCategorias];
        var totalGeneral = 0F;
        
        for (var fila = 0; fila < CantidadMozos; fila++)
        {
            for (var columna = 0; columna < CantidadCategorias; columna++)
            {
                // Se acumula por columna y, al mismo tiempo, se obtiene el total general.
                totalesPorCategoria[columna] += ventas[fila, columna];
                totalGeneral += ventas[fila, columna];
            }
        }
        for (var categoria = 0; categoria < CantidadCategorias; categoria++) lblTotalesCategoria[categoria].Text = FormatearImporte(totalesPorCategoria[categoria]);
        
        lblTotalGeneral.Text = $"Total general: {FormatearImporte(totalGeneral)}";
    }

    private void BtnLimpiar_Click(object? sender, EventArgs e)
    {
        // Se limpian las celdas visibles y también todos los valores de la matriz.
        foreach (DataGridViewRow fila in grilla.Rows)
            for (var columna = 1; columna <= CantidadCategorias; columna++) fila.Cells[columna].Value = null;
        Array.Clear(ventas);
        DeshabilitarConsultas();
        lblEstado.Text = "Pendiente de validación";
        lblEstado.ForeColor = Color.FromArgb(105, 117, 120);
        lblMozo.Text = "Validá los datos para consultar";
        lblImporteMozo.Text = "Importe: —";
        lblTotalGeneral.Text = "Total general: —";
        foreach (var etiqueta in lblTotalesCategoria) etiqueta.Text = "—";
    }

    private void DeshabilitarConsultas()
    {
        btnMozoDelDia.Enabled = false;
        btnTotales.Enabled = false;
    }

    private void DesmarcarValidacion()
    {
        lblEstado.Text = "Cambios pendientes de validación";
        lblEstado.ForeColor = Color.FromArgb(105, 117, 120);
        DeshabilitarConsultas();
    }

    private static bool EsImporteValido(string texto) => TryObtenerImporte(texto, out var importe) && importe >= 0;

    private static bool TryObtenerImporte(string texto, out float importe)
    {
        // Se intenta interpretar el importe con la cultura del equipo y luego con
        // la cultura invariante para aceptar coma o punto decimal.
        var estilos = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign | NumberStyles.AllowThousands;
        return float.TryParse(texto, estilos, CultureInfo.CurrentCulture, out importe) || float.TryParse(texto, estilos, CultureInfo.InvariantCulture, out importe);
    }

    private static string FormatearImporte(float importe) => importe.ToString("C2", new CultureInfo("es-AR"));
}
