using Asteroids2D_GameLogic;
using Asteroids2D_GameLogic.Architecture.Objects;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GUIController gui;
    [SerializeField] private LogicStarter logic;
    [SerializeField] private Factory factory;

    private Game game;

    private void Start()
    {
        game = logic.Core.Game;

        game.ObjectCreationNotify += CreateLinkedObject;
        game.GameIsOverNotify += GameOver;

        factory.Produce(game.Ship);



        Time.timeScale = 1;
        ApplicationData.Instance.GameIsOn = true;
    }

    private void CreateLinkedObject(BaseObject newObject)
    {
        factory.Produce(newObject);
    }

    // On Game Over
    private void GameOver()
    {
        ApplicationData.Instance.GameIsOn = false;
        ApplicationData.Instance.SetBestScore(game.Score.Count);
        gui.ShowGameOverPanel(game.Score.Count);
    }
}
