using Asteroids2D_GameLogic.Architecture.Objects;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject shipPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject laserRayPrefab;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject smallAsteroidPrefab;
    [SerializeField] private GameObject flyingSaucerPrefab;

    public void Produce(BaseObject newObject)
    {
        switch (newObject.Type)
        {
            case ObjectType.Ship:
                Instantiate(shipPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
            case ObjectType.Asteroid:
                Instantiate(asteroidPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
            case ObjectType.SmallAsteroid:
                Instantiate(smallAsteroidPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
            case ObjectType.FlyingSaucer:
                Instantiate(flyingSaucerPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
            case ObjectType.Bullet:
                Instantiate(bulletPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
            case ObjectType.LaserRay:
                Instantiate(laserRayPrefab).GetComponent<ExistingObject>().SetRepresentedObject(newObject);
                break;
        }
    }
}
