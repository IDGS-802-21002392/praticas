using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace praticas.Pages
{
    public class practica4Model : PageModel
    {
        public List<int> NumerosAleatorios { get; private set; }
        public int Suma { get; private set; }
        public double Promedio { get; private set; }
        public int Moda { get; private set; }
        public double Mediana { get; private set; }

        public void OnGet()
        {
            NumerosAleatorios = GenerarNumerosAleatorios(20);
            Suma = NumerosAleatorios.Sum();
            Promedio = NumerosAleatorios.Average();
            Moda = CalcularModa(NumerosAleatorios);
            Mediana = CalcularMediana(NumerosAleatorios);
        }

        private List<int> GenerarNumerosAleatorios(int cantidad)
        {
            Random random = new Random();
            List<int> numeros = new List<int>();
            for (int i = 0; i < cantidad; i++)
            {
                numeros.Add(random.Next(0, 101)); // Genera números aleatorios entre 0 y 100
            }
            return numeros;
        }

        private int CalcularModa(List<int> numeros)
        {
            var grupos = numeros.GroupBy(x => x);
            var maxFrecuencia = grupos.Max(g => g.Count());
            return grupos.First(g => g.Count() == maxFrecuencia).Key;
        }

        private double CalcularMediana(List<int> numeros)
        {
            numeros.Sort();
            int cantidad = numeros.Count;
            if (cantidad % 2 == 0)
            {
                int medio1 = numeros[cantidad / 2 - 1];
                int medio2 = numeros[cantidad / 2];
                return (medio1 + medio2) / 2.0;
            }
            else
            {
                return numeros[cantidad / 2];
            }
        }
    }
}
