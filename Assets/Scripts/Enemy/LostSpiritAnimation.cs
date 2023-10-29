using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostSpiritAnimation : MonoBehaviour
{
    private Animator animator;
    public GameObject atkObject;
    public GameObject shadowSpirit;

    public bool IsAttack
    {
        get { return animator.GetBool("IsAttack"); }
        set {
                animator.SetBool("IsAttack", value);
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = shadowSpirit.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 接触
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", true);
            atkObject.SetActive(true);
        }
    }

    public void AttackAnimationStop()
    {
        IsAttack = false;
    }
}
