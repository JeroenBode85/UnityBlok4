using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputScanner : MonoBehaviour
{

    public TextMeshProUGUI buttonPressed;
    public TextMeshProUGUI axisPressed;

    private bool bDetectKey;
    private KeyCode kCode;  //this stores your custom key

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (bDetectKey)
                bDetectKey = false;
            else
                bDetectKey = true;
        }

        //if (bDetectKey)  //this detects the key being pressed and saves it to kCode
        DetectInput();

        if (Input.GetKeyDown(kCode)) //the kCode is then compared like a standard Input.GetKeyDown(KeyCode) boolean
        {
            print("Custom key worked");
        }

        axisPressed.text = "Horizontal: " + Input.GetAxisRaw("Horizontal") + "\nVertical: " + Input.GetAxisRaw("Vertical");
        for (int i = 0; i < 10; i++)
        {
            axisPressed.text = axisPressed.text + "\n Axis" + (i + 3) + ": " + Input.GetAxisRaw("Axis" + (i + 3));
        }
    }

    public void DetectInput()
    {
        foreach (KeyCode vkey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vkey))
            {
                if (vkey != KeyCode.Return)
                {
                    kCode = vkey; //this saves the key being pressed               
                    bDetectKey = false;
                    buttonPressed.text = vkey.ToString();
                }
            }
        }
    }
}
