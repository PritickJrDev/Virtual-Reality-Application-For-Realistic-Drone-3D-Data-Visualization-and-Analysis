using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Measure : MonoBehaviour
{
    [Header("Arrows")]
    public GameObject point_1;
    public GameObject point_2;
    [Range(-0.15f,0.9f)]
    public float pointScale = 0.2f;
    [Range(0,90)]
    public float pointAngle=0;

    [Header("Text")]
    public TextMeshProUGUI textValue;
    [Range(0,0.03f)]
    public float textScale = 0.01f;
    public GameObject canvas;
    float distance;

    public Slider pointScaleSlider;
    public Slider pointAngleSlider;
    public Slider textScaleSlider;

    private void Start()
    {
        pointScale = 0.2f;
        pointAngle = 0;
        textScale = 0.01f;
    }

    private void OnDrawGizmos()
    {
        MeasureDistance();
    }

    void Update() //void OnValidate()
    {
        MeasureDistance();

        pointScaleSlider.onValueChanged.AddListener((value) =>
        {
            pointScale = value;
        });

        pointAngleSlider.onValueChanged.AddListener((value) =>
        {
            pointAngle = value;
        });

        textScaleSlider.onValueChanged.AddListener((value) =>
        {
            textScale = value;
        });
    }

    void MeasureDistance()
    {
        distance = Vector3.Distance(point_1.transform.position, point_2.transform.position);
        textValue.text = distance.ToString("N2") + "m";

        canvas.transform.position = LerpByDistance(point_1.transform.position, point_2.transform.position, 0.5f);
    
        if(point_1 != null)
        {
            point_1.transform.localScale = new Vector3(pointScale, pointScale, pointScale);
            point_1.transform.localRotation = Quaternion.Euler(pointAngle, 0, 0);
        }
        if (point_2 != null)
        {
            point_2.transform.localScale = new Vector3(pointScale, pointScale, pointScale);
            point_2.transform.localRotation = Quaternion.Euler(pointAngle, 0, 0);
        }

        if(textValue != null)
        {
            textValue.transform.localScale = new Vector3(textScale, textScale, textScale);
        }
    }

    Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
    {
        Vector3 p = A + x * (B - A);
        return p;
    }
}
