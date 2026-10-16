using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Tests : MonoBehaviour
{
    // 制限時間の最大値（TimeCounter と同じ値にする）
    public float maxTime = 5f;

    // 出現させる壁のプレハブ配列
    public GameObject[] wallPrefabs;

    // 壁を出現させる3つのレーン（スポーン位置）
    public Transform[] spawnPoints;

    // 出現間隔の初期値（※実際の待機には使われていない）
    public float minSpawnInterval = 1.5f;
    public float maxSpawnInterval = 3f;

    private float time;
    private float IntervalTime;

    void Start()
    {
        // 壁を一定間隔で出現させるコルーチン開始
        StartCoroutine(SpawnWalls());

        time = 2.0f;
        IntervalTime = 2.0f;
    }

    IEnumerator SpawnWalls()
    {
        // ゲーム中ずっと壁を出し続ける
        while (true)
        {
            time += Time.deltaTime;
            if (time >= IntervalTime)
            {
                time = 0f;
                // 今回出現する壁の数（1〜3個）
                int wallCount = Random.Range(1, 4);

                // 3レーン分のインデックス
                int[] indices = { 0, 1, 2 };

                // レーンをランダムな順番にシャッフル
                for (int i = 0; i < indices.Length; i++)
                {
                    int rand = Random.Range(i, indices.Length);
                    (indices[i], indices[rand]) = (indices[rand], indices[i]);
                }

                // シャッフルされたレーンに壁を生成
                for (int i = 0; i < wallCount; i++)
                {
                    Transform spawnPoint = spawnPoints[indices[i]];

                    // 3個目は必ず特定の壁を出す
                    if (i == 2)
                    {
                        Instantiate(
                            wallPrefabs[0],
                            spawnPoint.position,
                            wallPrefabs[0].transform.rotation
                        );
                        continue;
                    }

                    // それ以外はランダムな壁を選ぶ
                    GameObject randomWall = wallPrefabs[Random.Range(0, wallPrefabs.Length)];

                    Instantiate(
                        randomWall,
                        spawnPoint.position,
                        randomWall.transform.rotation
                    );
                }
                if (IntervalTime > 0.2f)
                {
                    IntervalTime -= 0.1f;
                }
                yield return new WaitForSeconds(IntervalTime);
            }
            yield return null;
        }
    }
}
