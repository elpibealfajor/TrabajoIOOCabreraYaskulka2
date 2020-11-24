using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Vector2
    {
        private float x; //campo x
        private float y; //campo y

        public static Vector2 Zero => new Vector2(0, 0); // ahora zero inicializa el vector en 0,0

        public float X { get => x; set => x = value; } // encapsulamiento x
        public float Y { get => y; set => y = value; } // encapsulamiento y

        public Vector2(float x, float y) //Constructor 
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 vector1, Vector2 vector2) //Suma de Vectores
        {
            return new Vector2(vector1.x + vector2.x, vector1.y + vector2.y);
        }

        public static bool operator ==(Vector2 vector1, Vector2 vector2) // bool que revisa si son iguales
        {
            return vector1.x == vector2.x && vector1.y == vector2.y;
        }

        public static bool operator !=(Vector2 vector1, Vector2 vector2) // bool que revisa si son distintos
        {
            return vector1.x != vector2.x || vector1.y != vector2.y;
        }

        public override string ToString() // devuelve un string que representa al objeto actual
        {
            return $"({x}, {y})"; // El signo de Dolaruco permite que en el string entren variables 
        }



    }
}
