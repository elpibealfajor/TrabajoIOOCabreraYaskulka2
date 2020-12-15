using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Render 
	{
		private string texturePath;
		private int h;
		private int w;
		public Texture texture;
		private Transform transform;
		protected Animation currentAnimation;

		public string TexturePath { get => texturePath; set => texturePath = value; }
		public Transform Transform { get => transform; set => transform = value; }

		public float Width => currentAnimation.CurrentFrame.Width;
		public float Height => currentAnimation.CurrentFrame.Height;
		//public int H { get => h; set => h = value; }
		//public int W { get => w; set => w = value; }
		//protected float OffsetX => (texture.Width * transform.Scale.X) / 2f;
		//protected float OffsetY => (texture.Height * transform.Scale.Y) / 2f;



		public Render(Texture texturePath, int h, int w)
		{

			//this.texturePath = texturePath;
			this.h = h;
			this.w = w;
			this.texture = texturePath;

		}

		public void Draw(Transform transform,Texture texturePath, float A, float B)
		{
			Engine.Draw(texturePath, transform.Position.X, transform.Position.Y, transform.Scale.X, transform.Scale.Y, transform.Angle,
				A, B);
		}
	}
}
