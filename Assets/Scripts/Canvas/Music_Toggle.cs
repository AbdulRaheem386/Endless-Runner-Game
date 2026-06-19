using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Toggle : MonoBehaviour
{
    public Toggle toggle;
    public RectTransform Knob;
    public Image background;


    public Color onColor = Color.green;
    public Color offColor = Color.red;


    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
        OnToggleChanged(toggle.isOn);
        
        
    }

   void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            Knob.anchoredPosition = new Vector2(-4, 0);
            background.color = onColor;
            AudioListener.volume = 1f;
        }
        else
        {
            Knob.anchoredPosition = new Vector2(4, 0);
            background.color = offColor;
            AudioListener.volume = 0f;
        }
    }
}
