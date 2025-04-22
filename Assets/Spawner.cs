using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject myItem;

    public void SpawnSphere()
    {
        Instantiate(myItem);
    }
}
