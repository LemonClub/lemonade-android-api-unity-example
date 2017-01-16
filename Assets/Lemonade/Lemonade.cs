using UnityEngine;
using System.Collections;

namespace LA.Unity
{
    public sealed class Lemonade : MonoBehaviour
    {
        public static string accessToken = "";

        public static bool isAndroidInit
        {
            private set { isAndroidInit = value; }
            get { return isAndroidInit; }
        }
        public static bool isUnityInit
        {
            private set { isUnityInit = value; }
            get { return isUnityInit; }
        }
        public static bool isLoggedIn
        {
            private set { isLoggedIn = value; }
            get { return isLoggedIn; }
        }
        public static bool isInitialized            // 내부 & 외부 모두 초기화 선언이 되었는지 확인
        {
            get { return isAndroidInit && isUnityInit; }
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
        #region _LEMONADE_API_
        /**
         * @brief 프로그램 초기화
         */
        public static void init()
        {
            isAndroidInit = false;
            isUnityInit = false;
            isLoggedIn = false;

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
            successDelegate = success;
        }
        /**
         * @brief 프로그램 초기화
         * @param fail 초기화 실패 이후 이루어질 함수
         * @param success 초기화 성공 이후 이루어질 함수
         */
        public static void init(InitDelegate fail, InitDelegate success)
        {
            init(success);
            failDelegate = success;
        }

        /**
         * @brief 로그인 시도 ( 내부 Lemonade 실행 )
         * @desc 최초 실행에만 '로그인' 실행 - 이후에는 '자동 로그인'
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
         * @brief 로그아웃 시도 ( 내부 Lemonade 실행 )
         * @desc '자동 로그인'을 풀기 위함
         */
        public static void Logout()
        {
            if (isInitialized)
            {
#if UNITY_ANDROID
                _plugin.Call("DisConnect", _plugin);
                isLoggedIn = true;
#elif UNITY_EDITOR
#endif
            }
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
                failDelegate = null;
            }
            else
            {
                failDelegate();
                successDelegate = null;
            }
        }
        #endregion


        public static string playerName
        {
            private set { playerName = value; }
            get { return playerName; }
        }
        public static int playerAge
        {
            private set { playerAge = value; }
            get { return playerAge; }
        }
        public static string playerSex
        {
            private set { playerSex = value; }
            get { return playerSex; }
        }
        #region _EDITION_0_API_
        /**
         * @brief 유저의 정보_0 을 받아오기 위한 함수
         * @desc 유저 정보_0을 받아 오기전에 이 함수를 실행할 것
         */
        public static void initPlayerInfo_0()
        {
#if UNITY_ANDROID
            _plugin.Call("initPlayerInfo_0");
#endif
        }
        /**
         * @brief 유저의 정보_0 을 받아오기 위한 함수
         * @param success 초기화 성공 이후 이루어질 함수
         */
        public static void initPlayerInfo_0(InitDelegate success)
        {
            initPlayerInfo_0();
            successDelegate = success;
        }
        /**
         * @brief 유저의 정보_0 을 받아오기 위한 함수
         * @param fail 초기화 실패 이후 이루어질 함수
         * @param success 초기화 성공 이후 이루어질 함수
         */
        public static void initPlayerInfo_0(InitDelegate fail, InitDelegate success)
        {
            initPlayerInfo_0(success);
            failDelegate = fail;
        }
        #endregion
        #region _EDITION_0_
        /**
         * @brief 사용중인 유저 이름 받아오기 ( 내부에서 작동 )
         * @param name 유저 이름
         */
        public void setPlayerName(string name) { playerName = name; }
        /**
         * @brief 사용중인 유저 나이 받아오기
         * @param age 유저 나이
         */
        public void setPlayerAge(string age) { playerAge = System.Convert.ToInt32(age); }
        /**
         * @brief 사용중인 유저 나이 받아오기
         * @param sex 유저 성별 (  남자 : "Boy"  ||  여자 : "Girl"  )
         */
        public void setPlayerSex(string sex) { playerSex = sex; }
        /**
         * @brief 모든 정보 전달이 끝났을 경우 위 함수가 호출 됨
         * @param msg 성공 여부 메세지
         */
        public void doneInfo_0(string msg)
        {
            if (msg.Equals("true")) { successDelegate(); failDelegate = null; }
            else { failDelegate(); successDelegate = null; }
        }
        #endregion



        public static string playerEmail
        {
            private set { playerEmail = value; }
            get { return playerEmail; }
        }
        public static string playerCP
        {
            private set { playerCP = value; }
            get { return playerCP; }
        }
        #region _EDITION_1_API_
        /**
         * @brief 유저의 정보_1 을 받아오기 위한 함수
         * @desc 유저 정보_1을 받아 오기전에 이 함수를 실행할 것
         */
        public static void initPlayerInfo_1()
        {
#if UNITY_ANDROID
            _plugin.Call("initPlayerInfo_1");
#endif
        }
        /**
         * @brief 유저의 정보_1 을 받아오기 위한 함수
         * @param success 초기화 성공 이후 이루어질 함수
         */
        public static void initPlayerInfo_1(InitDelegate success)
        {
            initPlayerInfo_0();
            successDelegate = success;
        }
        /**
         * @brief 유저의 정보_1 을 받아오기 위한 함수
         * @param fail 초기화 실패 이후 이루어질 함수
         * @param success 초기화 성공 이후 이루어질 함수
         */
        public static void initPlayerInfo_1(InitDelegate fail, InitDelegate success)
        {
            initPlayerInfo_1(success);
            failDelegate = fail;
        }
        #endregion
        #region _EDITION_1
        /**
         * @brief 사용중인 유저 이메일 받아오기
         * @param email 이메일
         */
        public void setPlayerEmail(string email) { playerEmail = email; }
        /**
         * @brief 사용중인 유저 번호 받아오기
         * @param CP 핸드폰 번호
         */
        public void setPlayerCP(string CP) { playerCP = CP; }
        /**
         * @brief 모든 정보 전달이 끝났을 경우 위 함수가 호출 됨
         * @param msg 성공 여부 메세지
         */
        public void doneInfo_1(string msg)
        {
            if (msg.Equals("true")) { successDelegate(); failDelegate = null; }
            else { failDelegate(); successDelegate = null; }
        }
        #endregion



        #region _EDITION_2_API_
        #endregion



        #region _ANDROID_API_
        /**
         * @brief 토스트 메세지 띄우기
         */
        public static void toast(string msg)
        {
#if UNITY_ANDROID
            _plugin.Call("ToastMessage", msg);
#endif
        }
        #endregion
    }
}