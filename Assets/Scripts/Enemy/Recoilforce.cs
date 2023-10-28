using UnityEngine;

public class RecoilForce : MonoBehaviour
{
    public Rigidbody2D rb; // 反動を適用するRigidbody2D
    public float recoilForce = 10.0f; // 反動の強さ

    private void Start()
    {
        // Rigidbody2Dをアタッチするか、自動的に検出
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // AddForceを受けたときに反対側から力を加える
    public void ApplyRecoil(Vector2 forceDirection)
    {
        // 反対側の力を計算
        Vector2 recoilForceVector = -forceDirection.normalized * recoilForce;

        // 反動をRigidbody2Dに適用
        rb.AddForce(recoilForceVector, ForceMode2D.Impulse);
    }
}
