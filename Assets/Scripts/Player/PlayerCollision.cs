using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public HPBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GetComponent<HPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var target = col.GetComponent<IRecoverable>();
        if (target != null)
        {
            Debug.Log("体力を回復した");
            int RecoveryNum = target.AddRecovery();
            hpBar.Recovery(RecoveryNum);
        }
    }
}
