using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance Instance;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
