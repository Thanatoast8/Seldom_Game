using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controler : MonoBehaviour {

    public Transform target;
    public Vector2 offset;

    public Vector2 targetPos;

    public Vector2 MaxPos;
    public Vector2 MinPos;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        targetPos.x = Mathf.Clamp(target.position.x, MinPos.x, MaxPos.x);
        targetPos.y = Mathf.Clamp(target.position.y, MinPos.y, MaxPos.y);
        transform.position = new Vector3(targetPos.x + offset.x, targetPos.y + offset.y, -10);
    }
}
