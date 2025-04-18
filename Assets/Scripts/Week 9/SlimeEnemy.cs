using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : BaseEnemy
{
    private Animator slimeAnimator;
    public AudioSource sfxSrc;
    public AudioClip slAtkSfx, slDmgSfx;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        slimeAnimator = GetComponent<Animator>();

        Debug.Log("HeeHo I'm a slime!");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        sfxSrc.clip = slAtkSfx;

        base.Attack();
        slimeAnimator.SetTrigger("TrAttack");
        sfxSrc.Play();
        Debug.Log(this.gameObject.name + " deals " + attackDamage + " damage to you!");
    }

    public override void TakeDamage(float damage)
    {
        sfxSrc.clip = slDmgSfx;

        base.TakeDamage(damage);
        slimeAnimator.SetTrigger("TrTakeDmg");
        sfxSrc.Play();
    }
}
