using UnityEngine;
using System.Collections;
using LA.Unity;

public class ExGame : MonoBehaviour
{

    void Start()
    {
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



    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerName);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerEmail);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerSex);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerEmail);
        GUI.Label(new Rect(0, 0, 100, 50), Lemonade.playerCP);
    }
}
