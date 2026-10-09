using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private int MoveEnemys = 0;
    [SerializeField] private Transform[] warpPoints;//指定するワープポイント
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch (MoveEnemys)
        {
            case 1:
                StartCoroutine(PointWarp());
                break;
        }
    }
    IEnumerator PointWarp()
    {
        yield return null;
    }
}
