using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class AttackSpeed : Enemy
    {
        private Animation idleAnimation;
        private Animation destroyAnimation;

        private Animation damageAnimation;

        private bool isAlive; // no esta usando life controller

        private int currentLife;
        public AttackSpeed(string texturePath, Vector2 position, float scale, float angle, float speed, int maxLife, float shooting, float shootCooldown) : base(texturePath, position, scale, angle, speed, maxLife, shooting, shootCooldown)
        {
            isAlive = true;
            currentLife = maxLife;
            CreateAnimations();
            currentAnimation = idleAnimation;
        }

        public override void Update()
        {
            //base.Update();
        }

        private void CreateAnimations()
        {
            List<Texture> idleTextures = new List<Texture>();
            for (int i = 1; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"PowerUps/AttackSpeed/{i}.png");
                idleTextures.Add(frame);
            }
            idleAnimation = new Animation(idleTextures, 0.1f, true, "Idle");

            List<Texture> destroyTexture = new List<Texture>();
            for (int i = 1; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"PowerUps/AttackSpeed/{i}.png");
                destroyTexture.Add(frame);
            }
            destroyAnimation = new Animation(destroyTexture, 0.05f, false, "Destroy");

            List<Texture> damageTexture = new List<Texture>();
            for (int i = 1; i < 4; i++)
            {
                Texture frame = Engine.GetTexture($"PowerUps/AttackSpeed/{i}.png");
                damageTexture.Add(frame);
            }
            damageAnimation = new Animation(damageTexture, 0.5f, false, "Idle");

        }
    }
}
