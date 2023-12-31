using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShadowCollider : MonoBehaviour
{
    private RaycastHit hit;
    private bool hasCreatedCollider = false;
    private GameObject newColliderObject;

    [SerializeField]
    bool isEnable = false;
    [SerializeField]
    private GameObject colPrefab;
    [SerializeField]
    private float shadowZ = 0.01f;

    private void OnDrawGizmos()
    {
        if (isEnable == false)
            return;

        var scaleX = transform.lossyScale.x * 0.5f;
        var scaleY = transform.lossyScale.y * 0.5f;

        var isHit = Physics.BoxCast(transform.position, new Vector3(scaleX, scaleY, 0.01f), transform.forward, out hit, transform.rotation);
        if (isHit)
        {
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, new Vector3(scaleX * 2, scaleY * 2, 0.01f));

            if (!hasCreatedCollider)
            {
                InstanceCollider(scaleX * 2, scaleY * 2, hit.distance);
            }
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * 100);
        }
    }

    private void InstanceCollider(float scaleX, float scaleY, float distance)
    {
        // 新しいゲームオブジェクトとコライダーを作成
        GameObject newColliderObject = Instantiate(colPrefab);
        BoxCollider newCollider = newColliderObject.AddComponent<BoxCollider>();

        // コライダーの位置、回転、サイズを設定
        newColliderObject.transform.position = transform.position + transform.forward * distance;
        newColliderObject.transform.rotation = transform.rotation;
        newCollider.size = new Vector3(scaleX, scaleY, shadowZ);
        hasCreatedCollider = true;
    }

    private void OnApplicationQuit()
    {
        if (newColliderObject != null)
        {
            Destroy(newColliderObject);
        }
    }
}