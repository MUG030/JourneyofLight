using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    [SerializeField] private GameObject _setObject;

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
        Debug.Log("呼ばれた");
        _setObject.SetActive(true);
    }

    public void OffActive()
    {
        Debug.Log("削除された");
        _setObject.SetActive(false);
    }
}
