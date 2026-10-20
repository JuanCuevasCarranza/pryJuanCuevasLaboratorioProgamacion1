namespace pryJuanCuevasLaboratorioProgamacion1
{
    public struct Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool EsEstudiante { get; set; }
        public string Plan { get; set; }
        public string Turno { get; set; }
        public int Meses { get; set; }
        public bool TieneCasillero { get; set; }
        public string FormaPago { get; set; }
        public int Cuotas { get; set; }
        public decimal TotalAPagar { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public Cliente(int id, string nombre, int edad, bool esEstudiante, string plan, 
                      string turno, int meses, bool tieneCasillero, string formaPago, 
                      int cuotas, decimal totalAPagar, DateTime fechaInscripcion)
        {
            Id = id;
            Nombre = nombre;
            Edad = edad;
            EsEstudiante = esEstudiante;
            Plan = plan;
            Turno = turno;
            Meses = meses;
            TieneCasillero = tieneCasillero;
            FormaPago = formaPago;
            Cuotas = cuotas;
            TotalAPagar = totalAPagar;
            FechaInscripcion = fechaInscripcion;
        }

        public override string ToString()
        {
            return $"{Id}|{Nombre}|{Edad}|{EsEstudiante}|{Plan}|{Turno}|{Meses}|{TieneCasillero}|{FormaPago}|{Cuotas}|{TotalAPagar}|{FechaInscripcion:yyyy-MM-dd HH:mm:ss}";
        }

        public static Cliente Desde(string linea)
        {
            var partes = linea.Split('|');
            if (partes.Length != 12)
                throw new ArgumentException("Formato de línea inválido");

            return new Cliente(
                int.Parse(partes[0]),
                partes[1],
                int.Parse(partes[2]),
                bool.Parse(partes[3]),
                partes[4],
                partes[5],
                int.Parse(partes[6]),
                bool.Parse(partes[7]),
                partes[8],
                int.Parse(partes[9]),
                decimal.Parse(partes[10]),
                DateTime.ParseExact(partes[11], "yyyy-MM-dd HH:mm:ss", null)
            );
        }
    }
}
