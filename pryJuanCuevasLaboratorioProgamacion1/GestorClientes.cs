using System;
using System.IO;
using System.Linq;

namespace pryJuanCuevasLaboratorioProgamacion1
{
    public class GestorClientes
    {
        private Cliente[] clientes;
        private int cantidadClientes;
        private string rutaArchivo;
        private const int CAPACIDAD_MAXIMA = 100;

        public GestorClientes(string rutaArchivo = "datos.txt")
        {
            this.rutaArchivo = rutaArchivo;
            clientes = new Cliente[CAPACIDAD_MAXIMA];
            cantidadClientes = 0;
            CargarDelArchivo();
        }

        /// <summary>
        /// Agrega un nuevo cliente al array y lo guarda en archivo
        /// </summary>
        public bool AgregarCliente(Cliente cliente)
        {
            if (cantidadClientes >= CAPACIDAD_MAXIMA)
            {
                Console.WriteLine("No se pueden agregar más clientes. Capacidad máxima alcanzada.");
                return false;
            }

            // Asignar ID automático
            cliente.Id = cantidadClientes + 1;
            clientes[cantidadClientes] = cliente;
            cantidadClientes++;
            GuardarEnArchivo();
            return true;
        }

        /// <summary>
        /// Guarda todos los clientes en el archivo de texto
        /// </summary>
        private void GuardarEnArchivo()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    for (int i = 0; i < cantidadClientes; i++)
                    {
                        writer.WriteLine(clientes[i].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// Carga los clientes desde el archivo de texto
        /// </summary>
        private void CargarDelArchivo()
        {
            if (!File.Exists(rutaArchivo))
                return;

            try
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                cantidadClientes = 0;

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    try
                    {
                        Cliente cliente = Cliente.Desde(linea);
                        clientes[cantidadClientes] = cliente;
                        cantidadClientes++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al cargar línea: {linea}. Error: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar archivo: {ex.Message}");
            }
        }

        /// <summary>
        /// Busca un cliente por nombre (búsqueda parcial)
        /// </summary>
        public Cliente[] BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return new Cliente[0];

            string nombreBusqueda = nombre.ToUpper();
            Cliente[] resultados = new Cliente[cantidadClientes];
            int encontrados = 0;

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (clientes[i].Nombre.ToUpper().Contains(nombreBusqueda))
                {
                    resultados[encontrados] = clientes[i];
                    encontrados++;
                }
            }

            // Redimensionar el array de resultados
            System.Array.Resize(ref resultados, encontrados);
            return resultados;
        }

        /// <summary>
        /// Busca clientes por plan
        /// </summary>
        public Cliente[] BuscarPorPlan(string plan)
        {
            if (string.IsNullOrWhiteSpace(plan))
                return new Cliente[0];

            Cliente[] resultados = new Cliente[cantidadClientes];
            int encontrados = 0;

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (clientes[i].Plan == plan)
                {
                    resultados[encontrados] = clientes[i];
                    encontrados++;
                }
            }

            System.Array.Resize(ref resultados, encontrados);
            return resultados;
        }

        /// <summary>
        /// Busca clientes por rango de edad
        /// </summary>
        public Cliente[] BuscarPorEdad(int edadMinima, int edadMaxima)
        {
            Cliente[] resultados = new Cliente[cantidadClientes];
            int encontrados = 0;

            for (int i = 0; i < cantidadClientes; i++)
            {
                if (clientes[i].Edad >= edadMinima && clientes[i].Edad <= edadMaxima)
                {
                    resultados[encontrados] = clientes[i];
                    encontrados++;
                }
            }

            System.Array.Resize(ref resultados, encontrados);
            return resultados;
        }

        /// <summary>
        /// Obtiene todos los clientes registrados
        /// </summary>
        public Cliente[] ObtenerTodos()
        {
            Cliente[] resultado = new Cliente[cantidadClientes];
            System.Array.Copy(clientes, resultado, cantidadClientes);
            return resultado;
        }

        /// <summary>
        /// Obtiene la cantidad actual de clientes
        /// </summary>
        public int ObtenerCantidad()
        {
            return cantidadClientes;
        }

        /// <summary>
        /// Obtiene reportes del total de ingresos por plan
        /// </summary>
        public Dictionary<string, decimal> ObtenerIngresosPorPlan()
        {
            Dictionary<string, decimal> ingresos = new Dictionary<string, decimal>();

            for (int i = 0; i < cantidadClientes; i++)
            {
                string plan = clientes[i].Plan;
                if (!ingresos.ContainsKey(plan))
                    ingresos[plan] = 0;

                ingresos[plan] += clientes[i].TotalAPagar;
            }

            return ingresos;
        }

        /// <summary>
        /// Obtiene la edad promedio de los clientes
        /// </summary>
        public double ObtenerEdadPromedio()
        {
            if (cantidadClientes == 0)
                return 0;

            int sumaEdades = 0;
            for (int i = 0; i < cantidadClientes; i++)
            {
                sumaEdades += clientes[i].Edad;
            }

            return (double)sumaEdades / cantidadClientes;
        }

        /// <summary>
        /// Obtiene el ingreso total de todas las inscripciones
        /// </summary>
        public decimal ObtenerIngresoTotal()
        {
            decimal total = 0;
            for (int i = 0; i < cantidadClientes; i++)
            {
                total += clientes[i].TotalAPagar;
            }
            return total;
        }
    }
}
