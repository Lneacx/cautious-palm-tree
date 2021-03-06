﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
 
    public void PlayGame()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting!");
        Application.Quit();
    }
}
