using Asteroids2D_GameLogic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    [SerializeField] private LogicStarter logic;

    [Header("GUI:")]
    [SerializeField] private Text TxtScore;
    [SerializeField] private Text TxtBestScore;
    [Header("Info Panel:")]
    [SerializeField] private Text TxtLaserShots;
    [SerializeField] private Text TxtXCoordinate;
    [SerializeField] private Text TxtYCoordinate;
    [SerializeField] private Text TxtAngle;
    [SerializeField] private Text TxtSpeed;
    [SerializeField] private Text TxtReloadLaserTimer;
    [SerializeField] private Image ReloadLaserProgressBar;

    [Header("Others:")]
    [SerializeField] private Text TxtLastScore;
    [SerializeField] private GameObject PanelGameOver;

    private GameInfo gameInfo;

    private void Start()
    {
        TxtBestScore.text = "BEST:  " + ApplicationData.Instance.BestScore.ToString();
        gameInfo = logic.Core.GameInfo;
    }

    private void Update()
    {
        InfoPanelUpdate();
        ScoreUpdate();
    }

    // Updating the points obtained during the game
    private void ScoreUpdate()
    {
        TxtScore.text = gameInfo.Score.ToString();
    }

    // Updating the current number of laser shots
    private void LaserShotsUpdate()
    {
        TxtLaserShots.text = gameInfo.NumOfLasershots + " \\ " + gameInfo.MaxLaserShots;
    }

    // The method displays game end panel and sets the value of scored points
    public void ShowGameOverPanel(int value)
    {
        PanelGameOver.SetActive(true);
        TxtLastScore.text = "Score: " + value.ToString();
    }

    // Updating dashboard components
    private void InfoPanelUpdate()
    {
        // Coordinates
        TxtXCoordinate.text = "X: " + (Math.Round(gameInfo.ShipLocationX, 1) * 10f).ToString();
        TxtYCoordinate.text = "Y: " + (Math.Round(gameInfo.ShipLocationY, 1) * 10f).ToString();

        // Speed and angle of spaceship
        TxtSpeed.text = "Speed: " + (Math.Round(gameInfo.ShipVelocity, 2) * 100f).ToString();
        TxtAngle.text = "Angle: " + Math.Round(gameInfo.ShipAngleOfRotation, 0).ToString() + "°";

        LaserShotsUpdate();
        ReloadInfoUpdate();
    }

    // Laser reload information update
    private void ReloadInfoUpdate()
    {
        TxtReloadLaserTimer.text = Math.Round(gameInfo.LaserShotReloadTimer, 2).ToString();
        ReloadLaserProgressBar.fillAmount = gameInfo.LaserShotReloadTimer / gameInfo.ReloadTimeOfOneLaserShot;
    }
}
