# Lemonade API
+ [Lemonade 메인 사이트](http://lemontree.dothome.co.kr/lemonade/)
+ [기본 API 함수 설명서](https://github.com/kyechan99/lemonade-android-api-unity-example/wiki)
+ 이메일 주소 : kyechan99@naver.com

## 필수 변경 사항
1. Lemonade.token 에 공급받은 accessToken 을 입력함.

   >![Example](http://postfiles13.naver.net/MjAxNzAzMTJfMTUy/MDAxNDg5MzExMDIwMjg1.NA1AuT_q0IUa4_gV5vtUhePpt4oND3m8JI2kNnDVC5Mg.37O5fU-y6Kl9LfsoAAexury8caTCIVOcRJmQfeYhTgUg.PNG.kyechan99/1.PNG?type=w1)


2. Assets/Plugins/Android/res/AndroidManifest.xml 

## 유저 정보 받아오기
1. 유저 정보를 받아올때 사용하는 함수 Lemonade.API.getUserInfo() 는 Coroutine 으로 호출해 주어야 함
   >StartCoroutine(Lemonade.API.getUserInfo(callFunc));

2. callFunc 는 Dictionary<string, object> 타입을 매개변수로 받는 함수가 들어가야 한다.
   >void callFunc(Dictionary<string, object> userInfo)
   >{
   >}

3. Dictionary<string, object>형 변수에는 유저 정보가 입력되며 아래와 같이 가져올수 있다.

   >![Example](http://postfiles12.naver.net/MjAxNzAzMTJfMjYw/MDAxNDg5MzExMDIwNTQz.UTavQYEmsMRD3rBeVGs4hukbvM5acxsGjV-SJcanaWMg.a9-wRh8bylGkMJzp1E3XvA0lkbJiJ9w2mkAE6grRyh0g.PNG.kyechan99/2.PNG?type=w1)

