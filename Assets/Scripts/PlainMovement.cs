using UnityEngine;

public class PlainMovement : MonoBehaviour
{
    public float maxSpeed = 10f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();

        Vector3 destVelocityVector = inputVector * maxSpeed;

        _rb.AddForce(destVelocityVector);
    }
}
