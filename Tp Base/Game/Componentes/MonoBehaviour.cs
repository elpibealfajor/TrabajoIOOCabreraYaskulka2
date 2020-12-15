using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class MonoBehaviour
    {

		protected float angle;
		protected float scale;
		private Transform transform;
		private Render render;
		private Collider collider;
		public Texture texture;
		protected Animation currentAnimation;

		public Transform Transform { get => transform; set => transform = value; }
		public Render Render { get => render; set => render = value; }
		public Collider Collider { get => collider; set => collider = value; }

		public float Width => currentAnimation.CurrentFrame.Width;
		public float Height => currentAnimation.CurrentFrame.Height;
		protected float OffsetX => (texture.Width * scale) / 2f;
		protected float OffsetY => (texture.Height * scale) / 2f;


		public MonoBehaviour(string texturePath,Transform transform, Render render,Collider collider,float angle, float scale)
		{
			this.transform = transform;
			this.render = render;
			this.collider = collider;
			this.scale = scale;
			this.angle = angle;
			this.texture = Engine.GetTexture(texturePath);
			
		}

		public void Renderer()
		{
			this.render.Draw(this.transform, this.texture, OffsetX, OffsetY);
		}
		public void CheckCollisions(List<Bullet> bullets)
		{
			for (int i = bullets.Count - 1; i >= 0; i--)
			{
				if (collider.IsBoxColliding (bullets[i]))
				{
					collider.BulletCollision(bullets[i]);
				}
			}
		}
		public abstract void Update();
	}
}
