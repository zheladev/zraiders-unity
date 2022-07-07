using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITooltip : MonoBehaviour
{
    private TMP_Text text = null;
    private RectTransform tooltipRect;

    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        tooltipRect = GetComponent<Image>().transform as RectTransform;
        transform.position = TranslateMousePosition(Input.mousePosition);
    }

    void Update()
    {
        transform.position = TranslateMousePosition(Input.mousePosition);
    }

    public void Show(Item item)
    {
        //text.text = item.name;
    }

    Vector3 TranslateMousePosition(Vector3 pos)
    {
        pos += new Vector3(-tooltipRect.rect.width /2, -tooltipRect.rect.height /2, 0);
        return pos;
    }
}
