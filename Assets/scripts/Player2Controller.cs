﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
