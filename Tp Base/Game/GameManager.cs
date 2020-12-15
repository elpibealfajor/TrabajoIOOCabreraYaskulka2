using System;
using System.Linq;
using System.Media;

namespace Game
{
    public class GameManager //control de estados 
    {
        public enum GameState // enum de enteros
        {
            MainMenu,
            Credits,
            Options,
            GameOverScreen,
            WinScreen,
            Level                          
        }
        public const string GAMEOVERTEXTURE_PATH = ("Png/Screens/Loser.png");
        public const string WIN_TEXTURE_PATH = ("Png/Screens/Win.png");
        public const string CREDITS_TEXTURE_PATH = ("Png/Screens/Credits.png");

        public LevelController LevelController { get; private set; } //para poder acceder desde las otras clases
        public SimpleMenuScreen GameOverScreen { get; private set; }
        public SimpleMenuScreen WinScreen { get; private set; }

        public SimpleMenuScreen Credits { get; private set; }
        public MainMenu MainMenu { get; private set; }


        private static GameManager instance;

        public static GameManager Instance // la prim se instancia lazy
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public GameState CurrentState { get; private set; } // private set no se puede cambiar desde afuera

        public void Initialization()
        {
            InitAudio();
            LevelController = new LevelController();
            GameOverScreen = new SimpleMenuScreen(GAMEOVERTEXTURE_PATH);
            WinScreen = new SimpleMenuScreen(WIN_TEXTURE_PATH);
            MainMenu = new MainMenu();
            Credits = new SimpleMenuScreen(CREDITS_TEXTURE_PATH);
            ChangeGameState(GameState.MainMenu);
        }


        public void Update()
        {
            if(Engine.GetKey(Keys.F1))
            {
                ChangeGameState(GameState.WinScreen);
            }

            if (Engine.GetKey(Keys.F2))
            {
                ChangeGameState(GameState.GameOverScreen);
            }


            switch (CurrentState) //casos posibles de var
            {
                case GameState.MainMenu:
                    EnemyListIsEmpty();
                    MainMenu.Update();
                    break;
                case GameState.Credits:
                    Credits.Update();
                    break;
                case GameState.Options:

                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Update();

                    break;
                case GameState.WinScreen:
                    WinScreen.Update();

                    break;
                case GameState.Level:
                    LevelController.Update();
                    WinCondition();
                    break;
                default:
                    break;
            }
        }
        public void Render()
        {
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    MainMenu.Render();

                    break;
                case GameState.Credits:
                    Credits.Render();

                    break;
                case GameState.Options:

                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Render();

                    break;
                case GameState.WinScreen:
                    WinScreen.Render();

                    break;
                case GameState.Level:
                    LevelController.Render();

                    break;
                default:
                    break;
            }
        }

        public void ChangeGameState(GameState newState)
        {
            CurrentState = newState;
        }

        public void ExitGame()
        {
            Environment.Exit(1);
        }

        public void WinCondition()
        {
            if (!LevelController.Enemies.Any() && !LevelController.TankyShips.Any())
            {
                ChangeGameState(GameState.WinScreen);
            }
        }
        public void EnemyListIsEmpty()
        {
            if (!LevelController.Enemies.Any() && !LevelController.TankyShips.Any())
            {
                LevelController.CreationOfEnemies();
                
            }
        }


        public void InitAudio()
        {
            //SoundPlayer music = new SoundPlayer("Roundabout WAV.wav");
            //music.PlayLooping();
        }
    }
}
