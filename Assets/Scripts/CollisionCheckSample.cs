using UnityEngine;
using System.Collections;

public class CollisionCheckSample : MonoBehaviour {

    // 接触フラグ
    public bool IsTop { get; private set; }
    public bool IsBottom { get; private set; }
    public bool IsRight { get; private set; }
    public bool IsLeft { get; private set; }


    // 接触メソッド
    void OnCollisionEnter(Collision collision)
    {
        // どの方向が接触したか判定
        CollisionCheck(collision);

        // テスト用結果表示
        PrintResult();
    }


    // どの方向が接触したか判定
    void CollisionCheck(Collision collision)
    {
        // 接触フラグ初期化
        IsTop = false;
        IsBottom = false;
        IsRight = false;
        IsLeft = false;

        // 接触ポイント取得
        ContactPoint contactPoint = collision.contacts[0];
        // 正規化した接触ポイントX
        float normalX = contactPoint.normal.x;
        // 正規化した接触ポイントY
        float normalY = contactPoint.normal.y;

        // 接触方向判定
        if(normalX == 1.0f)
        {
            IsLeft = true;
        }

        if(normalX == -1.0f)
        {
            IsRight = true;
        }

        if(normalY == 1.0f)
        {
            IsBottom = true;
        }

        if(normalY == -1.0f)
        {
            IsTop = true;
        }
    }


    // テスト用結果表示
    void PrintResult()
    {
        if (IsLeft)
        {
            Debug.Log("左接触");
        }
        if (IsRight)
        {
            Debug.Log("右接触");
        }
        if (IsTop)
        {
            Debug.Log("上接触");
        }
        if (IsBottom)
        {
            Debug.Log("下接触");
        }
    }

}
