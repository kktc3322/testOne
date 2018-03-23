using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Timers;

public class GameManagerBehavior : MonoBehaviour
{

    //public Text goldLabel;

    public UILabel[] labelCotroller;
    private static int gold;//金币
    private CameraShake cameraShake;


    public float animTime = 10;
    public GameObject startColTimeObj;
    public GameObject startColBackGround;
    public GameObject jianTouOBJ;
    public GameObject changeImage;
    public Sprite[] daoJishiTime;
    public GameObject topBackGround;
    public GameObject buttonBackGround;
    public GameObject allLoseImage;
    public static int getWave;
    // public GameObject nextWavaTop;
    //public GameObject nextWavaBotton;


    private float startTime;
    private float fireRote = 0f;
    private float dealyTime = 1;
    private int index = 0;
    private UISprite jianTouSprite;
    private float cotrollerTime;
    private Image numberImage;
    private Image pizaImage;
    private Image topImage;
    private Image buttonImage;
    private bool isChangImageNumber = false;
   // public delegate void TestDelegata(string message);
   // DateTime endTime;
    private Timer timer1 = new Timer();

    public static int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            //goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
            
        }
    }

    public Text waveLabel;
    public GameObject[] nextWaveLabels;

    public bool gameOver = false;

    private int wave;//波数
    public int Wave
    {
        get { return wave; }
        set
        {
            wave = value;
            getWave = wave;
            if (!gameOver)
            {
                
                changeImage.SetActive(true);
               
                isChangImageNumber = true;
                jianTouOBJ.SetActive(true);
                jianTouSprite.fillAmount = 1;
                pizaImage.fillAmount = 1;
                topImage.fillAmount = 1;
                buttonImage.fillAmount = 1;
                cotrollerTime = 0;
                index = 0;
                //for (int i = 0; i < nextWaveLabels.Length; i++)
                //{
                //    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                //}
            }
            //waveLabel.text = "WAVE: " + (wave + 1);
            labelCotroller[2].text = "WAVE: " + (wave + 1);

        }
    }

    //public Text healthLabel;
    //public GameObject[] healthIndicator;

    private int health;//血量
    public int Health
    {
        get { return health; }
        set
        {
            // 1
            if (value < health)
            {
                //Camera.main.GetComponent<CameraShake>().Shake();
                cameraShake.Shake();
            }
            // 2
            health = value;
            labelCotroller[3].text = "HEALTH: " + health;
            // 2
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
               // allLoseImage.GetComponent<Animator>().SetBool("gameOver", true);
               // print("daw78");
            }
            // 3 
            //for (int i = 0; i < healthIndicator.Length; i++) {
            //	if (i < Health) {
            //		healthIndicator[i].SetActive(true);
            //	} else {
            //		healthIndicator[i].SetActive(false);
            //	}
            //}
        }
    }

    private int level;

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
            labelCotroller[1].text = "LEVEL: " + level;
        }
    }

    private int slod;
    public int Slod
    {
        get
        {
            return slod;
        }

        set
        {
            slod = value;
            gold += slod;
            //labelCotroller[0].text = "GOLD: " + (gold + slod);
        }
    }





    // Use this for initialization
    int myint = 0;
    void Start()
    {
        jianTouSprite = jianTouOBJ.transform.GetComponent<UISprite>();
        numberImage = changeImage.GetComponent<Image>();
        pizaImage = startColBackGround.GetComponent<Image>();
        topImage = topBackGround.GetComponent<Image>();
        buttonImage = buttonBackGround.GetComponent<Image>();
        //startTime = Time.time;
        startTime = Time.timeSinceLevelLoad;
        // Time.timeScale = 0;


        cameraShake = GameObject.Find("Camera").GetComponent<CameraShake>();
        labelCotroller[4].text = "?";
        Gold = 1000;
        Wave = 0;
        Health = 5;
        Level = 1;
        labelCotroller[0].text = "GOLD: " + gold;
        //Tets();
        //test(ref myint);
        //test4(out myint);
        //print(myint);


        // endTime = DateTime.Now.AddSeconds(45);
        // timer1.Enabled = true;


    }

    // Update is called once per frame
    void Update()
    {

        cotrollerTime += Time.deltaTime;
        ChangeImagecol();
        JianTouCol();
       // DateTime show = endTime.Subtract(new TimeSpan(DateTime.Now.Ticks));
        //Debug.Log(show);
    }

    
    void test(ref int i)
    {
        
        myint = i;
    }
    void test4(out int i)
    {
        i = 10;
        myint = i;
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
        else
        {
            jianTouOBJ.SetActive(false);
        }

    }
    private void ChangeImagecol()
    {
        if (!isChangImageNumber)
        {
            return;
        }
      
        
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

                if (cotrollerTime > 6f)
                {
                    topImage.fillAmount -= 0.03f;
                    buttonImage.fillAmount -= 0.03f;
                    if (cotrollerTime > 7)
                    {
                        for (int i = 0; i < nextWaveLabels.Length; i++)
                        {
                            nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                        }
                        isChangImageNumber = false;
                        cotrollerTime = 0;
                    }
                }

            }

        }

        
    }
    
}

//delegate double MathAction(double num);

//class DelegateTest
//{
//    // Regular method that matches signature:
//    static double Double(double input)
//    {
//        return input * 2;
//    }

//    static void Main()
//    {
//        // Instantiate delegate with named method:
//        MathAction ma = Double;

//        // Invoke delegate ma:
//        double multByTwo = ma(4.5);
//        Console.WriteLine("multByTwo: {0}", multByTwo);

//        // Instantiate delegate with anonymous method:
//        MathAction ma2 = delegate (double input)
//        {
//            return input * input;
//        };

//        double square = ma2(5);
//        Console.WriteLine("square: {0}", square);

//        // Instantiate delegate with lambda expression
//        MathAction ma3 = s => s * s * s;
//        double cube = ma3(4.375);

//        Console.WriteLine("cube: {0}", cube);
//    }
//    // Output:
//    // multByTwo: 9
//    // square: 25
//    // cube: 83.740234375
//}



