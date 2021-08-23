using Asteroids2D_GameLogic.Architecture.Objects;
using System;
using UnityEngine;

public class ExistingObject : MonoBehaviour
{
    private BaseObject representedObject;
    public void SetRepresentedObject(BaseObject represented)
    {        
        representedObject = represented;
        representedObject.DestroyNotify += OnDestroyNotify;
    }

    private void Update()
    {
        try
        {
            SetLocation();
        }
        catch(NullReferenceException)
        {
            OnDestroyNotify(representedObject);
        }
    }

    private void OnDestroyNotify(BaseObject destroyed)
    {
        representedObject.DestroyNotify -= OnDestroyNotify;
        Destroy(gameObject);
    }

    private void SetLocation()
    {
        transform.position = new Vector3(representedObject.x, representedObject.y, 0);
        transform.rotation = Quaternion.Euler(0,0,representedObject.angleOfRotation);
    }
}
