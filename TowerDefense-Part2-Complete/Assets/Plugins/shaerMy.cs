using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cn.sharesdk.unity3d;
using UnityEngine.UI;


public class shaerMy : MonoBehaviour {
    public ShareSDK ssdk;
    private string objname;

    public Text text;
    public int myint = 0;
	// Use this for initialization
	void Start () {
        //截屏分享
        ssdk = gameObject.GetComponent<ShareSDK>();
        ssdk.shareHandler = OnShareResultHandler;
        //print("dww3455");


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnShareResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable result)
    {
        //print("afe335");
        if (state == ResponseState.Success)
        {
            print("share successfully - share result;");
            print(MiniJSON.jsonEncode(result));
            objname = "分析成功：" + MiniJSON.jsonEncode(result);
        }
        else if (state == ResponseState.Fail)
        {

        }
        else if (state == ResponseState.Cancel)
        {
            print("cancel");
        }
    }

    public void btuScreenCaponClick()
    {
        text.text = "开始截屏";
        ScreenCapture.CaptureScreenshot("Screenshot.png");
        text.text = "截屏中...";
        StartCoroutine(JiepingTime(0.5f));
        text.text = "完成截屏";
    }

    private IEnumerator JiepingTime(float a)
    {
        yield return new WaitForSeconds(a);
        string imagePath = Application.persistentDataPath;
        imagePath = imagePath + "/Screenshot.png";

        ShareContent content = new ShareContent();
        //content.SetText("大家好...");
        content.SetImagePath(imagePath);
        //content.SetTitle("什么鬼");
        //content.SetComment("分享一张照片");
        //content.SetShareType(ContentType.Image);
        ssdk.ShowPlatformList(null, content, 100, 100);
        ssdk.ShowShareContentEditor(PlatformType.WeChat, content);


    }

}
