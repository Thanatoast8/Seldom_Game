﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controler : MonoBehaviour {

    public Transform player;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10);
    }
}