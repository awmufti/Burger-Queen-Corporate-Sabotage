using UnityEngine;

public class Cooking : MonoBehaviour
{
    public GameObject to_Cook;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Cookable")
        {
            Vector3 spawnPosition = col.gameObject.transform.position;
            Quaternion rotationPosition = col.gameObject.transform.rotation;
            Destroy(col.gameObject);
            Instantiate(to_Cook, spawnPosition, rotationPosition);
        }
    }
}
