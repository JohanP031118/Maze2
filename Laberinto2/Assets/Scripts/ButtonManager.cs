using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public TextMeshProUGUI textCoord;
    private int index;
    
    void Start()
    {
        textCoord.gameObject.SetActive(false);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ExitApp()
    {
        Application.Quit();
    }

    public void Clue()
    {
        if(index == 0)
        {
            textCoord.gameObject.SetActive(true);
            index = 1;
        }else if(index == 1)
        {
            textCoord.gameObject.SetActive(false);
            index = 0;
        }
    }
}
