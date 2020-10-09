using System;

namespace Cadeteria
{
	class Helpers
	{
		public static Random random = new Random(Environment.TickCount);
		public static string[] Nombres = { "Pablo", "Maria", "Pedro", "Sara", "Juan", "Julieta" };
		public static string[] Apellidos = { "Perez", "Martinez", "Sanchez", "Fernandez", "Gonzalez", "Diaz" };
		public static string[] Direcciones = { "Cordoba", "Junin", "Maipu", "Muñecas", "Santiago", "Rondeau", "Larrea" };

		public static Pedido PedidoAleatorio(int _numeroP, Cliente _cliente)
		{
			string observacion = "";

			int aux = random.Next() % 2;
			bool estado;
			if (aux == 1)
			{
				estado = true;
			}
			else
			{
				estado = false;
			}

			string nombre = Nombres[random.Next(Nombres.Length)];
			nombre += " " + Apellidos[random.Next(Apellidos.Length)];
			string direccion = Direcciones[random.Next(Direcciones.Length)];

			aux = 15;
			while (aux < 100000000)
			{
				aux = aux * 10 + random.Next() % 10;
			}
			string telefono = aux.ToString();



			return new Pedido(_numeroP, observacion, estado, );
		}

		public static Cadete CadeteAleatorio(int id)
		{
			int t = random.Next(Enum.GetNames(typeof(Nombres)).Length);
			string nombre = Enum.GetNames(typeof(Nombres))[t];

			t = random.Next(Enum.GetNames(typeof(Apellidos)).Length);
			nombre += " " + Enum.GetNames(typeof(Apellidos))[t];

			t = random.Next(Enum.GetNames(typeof(Direcciones)).Length);
			string direccion = Enum.GetNames(typeof(Direcciones))[t];

			int aux = 15;
			while (aux < 100000000)
			{
				aux = aux * 10 + random.Next() % 10;
			}
			string telefono = aux.ToString();

			return new Cadete(id, nombre, direccion, telefono);
		}
	}
}
