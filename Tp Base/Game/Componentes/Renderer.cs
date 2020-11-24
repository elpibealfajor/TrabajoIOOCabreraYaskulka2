using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Componentes
{
    public class Renderer
    {
        private string texturePath;
        private int textureWidth;
        private int textureHeight;

        private Dictionary<string, Animation> animations;

        public string TexturePath { get => texturePath; set => texturePath = value; }
        public int TextureWidth { get => textureWidth; set => textureWidth = value; }
        public int TextureHeight { get => textureHeight; set => textureHeight = value; }

        public Renderer(int width, int height, string texture)
        {
            textureHeight = height;
            textureWidth = width;
            texturePath = texture;

        }

        public void Draw(Transform transform)
        {
            Animation currentAnimation;

            Engine.Draw(Engine.GetTexture(texturePath), transform.Position.X, transform.Position.Y, transform.Scale.X,
                transform.Scale.Y, transform.Rotation, textureWidth / 2, textureHeight / 2); 
        }
    }
}
