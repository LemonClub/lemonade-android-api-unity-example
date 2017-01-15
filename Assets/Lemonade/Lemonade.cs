using UnityEngine;
using System.Collections;

namespace LA.Unity
{
    public sealed class Lemonade : MonoBehaviour
    {
        public static string accessToken = "";

        public static bool isAndroidInit = false;
        public static bool isUnityInit = false;
        public static bool isLoggedIn = false;
        public static bool isInitialized            // 내부 & 외부 모두 초기화 선언이 되었는지 확인
        {
            get
            {
                return isAndroidInit && isUnityInit;
            }
        }

        private static AndroidJavaObject _plugin = null;

        void Awake()
        {
            gameObject.name = "_Lemonade";
            DontDestroyOnLoad(this);

            if (!GameObject.Find("_Lemonade"))
            {
                Debug.LogWarning("There are no \"_Lemonade\" Gameobject");
            }
#if     UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _plugin = jc.GetStatic<AndroidJavaObject>("currentActivity");
#elif   UNITY_EDITOR
#endif
        }

        public delegate void InitDelegate();
        static InitDelegate failDelegate;
        static InitDelegate successDelegate;

        /**
         * @brief 프로그램 초기화
         */
        public static void init()
        {
#if     UNITY_ANDROID
            _plugin.Call("init", accessToken);
            isUnityInit = true;
#elif   UNITY_EDITOR
#endif
        }
        /**
         * @brief 프로그램 초기화
         * @param success 초기화 성공 이후 이루어질 함수 ( 함수 실행이 바로 이루어 질수 있게 함 )
         */
        public static void init(InitDelegate success)
        {
            init();
            successDelegate += success;
        }
        /**
         * @brief 프로그램 초기화
         * @param func 초기화 실패 이후 이루어질 함수
         * @param func 초기화 성공 이후 이루어질 함수
         */
        public static void init(InitDelegate fail, InitDelegate success)
        {
            init(success);
            failDelegate += success;
        }

        /**
         * @brief 앱 내 (Lemonade) 에게 초기화 이루어 졌는지 신호 받음
         */
        public void ReceiveInit(string androidInit)
        {
            if (androidInit.Equals("true"))
            {
                isAndroidInit = true;
                successDelegate();
            }
            else
            {
                failDelegate();
            }
        }

        /**
         * @brief 로그인 시도 ( 내부 Lemonade 실행 )
         */
        public static void Login()
        {
            if (isInitialized)
            {
#if UNITY_ANDROID
                _plugin.Call("Connect", _plugin);
                isLoggedIn = true;
#elif UNITY_EDITOR
#endif
            }
        }

        /**
         * @brief 토스트 메세지 띄우기
         */
        public static void toast(string msg)
        {
#if UNITY_ANDROID
            _plugin.Call("ToastMessage", msg);
#endif
        }
    }
}