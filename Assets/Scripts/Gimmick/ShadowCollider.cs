using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCollider : MonoBehaviour
{
    private RaycastHit hit;
    private bool hasCreatedCollider = false;

	[SerializeField]
	bool isEnable = false;
    [SerializeField]
    private GameObject colPrefab;

	private void OnDrawGizmos()
	{
		if (isEnable == false)
			return;

		var scale = transform.lossyScale.x * 0.5f;

        var isHit = Physics.BoxCast (transform.position, new Vector3(scale, scale, 0.01f), transform.forward, out hit, transform.rotation);
		if (isHit) {
			Gizmos.DrawRay (transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireCube (transform.position + transform.forward * hit.distance, Vector3.one * scale * 2);

            if (!hasCreatedCollider){
                InstanceCollider(scale*2, hit.distance);
            }
		} else {
			Gizmos.DrawRay (transform.position, transform.forward * 100);
		}
	}

    private void InstanceCollider(float scale, float distance)
    {
        // 新しいゲームオブジェクトとコライダーを作成
        GameObject newColliderObject = Instantiate(colPrefab);
        BoxCollider newCollider = newColliderObject.AddComponent<BoxCollider>();

        // コライダーの位置、回転、サイズを設定
        newColliderObject.transform.position = transform.position + transform.forward * distance;
        newColliderObject.transform.rotation = transform.rotation;
        newCollider.size = new Vector3(scale, scale, 0.01f);
        hasCreatedCollider = true;
    }
}
