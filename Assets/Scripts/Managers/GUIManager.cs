﻿using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BodyHint
{
    [SerializeField]
    private Sprite mainSprite;
    public Sprite MainSprite
    {
        get { return mainSprite; }
    }

    [SerializeField]
    private Sprite[] toothSpriteList;
    public Sprite[] ToothSpriteList
    {
        get { return toothSpriteList; }
    }
}

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField]
    private Slider orgasmSlider;

    [SerializeField]
    private MeshRenderer[] toothMeshList;
    private MeshRenderer activeMesh = null;

    public BodyHint BodySprites;

    [SerializeField]
    private Image spriteContainer;

    [SerializeField]
    private float Duration = 1f;

    private float EndTime = -1f;

    // Use this for initialization
    private void OnEnable ()
    {
        foreach (MeshRenderer meshRenderer in toothMeshList)
            meshRenderer.gameObject.SetActive(false);
        BrushRythmManager.Instance.OnBrushCompleted += this.Instance_OnBrushCompleted;
	}

    private void OnDisable()
    {
        BrushRythmManager.Instance.OnBrushCompleted -= this.Instance_OnBrushCompleted;
    }

    private void Update()
    {
        if (EndTime < 0)
            return;

        if (Time.time > EndTime)
            ResetUI();
    }

    private void Instance_OnBrushCompleted(AraToothbrushZone zone, Accuracy accuracy)
    {
        orgasmSlider.value = GameManager.Instance.OrgasmJauge;
        int index = (int) zone;

        if (index < 0)
            return;

        EndTime = Time.time + Duration;

        if (activeMesh)
            activeMesh.gameObject.SetActive(false);

        toothMeshList[index].gameObject.SetActive(true);
        activeMesh = toothMeshList[index];

        if (BodySprites != null)
            spriteContainer.sprite = BodySprites.ToothSpriteList[index];

    }

    private void ResetUI()
    {
        if (activeMesh)
        {
            activeMesh.gameObject.SetActive(false);
            activeMesh = null;
        }

        spriteContainer.sprite = BodySprites.MainSprite;
        EndTime = -1;
    }
}