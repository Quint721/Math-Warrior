using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    private Enemy _enemy;
    private EnemyAnimation _enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.Find("GuardKnight").GetComponent<Enemy>();
        _enemyAnim = GameObject.Find("GuardKnight").GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "GuardKnight")
        {
           if(_enemy != null)
            {
             _enemyAnim.EnemyHit();   
             _enemy.EnemyLifeDown();
            }
        } 
    }
}
