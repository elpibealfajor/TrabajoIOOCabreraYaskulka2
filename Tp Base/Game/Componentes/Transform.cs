using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Componentes
{
    public class Transform
    {
        private Vector2 position;
        private float rotation;
        private Vector2 scale;


        public Transform(Vector2 position, float rotation, Vector2 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;

        }

        public Vector2 Position { get => position; set => position = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        public Vector2 Scale { get => scale; set => scale = value; }

    }
}
