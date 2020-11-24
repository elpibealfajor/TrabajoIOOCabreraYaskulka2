using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button : MonoBehaviour
    {
        private Texture selectedTexture;
        private Texture normalTexture;

        public Button NextButton { get; private set; }
        public Button PreviousButton { get; private set; }

        public Button(string texturePath, Vector2 position, float scale, float angle, string selectedTexture) : base(texturePath, position, scale, angle)
        {
            this.selectedTexture = Engine.GetTexture(selectedTexture);
            this.normalTexture = Engine.GetTexture(texturePath);
            this.texture = normalTexture;
            NormalButton();
        }

        public void AssignedButtons( Button previousButton, Button nextButton)
        {
            NextButton = nextButton;
            PreviousButton = previousButton;
        }


        public void SelectedButton()
        {
            this.texture = selectedTexture;
        }

        public void NormalButton()
        {
            this.texture = normalTexture;
        }


    }
}
