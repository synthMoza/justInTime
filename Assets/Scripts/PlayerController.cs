using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 position;
    
    public float moveSpeed;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    void Update()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");

        if (!PauseManager.isPhysicsPaused)
        {
            animator.SetFloat("Horizontal", position.x);
            animator.SetFloat("Vertical", position.y);
            animator.SetFloat("Speed", position.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        if (!PauseManager.isPhysicsPaused)
            rigidBody.AddForce(position * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }
}
