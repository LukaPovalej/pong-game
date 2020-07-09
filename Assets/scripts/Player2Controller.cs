using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    Vector3 initialPosition;
    Rigidbody2D rigidbody;

    void Start()
    {
        initialPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void resetPos()
    {
        transform.position = initialPosition;
        rigidbody.velocity = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.up * Time.deltaTime * 40f, Space.World);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector3.down * Time.deltaTime * 40f, Space.World);
        }
    }
    void OnCollisonExit2D(Collision2D other)
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
