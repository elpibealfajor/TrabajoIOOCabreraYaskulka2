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
        protected Texture texture;

        public Vector2 Position { get; set; } = Vector2.Zero;

        protected float OffsetX => (texture.Width * scale) / 2f;
        protected float OffsetY => (texture.Height * scale) / 2f;


        public MonoBehaviour(string texturePath, Vector2 position, float scale, float angle)
        {
            Engine.Debug("constructor de Monobehabiour");

            Position = position;

            this.scale = scale;
            this.angle = angle;
            this.texture = Engine.GetTexture(texturePath);
        }

        public virtual void Update()
        {

        }

        public virtual void Render()
        {
            Engine.Draw(texture, Position.X, Position.Y, scale, scale, angle, OffsetX, OffsetY);
        }
    }
}
