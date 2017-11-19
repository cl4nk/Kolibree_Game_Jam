using System;
using System.Collections.Generic;
using UnityEngine;

public struct BrushZoneData
{
    public AraToothbrushZone brushZone;
    public float duration;
}

public class BrushRythmManager : Singleton<BrushRythmManager>
{
    private Dictionary<AraToothbrushZone, BrushRythm> brushRythmDictionnary = new Dictionary<AraToothbrushZone, BrushRythm>();

    [SerializeField]
    private Queue<BrushZoneData> ZonesToBrush = new Queue<BrushZoneData>();

    [SerializeField]
    private int Count;
    public int MinCount = 8;
    public int MaxCount = 15;
    public float MinDuration = 2.0f;
    public float MaxDuration = 6.0f;

    private BrushZoneData CurrentData;
    private BrushRythm CurrentRythm;

    public SpriteRenderer TargetPrefab;

    public event Action<BrushRythm, Accuracy> OnBrushCompleted;

    public float PercentRythmCompleted
    {
        get
        {
            if (ZonesToBrush.Count <= 0)
                return 0.0f;
            return (float) (ZonesToBrush.Count - Count) / (float) ZonesToBrush.Count;
        }
    }

    public void OnEnable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone += this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void OnDisable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone -= this.AraDeviceHandler_OnAraDetectedZone;
    }

    public void InitZonesToBrush()
    {
        Array values = Enum.GetValues(typeof(AraToothbrushZone));
        System.Random random = new System.Random();

        ZonesToBrush.Clear();
        Count = UnityEngine.Random.Range(MinCount, MaxCount);
        for (int i = 0; i < Count; ++i)
        {
            BrushZoneData data;
            data.brushZone = (AraToothbrushZone) values.GetValue(random.Next(values.Length));
            data.duration = UnityEngine.Random.Range(MinDuration, MaxDuration);

            ZonesToBrush.Enqueue(data);
        }

        NextBrush();
    }

    public void Register (BrushRythm rythm)
    {
        if (!brushRythmDictionnary.ContainsKey(rythm.Zone))
        {
            brushRythmDictionnary.Add(rythm.Zone, rythm);
            SpriteRenderer go = Instantiate(TargetPrefab, rythm.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector2(0.1f, 0.1f);
            rythm.Target = go;
            rythm.SetTargetVisible(false);
        }
    }

    public void Unregister(BrushRythm rythm)
    {
        AraToothbrushZone zone = rythm.Zone;
        if (brushRythmDictionnary.ContainsKey(zone) && brushRythmDictionnary[zone] == rythm)
        {
            brushRythmDictionnary.Remove(zone);
        }
        else
            Debug.LogWarning("Rythm not found inside dictionnary");
    }

    private void AraDeviceHandler_OnAraDetectedZone(AraToothbrushZone zone)
    {
        BrushRythm brushRythm = brushRythmDictionnary.ContainsKey(zone) ? brushRythmDictionnary[zone] : null;
        if (zone != CurrentData.brushZone)
            OnBrushCompleted.Invoke(brushRythm, Accuracy.Bad);
        else
        {
            OnBrushCompleted.Invoke(brushRythm, Accuracy.Good);
        }
    }

    private void NextBrush()
    {
        if (CurrentRythm)
            CurrentRythm.SetTargetVisible(false);

        if (ZonesToBrush.Count == 0)
        {
            GameManager.Instance.State = GameManager.GameState.Finish;
            return;
        }
        CurrentData = ZonesToBrush.Dequeue();
        CurrentRythm = brushRythmDictionnary[CurrentData.brushZone];
        if (CurrentRythm)
            CurrentRythm.SetTargetVisible(true);
    }
    
}
