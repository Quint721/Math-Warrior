using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField]
    private Text InputField;
    [SerializeField]
    private Text Question_Field;
    int InputValue;
    public int QuestionResult;
    int OutputNumber;
    int result;
    [SerializeField]
    int FirstButtonCounter;
    string InputString;
    string FirstNumber;
    string SecondNumber;
    [SerializeField]
    bool displayedResults = false;
    [SerializeField]
    bool _operatorPressed = false;
    [SerializeField]
    bool _noQuestionYet = false;
    
    [SerializeField]
    bool _noResultYet = false;

    public List<int> Calc = new List<int>();
    public List<int> Questions = new List<int>();
    private PlayerAnimation _playerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimation = GameObject.Find("Player").GetComponent<PlayerAnimation>();
        _noResultYet = true;
        QuestionSet();
        _noQuestionYet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            QuestionSet();
            _noQuestionYet = false;
        }

        

        /*if(_noQuestionYet == false &&_displayedAnswer == false)
        {
            AttackCycle();
        }*/
    }

    public void QuestionSet()
    {
        Questions.Add(Random.Range(0, 21));
        Questions.Add(Random.Range(0, 21));
        QuestionResult = Questions[0] + Questions[1];
        WriteQuestionToField();
    }

    

    public void WriteTextToField()
    {
        InputField.text = InputString;
    }

    public void WriteQuestionToField()
    {
        //in order to make each component display you need to have a + inbetween, which will accumulate the stuff in the text field
        Question_Field.text = Questions[0].ToString() + "+" + Questions[1].ToString(); 
    }

    public void ButtonPressed()
    {
        //This section clears the input field of any text and values so that 
        //the next calculation can occur
        if (displayedResults == true)
        {
            InputField.text = "";
            InputString = "";
            displayedResults = false;
            Questions.Clear();
            Calc.Clear();
        }

        if (_operatorPressed == false)
        {
            FirstButtonCounter++;
        }

        Debug.Log("writing text");
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        InputString = InputString + buttonValue;
        WriteTextToField();

        //this section changes the string value(buttonValue) into a number value(OutputNumber).
        if (int.TryParse(buttonValue, out OutputNumber))
        {
            /*if (InputValue > 1)
            {
                InputValue = 0;
            }

            InputValue = InputValue + 1;*/

            if (_noResultYet == true)
            {
                Calc.Add(OutputNumber);
                _noResultYet = false;
            }
            //I only need to times by 10 at each point because we are updating slot Calc[0] which has already been multiplied by 10 previously 
            //at each point.
            switch (FirstButtonCounter)
            {
                case 2:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 3:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 4:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 5:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 6:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 7:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 8:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 9:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
                case 10:
                    Calc[0] = (Calc[0] * 10) + OutputNumber;
                    break;
            }
            AttackCycle();
            //_playerAnimation.Attack1();
        }

    }

    public void AttackCycle()
    {
        if (Calc[0] == QuestionResult)
        {
            //Debug.Log("Play Animation");
            _noResultYet = true;
            _noQuestionYet = true;
            _playerAnimation.Attack1();
            ClearInputField();
            QuestionSet();
            _noQuestionYet = false;
        }

    }

    public void ClearInputField()
    {

        //if (displayedResults == true)
        //{
        Calc.Clear();
        Questions.Clear();
        Question_Field.text = "";
        InputField.text = "";
        InputString = "";
        result = 0;
        QuestionResult = 0;
        FirstButtonCounter = 0;
        _operatorPressed = false;
        _noQuestionYet = true;
        _noResultYet = true;
        //displayedResults = false;
        //}
    }

    public void OperatorButtons()
    {
      
    }
}
