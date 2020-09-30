using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
	class Cliente
	{
		int id;
		string nombre;
		string direccion;
		string telefono;

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public string Telefono { get => telefono; set => telefono = value; }

		public Cliente(int _id, string _nombre, string _direccion, string _telefono)
		{
			Id = _id;
			Nombre = _nombre;
			Direccion = _direccion;
			Telefono = _telefono;
		}
	}

	class Pedido
	{
		int numero;
		string observacion;
		Cliente cliente;
		bool estado; //true-entregado, false-no entregado

		public int Numero { get => numero; set => numero = value; }
		public string Observacion { get => observacion; set => observacion = value; }
		public bool Estado { get => estado; set => estado = value; }
		internal Cliente Cliente { get => cliente; set => cliente = value; }

		public Pedido(int _numero, string _observacion, bool _estado, int _id, string _nombre, string _direccion, string _telefono)
		{
			Numero = _numero;
			Observacion = _observacion;
			Estado = _estado;
			Cliente = new Cliente(_id, _observacion, _direccion, _telefono);
		}
	}

	class Cadete
	{
		int id;
		string nombre;
		string direccion;
		string telefono;
		List<Pedido> Pedidos = new List<Pedido>();
		int cantPedidos = 0;
		int cantEntregados = 0;

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public string Telefono { get => telefono; set => telefono = value; }
		public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }
        public int CantEntregados { get => cantEntregados; set => cantEntregados = value; }

		public Cadete()
        {
			Id = 0;
			Nombre = "";
			Direccion = "";
			Telefono = "";
        }

        public Cadete(int _id, string _nombre, string _direccion, string _telefono)
		{
			Id = _id;
			Nombre = _nombre;
			Direccion = _direccion;
			Telefono = _telefono;
		}

		public void CargarPedido(Pedido P)
		{
			Pedidos.Add(P);
			CantPedidos++;
			if (P.Estado == true) CantEntregados++;
		}

		public double Jornal()
		{
			return 100 * CantEntregados;
        }

		public void MostrarDatos()
		{
			Console.WriteLine("Nombre: " + Nombre);
			Console.WriteLine("Cantidad de pedidos recibidos: " + CantPedidos);
			Console.WriteLine("Cantidad de pedidos entregados: " + CantEntregados);
			Console.WriteLine("Jornal a recibir: " + Jornal());
        }
	}
}
