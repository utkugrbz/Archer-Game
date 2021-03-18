using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool isGameStart;
    public static LevelManager Instance;

    IEnumerator GameStartDelay()
    {
        yield return new WaitForSeconds(1.5f);
        isGameStart = true;
    }
    void Start()
    {
        StartCoroutine(GameStartDelay());
    }

    private void Awake()
    {
        Instance = this;
    }

}
