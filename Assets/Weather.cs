using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject Cloud;
    public float SpawnTime;
    public float SpawnDelay;

    void Start()
    {
		InvokeRepeating("SpawnCloud", SpawnTime, SpawnDelay);
    }

    public void SpawnCloud() {
        var randomYOffset = Random.Range(-1.0f, 1.0f); 
        var position = new Vector3(transform.position.x, transform.position.y + randomYOffset, transform.position.z);
        Instantiate(Cloud, position, Quaternion.Euler(0, 0, 0));
    }
}
