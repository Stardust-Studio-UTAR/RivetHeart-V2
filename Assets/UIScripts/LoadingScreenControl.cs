﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private AsyncOperation operation;
    private Canvas BLoadingCanvas;

    private void Awake()
    {
        BLoadingCanvas = GetComponentInChildren<Canvas>(true);

        GameObject[] loadingObj = GameObject.FindGameObjectsWithTag("DontDestroy");
        if (loadingObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        UpdateProgressUI(0);
        BLoadingCanvas.gameObject.SetActive(true);

        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return null;
        }

        UpdateProgressUI(operation.progress);
        operation = null;
        BLoadingCanvas.gameObject.SetActive(false);
    }

    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
        //BLoadingCanvas.text = (int)(progress * 100f) + "%";
    }
}
