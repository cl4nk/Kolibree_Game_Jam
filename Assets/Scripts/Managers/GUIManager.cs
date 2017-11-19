using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField]
    private Slider orgasmSlider;

    [SerializeField]
    private MeshRenderer[] toothMeshList;
    private MeshRenderer activeMesh = null;

    [SerializeField]
    private Image spriteContainer;

    [SerializeField]
    private float Duration = 1f;

    private float resetMeshTime = -1f;
    private float resetSpriteTime = -1f;


    // Use this for initialization
    private void OnEnable ()
    {
        foreach (MeshRenderer meshRenderer in toothMeshList)
            meshRenderer.gameObject.SetActive(false);

        AraDeviceHandlerSimulator.OnAraDetectedZone += this.AraDeviceHandlerSimulator_OnAraDetectedZone;
        MobileDebugView.LogInfo("GUIManager : connect to AraDeviceHandler");
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
    }

    private void OnDisable()
    {
        AraDeviceHandlerSimulator.OnAraDetectedZone -= this.AraDeviceHandlerSimulator_OnAraDetectedZone;
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
        MobileDebugView.LogInfo("GUIManager : disconnect to AraDeviceHandler");
    }

    private void Update()
    { 
        if (Time.time > resetMeshTime && resetMeshTime > 0)
            ResetMesh();

        if (Time.time > resetSpriteTime && resetSpriteTime > 0)
            ResetSprite();
    }

    private void AraDeviceHandlerSimulator_OnAraDetectedZone(AraToothbrushZone zone)
    {
        int index = (int) zone;

        if (index < 0)
            return;

        if (activeMesh)
            activeMesh.gameObject.SetActive(false);

        toothMeshList[index].gameObject.SetActive(true);
        activeMesh = toothMeshList[index];

        MobileDebugView.LogInfo(index);
    }

    private void Instance_OnBrushCompleted(BrushRythm rythm, AraToothbrushZone zone, Accuracy accuracy)
    {
        orgasmSlider.value = GameManager.Instance.OrgasmJauge;
        MobileDebugView.LogInfo("rentre dans la fonction Complete");

        int index = (int) zone;

        if (index < 0)
            return;

        spriteContainer.sprite = rythm.hintSprite;
        MobileDebugView.LogInfo("Value de orgasmSlider: " + orgasmSlider.value);

    }

    private void ResetMesh()
    {
        if (activeMesh)
        {
            activeMesh.gameObject.SetActive(false);
            activeMesh = null;
        }

        resetMeshTime = -1;
    }

    private void ResetSprite()
    {
        spriteContainer.sprite = GameManager.Instance.character.MainHintSprite;
        resetSpriteTime = -1;
    }

}
