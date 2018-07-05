using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour 
{

    public List<Sprite> sprites;

    public int frameRate = 10;

    float timeBetweenFrames
    {
        get
        {
            return 1f / frameRate;
        }
    }

    int currentSpriteIndex;

    float timeNextFrame;

    SpriteRenderer _spriteRenderer;
    SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent <SpriteRenderer> ();
            return _spriteRenderer;
        }
    }

    void Start ()
    {
        currentSpriteIndex = 0;
        timeNextFrame = Time.time + timeBetweenFrames;
        UpdateSprite ();
    }

    void Update ()
    {
        if (Time.time >= timeNextFrame)
        {
            currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Count;
            timeNextFrame = timeNextFrame + timeBetweenFrames;
            UpdateSprite ();
        }
    }

    void UpdateSprite ()
    {
        spriteRenderer.sprite = sprites [currentSpriteIndex];
    }
	
}
