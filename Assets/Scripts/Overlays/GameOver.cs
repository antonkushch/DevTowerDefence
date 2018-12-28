using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text wavesSurvivedText;

    void OnEnable()
    {
        wavesSurvivedText.text = PlayerStuff.wavesSurvived.ToString();
    }

    public void StartOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
