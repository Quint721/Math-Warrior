using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Calculator3 : MonoBehaviour
{
    [SerializeField]
    private Text InputField;
    int InputValue;
    int StoredValue;
    int OutputNumber;
    int result;
    [SerializeField]
    int FirstButtonCounter;
    [SerializeField]
    int SecondButtonCounter;
    string InputString;
    string operatorSymbol;
    [SerializeField]
    bool displayedResults = false;  
    [SerializeField]
    bool _operatorPressed = false;
    [SerializeField]
    bool _noCalculationyet = false;
    

   
    public List<int> Calc = new List<int>(); 

    // Start is called before the first frame update
    void Start()
    {
        _noCalculationyet = true;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void WriteTextToField()
    {
        InputField.text = InputString;
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
            Calc.Clear();
        }

        if (_operatorPressed == false)
        {
            FirstButtonCounter++;
        }
        else if (_operatorPressed == true)
        {
            SecondButtonCounter++;
        }
        
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

            InputValue = InputValue + 1;

            if (_noCalculationyet == true || _operatorPressed == true)
            {
                Calc.Add(OutputNumber);
                _noCalculationyet = false;
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

            switch (SecondButtonCounter)
            {
                case 2:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 3:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;                  
                    break;
                case 4:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 5:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 6:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 7:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 8:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 9:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
                case 10:
                    Calc[1] = (Calc[1] * 10) + OutputNumber;
                    break;
            }

            // working double digit function to be replaced with switch statement
            /*if (FirstButtonCounter == 2)
            {

                Calc[0] = (Calc[0] * multiplierSet[0]) + OutputNumber;
                FirstButtonCounter = 0;
            }

            if (SecondButtonCounter == 2)
            {
             
                Calc[1] = (Calc[1] * multiplierSet[0]) + OutputNumber;
                SecondButtonCounter = 0;
            }*/



             //test double digit function
            /*if (_buttonFirstPressed == true)
            {
                Calc.Add((OutputNumber * 10) + 1);
            }
            else
            {
                Calc.Add(OutputNumber);
            }*/
        }
    
    }

        public void ClearInputField()
    {
         Calc.Clear();
        //if (displayedResults == true)
        //{
         InputField.text = "";
         InputString = "";
         result = 0;
         FirstButtonCounter = 0;
         SecondButtonCounter = 0;
        _operatorPressed = false;
        _noCalculationyet = true;
        //displayedResults = false;
        //}
    }

    public void OperatorButtons()
    {
        Debug.Log("writing text");
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        string buttonValue = EventSystem.current.currentSelectedGameObject.name;
        InputString = InputString + buttonValue;
        _operatorPressed = true;


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

                        result = Calc[0] + Calc[1];

                        break;
                    case "-":

                        result = Calc[0] - Calc[1];

                        break;
                }
                displayedResults = true;
                InputString = result.ToString();
                _operatorPressed = false;
                _noCalculationyet = true;
                FirstButtonCounter = 0;
                SecondButtonCounter = 0;
                //number = new int[2];
                break;
            

        }
        FirstButtonCounter = 0;
        WriteTextToField();
    }
} 
