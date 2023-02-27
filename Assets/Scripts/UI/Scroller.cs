using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage backgroundImg;
    [SerializeField] float xMov;

    private void Update()
    {
        //Move the Image on the X axis to create a scrolling background
        backgroundImg.uvRect = new Rect(backgroundImg.uvRect.position + new Vector2(xMov, 0) * Time.deltaTime, backgroundImg.uvRect.size);
    }
}
