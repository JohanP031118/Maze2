using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyManager : MonoBehaviour
{
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Toco la llave");
        gameObject.SetActive(false);
        GameManager.Instance.counterKey++;
    }


}
