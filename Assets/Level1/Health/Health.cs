using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header("Sound")]
    [SerializeField] private AudioSource healSound;
    [SerializeField] private AudioSource deathSound;

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
            
            // hurt
            anim.SetTrigger("hurt");
            anim.SetTrigger("angryHurt");
            //anim.SetTrigger("ChamleonHurt");
        }
        else
        {
            if (!dead)
            {
                /*anim.SetTrigger("angryDie");
                anim.SetTrigger("ChamleonDie");*/
                anim.SetTrigger("angryDie");
                if (GetComponent<model>() != null)
                {
                    GetComponent<model>().enabled = false;
                    SceneManager.LoadScene("Lose");
                } 
                else
                {
                    //Deactivate all attacked components classes
                    foreach (Behaviour component in components)
                        component.enabled = false;
                    
                    anim.SetTrigger("ChamleonDie");
                }

                dead = true;
                //SceneManager.LoadScene("Lose");
                deathSound.Play();

            }

        }
    }

    public void AddHealth(float _value)
    {
        healSound.Play();

        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
