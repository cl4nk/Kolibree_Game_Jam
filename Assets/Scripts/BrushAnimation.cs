using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BrushAnimation : MonoBehaviour
{
    [SerializeField]
    private AraToothbrushZone _zone;

    private void OnEnable()
    {
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    private void OnDisable()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void Instance_OnBrushCompleted(AraToothbrushZone zone, Accuracy accuracy)
    {
        if (zone == _zone)
        {
            Debug.Log(accuracy.ToString());
            GetComponent<Animator>().SetTrigger(accuracy.ToString());
        }
    }
}
