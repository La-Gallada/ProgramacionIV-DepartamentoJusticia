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
        public Agente(int id, string numeroPlaca, string nombreCompleto, string especialidad, string rango, DateTime fechaIngreso, int aniosExperiencia, double salarioBase, string estado, double salarioTotal)
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
            this.FechaIngreso = DateTime.Now;
            this.AniosExperiencia = 0;
            this.SalarioBase = 0;
            this.Estado = "";
            this.SalarioTotal = 0;
        }
        // Calcula el salario total con los incentivos definidos para el proyecto.
        public double CalcularSalarioTotal()
        {
            // 1.8% del salario base por cada año de experiencia
            double incentivoExperiencia = SalarioBase * 0.018 * AniosExperiencia;
            // Si el rango no es válido, no hay incentivo
            double incentivoRango = 0;
            // Porcentaje según el rango, siempre sobre el salario base
            switch (Rango)
            {
                case "Especial":
                    incentivoRango = SalarioBase * 0.10;
                    break;
                case "Supervisor":
                    incentivoRango = SalarioBase * 0.15;
                    break;
                case "Adjunto a Cargo":
                    incentivoRango = SalarioBase * 0.20;
                    break;
                case "Directivos Superiores":
                    incentivoRango = SalarioBase * 0.25;
                    break;
            }
            // Suma de los tres componentes
            return SalarioBase + incentivoExperiencia + incentivoRango;
        }
        [Required]
        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage = "El número de placa es obligatorio")]
        [Display(Name = "Número de placa")]
        public string NumeroPlaca { get => numeroPlaca; set => numeroPlaca = value; }

        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

        [Required(ErrorMessage = "Debe seleccionar una especialidad")]
        public string Especialidad { get => especialidad; set => especialidad = value; }

        [Required(ErrorMessage = "Debe seleccionar un rango")]
        public string Rango { get => rango; set => rango = value; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }

        [Required(ErrorMessage = "Los años de experiencia son obligatorios")]
        [Range(0, int.MaxValue, ErrorMessage = "Los años de experiencia no pueden ser negativos")]
        [Display(Name = "Años de experiencia")]
        public int AniosExperiencia { get => aniosExperiencia; set => aniosExperiencia = value; }

        [Required(ErrorMessage = "El salario base es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El salario base debe ser un número mayor a 0")]
        [Display(Name = "Salario base")]
        public double SalarioBase { get => salarioBase; set => salarioBase = value; }

        [Required(ErrorMessage = "Debe seleccionar un estado")]
        public string Estado { get => estado; set => estado = value; }

        [Display(Name = "Salario total")]
        public double SalarioTotal { get => salarioTotal; set => salarioTotal = value; }
    }
}
