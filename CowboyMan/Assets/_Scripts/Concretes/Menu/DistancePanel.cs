using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePanel : MonoBehaviour
{
    [SerializeField] RectTransform FrontImage;
    float ImageValue;
    [SerializeField] CalculatePoint _calculatePoint;

    void Update()
    {
        SetImage(_calculatePoint.GetCurrentDistance(), _calculatePoint.GetPlus());
    }
    public void SetImage(float value,float plus) 
    {
        ImageValue = value * plus;
        FrontImage.sizeDelta = new Vector2(ImageValue, FrontImage.sizeDelta.y);
    }
 }
