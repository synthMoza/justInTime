using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public class PlayerController : MonoBehaviour
{
    private Vector2 position;
    private Direction facingDirection;
    private float moveSpeed = 30f;

    [SerializeField] private Rigidbody2D rigidBody;

    // Update is called once per frame
    void Update()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (!PauseManager.isPhysicsPaused)
            rigidBody.MovePosition(rigidBody.position + position * moveSpeed * Time.fixedDeltaTime);
    }
}
