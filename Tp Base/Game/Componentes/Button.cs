using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        private Vector2 position;
        private string selectedTexture;
        private string normalTexture;
        private string currentTexture;

        public Button NextButton { get; private set; }
        public Button PreviousButton { get; private set; }

        public Button(string selectedTexture, string normalTexture, Vector2 position)
        {
            this.selectedTexture = selectedTexture;
            this.normalTexture = normalTexture;
            this.position = position;

            this.currentTexture = normalTexture;
            NormalButton();
        }

        public void AssignedButtons(Button previousButton, Button nextButton)
        {
            NextButton = nextButton;
            PreviousButton = previousButton;

        }
        public void Update()
        {

        }

        public void SelectedButton()
        {
            this.currentTexture = selectedTexture;
        }

        public void NormalButton()
        {
            this.currentTexture = normalTexture;
        }

        public void Render()
        {
            Engine.Draw(currentTexture, position.X, position.Y);
        }
    }
}
