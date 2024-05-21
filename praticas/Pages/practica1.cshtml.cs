using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace praticas.Pages
{
	public class practica1Model : PageModel
	{
		[BindProperty]
		public string peso { get; set; } = "";

		[BindProperty]
		public string estatura { get; set; } = "";

		public double imc { get; private set; } = 0;
		public string Clasificacion { get; private set; } = "";

		public void OnPost()
		{
			if (!string.IsNullOrEmpty(peso) && !string.IsNullOrEmpty(estatura))
			{
				double peso1 = Convert.ToDouble(peso);
				double estatura1 = Convert.ToDouble(estatura);

				imc = peso1 / (estatura1 * estatura1);

				if (imc < 18)
					Clasificacion = "Peso Bajo";
				else if (imc >= 18 && imc < 25)
					Clasificacion = "Peso Normal";
				else if (imc >= 25 && imc < 27)
					Clasificacion = "Sobrepeso";
				else if (imc >= 27 && imc < 30)
					Clasificacion = "Obesidad grado I";
				else if (imc >= 30 && imc < 40)
					Clasificacion = "Obesidad grado II";
				else
					Clasificacion = "Obesidad grado III";
			}
			ModelState.Clear();
		}
	}
}
