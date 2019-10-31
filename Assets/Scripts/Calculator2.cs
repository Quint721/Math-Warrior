using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calculator2 : MonoBehaviour
{
    [SerializeField]
    private Text InputField;
    int[] number = new int[2];
    int InputValue;
    int StoredValue;
    int OutputNumber;
    int result;
    string InputString;
    string operatorSymbol;
    [SerializeField]
    bool displayedResults = false;
    [SerializeField]
    bool _buttonFirstPressed = false;
    [SerializeField]
    bool _buttonPressed = false;

    void Start()
    {

    }

    void Update()
    {

    }

    public void WriteTextToField()
    {
        InputField.text = InputString;
    }

    public void _ButtonPressed()
    {
        //this section is here merely to clear the inputfield or keep it as it is until something new
        //is typed in.
        if (displayedResults == true)
        {
            InputField.text = "";
            InputString = "";
            displayedResults = false;
            _buttonPressed = true;

        }

        //this section takes the button name and converts it in to characters printed in the inputfield
        Debug.Log("writing text");
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        InputString = InputString + buttonValue;
        WriteTextToField();

        //this section changes the string value(buttonValue) into a number value(OutputNumber).
        if (int.TryParse(buttonValue, out OutputNumber))
        {
            if (InputValue > 1)
            {
                InputValue = 0;
            }

            if (_buttonPressed == true)
            {
                number[InputValue] = OutputNumber;
            }
            else
            {
                number[InputValue] = OutputNumber;
            }

            InputValue = InputValue + 1;
           

        }
        else
        {
            switch (buttonValue)
            {
                case "+":
                    operatorSymbol = buttonValue;
                    break;
                case "-":
                    operatorSymbol = buttonValue;
                    break;
                case "=":
                    
                    switch (operatorSymbol)
                    {
                        case "+":

                            if (_buttonFirstPressed == true)
                            {
                                result = StoredValue + number[1];
                            }
                            else
                            {
                                 result = number[0] + number[1];
                             }
                            break;
                        case "-":

                            if (_buttonFirstPressed == true)
                            {
                                result = StoredValue - number[1];
                            }
                            else
                            {
                                result = number[0] - number[1];
                            }
                            break;
                    }
                    StoredValue = result;
                    _buttonFirstPressed = true;
                    displayedResults = true;
                    InputString = result.ToString();
                    //number = new int[2];
                    break;
            }
        }
        WriteTextToField();
    }
}