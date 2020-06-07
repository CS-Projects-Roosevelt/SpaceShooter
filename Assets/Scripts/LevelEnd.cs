using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string transportTo;
    // Start is called before the first frame update
    void Start()
    {
        //AssetBundle.LoadFromFile("Assets/Scenes/" + transportTo + ".unity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.root.name == "PlayerShip")
        {
            Debug.Log("Level end collision with " + other.gameObject.transform.root.name);
            SceneManager.LoadScene(transportTo);
        }
    }
}
