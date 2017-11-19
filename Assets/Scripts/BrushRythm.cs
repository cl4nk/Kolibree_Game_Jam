using UnityEngine;

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

    public Sprite hintSprite;

    private SpriteRenderer target = null;
    public SpriteRenderer Target
    {
        get { return target; }
        set
        {
            if (target != null)
                return;
            target = value;
        }
    }


    public void OnEnable()
    {
        BrushRythmManager.Instance.Register(this);
    }

    private void OnDisable()
    {
        BrushRythmManager.Instance.Unregister(this);
    }

    void SetTargetVisible (bool value)
    {
        if (Target == null)
            return;
        Color newColor = Target.color;
        newColor.a = value ? 1.0f : 0.5f;
        Target.color = newColor;
    }
    
}
