using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float accelerationAmount = 10f;
    [SerializeField] private float decelerationThreshold = 0.2f;
    [SerializeField] private float decelerationAmount = 5f;
    [SerializeField] private float Control = 1f;
    [SerializeField] private float tiltAngle = 20f;

    private Rigidbody _rb;

    private bool canMove = true;

    [SerializeField] private GameObject deathEffect;

    [SerializeField] private GameObject hitEffect;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        _rb = GetComponent<Rigidbody>();
        //ps = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        canMove = CheckAlive();
        if (!canMove) return;

        //float h = Input.GetAxis("Horizontal");
        //transform.rotation = Quaternion.identity;
        //transform.Rotate(Vector3.forward, -tiltAngle * h);

        Vector3 inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        inputVector = Camera.main.transform.TransformDirection(inputVector);
        inputVector.Normalize();

        Vector3 destVelocityVector = inputVector * maxSpeed;
        Vector3 curVelocityVector = _rb.velocity;

        Vector3 forceVector = destVelocityVector - curVelocityVector;
        if (inputVector.magnitude > decelerationThreshold)
        {
            forceVector *= accelerationAmount;
        }
        else
        {
            forceVector *= decelerationAmount;
        }

        forceVector *= Control;
        _rb.AddForce(forceVector);
    }

    bool CheckAlive()
    {
        return PlayerStats.currHealth > 0;
    }

    public void TakeDamage(int amount)
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        PlayerStats.currHealth -= amount;
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        canMove = false;
        this.gameObject.SetActive(false);
    }
}
