using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdataTowder : MonoBehaviour {


    GameManagerBehavior gm;
    MonsterData msData;
    private GameObject AtackOBJ;
    private Transform getAtackobjComponent;
    private PlaceMonster placeMonster;
    private ShootEnemies shootEnemies;
    private GameObject soldOBJ;
    public const float shootRadius = 0.66f;
    public UIEventListener[] soldAndUpEvent;
   // private GameObject CircleObj;
    // Use this for initialization
    void Start () {
        //UIEventListener.Get(transform.gameObject).onClick = CanCostGold;
        foreach (UIEventListener g in soldAndUpEvent)
        {
            g.onClick += CanCostGold;
        }
        //gm = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        
        placeMonster = PlaceMonster.mySelfGameObject.GetComponent<PlaceMonster>();
        //AtackOBJ = Resources.Load<GameObject>("wroop") as GameObject;
        //getAtackobjComponent = AtackOBJ.transform.Find(PlaceMonster.towerName);
        msData = PlaceMonster.mySelfGameObject.GetComponent<MonsterData>();
        //placeMonster = getAtackobjComponent.GetComponent<PlaceMonster>();
        shootEnemies = PlaceMonster.mySelfGameObject.GetComponent<ShootEnemies>();
       // CircleObj = PlaceMonster.mySelfGameObject.transform.Find("Circle").gameObject;
        msData.CurrentLevel = msData.levels[0];
        

    }

   private bool CanUpgradTower()
    {
        if (msData != null)
        {
            MonsterLevel nextLevels = msData.getNextLevel();
            if (nextLevels != null)
            {
                return GameManagerBehavior.Gold >= nextLevels.cost;
            }
        }
        return false;
       
    }

	// Update is called once per frame
	void Update () {
		
	}

    void CanCostGold(GameObject go)
    {
        if (go.transform.name.Equals("levelUp"))
        {
            if (CanUpgradTower())
            {
                msData.increaseLevel();
                GameManagerBehavior.Gold -= msData.CurrentLevel.cost;
                transform.GetChild(1).transform.GetChild(1).GetComponent<UILabel>().text = msData.CurrentLevel.cost.ToString();
                transform.GetChild(0).transform.GetChild(0).GetComponent<UILabel>().text = msData.CurrentLevel.slod.ToString();
                placeMonster.crielrSclac += 0.15f;
                shootEnemies.m_Radius = placeMonster.crielrSclac * shootRadius;
                //print(PlaceMonster.crielrSclac);

                placeMonster.circelRanger.transform.localScale = new Vector3(placeMonster.crielrSclac, placeMonster.crielrSclac, 1);
            }
        }
        else if (go.transform.name.Equals("levelSlod"))
        {
            if (PlaceMonster.mySelfGameObject != null)
            {

                // transform.GetChild(0).GetComponent<UILabel>().text = monsterData.CurrentLevel.slod.ToString();
                GameManagerBehavior.Gold += msData.CurrentLevel.slod;

                Destroy(PlaceMonster.mySelfGameObject);
                Destroy(transform.gameObject);
            }

        }
        
        
    }

}
