using UnityEngine;

public class SunrayMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var delta = transform.rotation * Vector2.right;
        var myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(delta * 100, ForceMode2D.Force);
    }
}
