﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCarSelect : MonoBehaviour
{
    // AudioClips
    [SerializeField] AudioClip buttonClickNoise;

    // AudioClip Volume
    [SerializeField] [Range(0,1)] float buttonClickVolume = 0.4f;

    // Sprite Renderer Component
    SpriteRenderer spriteRenderer;

    // Index Of Original Red Car
    [SerializeField] int currentCarIndex;

    // All Cars
    [SerializeField] public Sprite[] allCarsLeft;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentCarIndex = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoLeft()
    {
        currentCarIndex -- ;
        if (currentCarIndex < 0)
        {
            currentCarIndex = allCarsLeft.Length - 1;
        }
        spriteRenderer.sprite = allCarsLeft[ currentCarIndex ];
    }

    public void GoRight()
    {
        currentCarIndex ++ ;
        if (currentCarIndex > allCarsLeft.Length - 1)
        {
            currentCarIndex = 0;
        }
        spriteRenderer.sprite = allCarsLeft[ currentCarIndex ];
    }

    /* LEFT BUTTONS */

    public void LeftCarLeftButton()
    {
        Debug.Log("Left Left");
        GoLeft();
        // Play Click SFX
        AudioSource.PlayClipAtPoint(buttonClickNoise, 
                                Camera.main.transform.position, 
                                buttonClickVolume);
    }

    public void LeftCarRightButton()
    {
        Debug.Log("Left Right");
        GoRight();
        // Play Click SFX
        AudioSource.PlayClipAtPoint(buttonClickNoise, 
                                Camera.main.transform.position, 
                                buttonClickVolume);
    }

    public Sprite GetCarSprite()
    {
        return spriteRenderer.sprite;
    }
}
