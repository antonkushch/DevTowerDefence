using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject overlay;
    private GameManagement gameManagement;

    void Awake()
    {
        gameManagement = GetComponent<GameManagement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOnOff();
        }
    }

    public void TurnOnOff()
    {
        if (gameManagement.GameOver)
            return;

        overlay.SetActive(!overlay.activeSelf);
        if (overlay.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void StartOver()
    {
        TurnOnOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
