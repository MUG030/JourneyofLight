using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShadow : MonoBehaviour
{
    [SerializeField] private float rayDistance = 1.0f;
    private Color shadowColor;
    private GameObject floorObject;
 
    void Start()
    {

    }
 
    void Update()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        Debug.DrawRay(rayPosition, Vector3.down * rayDistance, Color.red);
 
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, rayDistance))
        {
            floorObject = hit.collider.gameObject;
            shadowColor = floorObject.GetComponent<Renderer>().material.color;
        }
        
        Debug.Log(shadowColor);
        
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.position = new Vector3 (transform.position.x + x, transform.position.y, transform.position.z + z);
    }
}
