using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    
    public TextMeshProUGUI textoCoord;
    float earthRadius = 6371000;
   
    //Target Locations
    private double target1Lat = 4.659912;
    private double target1Long = -74.05845;

    //Background color
    Image image;
    public GameObject bgPanel;

    private double finalDistance;
    //AR Camera
    public GameObject arCamera;
    public GameObject camera2;

    public GameObject clueButton;

    void Start()
    {
        StartLocation();
        Input.location.Start();
        image = bgPanel.GetComponent<Image>();
        bgPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        finalDistance = Distance(-74.0580658, 4.6594783, -74.05838, 4.658827);
        textoCoord.text = finalDistance.ToString("n0") + " metros.";

        // Get the device's location
        if (Input.location.status == LocationServiceStatus.Running)
        {
            finalDistance = Distance(target1Long, target1Lat, Input.location.lastData.longitude, Input.location.lastData.latitude);
            textoCoord.text = finalDistance.ToString("n0") + " metros.";

        }
        else
        {
            StartLocation();
            Input.location.Start();
        }


        ColorGradient();
        Background();
        NewLongAndLoc();
        ClueHide();
    }

    IEnumerator StartLocation()
    {
        // Start location services
        Input.location.Start();

        // Wait for location services to initialize
        while (Input.location.status == LocationServiceStatus.Initializing)
            yield return new WaitForSeconds(1);
    }

  /*  private void UpdateText()
    {
        textoLatitud.text = "Latitud: " + latitude.ToString();
        textoLongitud.text = "Longitud: " + longitude.ToString();
    }*/

    //Haversine formula
    private float Distance(double targetLong, double targetLat, double deviceLong, double deviceLat)
    {

        float distance;
        double difLat;
        double difLong;
        double a;

        double deviceLatRad = deviceLat * Mathf.Deg2Rad;
        double deviceLongRad = deviceLong * Mathf.Deg2Rad;
        double targetLatRad = targetLat * Mathf.Deg2Rad;
        double targetLongRad = targetLong * Mathf.Deg2Rad;

        difLat = deviceLatRad - targetLatRad;
        difLong = deviceLongRad - targetLongRad;

        a = Math.Pow(Math.Sin(difLat / 2), 2) + Math.Cos(deviceLatRad) * Math.Cos(targetLatRad) * Math.Pow(Math.Sin(difLong / 2), 2);
        float b = Convert.ToSingle(a);

        distance = earthRadius * (2 * Mathf.Atan2(Mathf.Sqrt(b), Mathf.Sqrt(1 - b)));

        return distance;
    }

   /* public void TargetInteraction1()
    {
        if (finalDistance > 100)
        {
            image.color = Color.red;
        }
        else if (finalDistance < 100 && finalDistance > 50)
        {
            image.color = new Color(1.0f, 0.64f, 0.0f);
        }
        else if (finalDistance < 50 && finalDistance > 25)
        {
            bgPanel.SetActive(false);
            image.color = Color.green;
        }
        else if (finalDistance < 25)
        {
            bgPanel.SetActive(false);
            //arCamera.SetActive(true);
        }
    }*/

    public void ColorGradient()
    {
        float normalizedValue = Mathf.InverseLerp(25f, 100f, Convert.ToSingle(finalDistance));
        Color lerpedColor = Color.Lerp(Color.green, Color.red, normalizedValue);
        image.color = lerpedColor;
    }

    public void Background()
    {
        if(finalDistance <= 25)
        {
            bgPanel.gameObject.SetActive(false);
            arCamera.SetActive(true);
            camera2.SetActive(false);


        }else if(finalDistance > 25)
        {
            bgPanel.gameObject.SetActive(true);
            arCamera.SetActive(false);
            camera2.SetActive(true);
        }
    }
    public void NewLongAndLoc()
    {
        if(GameManager.Instance.counterKey == 1)
        {
            target1Lat = 4.6603972;
            target1Long = -74.0594246;

        } else if(GameManager.Instance.counterKey == 2)
        {
            target1Lat = 4.661409017744926;
            target1Long = -74.05963023223235;

        }
    }
    public void ClueHide()
    {
        if(bgPanel.activeSelf)
        {
            clueButton.gameObject.SetActive(true);
        }
        else
        {
            clueButton.gameObject.SetActive(false);
        }
    }
}
