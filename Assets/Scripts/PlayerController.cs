using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 position;
    
    public float moveSpeed;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource walkingAudioSource;
    [SerializeField] private AudioClip[] walkingSoundClips;
    private float walkingSoundTimer;
    private float walkingSoundDelay = 0.25f;

    void HandleWalkingSounds()
    {
        if (position == Vector2.zero)
            return;
        
        walkingSoundTimer -= Time.deltaTime;
        if (walkingSoundTimer <= 0)
        {
            walkingAudioSource.PlayOneShot(walkingSoundClips[Random.Range(0, walkingSoundClips.Length)]);
            walkingSoundTimer = walkingSoundDelay;
        }
    }

    void Update()
    {
        position.x = Input.GetAxisRaw("Horizontal");
        position.y = Input.GetAxisRaw("Vertical");

        if (!PauseManager.isPhysicsPaused)
        {
            HandleWalkingSounds();
            
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
