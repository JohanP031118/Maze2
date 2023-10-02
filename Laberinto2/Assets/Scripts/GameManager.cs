using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int counterKey;
    public GameObject panelWin; 
    public GameObject arCamera;
    public GameObject camera2;
    public GameObject clueButton;


    void Start()
    {
        Instance = this;
        counterKey = 0;
        panelWin.SetActive(false);
        arCamera.SetActive(false);
        camera2.SetActive(true);
        clueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Counter(); 
    }

     
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Counter()
    {
        if(counterKey == 3)
        {
            panelWin.SetActive(true);
        }
    }

    public void PanelWin()
    {
        panelWin.SetActive(true);
        arCamera.SetActive(false);
        camera2.SetActive(true);    
    }
}
