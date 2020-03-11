using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    private GameObject target;
    public string targetName;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(targetName);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaVector = target.transform.position - transform.position;
        if (transform.position != target.transform.position)
        {
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, deltaVector));
        }
        if (deltaVector.magnitude > speed) // prevents ship from rapidly changing directions when it's over its target
        {
            //transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector3.up, deltaVector));
            transform.position += deltaVector / deltaVector.magnitude * speed * Time.deltaTime;
        }
        else
        {
            transform.position = target.transform.position;
        }
    }
}
