using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTranform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D sawRb2d;
    [SerializeField] private GameObject sawGo;
    // Start is called before the first frame update
    void Start()
    {
        sawRb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sawRb2d.velocity = new Vector2(6f, sawRb2d.velocity.y);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MainScript.FireHP = -1;

        }
        if(collision.gameObject.tag == "Delet")
        {
            Destroy(sawGo);
        }
    }
}
