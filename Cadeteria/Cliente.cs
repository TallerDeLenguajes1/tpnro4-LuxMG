using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
	class Cliente : Persona
	{
		private int cantPedidos = 0;

		public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }

		public Cliente() : base() { }
		public Cliente(int _id, string _nombre, string _direccion, string _telefono) : base(_id, _nombre, _direccion, _telefono) { }

		public void MostrarDatos()
		{
			Console.WriteLine("Cliente #" + Id);
			Console.WriteLine("Nombre: " + Nombre);
			Console.WriteLine("Direccion: " + Direccion);
			Console.WriteLine("Telefono: " + Telefono);
			Console.WriteLine("Cantidad de pedidos que realizo: " + CantPedidos);
		}
	}
}
