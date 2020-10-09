namespace Cadeteria
{
	class Persona
	{
		private int id;
		private string nombre;
		private string direccion;
		private string telefono;

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public string Telefono { get => telefono; set => telefono = value; }

		public Persona()
		{
			Id = 0;
			Nombre = "";
			Direccion = "";
			Telefono = "";
		}

		public Persona(int _id, string _nombre, string _direccion, string _telefono)
		{
			Id = _id;
			Nombre = _nombre;
			Direccion = _direccion;
			Telefono = _telefono;
		}
	}
}
