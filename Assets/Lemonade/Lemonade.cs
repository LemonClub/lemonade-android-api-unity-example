using UnityEngine;

namespace LA.Unity
{
    public sealed class Lemonade : MonoBehaviour
    {
        public static LA.API API = new LA.API();
        static string token = "aGlrY29tLmhvdC5oaWs=";      // 이곳에 게임 토큰을 적어주세요.
        public static string accessToken
        {
            get
            {
                if (token.Equals(""))
                {
                    Debug.LogWarning("There are no \"accessToken\" value");
                    return "";
                }
                else
                {
                    return token;
                }
            }
        }

        private static bool m_isAndroidInit;
        private static bool m_isUnityInit;
        private static bool m_isLoggedIn;

        public static bool isInitialized            // 내부 & 외부 모두 초기화 선언이 되었는지 확인
        {
            get { return (m_isAndroidInit && m_isUnityInit); }
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
#if     UNITY_EDITOR
#elif   UNITY_ANDROID
            AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            _plugin = jc.GetStatic<AndroidJavaObject>("currentActivity");
#else
#endif
            StartCoroutine(API.init(accessToken));
        }

        public delegate void InitDelegate();
        static InitDelegate failDelegate;
        static InitDelegate successDelegate;
        #region _LEMONADE_API_
        /// <summary>
        /// 프로그램 초기화
        /// </summary>
        public static void init()
        {
            m_isAndroidInit = false;
            m_isUnityInit = false;
            m_isLoggedIn = false;
            
#if UNITY_EDITOR
            ///
            /// Unity EDITOR 버전에서 안드로이드 과정을 거치지 않고 테스트 하기 위한 부분입니다.
            /// 
            m_isUnityInit = true;
            LA.User.Lemon._user.playerToken = "testtoken";
            m_isAndroidInit = true;
            if (successDelegate != null)
                successDelegate();
#elif UNITY_ANDROID
            _plugin.Call("init", accessToken);
            m_isUnityInit = true;
#else
#endif
        }
        /// <summary>
        /// 프로그램 초기화
        /// </summary>
        /// <param name="success">초기화 성공 이후 이루어질 함수 ( 함수 실행이 바로 이루어 질수 있게 함 )</param>
        public static void init(InitDelegate success)
        {
            successDelegate = success;
            init();
        }
        /// <summary>
        /// 프로그램 초기화
        /// </summary>
        /// <param name="success">초기화 성공 이후 이루어질 함수</param>
        /// <param name="fail">초기화 실패 이후 이루어질 함수</param>
        public static void init(InitDelegate success, InitDelegate fail)
        {
            failDelegate = fail;
            init(success);
        }

        /// <summary>
        /// 로그인 시도 ( 내부 Lemonade 실행 )
        /// </summary>
        /// <remarks>최초 실행에만 '로그인' 실행 - 이후에는 '자동 로그인'</remarks>
        public static void Login()
        {
            if (isInitialized)
            {
#if     UNITY_EDITOR
                m_isLoggedIn = true;
#elif   UNITY_ANDROID
                _plugin.Call("Connect", _plugin);
                m_isLoggedIn = true;
#else
#endif
            }
        }

        /// <summary>
        /// 로그아웃 시도 ( 내부 Lemonade 실행 )
        /// </summary>
        /// <remarks>'자동 로그인'을 풀기 위함</remarks>
        public static void Logout()
        {
            if (isInitialized)
            {
#if     UNITY_EDITOR
                m_isLoggedIn = true;
#elif   UNITY_ANDROID
                _plugin.Call("DisConnect", _plugin);
                m_isLoggedIn = true;
#endif
            }
        }

        /// <summary>
        /// 앱 내 (Lemonade) 에게 초기화 이루어 졌는지 신호 받음
        /// </summary>
        /// <param name="androidInit">안드로이드 초기화가 제대로 이루어졌는지 확인, 올바르게 되었다면 '유저토큰'이 전달받음</param>
        public void ReceiveInit(string androidInit)
        {
            if (androidInit.Equals("FAIL"))
            {
                if (failDelegate != null)
                    failDelegate();
                successDelegate = null;
            }
            else
            {
                LA.User.Lemon._user.playerToken = androidInit;
                m_isAndroidInit = true;
                if (successDelegate != null)
                    successDelegate();
            }
            failDelegate = null;
            successDelegate = null;
        }
        #endregion

        #region _PLAYER_
        public static string playerName { get { return LA.User.Lemon._user.playerName; } }
        public static int playerAge { get { return LA.User.Lemon._user.playerAge; } }
        public static string playerSex { get { return LA.User.Lemon._user.playerSex; } }
        

        public static string playerEmail { get { return LA.User.Lemon._user.playerEmail; } }
        public static string playerCP { get { return LA.User.Lemon._user.playerCP; } }
        #endregion

        #region _ANDROID_API_
        /// <summary>
        /// 토스트 메세지 띄우기
        /// </summary>
        public static void toast(string msg)
        {
#if     UNITY_EDITOR
#elif   UNITY_ANDROID
            _plugin.Call("ToastMessage", msg);
#endif
        }
        #endregion
    }
}