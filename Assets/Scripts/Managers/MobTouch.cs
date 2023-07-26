using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTouch : MonoBehaviour
{
    [SerializeField] private GameObject guidObject;

    private void Start()
    {
        guidObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guidObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            guidObject.SetActive(false);
        }
    }
}
