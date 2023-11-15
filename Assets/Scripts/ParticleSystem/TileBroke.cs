using UnityEngine;
using Cysharp.Threading.Tasks;

public class TileBroke : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShakeAndDestroy(gameObject).Forget();
        }
    }

    private async UniTaskVoid ShakeAndDestroy(GameObject target)
    {
        Vector3 originalPosition = target.transform.position;

        for (float t = 0; t < 2f; t += Time.deltaTime)
        {
            float x = originalPosition.x + Mathf.Sin(3 * t * Mathf.PI * 2) * 0.1f;
            target.transform.position = new Vector3(x, originalPosition.y, originalPosition.z);
            await UniTask.Yield();
        }

        Destroy(target);
    }
}
