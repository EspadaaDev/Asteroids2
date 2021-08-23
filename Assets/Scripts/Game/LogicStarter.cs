using Asteroids2D_GameLogic;
using UnityEngine;

public class LogicStarter : MonoBehaviour
{
    public Core Core { get; private set; }

    private void Awake()
    {
        Core = new Core();
    }
    private void FixedUpdate()
    {
        Core.TimeWarp.AddTime(Time.deltaTime);
    }
}
