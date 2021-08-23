using Asteroids2D_GameLogic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] LogicStarter logic;

    private InputManager inputManager;
    private void Start()
    {
        inputManager = logic.Core.InputManager;
    }
    // Update is called once per frame
    void Update()
    {
        inputManager.AxisInput(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnLeftMouseClick();
        OnRightMouseClick();
    }

    private void OnLeftMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            inputManager.MakeBulletShot();
        }
    } 
    private void OnRightMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            inputManager.MakeLaserShot();
        }
    } 
}
