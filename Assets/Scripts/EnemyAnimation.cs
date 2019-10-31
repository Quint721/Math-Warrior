using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    public Animator _anim;
    private Enemy _enemy;
    private SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        /*if(tag == "GuardKnight(Clone)")
        {
            _anim = GameObject.Find("GuardKnight(Clone)").GetComponent<Animator>();
            _enemy = GameObject.Find("GuardKnight(Clone)").GetComponent<Enemy>();
        }
        else
        {
           _anim = GameObject.Find("GuardKnight").GetComponent<Animator>();
           _enemy = GameObject.Find("GuardKnight").GetComponent<Enemy>();
        }*/


        _anim = GameObject.Find("GuardKnight").GetComponent<Animator>();
        _enemy = GameObject.Find("GuardKnight").GetComponent<Enemy>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyAttack();
        StartCoroutine(EnemyAnimReturntoIdle());
        EnemyDeathAnim();
    }

    void EnemyAttack()
    {
        if (_enemy.timeLeft <= 0)
        {
            Debug.Log("enemy attack");
            _anim.SetBool("TimeUp", true);
            _enemy.timeLeft = 2;
        }
    }

    public IEnumerator EnemyAnimReturntoIdle()
    {
        if (_anim.GetBool("TimeUp") == true)
        {
            yield return new WaitForSeconds(2.0f);
            _anim.SetBool("TimeUp", false);
        }
    }

    public void EnemyHit()
    {
        _anim.SetBool("IsHit", true);
        StartCoroutine(EnemyHitReturntoIdle());
    }

    public IEnumerator EnemyHitReturntoIdle()
    {
        if (_anim.GetBool("IsHit") == true)
        {
            yield return new WaitForSeconds(1.0f);
            _anim.SetBool("IsHit", false);
        }
    }

    public void EnemyDeathAnim()
    {
        if (_enemy.health <= 0)
        {
            _anim.SetBool("IsDead", true);
            StartCoroutine(EnemyDeathClear());
            _spawnManager._badGuyDead = true;
            //_anim.SetBool("IsDead", false);
            Debug.Log("DeathAnim played");
            _enemy.health = 2;
        }
    }

    public IEnumerator EnemyDeathClear()
    {
        yield return new WaitForSeconds(3.0f);
        //_anim.SetBool("IsDead", false);
        Destroy(this.gameObject);
    }
}
