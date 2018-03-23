using UnityEngine;
using System.Collections;

public class PlaceMonster : MonoBehaviour {

	//public GameObject monsterPrefab;
    public GameObject moddleSprite;
    private GameObject upDataOBJ;
    private GameObject slodOBJ;
    private GameObject upAndSlod;
    private GameObject creatUpAndSoldOBJ;
    public GameObject circelRanger;
    public float crielrSclac = 0.5f;
    public static GameObject mySelfGameObject;
    public static string towerName;
    //public GameObject bullet;

    private bool isShowUpdata=false;
    private GameObject monster;
	private GameManagerBehavior gameManager;
    
    
   // private Transform circelRanger;
    

   // public UIEventListener[] allWarEvent;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        upAndSlod = Resources.Load<GameObject>("UpAndSold") as GameObject;
        //mySelfGameObject = transform.gameObject;
        //moddleSprite = GameObject.FindWithTag("middle");
        //foreach (UIEventListener e in allWarEvent)
        //{
        //    e.onClick += _btnClicked;
        //}
        UIEventListener.Get(this.transform.gameObject).onClick = _btnClicked;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private bool canPlaceMonster() {
		int cost = transform.GetComponent<MonsterData> ().levels[0].cost;//需要花费的金币
		return moddleSprite != null && GameManagerBehavior.Gold >= cost;//判断金币需求
	}
	
	//1
	void _btnClicked(GameObject go)
    {
        //2
        // Debug.Log("ni hao ");
        
        
            if (canPlaceMonster())
            {
                //3
                // monster = (GameObject) Instantiate(monsterPrefab, transform.position, Quaternion.identity);
                // monster.transform.parent = transform;
                // monster.transform.localScale = Vector3.one;
                //monster.transform.rotation = Quaternion.Euler(0,0,90f);
                this.transform.position = moddleSprite.transform.position;
            this.transform.parent = moddleSprite.transform.parent.parent;
            this.transform.localScale = Vector3.one;
            towerName = this.transform.name;
            // print(towerName);
            //monsterPrefab.GetComponent<SphereCollider>().radius = 200;
            //collider.radius = 200f;
            transform.gameObject.AddComponent<ShootEnemies>();
            //transform.GetChild(0).gameObject.AddComponent<ShootEnemies>();
            //monsterPrefab.AddComponent<ShowUpdataOBJ>();
                Destroy(moddleSprite.transform.parent.gameObject);

            //4
            //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioSource.clip);
            //gameObject.AddComponent<AudioCotroller>();
            // AudioCotroller audioCotroller= gameObject.GetComponent<AudioCotroller>();
            // AudioCotroller.intants.GetAucioClip(0);
            // print("canPlaceMonster");

            GameManagerBehavior.Gold -= transform.gameObject.GetComponent<MonsterData>().CurrentLevel.cost;
            }
            else 
            {
            //monster.GetComponent<MonsterData>().increaseLevel();//第一次给等级赋值，确认等级
            //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            //audioSource.PlayOneShot(audioSource.clip);

            //gameManager.Gold -= monster.GetComponent<MonsterData>().CurrentLevel.cost;
            //print("canUpgradeMonster");
            canUpgradeMonster();
            }

       
		
	}

	private void canUpgradeMonster()
    {
        
        if (transform.gameObject != null && !isShowUpdata)
        {
            // print("dage456");
            // MonsterData monsterData = monster.GetComponent<MonsterData>();
            //MonsterLevel nextLevel = monsterData.getNextLevel();
            //if (nextLevel != null)
            // {
            // return gameManager.Gold >= nextLevel.cost;
            //}
            // circelRanger = transform.GetChild(2);
            //ShootEnemies se = monsterPrefab.GetComponent<ShootEnemies>();
             creatUpAndSoldOBJ = Instantiate(upAndSlod, transform.position, Quaternion.identity) as GameObject;
            creatUpAndSoldOBJ.transform.parent = transform.parent;
            creatUpAndSoldOBJ.transform.localScale = Vector3.one;
            circelRanger.transform.localScale = new Vector3(crielrSclac, crielrSclac, 1);
            
           // upDataOBJ.transform.parent = transform.parent;
            //slodOBJ.transform.parent = transform.parent;
            //circelRanger.transform.parent = transform.parent;
           // upDataOBJ.transform.GetChild(1).GetComponent<UILabel>().text = transform.gameObject.GetComponent<MonsterData>().CurrentLevel.cost.ToString();
            //slodOBJ.transform.GetChild(0).GetComponent<UILabel>().text = transform.gameObject.GetComponent<MonsterData>().CurrentLevel.slod.ToString();
            creatUpAndSoldOBJ.transform.GetChild(0).transform.GetChild(0).GetComponent<UILabel>().text= transform.gameObject.GetComponent<MonsterData>().CurrentLevel.slod.ToString();
            creatUpAndSoldOBJ.transform.GetChild(1).transform.GetChild(1).GetComponent<UILabel>().text = transform.gameObject.GetComponent<MonsterData>().CurrentLevel.cost.ToString();
            //upDataOBJ.SetActive(true);
            //slodOBJ.SetActive(true);
            circelRanger.SetActive(true);
            mySelfGameObject = this.transform.gameObject;
            isShowUpdata = true;
        }
        else if(isShowUpdata)
        {
            circelRanger.SetActive(false);
            Destroy(creatUpAndSoldOBJ);
            //upDataOBJ.SetActive(false);
            //slodOBJ.SetActive(false);
            isShowUpdata = false;
            //return true;
        }
		//return false;
	}
}
