using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    private LerpColor lerpColor;

    [SerializeField] private float JumpForce = 400f;							// Amount of force added when the player jumps.
    [SerializeField] private float decelerationThreshold = 0.2f;
    [SerializeField] private float decelerationAmount = 5f;
    [SerializeField] private float Control = 1f;
    [SerializeField] private float tiltAngle = 20f;

    // Pickup-Modified Variables
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float accelerationAmount = 10f;

    /// <summary>
    /// Implementiere Jump-Funktion
    /// </summary>
    bool onGround = true;
    [SerializeField] private float gravityScale = 3.0f;
    [SerializeField] private float globalGravity = -9.81f;


    public Rigidbody _rb;

    private bool canMove = true;

    [SerializeField] private GameObject deathEffect;
    [SerializeField] private GameObject hitEffect;

    [SerializeField] private AudioClip playerExplosion;


    // Pickup Coroutines
    public IEnumerator GhostStatus()
    {
        GameObject.Find("Player").tag = "Ghost";

        yield return new WaitForSeconds(5f);

        GameObject.Find("Player").tag = "Player";
        Debug.Log("changed");
    }

    public void GhostStatusStart()
    {
        StartCoroutine(GhostStatus());
    }

    public IEnumerator StatIncreaseDuration()
    {
        Debug.Log("Green Start");
        maxSpeed = maxSpeed * 2;
        accelerationAmount = accelerationAmount * 2;

        yield return new WaitForSeconds(5f);

        maxSpeed = maxSpeed / 2;
        accelerationAmount = accelerationAmount / 2;
        Debug.Log("Green Stop");

    }

    public void StatIncreaseDurationStart()
    {
        StartCoroutine(StatIncreaseDuration());
    }

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        _rb = GetComponent<Rigidbody>();
        lerpColor = GetComponent<LerpColor>();

    }

    private void Update()
    {
        // Jump-Abfrage
        if (Input.GetButtonDown("Jump") && onGround)
        {
            // Add a vertical force to the player.
            _rb.AddForce(Vector3.up * JumpForce);
            onGround = false;
        }
    }

    private void FixedUpdate()
    {
        CheckAlive();
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

        // Schwerkraftsanpassung für Jumps
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        _rb.AddForce(gravity, ForceMode.Acceleration);
    }

    /// <summary>
    /// Abfrage, ob der Spieler auf dem Boden ist, um einen Jump ausführen zu können
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject){
            onGround = true;
        }
    }


    void CheckAlive()
    {
        if (!(PlayerStats.currHealth > 0)) Die(); 
    }

    public void TakeDamage(int amount)
    {
        PlayerStats.currHealth -= amount;

        if (GameManager.makeItJuicy)
        {
            ChangeColor();
            GameObject effect = (GameObject)Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        } else if (GameManager.makeItMinimal)
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        if (!lerpColor.isRunning) StartCoroutine(lerpColor.StartLerping());
    }

    void ChangeColorWhite()
    {
        if (!lerpColor.isRunning) StartCoroutine(lerpColor.StartLerpingWhite());
    }
    
    public void ReceiveHealing(int amount)
    {
        if(PlayerStats.currHealth + amount <= PlayerStats.maxHealth)
        {
            PlayerStats.currHealth += amount;

            if (GameManager.makeItJuicy)
            {
                ChangeColorWhite();
            }
        }
        else
        {
            PlayerStats.currHealth = PlayerStats.maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("player died!");
        canMove = false;
        Destroy(this.gameObject);

        if (GameManager.makeItJuicy)
        {
            AudioSource.PlayClipAtPoint(playerExplosion, this.transform.position);
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
        } else if (GameManager.makeItMinimal)
        {
            AudioSource.PlayClipAtPoint(playerExplosion, this.transform.position);
        } 
    }
}
