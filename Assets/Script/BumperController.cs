using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public float score;
    // private Renderer renderer;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;


    private Animator animator;

    void Start() 
    {
        animator = GetComponent<Animator>();
        // renderer = GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // Animasi
            animator.SetTrigger("Hit");

            // playsfx
            audioManager.PlaySFX(collision.transform.position);

            // playvfx
            vfxManager.PlayVFX(collision.transform.position);

            // Score
            scoreManager.AddScore(score);
        }
    }
}
