namespace Cadeteria
{
	public enum TiposPedido { Default = 0, Ecologico = 0, Express = 25, Delicado = 30 }

	class Pedido
	{
		private int numero;
		private string observacion;
		private Cliente cliente;
		private bool estado; //true-entregado, false-no entregado
		private TiposPedido tipo;

		public int Numero { get => numero; set => numero = value; }
		public string Observacion { get => observacion; set => observacion = value; }
		public bool Estado { get => estado; set => estado = value; }
		internal Cliente Cliente { get => cliente; set => cliente = value; }
		public TiposPedido Tipo { get => tipo; set => tipo = value; }

		public Pedido(int _numero, string _observacion, bool _estado, int _tipo, Cliente _cliente)
		{
			Numero = _numero;
			Observacion = _observacion;
			Estado = _estado;

			switch (_tipo)
			{
				case 0:
					Tipo = TiposPedido.Ecologico;
					break;
				case 1:
					Tipo = TiposPedido.Express;
					break;
				case 2:
					Tipo = TiposPedido.Delicado;
					break;
				default:
					Tipo = TiposPedido.Default;
					break;
			}

			Cliente = _cliente;
			_cliente.CantPedidos++;
		}

		public float Costo(bool _cupon = false)
		{
			float total = 150;
			total += (total * (int)Tipo) / 100;
			if (_cupon) total -= total * (float)0.1;
			return total;
		}
	}
}
