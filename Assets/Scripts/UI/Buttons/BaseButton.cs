using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour
{
    public Button button;

    void Start()
    {
        if (!button) button = GetComponent<Button>();
        Button btn = button.GetComponent<Button>();
    }
}
