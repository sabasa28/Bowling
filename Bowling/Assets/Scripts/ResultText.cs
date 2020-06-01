using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    TextMeshProUGUI tmp;
    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        if (Result.Get().win)
        {
            tmp.text = "CONGRATULATIONS! \nYou won";
        }
        else
        {
            tmp.text = "BETTER LUCK NEXT TIME! \nYou lost";
        }
    }
}
