using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShellEnemy : SlimeEnemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        
    }

    void OnCollsionEnter(Collision other)
    {

    }
}
