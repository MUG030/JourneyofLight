using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    [SerializeField] private GameObject setObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        setObject.SetActive(true);
    }

    public void OffActive()
    {
        setObject.SetActive(false);
    }
}
