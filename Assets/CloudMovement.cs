using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        var delta = Vector2.right;
        var myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.AddForce(delta * Speed, ForceMode2D.Force);
    }
}
