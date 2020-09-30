using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
	class Helpers
	{
		static public Random random = new Random(Environment.TickCount);
		public enum Nombres { Pablo, Maria, Pedro, Sara, Juan, Julieta };
		public enum Apellidos { Perez, Martinez, Sanchez, Fernandez, Gonzalez, Diaz };
		public enum Direcciones { Cordoba, Junin, Maipu, Muñecas, Santiago, Rondeau, Larrea };
		
		static public Pedido PedidoAleatorio(int numeroP, int idC)
		{
			string observacion = "";
			
			int aux = random.Next() % 2;
			bool estado;
			if(aux == 1)
			{
				estado = true;
			}
			else
			{
				estado = false;
			}

			int t = random.Next(Enum.GetNames(typeof(Nombres)).Length);
			Type tipoEnum = typeof(Nombres);
			string nombre = Enum.GetNames(tipoEnum)[t];

			t = random.Next(Enum.GetNames(typeof(Apellidos)).Length);
			tipoEnum = typeof(Apellidos);
			nombre += " " + Enum.GetNames(tipoEnum)[t];

			t = random.Next(Enum.GetNames(typeof(Direcciones)).Length);
			tipoEnum = typeof(Direcciones);
			string direccion = Enum.GetNames(tipoEnum)[t];

			aux = 15;
			while(aux < 100000000)
			{
				aux = aux * 10 + random.Next() % 10;
			}
			string telefono = aux.ToString();

			return new Pedido(numeroP, observacion, estado, idC, nombre, direccion, telefono);
		}

		static public Cadete CadeteAleatorio(int id)
		{
			int t = random.Next(Enum.GetNames(typeof(Nombres)).Length);
			Type tipoEnum = typeof(Nombres);
			string nombre = Enum.GetNames(tipoEnum)[t];

			t = random.Next(Enum.GetNames(typeof(Apellidos)).Length);
			tipoEnum = typeof(Apellidos);
			nombre += " " + Enum.GetNames(tipoEnum)[t];

			t = random.Next(Enum.GetNames(typeof(Direcciones)).Length);
			tipoEnum = typeof(Direcciones);
			string direccion = Enum.GetNames(tipoEnum)[t];

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
