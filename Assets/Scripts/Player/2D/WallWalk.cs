using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWalk : MonoBehaviour
{
    public float speed = 5f; // プレイヤーの移動速度
    public float rayDistance = 1f; // Rayの距離

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isTouchingWall = CheckWallContact();

        if (isTouchingWall)
        {
            MoveAlongWall();
        }
    }

    // 壁に接触しているかどうかをチェックするメソッド
    private bool CheckWallContact()
    {
        // Rayを生成
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // RayをScene上で可視化
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        // Rayが壁に接触しているかどうかを判断
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }

        return false;
    }

    // 壁に沿って移動するメソッド
    private void MoveAlongWall()
    {
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move, 0, 0) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
