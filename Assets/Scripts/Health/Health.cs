using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header ("Death Sound")]
    [SerializeField] private AudioClip deathSound;
     [SerializeField] private AudioClip hurtSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            //SoundManager.instance.PlaySound(hurtSound);
            //iframes
        }
        else
        {
                GetComponent<PlayerDeath>().die();

                //Deactivate all attached component classes
                foreach (Behaviour component in components)
                        component.enabled = false;
                    
        }
    }

    public void AddHealth(int amount){
        this.currentHealth += amount;
        if(currentHealth > startingHealth) currentHealth = startingHealth;
    }

     private void Deactivate()
     {
        gameObject.SetActive(false);
     }
 
}
