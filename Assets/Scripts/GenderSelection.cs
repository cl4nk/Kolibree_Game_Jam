using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSelection : MonoBehaviour
{
    public int MainSceneIndex = 2;

    public Character FemaleCharacter;
    public Character MaleCharacter;

    public void SelectMale()
    {
        if (MaleCharacter == null)
        {
            Debug.LogError("No male character found");
            return;
        }
        CharacterDataKeeper.Instance.characterPrefab = MaleCharacter;
        LaunchMainScene();
    }

    public void SelectFemale()
    {
        if (FemaleCharacter == null)
        {
            Debug.LogError("No female character found");
            return;
        }
        CharacterDataKeeper.Instance.characterPrefab = FemaleCharacter;
        LaunchMainScene();
    }

    private void LaunchMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainSceneIndex);
    }
}
