using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private int MoveEnemys = 0;
    [SerializeField] private GameObject[] Enemys; 
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
        while (true)
        {
            int[] indices = { 0, 8 };       
            for (int i = 0; i < indices.Length; i++)
            {
               int enemy = Random.Range(i, Enemys.Length);
               (indices[i], indices[enemy]) = (indices[enemy], indices[i]);
            }
            for(int i = 0; i < indices.Length; i++)
            {
                Transform WarpPoint = warpPoints[indices[i]];

                GameObject Warpenemy = Enemys[Random.Range(0, Enemys.Length)];
            }

        }
    }
}
