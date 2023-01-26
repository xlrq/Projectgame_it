using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            Deactivate();
        }
    }

     private void Deactivate()
     {
        gameObject.SetActive(false);
     }
}