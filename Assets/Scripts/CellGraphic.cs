using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGraphic : MonoBehaviour
{
    [SerializeField] GameObject topWall;
    [SerializeField] GameObject rightWall;
    [SerializeField] GameObject bottomWall;
    [SerializeField] GameObject leftWall;

    Transform thisTransform;

    public Cell CellData
    {
        set
        {
            cellData = value;
            topWall.SetActive(!cellData.top);
            rightWall.SetActive(!cellData.right);
            bottomWall.SetActive(!cellData.bottom);
            leftWall.SetActive(!cellData.left);

        }
    }

    GameObject player;
    Cell cellData;

    private void Start()
    {
        thisTransform = transform;

    }

}