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
        public static Texture texture;
        public string texturePath = "Png/Player/Idle/1.png";
        private float currentShootingCooldown;
        private float shootingCooldown = 0.5f;
        private Animation idleAnimation;
        private Animation currentAnimation;
        protected LifeController lifeController;
        private PoolBullets poolBullets;
        public Player(string texturePath,Vector2 position, float angle, float scale, float speed, int maxLife):
            base (texturePath,new Transform (position, new Vector2 (scale, scale), angle), new Render (texture,100,100),new Collider() ,1,1)
        {
            //this.lifeController = new LifeController(maxLife);
            texture = Engine.GetTexture(texturePath);
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
                Transform.Position = new Vector2(Transform.Position.X + speed * Program.deltaTime, Transform.Position.Y);
            }
            if (isMoveLeftKeyPressed)
            {
                Transform.Position = new Vector2(Transform.Position.X - speed * Program.deltaTime, Transform.Position.Y);
            }
            if (isMoveUpKeyPressed)
            {
                Transform.Position = new Vector2(Transform.Position.X, Transform.Position.Y - speed * Program.deltaTime);
            }
            if (isMoveDownKeyPressed)
            {
                Transform.Position = new Vector2(Transform.Position.X, Transform.Position.Y + speed * Program.deltaTime);
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
            bullet.Position = Transform.Position;
        }
    }
}