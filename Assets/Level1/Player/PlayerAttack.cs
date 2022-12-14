using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    [SerializeField] private AudioSource fireballSound;

    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
   
    public void CanAttack (){
        if (cooldownTimer > attackCooldown)
        {
            Attack();
            // SoundManager.instance.PlaySound(fireballSound);
        }
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        fireballSound.Play();
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projtile>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
