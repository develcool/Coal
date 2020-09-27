using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Player")
        {
            if (MainScript.isPicked == true)
            {
                MainScript.isPicked = false;
                MainScript.FireHP += 2;
            }
        }
    }
}
