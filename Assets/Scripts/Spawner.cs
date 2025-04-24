using Meta.WitAi;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cheese;
    public GameObject burger;
    public GameObject bunTop;
    public GameObject bunBot;
    public GameObject lettuce;
    public GameObject tomato;

    public void SpawnCheese()
    {
        Instantiate(cheese);
    }

    public void SpawnBurger()
    {
        Instantiate(burger);
    }
    public void SpawnLettuce()
    {
        Instantiate(lettuce);
    }
    
    public void SpawnBun()
    {
        Instantiate(bunTop);
        Instantiate(bunBot);
    }
    
    public void SpawnTomato()
    {
        Instantiate(tomato);
    }
}
