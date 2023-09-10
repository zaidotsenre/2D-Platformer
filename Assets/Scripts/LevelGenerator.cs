using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Level level;
    [SerializeField] int mazeWidth = 20;
    [SerializeField] int mazeHeight = 5;

    private void Start()
    {
        MakeLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            MakeLevel();
    }


    public void MakeLevel()
    {
        level.Delete();
        level.Make(mazeWidth, mazeHeight);
    }
}