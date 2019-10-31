using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthBar;
    public Image timeBar;
    public float maxTime = 5f;
    public float timeLeft = 0f;
    public float startHealth = 100f;
    public float damageDone = 15f;
    //public float enemyWeaponDamage = 15f;
    public float playerWeaponDamage = 15f;
    public float health = 0f;
    [SerializeField]
    private float _speed = 5.0f;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        health = startHealth;
        timeLeft = maxTime;
    }

    void Update()
    {
        Timer();

        if (timeLeft <= 0)
        {
            Debug.Log("Enemy Attack Animation");
            StartCoroutine(AnimBreather());
        }

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            EnemyLifeDown();
            
            if(health <= 0)
            {
                health = startHealth;
                healthBar.fillAmount = health / startHealth;
            }
        }*/
    }

    

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * _speed * horizontalInput * Time.deltaTime);
    }

    public void EnemyLifeDown()
    {
        health -= playerWeaponDamage;
        healthBar.fillAmount = health / startHealth;
    }

    public void Timer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }

        /*if (timeLeft <= 0)
        {
            timeLeft = 0;
        }*/
        
    }

    public IEnumerator AnimBreather()
    {
        yield return new WaitForSeconds(1.5f);
        timeLeft = maxTime;

    }


}
