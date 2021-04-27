using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private new Camera camera;
    
    [SerializeField]
    private float speed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 impulse = new Vector3();
        /*
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        impulse = camera.transform.right * x + camera.transform.forward * z;
        */
        if (Input.GetKey(KeyCode.W))
        {
            impulse += new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            impulse += new Vector3(-camera.transform.right.x, 0, -camera.transform.right.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            impulse += new Vector3(-camera.transform.forward.x, 0, -camera.transform.forward.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            impulse += new Vector3(camera.transform.right.x, 0, camera.transform.right.z);
        }
        

        impulse = impulse.normalized * Time.deltaTime * speed;

        this.gameObject.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Acceleration);
    }
}
