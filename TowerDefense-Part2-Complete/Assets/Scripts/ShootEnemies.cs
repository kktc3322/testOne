using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShootEnemies : MonoBehaviour {

	public List<GameObject> enemiesInRange;
    public TowerType towerType = TowerType.Fire;//0或塔 1冰塔
    public float bltInterval = 0.5f;
    public GameObject bltPrefab;

	private float lastShotTime;
	private MonsterData monsterData;
    private float dealyTime = 1;
    public  float m_Radius = 0.462f;
    private Ray ray;
    private Vector3 beginPoint;
    private int targetMask;
    private float timer;
    private int damage = 1;
   // private PlaceMonster placeMonster;

    // Use this for initialization
    void Start () {
		enemiesInRange = new List<GameObject>();
		lastShotTime = Time.time;
        monsterData = gameObject.GetComponentInChildren<MonsterData> ();
        //monsterData = gameObject.transform.parent.GetComponent<MonsterData>();
        beginPoint = transform.position;
       // placeMonster = transform.GetComponent<PlaceMonster>();
       // targetMask = LayerMask.GetMask("targetMask");

        //print("324deg");
    }
	
	// Update is called once per frame
	void Update () {
		GameObject target = null;
        // print("gdrr3456");
        // 1
        //Vector3 frw = transform.TransformDirection(transform.forward);
        //ray = new Ray(transform.position, new Vector3(0,0,0));
        //float f=transform.position.x*20*Mathf.Cos()
        // 绘制圆环
        //Vector3 beginPoint = transform.position;
        // Vector3 firstPoint = Vector3.zero;
        //RaycastHit hit;
        //for (float theta = 0; theta < 360; theta +=10f)
        //{
        //    float x = transform.position.x+ m_Radius * Mathf.Cos(theta* 3.14f/180);
        //    float y = transform.position.y+ m_Radius * Mathf.Sin(theta * 3.14f / 180);
        //    Vector3 endPoint = new Vector3(x, y, 0);
        //    if (Physics.Raycast(transform.position, endPoint, out hit, 1))
        //    {
        //        Debug.DrawLine(beginPoint, hit.transform.position, Color.red, 1);
        //        print(hit.transform.name);
        //    }


        //}


        //挑选出射程内的敌人
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, m_Radius, 1 << LayerMask.NameToLayer("Enemies"));
        //攻击炮塔旋转量最小的
        GameObject targetEnemy = null;
        float minRotate = float.MaxValue;
        foreach (Collider2D en in enemies)
        {


           // float currRotate = Vector2.Angle(transform.forward, (en.transform.position - transform.position));
            //if (minRotate > currRotate)
            //{
            //    minRotate = currRotate;
            //    targetEnemy = en.transform;
            //}
            float distanceToGoal = en.transform.GetComponent<MoveEnemy>().distanceToGoal();//保证最前面的敌人被最先攻击
            //print(distanceToGoal);
            if (distanceToGoal < minRotate)
            {
                target = en.transform.gameObject;
                minRotate = distanceToGoal;
               // print(minimalEnemyDistance);
            }

        }
        Debug.DrawLine(transform.position,new Vector3(transform.position.x+ m_Radius, transform.position.y+ m_Radius, transform.position.z),Color.red,5);

        //找到最近的敌人
        //if (targetEnemy != null)
        //{
        //if (towerType == TowerType.Fire)
        //{
        //    //转向敌人
        //    transform.LookAt(targetEnemy.transform.position);
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);



        //}

        //Vector3 direction = gameObject.transform.position - targetEnemy.position;
        //gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, new Vector3(0, 0, 1));
        //timer += Time.deltaTime;
        //if (timer >= bltInterval)
        //{
        //    GameObject bulletPrefab = monsterData.CurrentLevel.bullet;//赋与子弹
        //    timer = 0;
        //    GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        //    BltControl bc = go.GetComponent<BltControl>();
        //    bc.Target = targetEnemy;//把目标给子弹
        //    bc.damage = this.damage;
        //}
        //}

        //void OnDrawGizmosSelected()
        //{
        //    //画塔射击范围
        //    Gizmos.DrawWireSphere(transform.position, range);
        //}

        //float minimalEnemyDistance = float.MaxValue;

        //foreach (GameObject enemy in enemiesInRange)
        //{
        //     print("daw3355");
        //    float distanceToGoal = enemy.GetComponent<MoveEnemy>().distanceToGoal();
        //    print(distanceToGoal);
        //    if (distanceToGoal < minimalEnemyDistance)
        //    {
        //        target = enemy;
        //        minimalEnemyDistance = distanceToGoal;
        //         print(minimalEnemyDistance);
        //    }
        //}
        // 2
        if (target != null)
        {
            if (Time.time - lastShotTime > monsterData.CurrentLevel.fireRate)
            {
                //print(lastShotTime);
                //print(Time.time);
                Shoot(target.GetComponent<CircleCollider2D>());
                lastShotTime = Time.time + dealyTime;

            }
            // 3获取敌人和炮台之间的向量，这样可以计算出弧度，然后用Atan2将弧度转换为角度（弧度转角360/2π，角转弧度2π/360）
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,new Vector3(0, 0, 1));
        }
    }

	void OnEnemyDestroy (GameObject enemy) {
		enemiesInRange.Remove (enemy);
	}
	
	void OnTriggerEnter(Collider other)
    {
        print("gsr667");
        if (other.gameObject.tag.Equals("Enemy"))
        {
           
			enemiesInRange.Add(other.gameObject);
			EnemyDestructionDelegate del =
				other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate += OnEnemyDestroy;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			enemiesInRange.Remove(other.gameObject);
			EnemyDestructionDelegate del =
				other.gameObject.GetComponent<EnemyDestructionDelegate>();
			del.enemyDelegate -= OnEnemyDestroy;
		}
	}

	void Shoot(CircleCollider2D target) {
		GameObject bulletPrefab = monsterData.CurrentLevel.bullet;//赋与子弹
		// 1 
		Vector3 startPosition = gameObject.transform.position;
		Vector3 targetPosition = target.transform.position;
		startPosition.z = bulletPrefab.transform.position.z;
		targetPosition.z = bulletPrefab.transform.position.z;
		
		// 2 
		GameObject newBullet = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);//创建子弹
        newBullet.transform.parent = transform.parent;
        newBullet.transform.localScale = Vector3.one;
		//newBullet.transform.position = startPosition;
       // newBullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        //newBullet.transform.rotation = Quaternion.Euler(0, 0, transform.position.z + 45f);
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();//得到子弹脚本
		bulletComp.target = target.transform.gameObject;
		bulletComp.startPosition = startPosition;
		bulletComp.targetPosition = targetPosition;
        //print(targetPosition);
		
		// 3 
		//Animator animator = monsterData.CurrentLevel.visualization.GetComponent<Animator> ();
		//animator.SetTrigger ("fireShot");
		//AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		//audioSource.PlayOneShot(audioSource.clip);
	}
}

public enum TowerType
{
    Fire,
    Ice,
}
