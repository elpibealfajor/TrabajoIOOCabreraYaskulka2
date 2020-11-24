using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Player : MonoBehaviour
	{
        private float speed;

        #region // Variables de inputs de teclado
        private bool isMoveRightKeyPressed;
        private bool isMoveLeftKeyPressed;
        private bool isMoveUpKeyPressed;
        private bool isMoveDownKeyPressed;
        #endregion

        private bool isShootingKeyPressed;

        private float currentShootingCooldown;
        private float shootingCooldown = 0.5f;
        private Animation idleAnimation;
        private Animation currentAnimation;
        private PoolBullets poolBullets;
        public Player(string texturePath, Vector2 position, float scale, float angle, float speed) : base(texturePath, position, scale, angle)
        {
            this.speed = speed;
            CreateAnimations();
            currentAnimation = idleAnimation;
            poolBullets = new PoolBullets();
        }

        //private const float IDLE_ANIMATION_PATH = "Png/Player/Idle/;
        public void InputDetection()
        {
            isMoveRightKeyPressed = Engine.GetKey(Keys.D);
            isMoveLeftKeyPressed = Engine.GetKey(Keys.A);
            isShootingKeyPressed = Engine.GetKey(Keys.SPACE);
            isMoveDownKeyPressed = Engine.GetKey(Keys.S);
            isMoveUpKeyPressed = Engine.GetKey(Keys.W);
        }

        public override void Update()
        {
            //base.Update(); // llama al update que haya en el monobehaviour

            currentShootingCooldown -= Program.deltaTime;
            #region  // if's de input de teclado


            if (isMoveRightKeyPressed)
            {
                Position = new Vector2(Position.X + speed * Program.deltaTime, Position.Y);
            }
            if (isMoveLeftKeyPressed)
            {
                Position = new Vector2(Position.X - speed * Program.deltaTime, Position.Y);
            }
            if (isMoveUpKeyPressed)
            {
                Position = new Vector2(Position.X, Position.Y - speed * Program.deltaTime);
            }
            if (isMoveDownKeyPressed)
            {
                Position = new Vector2(Position.X, Position.Y + speed * Program.deltaTime);
            }
            #endregion

            if (isShootingKeyPressed && currentShootingCooldown <= 0)
            {
                ShootBullet(); // aun no
            }

            currentAnimation.Update();
            texture = currentAnimation.CurrentFrame;
        }


        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 5; i++)
            {
                Texture frame = Engine.GetTexture($"Png/Player/Idle/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.18f, true, "Idle");
        }


        private void ShootBullet() 
        {
            currentShootingCooldown = shootingCooldown;
            //Bullet bullet = new Bullet(Position, 90f, 1f, 300f, 50);
            Bullet bullet = poolBullets.GetBullet();
            bullet.Position = Position;
        }
    }
}