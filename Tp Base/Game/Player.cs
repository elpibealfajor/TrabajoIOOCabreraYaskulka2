using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
	public class Player
	{
        private float angle;
        private float scale;
        private float speed;

        #region // Variables de inputs de teclado
        private bool isMoveRightKeyPressed;
        private bool isMoveLeftKeyPressed;
        private bool isMoveUpKeyPressed;
        private bool isMoveDownKeyPressed;
        private bool isMovingInDiagonalUpRight;
        private bool isMovingInDiagonalDownRight;
        private bool isMovingInDiagonalUpLeft;
        private bool isMovingInDiagonalDownLeft;
        #endregion

        private bool isShootingKeyPressed;

        private float currentShootingCooldown;
        private float shootingCooldown = 0.5f;
        private LifeController lifeController;
        private Animation idleAnimation;
        private Animation currentAnimation;

        //animaciones

        public Vector2 Position { get; set; } = Vector2.Zero;

        public Player(Vector2 position, float angle, float scale, float speed, int maxLife)
        {
            Position = position;

            this.lifeController = new LifeController(maxLife);
            this.angle = angle;
            this.scale = scale;
            this.speed = speed;

            CreateAnimations();
            currentAnimation = idleAnimation;

        }

        public void InputDetection()
        {
            isMoveRightKeyPressed = Engine.GetKey(Keys.D);
            isMoveLeftKeyPressed = Engine.GetKey(Keys.A);
            isShootingKeyPressed = Engine.GetKey(Keys.SPACE);
            isMoveDownKeyPressed = Engine.GetKey(Keys.S);
            isMoveUpKeyPressed = Engine.GetKey(Keys.W);
            isMovingInDiagonalUpRight = Engine.GetKey(Keys.W) && Engine.GetKey(Keys.D);
            isMovingInDiagonalDownRight = Engine.GetKey(Keys.S) && Engine.GetKey(Keys.D);
            isMovingInDiagonalUpLeft = Engine.GetKey(Keys.W) && Engine.GetKey(Keys.A);
            isMovingInDiagonalDownLeft = Engine.GetKey(Keys.S) && Engine.GetKey(Keys.A);
        }

        public void Update()
        {
            currentShootingCooldown -= Program.deltaTime;
            #region  // if's de input de teclado

            if (isMovingInDiagonalUpRight)
            {
                Position = new Vector2(Position.X + speed * Program.deltaTime, Position.Y - speed * Program.deltaTime);
            }
            else if (isMovingInDiagonalDownRight)
            {
                Position = new Vector2(Position.X + speed * Program.deltaTime, Position.Y + speed * Program.deltaTime);
            }
            else if (isMovingInDiagonalUpLeft)
            {
                Position = new Vector2(Position.X - speed * Program.deltaTime, Position.Y - speed * Program.deltaTime);
            }
            else if (isMovingInDiagonalDownLeft)
            {
                Position = new Vector2(Position.X - speed * Program.deltaTime, Position.Y + speed * Program.deltaTime);
            }
            else if (isMoveRightKeyPressed)
            {
                Position = new Vector2(Position.X + speed * Program.deltaTime, Position.Y);
            }
            else if (isMoveLeftKeyPressed)
            {
                Position = new Vector2(Position.X - speed * Program.deltaTime, Position.Y);
            }
            else if (isMoveUpKeyPressed)
            {
                Position = new Vector2(Position.X, Position.Y - speed * Program.deltaTime);
            }
            else if (isMoveDownKeyPressed)
            {
                Position = new Vector2(Position.X, Position.Y + speed * Program.deltaTime);
            }
            #endregion

            if (isShootingKeyPressed && currentShootingCooldown <= 0)
            {
                ShootBullet(); // aun no
            }

            currentAnimation.Update();
        }

        public void Attack()
        {

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
        private void ShootBullet() //aun no
        {
            currentShootingCooldown = shootingCooldown;
            Bullet bullet = new Bullet(Position, 90f, 1f, 300f, 50);
        }
    }
}