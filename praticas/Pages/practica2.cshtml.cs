using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace praticas.Pages
{
    public class practica2Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int N { get; set; } = 3;

        public string Resultado { get; private set; }

        public IActionResult OnPost(string action)
        {
            switch (action)
            {
                case "Codificar":
                    Resultado = CodificarMensaje(Mensaje.ToUpper(), N);
                    break;
                case "Decodificar":
                    Resultado = DecodificarMensaje(Mensaje.ToUpper(), N);
                    break;
                default:
                    break;
            }

            return Page();
        }

        private string CodificarMensaje(string mensaje, int n)
        {
            string mensajeCifrado = "";
            foreach (char letra in mensaje)
            {
                switch (letra)
                {
                    case char l when (l >= 'A' && l <= 'Z'):
                        char letraCifrada = (char)(((l - 'A' + n) % 26) + 'A');
                        mensajeCifrado += letraCifrada;
                        break;
                    default:
                        mensajeCifrado += letra;
                        break;
                }
            }
            return mensajeCifrado;
        }

        private string DecodificarMensaje(string mensajeCifrado, int n)
        {
            string mensajeOriginal = "";
            foreach (char letra in mensajeCifrado)
            {
                switch (letra)
                {
                    case char l when (l >= 'A' && l <= 'Z'):
                        char letraOriginal = (char)(((l - 'A' - n + 26) % 26) + 'A');
                        mensajeOriginal += letraOriginal;
                        break;
                    default:
                        mensajeOriginal += letra;
                        break;
                }
            }
            return mensajeOriginal;
        }
    }
}
