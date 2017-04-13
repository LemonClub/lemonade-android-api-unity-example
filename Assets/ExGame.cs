﻿using UnityEngine;
using LA.Unity;
using System.Collections.Generic;

public class ExGame : MonoBehaviour
{
    void Start()
    {
        if (!Lemonade.isInitialized)
            Lemonade.init(failedInit, successInit);
        else
            Lemonade.Login();
    }

    public void successInit()
    {
        Lemonade.Login();
    }
    public void failedInit()
    {
        Debug.Log("FAIL");
    }

    public void callFunc(Dictionary<string, object> userInfo)
    {
        // 권한이 없는 정보를 사용하려 하면 ERROR가 생김
        Debug.Log(userInfo["token"]);       // 보안 0
        Debug.Log(userInfo["name"]);        //   "
        Debug.Log(userInfo["age"]);         //   "
        Debug.Log(userInfo["sex"]);         //   "

        Debug.Log(userInfo["email"]);       // 보안 1
        Debug.Log(userInfo["CP"]);          //   "
        Debug.Log(userInfo["achieve"]);     //   "
        Debug.Log(userInfo["friends"]);     //   "

        Debug.Log(userInfo["games"]);       // 보안 2
    }
}
