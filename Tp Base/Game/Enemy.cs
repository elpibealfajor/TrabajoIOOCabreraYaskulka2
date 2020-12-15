using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Enemy : MonoBehaviour 
    {

        private float speed;
        private float currentShootingCooldown;
        private float shootingCooldown;
        private float shootCooldown;
        private Animation idleAnimation;
        private Animation destroyAnimation;
        private Animation damageAnimation;
        private Animation currentAnimation;

        private bool isAlive; // no esta usando life controller

        private int currentLife;

        private float Width => currentAnimation.CurrentFrame.Width;
        private float Height => currentAnimation.CurrentFrame.Height;



        public Enemy(string texturePath, Vector2 position, float scale, float angle, float speed, int maxLife, float shooting, float shootCooldown) : base(texturePath, position, scale, angle)
        {

            isAlive = true;
            currentLife = maxLife;
            this.speed = speed;
            this.shootCooldown = shootCooldown;

            CreateAnimations();
            currentAnimation = idleAnimation;

        }

        private  void CreateAnimations()
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

        public  override void Update()
        {
            currentShootingCooldown -= Program.deltaTime;

            if(currentShootingCooldown <= 0)
            {
                currentShootingCooldown = shootCooldown;

            }
            if (isAlive)
            {
                CheckCollisions(GameManager.Instance.LevelController.Bullets);

            }
            else
            {
                if (currentAnimation.CurrentFrameIndex == currentAnimation.FramesCount - 1)
                {
                    GameManager.Instance.LevelController.Enemies.Remove(this);
                    GameManager.Instance.LevelController.TankyShips.Remove(this);
                }
            }

            currentAnimation.Update();
            texture = currentAnimation.CurrentFrame;
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
        private void Shoot()
        {

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
