using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace praticas.Pages
{
    public class practica3Model : PageModel
    {
		[BindProperty]
		public string A { get; set; } = "0";

		[BindProperty]
		public string B { get; set; } = "0";

		[BindProperty]
		public string X { get; set; } = "0";

		[BindProperty]
		public string Y { get; set; } = "0";

		[BindProperty]
		public string N { get; set; } = "0";

		public string Result { get; set; } = "Resultado";

		public void OnGet()
		{
		}

		public void OnPost()
		{
			double numA, numB, numX, numY;
			int numN;

			if (!double.TryParse(A, out numA) || !double.TryParse(B, out numB) ||
				!double.TryParse(X, out numX) || !double.TryParse(Y, out numY) ||
				!int.TryParse(N, out numN))
			{
				ModelState.AddModelError("", "Por favor, ingresa números válidos en todos los campos.");
				return;
			}

			ModelState.Clear();

			Result = BinomialExpansion(numA, numB, numY, numX, numN).ToString();
			if (Result == "NaN")
			{
				ModelState.AddModelError("Result", "Error: Resultado no definido");
			}
		}

		private static double BinomialExpansion(double A, double B, double Y, double X, int N)
		{
			double result = 0;
			for (int i = 0; i <= N; i++)
			{
				result += (Factorial(N) / (Factorial(i) * Factorial(N - i))) * Math.Pow(A * X, N - i) * Math.Pow(B * Y, i);
			}
			return result;
		}

		private static double Factorial(int number)
		{
			if (number == 0)
				return 1;
			double result = 1;
			for (int i = 1; i <= number; i++)
			{
				result *= i;
			}
			return result;
		}
	}
}
