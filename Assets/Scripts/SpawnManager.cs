using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _guardKnightPrefab;
    public bool _badGuyDead = false;
    //public EnemyAnimation _enemyAnim;
    //public EnemyAnimation _enemyAnimation;
    //public Animator _anim;
    //public Enemy _enemy;
    
    // Start is called before the first frame update

    void Start()
    {
        //_anim = GameObject.Find("GuardKnight").GetComponent<Animator>();
        //_enemyAnimation = GameObject.Find("GuardKnight(Clone)").GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_badGuyDead == true)
        {
            StartCoroutine(SpawnEnemyRoutine());
            _badGuyDead = false;
            //_enemyAnimation._anim.SetBool("IsDead", false);
            Debug.Log("badguy off and co routine played");   
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(_guardKnightPrefab, new Vector3(1.05f, 1.05f, -0.03f), Quaternion.Euler(0f, -90.141f, 0f));
        }
        
        
    }

    public IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(4.0f);
        if (_guardKnightPrefab != null)
        {
            Instantiate(_guardKnightPrefab.gameObject, new Vector3(-3.05f, 1.05f, -0.03f), Quaternion.Euler(0f, -90.141f, 0f));
            
        }  
        //_badGuyDead = false;
        //yield return new WaitForSeconds(3.0f);
    }
}
