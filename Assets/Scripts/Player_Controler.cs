using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controler : MonoBehaviour {

    [Header("Player Attributes:")]
    public float movementMultiplier = 1;

    [Space]
    [Header("Player Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;

    [Space]
    [Header("Component Referances:")]
    public Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void FixedUpdate() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        ProcessInputs();
        Move();
        Animate();
    }

    void ProcessInputs() {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move() {
        rb.velocity = movementDirection * movementSpeed * movementMultiplier;
    }

    void Animate() {
        if (movementDirection != Vector2.zero) {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Velocity", movementSpeed);
    }

}
