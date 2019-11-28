using System;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;
    // Use this for initialization
    private void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
        
        //OnGameStart();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //public event Action OnGameStart;
}