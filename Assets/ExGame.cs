using UnityEngine;
using System.Collections;
using LA.Unity;

public class ExGame : MonoBehaviour
{

    void Start()
    {
        Lemonade.accessToken = "bGVtb25uZXQubGVtb250cmVlLmxlbW9u";

        if (!Lemonade.isInitialized)
            Lemonade.init(finishInit);
        else
            Lemonade.Login();
    }

    public void finishInit()
    {
        Lemonade.Login();
    }
}
