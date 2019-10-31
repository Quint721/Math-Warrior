using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    private Calculator _calculator;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("Player").GetComponent<Animator>();
        _calculator = GameObject.Find("Attack_Calculator").GetComponent<Calculator>();
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDeathAnim();
        if (Input.GetKeyDown(KeyCode.X))
        {
            _anim.SetTrigger("AnswerCorrect");
            //_anim.SetBool("Answer_Correct", true);
            //StartCoroutine(AnimReturntoIdle());
        }
    }

    public void Attack1()
    {
        if (_calculator.Calc[0] == _calculator.QuestionResult)
        {
            Debug.Log("Play Animation from animator");
            _anim.SetTrigger("AnswerCorrect");
            //StartCoroutine(AnimReturntoIdle());
        }
        /*while (_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            yield return null;
        }

        if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            _anim.SetBool("Answer_Correct", false);
        }*/
        /*if(_anim.IsPlaying("Attack"))
        {
            _anim.SetBool("Answer_Correct", true);
        }
        else if (!_anim.IsPlaying("Attack"))
        {
            _anim.SetBool("Answer_Correct", false);
        }*/
    }

    public IEnumerator AnimReturntoIdle()
    {
        if(_anim.GetBool("Answer_Correct") == true)
        {
            yield return new WaitForSeconds(2.0f);
            //_anim.SetTrigger("Animation_complete");
            //_anim.SetBool("Answer_Correct", false);
        }
    }

    public void PlayerHit()
    {
        _anim.SetBool("IsHit", true);
        StartCoroutine(HitReturntoIdle());
    }

    public IEnumerator HitReturntoIdle()
    {
        if (_anim.GetBool("IsHit") == true)
        {
            yield return new WaitForSeconds(1.0f);
            _anim.SetBool("IsHit", false);
        }
    }

    public void PlayerDeathAnim()
    {
        if (_player._playerLife <= 0)
        {
            _anim.SetBool("IsDead", true);
        }
    }
}
