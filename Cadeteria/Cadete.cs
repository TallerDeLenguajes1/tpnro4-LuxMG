using System;
using System.Collections.Generic;

namespace Cadeteria
{
	public enum Vehiculos { Default = 0, Bicicleta = 5, Moto = 20, Auto = 25 }

	class Cadete : Persona
	{
		private List<Pedido> Pedidos = new List<Pedido>();
		private int cantPedidos = 0;
		private int cantEntregados = 0;
		private Vehiculos vehiculo;

		public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }
		public int CantEntregados { get => cantEntregados; set => cantEntregados = value; }
		public Vehiculos Vehiculo { get => vehiculo; set => vehiculo = value; }
        internal List<Pedido> PedidosP { get => Pedidos; set => Pedidos = value; }

        public Cadete() : base()
		{
			Vehiculo = Vehiculos.Default;
		}

		public Cadete(int _id, string _nombre, string _direccion, string _telefono, int _vehiculo) : base(_id, _nombre, _direccion, _telefono)
		{
			switch (_vehiculo)
			{
				case 0:
					Vehiculo = Vehiculos.Bicicleta;
					break;
				case 1:
					Vehiculo = Vehiculos.Moto;
					break;
				case 2:
					Vehiculo = Vehiculos.Auto;
					break;
				default:
					Vehiculo = Vehiculos.Default;
					break;
			}
		}

		public bool CargarPedido(Pedido P)
		{
			if ((Vehiculo == Vehiculos.Bicicleta && P.Tipo == TiposPedido.Ecologico) || (Vehiculo == Vehiculos.Moto && P.Tipo == TiposPedido.Express) || (Vehiculo == Vehiculos.Auto && P.Tipo == TiposPedido.Delicado))
			{
				Pedidos.Add(P);
				CantPedidos++;
				if (P.Estado) CantEntregados++;
				return true;
			}
			else
			{
				return false; //no se puede cargar el pedido debido a que el cadete no tiene el vehiculo para llevarlo
			}
		}

		public float Jornal()
		{
			float total = 100 * cantEntregados;
			total += (total * (int)Vehiculo) / 100;
			return total;
		}

		public void MostrarDatos()
		{
			Console.WriteLine("Cadete #" + Id);
			Console.WriteLine("Nombre: " + Nombre);
			Console.WriteLine("Cantidad de pedidos recibidos: " + CantPedidos);
			Console.WriteLine("Cantidad de pedidos entregados: " + CantEntregados);
			Console.Write("Vehiculo que posee: ");
			switch (Vehiculo)
            {
				case Vehiculos.Bicicleta:
					Console.WriteLine("Bicicleta");
					break;
				case Vehiculos.Moto:
					Console.WriteLine("Moto");
					break;
				case Vehiculos.Auto:
					Console.WriteLine("Auto");
					break;
				default:
					Console.WriteLine("No posee");
					break;
			}
			Console.WriteLine("Jornal a recibir: " + Jornal());
		}
	}
}
