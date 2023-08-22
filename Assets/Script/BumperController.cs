using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    // private Renderer renderer;
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
        }
    }
}
