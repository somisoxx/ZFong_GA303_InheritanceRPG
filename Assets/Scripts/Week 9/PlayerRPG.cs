using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float health = 100f;
    public float attackDamage = 5f;
    public float attackInterval = 1f;

    private float timer;
    private bool isAttackReady = true;

    public Image attackReadyImage;

    //added variables:
    private bool isRangedAtkReady = true;
    public Image rangedAtkReadyImage;

    public GameObject bulletPrefab;
    public float bulletForce;
    public Transform bulletSpawnPosition;

    public AudioSource sfxSrc;
    public AudioClip pAtkSfx;

    Coroutine atkCd;
    

    protected virtual void Start()
    {
        
    }

    
    void Update()
    {
        /*if(healthSlider.value != life)
        {
            healthSlider.value = life;
        }*/

        if(isAttackReady == false) //MeleeAttack cooldown
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                isAttackReady = true;
                attackReadyImage.gameObject.SetActive(isAttackReady);
                timer = 0f;
            }
        }
        

        if(Input.GetMouseButtonDown(0)) //MeleeAttack
        {
            if(isAttackReady == true)
            {
                sfxSrc.clip = pAtkSfx;

                RaycastHit hit;
                sfxSrc.Play();

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();

                    if (enemy != null)
                    {
                        Attack(enemy);
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.F)) //RangedAtk
        {
            if (isRangedAtkReady == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition);
                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce);
                Destroy(bullet, 3f);
            }
        }
    }

    //IEnumerator AttackCD()
    
    public void Attack(BaseEnemy enemy) //MeleeAttack Recieved by BaseEnemy?
    {
        enemy.TakeDamage(attackDamage);
        isAttackReady = false;
        attackReadyImage.gameObject.SetActive(isAttackReady);
    }

    public void TakeDamage(float damage) //Player Death
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }
}
