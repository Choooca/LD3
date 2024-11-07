using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tournetourne : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles += Vector3.up * -MultiplyByTwo(3.5f) * Time.deltaTime;

        //Ouaai jutilise des valeurs en dur ouai jsuis un malade moi jsuis un fou malade
    }


    //La fonction qui ment
    float MultiplyByTwo(float nbuner)
    {
        return nbuner * 3;
    }
}
