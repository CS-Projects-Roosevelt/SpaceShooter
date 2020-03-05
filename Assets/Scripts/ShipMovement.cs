using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }
	private float speed = 30.0f;

	public float Speed { get => speed; set => speed = value; }

	// Update is called once per frame
	void Update()
    {
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
               
                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
    }
}