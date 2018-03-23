using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceAnimation : MonoBehaviour {

    //public Transform[] animationOBJ;
    public float animTime = 5;
    public GameObject startColTimeObj;
    public GameObject startColBackGround;
    public GameObject jianTouOBJ;
    public GameObject changeImage;
    public Sprite[] daoJishiTime;
    public GameObject topBackGround;
    public GameObject buttonBackGround;
    public GameObject nextWavaTop;
    public GameObject nextWavaBotton;


    private float startTime;
    private float fireRote=0f;
    private float dealyTime = 1;
    private int index = 0;
    private UISprite jianTouSprite;
    private float cotrollerTime;
    private Image numberImage;
    private Image pizaImage;
    private Image topImage;
    private Image buttonImage;
   
    //public GameObject getAnimOBJ;
	// Use this for initialization
	void Start () {
        jianTouSprite = jianTouOBJ.transform.GetComponent<UISprite>();
        numberImage = changeImage.GetComponent<Image>();
        pizaImage = startColBackGround.GetComponent<Image>();
        topImage = topBackGround.GetComponent<Image>();
        buttonImage = buttonBackGround.GetComponent<Image>();
        //startTime = Time.time;
        startTime = Time.timeSinceLevelLoad;
       // Time.timeScale = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
        cotrollerTime += Time.deltaTime;
        ChangeImagecol();

    }
    IEnumerator DeadTimeCol()
    {
        yield return new WaitForSeconds(5);
    }

    private void JianTouCol()
    {
        if (cotrollerTime < animTime)
        {

            if (jianTouSprite.fillAmount < 1)
            {
                jianTouSprite.fillAmount += 0.03f;

            }
            else if (jianTouSprite.fillAmount == 1 && Time.time - startTime > fireRote)
            {
                jianTouSprite.fillAmount = 0;
                startTime = Time.time + dealyTime;
            }
        }

    }
    private void ChangeImagecol()
    {
        if (Time.time - startTime > fireRote && index < 3)
        {
            numberImage.sprite = daoJishiTime[index];
            startTime = Time.time + dealyTime;
            index++;

        }
        else if (cotrollerTime > 4)
        {

            changeImage.SetActive(false);
            if (cotrollerTime > 4.5f)
            {
                pizaImage.fillAmount -= 0.01f;

                if (cotrollerTime > 6.5f)
                {
                    topImage.fillAmount -= 0.03f;
                    buttonImage.fillAmount -= 0.03f;
                    if (cotrollerTime > 7)
                    {
                        nextWavaTop.SetActive(true);
                        nextWavaBotton.SetActive(true);
                    }
                }
                
            }

        }
        

    }
}
