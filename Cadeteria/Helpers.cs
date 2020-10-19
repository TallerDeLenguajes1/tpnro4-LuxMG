using System;

namespace Cadeteria
{
	class Helpers
	{
		public static Random random = new Random(Environment.TickCount);
		public static string[] Nombres = { "Pablo", "Maria", "Pedro", "Sara", "Juan", "Julieta" };
		public static string[] Apellidos = { "Perez", "Martinez", "Sanchez", "Fernandez", "Gonzalez", "Diaz" };
		public static string[] Direcciones = { "Cordoba", "Junin", "Maipu", "Muñecas", "Santiago", "Rondeau", "Larrea" };
		public static string[] Observaciones = { "sin observaciones", "toque el timbre", "cuidado con el perro", "grite mi nombre", "el timbre no funciona", "casa de dos pisos" };

		public static Pedido PedidoAleatorio(int _numeroP, Cliente _cliente, Cadete _cadete)
		{
			string observacion = Observaciones[random.Next(Observaciones.Length)];

			int aux = random.Next(0, 2);
			bool estado;
			if (aux == 1)
			{
				estado = true;
			}
			else
			{
				estado = false;
			}

			int tipo;
            switch (_cadete.Vehiculo)
            {
				case Vehiculos.Bicicleta:
					tipo = 0;
					break;
				case Vehiculos.Moto:
					tipo = 1;
					break;
				case Vehiculos.Auto:
					tipo = 2;
					break;
				default:
					tipo = -1;
					break;
            }

			return new Pedido(_numeroP, observacion, estado, tipo, _cliente);
		}

		public static Cadete CadeteAleatorio(int id)
		{
			string nombre = Nombres[random.Next(Nombres.Length)];
			nombre += " " + Apellidos[random.Next(Apellidos.Length)];
			string direccion = Direcciones[random.Next(Direcciones.Length)];
			direccion += " " + random.Next(1, 5000);

			int aux = 15;
			while (aux < 100000000)
			{
				aux = aux * 10 + random.Next(0, 10);
			}
			string telefono = aux.ToString();

			int vehiculo = random.Next(0, 3);

			return new Cadete(id, nombre, direccion, telefono, vehiculo);
		}

		public static Cliente ClienteAleatorio(int id)
		{
			string nombre = Nombres[random.Next(Nombres.Length)];
			nombre += " " + Apellidos[random.Next(Apellidos.Length)];
			string direccion = Direcciones[random.Next(Direcciones.Length)];
			direccion += " " + random.Next(1, 5000);

			int aux = 15;
			while (aux < 100000000)
			{
				aux = aux * 10 + random.Next(0, 10);
			}
			string telefono = aux.ToString();

			return new Cliente(id, nombre, direccion, telefono);
		}
	}
}
