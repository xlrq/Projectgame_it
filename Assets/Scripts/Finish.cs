using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private Animator anim;

    //private AudioSource finishSound;
    private void Start()
    {
        //finishSound = GetComponent<AudioSource>();
        rb = player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //finishSound.Play();
        PlayerManager.isLevelCompleted = true;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Raise");
    }
}
