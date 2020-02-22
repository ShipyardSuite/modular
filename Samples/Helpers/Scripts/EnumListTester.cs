using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Shipyard.Modular.Helper;

public class EnumListTester : MonoBehaviour
{
    public EnumList enumList;

    public Text currentSelectionOutput;
    public Text selectionSwitchResultOutput;
    public Text amountOfItemsOutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(enumList.value)
        {
            case "Sat":
            {
                selectionSwitchResultOutput.text = "Its Saturday!";
                break;
            }
            default: 
                selectionSwitchResultOutput.text = "";
                break;
        }

        
        amountOfItemsOutput.text = enumList.ListOfValues.Count.ToString();
    }
}
