using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        private float angle;
        private float scale;
        private float speed;
        private float collisionRadius;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private float lifeTime = 8f;
        private float currentLifeTime;
        private int damage;

        public float CollisionRadius => collisionRadius;
        public int Damage => damage;
        public Vector2 Position { get; set; } = Vector2.Zero;

        public float Width => currentAnimation.CurrentFrame.Width;
        public float Height => currentAnimation.CurrentFrame.Height;
        public Bullet(Vector2 initialPosition, float angle, float scale, float speed, int damage)
        {
            Position = initialPosition;

            this.angle = angle;
            this.scale = scale;
            this.speed = speed;
            this.damage = damage;

            Program.bullets.Add(this);
            CreateAnimations();
            currentAnimation = idleAnimation;
            collisionRadius = Height > Width ? Height / 2 : Width / 2;
        }

        public void Start()
        {

        }

        public void Update()
        {
            currentLifeTime += Program.deltaTime;

            if (currentLifeTime >= lifeTime)
            {
                DestroyBullet();
            }
            Position = new Vector2(Position.X + speed * Program.deltaTime, Position.Y);

            currentAnimation.Update();
        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Png/Bullet/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");
        }

        public void DestroyBullet()
        {
            Program.bullets.Remove(this);
        }


        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentFrame, Position.X, Position.Y, scale, scale, angle, GetOffSetX(), GetOffSetY());
        }
        private float GetOffSetX()
        {
            return (currentAnimation.CurrentFrame.Width * scale) / 2f;
        }

        private float GetOffSetY()
        {
            return (currentAnimation.CurrentFrame.Height * scale) / 2f;
        }
    }
}
