using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy
    {
        private float angle;
        private float scale;
        private float speed;
        private float currentShootingCooldown;
        private float shootingCooldown;

        private Animation idleAnimation;
        private Animation destroyAnimation;
        private Animation damageAnimation;
        private Animation currentAnimation;

        private bool isAlive;
        private int currentLife;

        private float Width => currentAnimation.CurrentFrame.Width;
        private float Height => currentAnimation.CurrentFrame.Height;
        public Vector2 Position { get; set; } = Vector2.Zero;

        public Enemy(Vector2 initialPosition, float scale, float angle, float speed, int maxLife)
        {
            Position = initialPosition;

            isAlive = true;
            currentLife = maxLife;
            this.scale = scale;
            this.angle = angle;
            this.speed = speed;

            CreateAnimations();
            currentAnimation = idleAnimation;

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
            return (currentAnimation.CurrentFrame.Height) / 2f;
        }
        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Png/Enemy/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");

            List<Texture> destroyTexture = new List<Texture>();
            for (int i = 1; i < 8; i++)
            {
                Texture frame = Engine.GetTexture($"Png/Enemy/Destroy/{i}.png");
                destroyTexture.Add(frame);
            }
            destroyAnimation = new Animation(destroyTexture, 0.05f, false, "Destroy");

            List<Texture> damageTexture = new List<Texture>();
            for (int i = 1; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"Png/Enemy/Damage/{i}.png");
                damageTexture.Add(frame);
            }
            damageAnimation = new Animation(damageTexture, 0.5f, false, "Idle");

        }

        public void Update()
        {
            if (isAlive)
            {
                CheckCollisions(GameManager.Instance.LevelController.Bullets);

            }
            else
            {
                if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
                {
                    GameManager.Instance.LevelController.Enemies.Remove(this);
                }
            }

            currentAnimation.Update();
        }

        private void CheckCollisions(List<Bullet> bullets)
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (IsBoxColliding(bullets[i]))
                {
                    BulletCollision(bullets[i]);
                }
            }
        }


        private void BulletCollision(Bullet bullet)
        {
            currentLife -= bullet.Damage;
            bullet.DestroyBullet();

            if (currentLife <= 0)
            {
                isAlive = false;
                currentAnimation = destroyAnimation;
            }
        }
        private bool IsBoxColliding(Bullet bullet)
        {
            float distanceX = Math.Abs(Position.X - bullet.Position.X);
            float distanceY = Math.Abs(Position.Y - bullet.Position.Y);

            float WidthDiv2 = Width / 2 + bullet.Width / 2;
            float HeightDiv2 = Height / 2 + bullet.Height / 2;

            return distanceX <= WidthDiv2 && distanceY <= HeightDiv2;
        }
    }
}
