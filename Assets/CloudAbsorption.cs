using UnityEngine;

public class CloudAbsorption : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {        
        if(other.gameObject.CompareTag("Sunray")) {
            Destroy(other.gameObject);
        }
    }
}
