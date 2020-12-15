using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Transform
	{
		private float angle;
		private Vector2 position;
		private Vector2 scale;

		public Vector2 Scale { get => scale; set => scale = value; }
		public Vector2 Position { get => position; set => position = value; }
		public float Angle { get => angle; set => angle = value; }

		public Transform(Vector2 position, Vector2 scale, float angle)
		{
			this.position = position;
			this.scale = scale;
			this.angle = angle;
		}
	}
}

