using UnityEngine;

public class SpawnSunray : MonoBehaviour
{
    public GameObject Sunray;
    public float SpawnTime;
    public float SpawnDelay;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSunrays", SpawnTime, SpawnDelay);
	}
	
    public void SpawnSunrays() {
        for (int degree = 0; degree < 360; degree += 5) {
            Instantiate(Sunray, transform.position, Quaternion.Euler(0, 0, degree));
        }
    }
}
