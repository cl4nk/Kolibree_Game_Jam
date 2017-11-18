﻿using UnityEngine;

public enum Accuracy
{
    None = -1,
    Bad = 0, 
    Good = 1,
    Perfect = 2,
    Completed = 3
}

[System.Serializable]
public struct AraToothbrushRythm
{
    public AraToothbrushZone Zone;
    public BrushRythm Rythm;
}

public class BrushRythm : MonoBehaviour
{
    [SerializeField]
    private AraToothbrushZone zone;
    public AraToothbrushZone Zone
    {
        get { return zone; }
    }

    [SerializeField]
    private float delayBetween = 0.5f;
    [SerializeField]
    private float delayAcceptation = 0.1f;
    [SerializeField]
    private int goodBrushCount = 5;

    public Sprite hintSprite;

    private int currentBrushCount = 0;

    private float lastBrushTime = -1;

    public float PercentCompleted
    {
        get { return currentBrushCount / goodBrushCount; }
    }

    public void OnEnable()
    {
        BrushRythmManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        BrushRythmManager.Instance.Unregister(this);
    }

    public Accuracy OnBrushDetected()
    {
        if (lastBrushTime < 0)
        {
            lastBrushTime = Time.time;
            return Accuracy.None;
        }
        else
        {
            float TimePassed = Time.time - lastBrushTime;
            float Diff = Mathf.Abs(TimePassed - delayBetween);

            lastBrushTime = Time.time;

            if (++currentBrushCount >= goodBrushCount)
                return Accuracy.Completed;

            if (Diff > delayAcceptation)
                return Accuracy.Bad;
            else if (Diff > delayAcceptation / 2)
                return Accuracy.Good;
            else
                return Accuracy.Perfect;
        }
    }

    public void StopBrush()
    {
        lastBrushTime = -1;
    }

    
}
