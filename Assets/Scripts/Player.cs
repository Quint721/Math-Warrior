using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    public float _playerLife = 100f;
    //public float _playerWeaponDamage = 15f;
    public float _enemyDamage = 15f;

    private Enemy _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GameObject.Find("GuardKnight").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.left * _speed * horizontalInput * Time.deltaTime);
    }

    public void PlayerLifeDown()
    {
        _playerLife -= _enemyDamage;
    }
}
