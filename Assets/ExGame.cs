using UnityEngine;
using System.Collections;
using LA.Unity;

public class ExGame : MonoBehaviour
{
    LA.API cc = new LA.API();
    void Start()
    {
        //StartCoroutine(cc.w(calll));

        Lemonade.accessToken = "bGVtb25uZXQubGVtb250cmVlLmxlbW9u";

        if (!Lemonade.isInitialized)
            Lemonade.init(finishInitLogin);
        else
            Lemonade.Login();
    }

    public void finishInitLogin()
    {
        Lemonade.Login();
    }

    public void calll(string ss)
    {
        Debug.Log(ss);
    }


    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerName);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerEmail);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerSex);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerEmail);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerCP);
    }
}
