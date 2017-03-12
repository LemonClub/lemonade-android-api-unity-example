# Lemonade API
+ [Lemonade ���� ����Ʈ](http://lemontree.dothome.co.kr/lemonade/)

## �ʼ� ���� ����
1. Lemonade.token �� ���޹��� accessToken �� �Է���.

   >![Example](http://postfiles13.naver.net/MjAxNzAzMTJfMTUy/MDAxNDg5MzExMDIwMjg1.NA1AuT_q0IUa4_gV5vtUhePpt4oND3m8JI2kNnDVC5Mg.37O5fU-y6Kl9LfsoAAexury8caTCIVOcRJmQfeYhTgUg.PNG.kyechan99/1.PNG?type=w1)


2. Assets/Plugins/Android/res/AndroidManifest.xml 

## ���� ���� �޾ƿ���
1. ���� ������ �޾ƿö� ����ϴ� �Լ� Lemonade.API.getUserInfo() �� Coroutine ���� ȣ���� �־�� ��
>StartCoroutine(Lemonade.API.getUserInfo(callFunc));

2. callFunc �� Dictionary<string, object> Ÿ���� �Ű������� �޴� �Լ��� ���� �Ѵ�.
>void callFunc(Dictionary<string, object> userInfo)
>{
>}

3. Dictionary<string, object>�� �������� ���� ������ �ԷµǸ� �Ʒ��� ���� �����ü� �ִ�.

   >![Example](http://postfiles12.naver.net/MjAxNzAzMTJfMjYw/MDAxNDg5MzExMDIwNTQz.UTavQYEmsMRD3rBeVGs4hukbvM5acxsGjV-SJcanaWMg.a9-wRh8bylGkMJzp1E3XvA0lkbJiJ9w2mkAE6grRyh0g.PNG.kyechan99/2.PNG?type=w1)

