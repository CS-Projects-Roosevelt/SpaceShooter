using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }
    private float damp = 0.5f;
	public float speed;
    public GameObject camera;
	public float Speed { get => speed; set => speed = value; }
    public Vector2 velocity;

	// Update is called once per frame
	void Update()
    {
        camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        /*
        if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 125));
                transform.position += Vector3.down * speed * Time.deltaTime * damp; //Vector3(-1,-1,0)
                transform.position += Vector3.left * speed * Time.deltaTime * damp;
            }
            else if ((Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.RightArrow)))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 225));
                transform.position += Vector3.down * speed * Time.deltaTime * damp;
                transform.position += Vector3.right * speed * Time.deltaTime * damp;
            }
            else if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.LeftArrow)))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
                transform.position += Vector3.up * speed * Time.deltaTime * damp; //Vector3(-1,-1,0)
                transform.position += Vector3.left * speed * Time.deltaTime * damp;
            }
            else if ((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.RightArrow)))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 315));
                transform.position += Vector3.up * speed * Time.deltaTime * damp;
                transform.position += Vector3.right * speed * Time.deltaTime * damp;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
                */
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        velocity = new Vector2(horizontalInput, verticalInput) * speed;
        float facingAngle = (Vector2.SignedAngle(Vector2.up, velocity) + 360) % 360; //last part makes sure the angle is positive (necessary for next line to work)
        velocity *= Mathf.Cos(((facingAngle + 45) % 90 - 45) * Mathf.PI / 180); //accounts for the fact that a 1,1 vector has greater magnitude than 1,0 (prevents player from going faster diagonally)
        if (velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, facingAngle)); //.lookat; .direction
        }
        transform.position += (Vector3)velocity * Time.deltaTime;

        camera.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")))));
    }
}