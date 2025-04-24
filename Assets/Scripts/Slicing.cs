using UnityEngine;

public class Slicing : MonoBehaviour
{
    public GameObject cut_cabbage;
    public GameObject cut_tomato;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Tomato (Uncut)(Clone)")
        {
            Vector3 spawnPosition = col.gameObject.transform.position;
            Destroy(col.gameObject);
            Instantiate(cut_tomato, spawnPosition, Quaternion.identity);
        } else if (col.gameObject.name == "Cabbage (Uncut)(Clone)")
        {
            Vector3 spawnPosition = col.gameObject.transform.position;
            Destroy(col.gameObject);
            Instantiate(cut_cabbage, spawnPosition, Quaternion.identity);
        }
    }

}
