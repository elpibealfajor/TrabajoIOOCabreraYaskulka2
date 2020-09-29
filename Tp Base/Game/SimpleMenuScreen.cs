using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SimpleMenuScreen
    {

        private string texturePath;
        public SimpleMenuScreen(string texturePath)
        {
            this.texturePath = texturePath;
        }

        public void Update()
        {
            if (Engine.GetKey(Keys.ESCAPE))
            {
                GameManager.Instance.ChangeGameState(GameManager.GameState.MainMenu);
            }
        }

        public void Render()
        {
            Engine.Draw(texturePath,0,0);
        }
    }
}
