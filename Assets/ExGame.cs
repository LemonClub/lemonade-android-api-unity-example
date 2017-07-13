using UnityEngine;
using LA.Unity;
using LA.User;
using System.Collections.Generic;

public class ExGame : MonoBehaviour
{
    public UnityEngine.UI.Text te;
    public UnityEngine.UI.Image im;

    void Start()
    {
        if (!Lemonade.isInitialized)
            Lemonade.init(successInit, failedInit);
        else
            Lemonade.Login();
    }

    public void successInit()
    {
        Lemonade.Login();
        StartCoroutine(Lemonade.API.getUserInfo(Lemon._user.playerToken, callFunc));
        
        Dictionary<string, object> dic = new Dictionary<string, object>();
        dic.Add("INVEN", 1000);
        dic.Add("SKILL", 3000);
        StartCoroutine(Lemonade.API.addDatabaseC(dic));

        StartCoroutine(Lemonade.API.getDatabaseC("-", "322a8112f7647a00e4b029edce83950f"));
    }

    public void failedInit()
    {
        te.text = "FAIL";
    }

    public void callFunc(LA.User.UserInfo userInfo)
    {
        // 권한이 없는 정보를 사용하려 하면 ERROR가 생김
        te.text = userInfo.playerToken;

        Debug.Log(userInfo.playerToken);       // 보안 0
        Debug.Log(userInfo.playerName);        //   "
        Debug.Log(userInfo.playerAge);         //   "
        Debug.Log(userInfo.playerSex);         //   "

        Debug.Log(userInfo.playerEmail);       // 보안 1
        Debug.Log(userInfo.playerCP);          //   "
        Debug.Log(userInfo.playerAchievement); //   "
        Debug.Log(userInfo.playerFollower);    //   "

        Debug.Log(userInfo.playerGames);       // 보안 2
    }
}
