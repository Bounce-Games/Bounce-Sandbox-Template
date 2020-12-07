﻿using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

    [SerializeField] private GameObject one = null;
    [SerializeField] private GameObject two = null;
    [SerializeField] private GameObject three = null;

    private bool gamePaused;
    private SpawnObject mySpawnObj;

    void Start()
    {
        mySpawnObj = FindObjectOfType<SpawnObject>();
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gamePaused)
            {
                case true:
                    Resume();
                    break;
                case false:
                    Pause();
                    break;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseMenu.transform.Find("ResumeButton").transform.localScale = new Vector3(1f, 1f, 1f);
        gamePaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void SelectObj(int selection)
    {
        if (selection != 0)
        {
            mySpawnObj.spawnRandom = false;
        }

        switch (selection)
        {
            case 0:
                mySpawnObj.spawnRandom = true;
                break;
            case 1:
                mySpawnObj.objToSpawn = one;
                break;
            case 2:
                mySpawnObj.objToSpawn = two;
                break;
            case 3:
                mySpawnObj.objToSpawn = three;
                break;
        }
    }
}
