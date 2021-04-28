using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private Vector3 offset;

    public float turnSpeed = 0.3f;

    [SerializeField] private bool cameraStyle = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        offset = transform.position - player.transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");

        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (cameraStyle)
        {
            // Focus Style
            if (Input.GetKey(KeyCode.E))
            {
                offset = Quaternion.AngleAxis(turnSpeed, Vector3.up) * offset;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                offset = Quaternion.AngleAxis(-turnSpeed, Vector3.up) * offset;
            }

            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        } else
        {
            // RTS Style
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }

            //float scroll = Input.GetAxis("Mouse ScrollWheel");
            //
            //Vector3 pos = transform.position;
            //
            //pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            //pos.y = Mathf.Clamp(pos.y, minY, maxY);
            //
            //transform.position = pos;
        }
    }
}
