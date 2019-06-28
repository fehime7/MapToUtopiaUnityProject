using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    
    public GameObject infoPanel;
    public GameObject[] StateTexts;
    public Sprite logo_0;
    public Sprite logo_1;
    public GameObject m_button;

    void Start()
    {
        m_button.GetComponent<Image>().sprite = logo_1; 
    }

   
    void Update()
    {
        
    }

    public void OnClickCorner()
    {
        SetCorrectStateText();
        if (infoPanel.active)
        {
            infoPanel.SetActive(false);      
        }
        else
        {
            infoPanel.SetActive(true);
            m_button.GetComponent<Image>().sprite = logo_0;
        }
    }

    public void SetCorrectStateText()
    {
        for(int i =0; i<StateTexts.Length; i++)
        {
            if (i == DefaultTrackableEventHandler.state)
            {
                StateTexts[i].SetActive(true);
            }
            else
            {
                StateTexts[i].SetActive(false);
            }
        }
    }

 
}
