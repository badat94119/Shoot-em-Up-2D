using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
    }

    [HideInInspector] public bool isGameStarted;
    [HideInInspector] public bool isGameOvered;
    [HideInInspector] public bool isGameCompleted;

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        isGameOvered = false;
        isGameCompleted = false;
    }

    private void OnDestroy( )
    {
       Destroy(instance);
    }
}
