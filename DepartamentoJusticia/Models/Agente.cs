using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models
{
    public class Agente
    {
        private int id;
        private string numeroPlaca;
        private string nombreCompleto;
        private string especialidad;
        private string rango;
        private DateTime fechaIngreso;
        private int aniosExperiencia;
        private double salarioBase;
        private string estado;
        private double salarioTotal;
        public Agente(int id, string numeroPlaca, string nombreCompleto, string especialidad, string rango, DateTime fechaIngreso, int aniosExperiencia, double salarioBase, string estado,double salarioTotal)
        {
            this.Id = id;
            this.NumeroPlaca = numeroPlaca;
            this.NombreCompleto = nombreCompleto;
            this.Especialidad = especialidad;
            this.Rango = rango;
            this.FechaIngreso = fechaIngreso;
            this.AniosExperiencia = aniosExperiencia;
            this.SalarioBase = salarioBase;
            this.Estado = estado;
            this.SalarioTotal = salarioTotal;
        }
        public Agente()
        {
            this.Id = 0;
            this.NumeroPlaca = "";
            this.NombreCompleto = "";
            this.Especialidad = "";
            this.Rango = "";
            this.FechaIngreso = DateTime.MinValue;
            this.AniosExperiencia = 0;
            this.SalarioBase = 0;
            this.Estado = "";
            this.SalarioTotal = 0;
        }
        //Pacha con jet

        public double CalcularSalarioTotal()
        {
            // 1.8% del salario base por cada año de experiencia
            double incentivoExperiencia = SalarioBase * 0.018 * AniosExperiencia;

            // Si el rango no es válido, no hay incentivo
            double incentivoRango = 0;

            // Porcentaje según el rango, siempre sobre el salario base
            if (Rango == "Especial")
                incentivoRango = SalarioBase * 0.10;
            else if (Rango == "Supervisor")
                incentivoRango = SalarioBase * 0.15;
            else if (Rango == "Adjunto a Cargo")
                incentivoRango = SalarioBase * 0.20;
            else if (Rango == "Directivos Superiores")
                incentivoRango = SalarioBase * 0.25;

            // Suma de los tres componentes
            return SalarioBase + incentivoExperiencia + incentivoRango;
        }

        [Required]
        public int Id { get => id; set => id = value; }
        public string NumeroPlaca { get => numeroPlaca; set => numeroPlaca = value; }
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public string Rango { get => rango; set => rango = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public int AniosExperiencia { get => aniosExperiencia; set => aniosExperiencia = value; }
        public double SalarioBase { get => salarioBase; set => salarioBase = value; }
        public string Estado { get => estado; set => estado = value; }
        public double SalarioTotal { get => salarioTotal; set => salarioTotal = value; }
    }
}
