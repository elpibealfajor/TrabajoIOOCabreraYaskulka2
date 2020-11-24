using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        private int initialDamage;
        private float initialSpeed;
        private float angle;
        private float scale;
        private float speed;
        private float collisionRadius;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private float lifeTime = 8f;
        private float currentLifeTime;
        private int damage;
        public event Action<Bullet> OnDeactivate;
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
            initialSpeed = speed;
            initialDamage = damage;

            Engine.Debug("se creo una nueva bala");
            CreateAnimations();
            ResetValues();

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

        public void ResetValues()
        {
            GameManager.Instance.LevelController.Bullets.Add(this);
            currentAnimation = idleAnimation;
            collisionRadius = Height > Width ? Height / 2 : Width / 2;
            damage = initialDamage;
            speed = initialSpeed;
            currentLifeTime = 0;
            CreateAnimations();
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
            GameManager.Instance.LevelController.Bullets.Remove(this);
            OnDeactivate?.Invoke(this);

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
