using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public LevelController LevelController { get; private set; } //para poder acceder desde las otras clases

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
            LevelController = new LevelController();
            ChangeGameState(GameState.Level);
        }


        public void Update()
        {
            switch (CurrentState) //casos posibles de var
            {
                case GameState.MainMenu:

                    break;
                case GameState.Credits:

                    break;
                case GameState.Options:

                    break;
                case GameState.GameOverScreen:

                    break;
                case GameState.WinScreen:

                    break;
                case GameState.Level:
                    LevelController.Update();
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
                    //MainMenu.Render
                    break;
                case GameState.Credits:

                    break;
                case GameState.Options:

                    break;
                case GameState.GameOverScreen:

                    break;
                case GameState.WinScreen:

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
    }



}
