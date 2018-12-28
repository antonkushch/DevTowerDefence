using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using UnityEngine.UI;

public class SpawningWaves : MonoBehaviour {

    public Wave[] waves;
    public int nextWave = 0;
    public float timeBetweenWaves = 4f;
    public float waveCountdown;

    public string waveCountdownText;
    public Text waveCountdownTimerText;
    public Text waveNumberText;
    
    private State currentState;
    public State CurrentState
    {
        set { currentState = value; }
    }

	// Use this for initialization
	void Start ()
    {
        if (waves.Length != 0)
        {
            SetState(new SpawningState(this, this));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Current state: " + currentState.GetType() + " ; nextWave = " + nextWave);
        if (waveCountdown <= 0)
        {
            currentState.Tick();
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            waveCountdown = Mathf.Clamp(waveCountdown, 0f, Mathf.Infinity);
            waveCountdownTimerText.text = waveCountdownText + string.Format("{0:00.0}", waveCountdown);
            waveNumberText.text = "Wave " + nextWave.ToString();
        }
	}

    public Wave GetWaveByIndex(int index)
    {
        if (index >= 0 && index < waves.Length)
            return waves[index];
        else
            return null;
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }
}
