using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlaneGenerator : MonoBehaviour
{
    public Light spotLight;  // SpotLightをInspectorから設定
    public GameObject objectToCastShadow;  // 影を投影するオブジェクトをInspectorから設定
    private GameObject shadowObject;  // 影の大きさに合わせて生成するオブジェクト

    void Start()
    {
        // 光源の情報を取得
        Vector3 lightPosition = spotLight.transform.position;
        Vector3 lightDirection = spotLight.transform.forward;
        float lightRange = spotLight.range;

        // オブジェクトの情報を取得
        Vector3 objectPosition = objectToCastShadow.transform.position;
        Vector3 objectSize = objectToCastShadow.GetComponent<Renderer>().bounds.size;

        // レイキャストを使用して影の位置を計算
        RaycastHit hit;
        if (Physics.Raycast(lightPosition, (objectPosition - lightPosition).normalized, out hit, lightRange))
        {
            Vector3 shadowCenter = hit.point;

            // 影の大きさを計算
            float shadowHeight = objectSize.y * Mathf.Abs(Vector3.Dot(lightDirection, Vector3.up));
            float shadowWidth = objectSize.x * Mathf.Abs(Vector3.Dot(lightDirection, Vector3.right));

            // 影の大きさに合わせて新たなオブジェクトを生成
            shadowObject = new GameObject("ShadowObject");
            shadowObject.transform.position = shadowCenter;
            shadowObject.transform.localScale = new Vector3(shadowWidth, 1, shadowHeight);

            // 新たなオブジェクトにコライダーを適用
            BoxCollider collider = shadowObject.AddComponent<BoxCollider>();
            collider.size = new Vector3(shadowWidth, 1, shadowHeight);

            // 影のオブジェクトの回転をスポットライトの方向に合わせる
            shadowObject.transform.rotation = Quaternion.LookRotation(lightDirection);

            // 影の大きさを出力
            Debug.Log("Shadow Width: " + shadowWidth + ", Shadow Height: " + shadowHeight);
        }
    }
}
