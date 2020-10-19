using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
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
		static public List<Cliente> Clientes = new List<Cliente>();
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

			int aux = random.Next(5, 21);
			Cliente cli = new Cliente();
			//creacion de los clientes de la lista
			for(int i = 0; i < aux; i++)
			{
				cli = Helpers.ClienteAleatorio(idCliente++);
				Clientes.Add(cli);
			}			
			
			Cadete cad = new Cadete();
			//creacion de los cadetes de la lista
			for (int i = 0; i < n; i++)
			{
				cad = Helpers.CadeteAleatorio(idCadete++);
				
				aux = random.Next(1, 21);
				for(int j = 0; j < aux; j++)
				{
					cad.CargarPedido(Helpers.PedidoAleatorio(idPedido++, Clientes[random.Next(Clientes.Count)], cad));
				}

				Cadetes.Add(cad);
			}

			int seguir;
			do
			{
				seguir = Menu();
			} while (seguir == 1);
		}

		static int Menu()
        {
			Console.WriteLine("1. Ver lista de cadetes");
			Console.WriteLine("2. Ver pedidos que se realizaron");
			Console.WriteLine("3. Ver lista de clientes");
			Console.WriteLine("4. Revisar parametros generales (nombre temporal)");
			Console.WriteLine("0. Salir");

			int opcion;
			do
			{
				Console.Write("Opcion: ");
				try
				{
					opcion = Convert.ToInt32(Console.ReadLine());
				}
				catch (System.FormatException)
				{
					opcion = -1;
				}
			} while (opcion < 0);

			Console.WriteLine();
			
			switch (opcion)
			{
				case 0:
					return 0;
				case 1:
					MostrarCadetes();
					break;
				case 2:
					MostrarPedidos();
					break;
				case 3:
					MostrarClientes();
					break;
				case 4:
					MostrarGeneral();
					break;

				default:
					Console.WriteLine("Opcion no existente");
					break;
            }
			Console.WriteLine();
			return 1;
        }

		static void MostrarCadetes()
        {
			Console.WriteLine("-----------------------------------");
			Console.WriteLine("--------INFORME DE CADETES---------");
			Console.WriteLine("-----------------------------------");

			foreach (Cadete C in Cadetes)
			{
				C.MostrarDatos();
				Console.WriteLine();
			}
		}

		static void MostrarPedidos()
        {
			Console.WriteLine("-----------------------------------");
			Console.WriteLine("--------INFORME DE PEDIDOS---------");
			Console.WriteLine("-----------------------------------");

			foreach (Cadete C in Cadetes)
			{
				foreach (Pedido P in C.PedidosP)
                {
					P.MostrarDatos();
					Console.WriteLine();
				}
			}
		}

		static void MostrarClientes()
        {
			Console.WriteLine("-----------------------------------");
			Console.WriteLine("--------INFORME DE CLIENTES--------");
			Console.WriteLine("-----------------------------------");

			foreach (Cliente C in Clientes)
			{
				C.MostrarDatos();
				Console.WriteLine();
			}
		}

		static void MostrarGeneral()
        {
			int aux = 1, totalE = 0, total = 0;
			Cadete cad = new Cadete();

			foreach(Cadete C in Cadetes)
            {
				if(C.CantEntregados > aux)
                {
					aux = C.CantEntregados;
					cad = C;
                }
				total += C.CantPedidos;
				totalE += C.CantEntregados;
            }

			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Cadete con mayor cantidad de entregas: " + cad.Nombre);
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Cantidad total de pedidos recibidos: " + total);
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Cantidad total de pedidos entregados: " + totalE);
			Console.WriteLine("------------------------------------------------------");
			Console.WriteLine("Promedio de pedidos entregados por cadete: " + (float)totalE / Cadetes.Count);
			Console.WriteLine("------------------------------------------------------");
		}
	}
}
