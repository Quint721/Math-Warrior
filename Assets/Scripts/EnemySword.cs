using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    private Player _player;
    private PlayerAnimation _playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _playerAnim = GameObject.Find("Player").GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Collided with:" + other.name);

            if (_player != null)
            {   
              _playerAnim.PlayerHit();
              //_playerAnim.HitReturntoIdle();
              _player.PlayerLifeDown();

              /*if (_player._playerLife <= 0)
               {
                 _playerAnim.PlayerDeathAnim();
               }*/
                
            }
        }
    }
}
