using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    private Text health;
    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.transform.Find("Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int number)
    {
        health.text = "" + number;
    }
}
