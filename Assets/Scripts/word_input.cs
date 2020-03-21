using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_input : MonoBehaviour
{
    [Header("Set in Inspector")]
    public word_manager word_manager;
    // Update is called once per frame

    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            word_manager.type_letter(letter);
        }
    }

}
