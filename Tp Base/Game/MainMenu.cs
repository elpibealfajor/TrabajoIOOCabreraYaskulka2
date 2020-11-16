using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu
    {

        private const string TEXTURE_PATH = "Png/Screens/MainMenu.png";
        private const string PLAY_BUTTON_TEXTURE_PATH_S = "Png/Buttons/Play-.png";
        private const string PLAY_BUTTON_TEXTURE_PATH_N = "Png/Buttons/Play.png";
        private const string CREDITS_BUTTON_TEXTURE_PATH_S = "Png/Buttons/Credits-.png";
        private const string CREDITS_BUTTON_TEXTURE_PATH_N = "Png/Buttons/Credits.png";
        private const string QUIT_BUTTON_TEXTURE_PATH_S = "Png/Buttons/Quit-.png";
        private const string QUIT_BUTTON_TEXTURE_PATH_N = "Png/Buttons/Quit.png";
        private const float INPUT_DELAY_TIME = 0.2f;
        private float currentInputDelayTime;


        private Button playButton;
        private Button creditsButton;
        private Button quitButton;
        private Button currentButton;

        private List<Button> buttons= new List<Button>();

        public MainMenu()
        {
            playButton = new Button(PLAY_BUTTON_TEXTURE_PATH_S, new Vector2(400,250),1,0,PLAY_BUTTON_TEXTURE_PATH_N );
            creditsButton = new Button(CREDITS_BUTTON_TEXTURE_PATH_S, new Vector2(400, 400),1,0, CREDITS_BUTTON_TEXTURE_PATH_N);
            quitButton = new Button(QUIT_BUTTON_TEXTURE_PATH_S, new Vector2(400, 550) , 1,0,QUIT_BUTTON_TEXTURE_PATH_N);
            buttons.Add(playButton);
            buttons.Add(creditsButton);
            buttons.Add(quitButton);


            playButton.AssignedButtons(quitButton, creditsButton);
            creditsButton.AssignedButtons(playButton, quitButton);
            quitButton.AssignedButtons(creditsButton,playButton);
            

            currentButton = playButton;
            currentButton.SelectedButton();

        }

        public void Update()
        {
            currentInputDelayTime -= Program.deltaTime;
            foreach (var button in buttons)
            {
                button.Update();
            }

            if (Engine.GetKey(Keys.UP) && currentInputDelayTime <=0)
            {
                ChangeButton(currentButton.PreviousButton);

            }
            if (Engine.GetKey(Keys.DOWN) && currentInputDelayTime <= 0)
            {
                ChangeButton(currentButton.NextButton);

            }
            if (Engine.GetKey(Keys.SPACE) && currentInputDelayTime <= 0)
            {
                SelectButton(currentButton);

            }


        }


        public void Render()
        {

            Engine.Draw(TEXTURE_PATH, 0, 0);
            foreach (var button in buttons)
            {
                button.Render();
            }

        }

        private void SelectButton (Button selectedButton)
        {
            if (selectedButton == playButton)
            {
                GameManager.Instance.ChangeGameState(GameManager.GameState.Level);
            }
            else if (selectedButton == creditsButton)
            {
                GameManager.Instance.ChangeGameState(GameManager.GameState.Credits);
            }
            else if (selectedButton == quitButton)
            {
                GameManager.Instance.ExitGame();
            }
        }
        public void ChangeButton(Button newSelectedButton)
        {
            currentInputDelayTime = INPUT_DELAY_TIME;
            currentButton.NormalButton();
            currentButton = newSelectedButton;
            currentButton.SelectedButton();
        }
    }
}
