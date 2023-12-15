using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ModelMoveDemo : MonoBehaviour
{
    private bool xBool;
    private bool yBool;
    private float move;

    void Start()
    {
        move = 0.05f;
        xBool = false;
        yBool = false;
    }

    void Update()
    {
        Vector3 position = new Vector3(move, 0, 0);
        transform.Translate(position);

        //1番目の回転
        if (float.Parse(this.transform.position.x.ToString("f2")) == 3.0f)
        {
            if (!xBool) //xBoolがfalseの場合
            {
                xBool = true; //xBoolをtrueにする
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        //2番目の回転
        if (float.Parse(this.transform.position.y.ToString("f2")) == -3.0f)
        {
            if (!yBool) //yBoolがfalseの場合
            {
                yBool = true; //yBoolをtrueにする
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        //3番目の回転
        if (float.Parse(this.transform.position.x.ToString("f2")) == -3.0f)
        {
            if (xBool) //xBoolがtrueの場合
            {
                xBool = false; //xBoolをfalseにする
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        //4番目の回転
        if (float.Parse(this.transform.position.y.ToString("f2")) == 3.0f)
        {
            if (yBool) //yBoolがtrueの場合
            {
                yBool = false; //yBoolをfalseにする
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }
    }
}
