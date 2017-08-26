using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Time.timeScale == 1.0)
            {
                Time.timeScale = 0;
            }

            else
            {
                Time.timeScale = 1.0f;

            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in cubes)
            {
                g.SendMessage("StartWindSimulation", SendMessageOptions.DontRequireReceiver);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in cubes)
            {
                g.SendMessage("StopParticleSystem", SendMessageOptions.DontRequireReceiver);
            }
            
        }
    }
}
