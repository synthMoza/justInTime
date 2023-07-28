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

public class Player : MonoBehaviour
{
    private Vector2 position;
    private Direction facingDirection;
    private float moveSpeed = 25f;
    private bool isActive;

    [SerializeField] private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    public void ChangeState()
    {
        isActive = !isActive;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (isActive)
            rigidBody.MovePosition(rigidBody.position + position * moveSpeed * Time.fixedDeltaTime);
    }
}
