using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
	class Program
	{
		static public int idCliente = 0;
		static public int idCadete = 0;
		static public int idPedido = 0;

		static public List<Cadete> Cadetes = new List<Cadete>();
		static public Random random = new Random(Environment.TickCount);

		static void Main()
		{
			Console.WriteLine("-----------------------------------");
			Console.WriteLine("-------------CADETERIA-------------");
			Console.WriteLine("-----------------------------------");

			int n;
			do
			{
				Console.Write("Ingrese el numero de cadetes: ");
				try
				{
					n = Convert.ToInt32(Console.ReadLine());
				}
				catch (System.FormatException)
				{
					n = 0;
				}
			} while (n <= 0);

			Console.WriteLine();

			int aux;
			Cadete cad = new Cadete();
			//creacion de los cadetes de la lista
			for (int i = 0; i < n; i++)
            {
				cad = Helpers.CadeteAleatorio(idCadete++);
				
				aux = random.Next() % 25 + 1;
				for(int j = 0; j < aux; j++)
                {
					cad.CargarPedido(Helpers.PedidoAleatorio(idPedido++, idCliente++));
                }

				Cadetes.Add(cad);
			}

			Console.WriteLine("-----------------------------------");
			Console.WriteLine("--------INFORME DE ENTREGAS--------");
			Console.WriteLine("-----------------------------------");

			aux = 1;
			float promedio = 0;
			//mostrar el informe
			foreach (Cadete C in Cadetes)
            {
				C.MostrarDatos();
				Console.WriteLine();

				if(C.CantEntregados > aux)
                {
					aux = C.CantEntregados;
					cad = C;
                }

				promedio += C.CantEntregados;
            }

			promedio /= n;

			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Cadete con mayor cantidad de entregas: " + cad.Nombre);
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Promedio de pedidos entregados: " + promedio);
			Console.WriteLine("------------------------------------------------------");
		}
	}
}
