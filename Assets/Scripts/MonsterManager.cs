using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    

    [SerializeField] CubeMoveRotXR player; //어트리뷰트, private이지만 인스펙터창에서는 보인다.
    [SerializeField]private int monster;

    List<Transform> monsterTrans = new List<Transform>();
    GameObject monsterRoot;

    void Start()
    {

        monsterRoot = new GameObject("@monsterRoot");
        player.HP = 100;

        InitmonTrans(20);
    }

    private void InitmonTrans(int moncount)
    {
        var mon = Resources.Load<Transform>("Monster");

        for (int i = 0; i < moncount; i++)
        {
            var mMon = Instantiate(mon, monsterRoot.transform);

            Vector3 ranPos = GetGeneratePosition();
            mMon.position = ranPos;
            monsterTrans.Add(mMon);

            var monster = mMon.GetComponent<Monster>();
            monster.LateSetTarget();
        }
    }

    void Update()
    {
        MonsterAttack();
    }

    private Vector3 GetGeneratePosition()
    {
        Vector3 ranPos = Vector3.zero;

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            int randX = Random.Range(0, 2); 

            float posX = randX == 0 ? 49 : -49;
            float posZ = Random.Range(-49, 49);
            ranPos = new Vector3(posX, 0, posZ);
        }
        else
        {
            int randZ = Random.Range(0, 2);

            float posZ = randZ == 0 ? 49 : -49;
            float posX = Random.Range(-49, 49);
            ranPos = new Vector3(posX, 0, posZ);
        }

        return ranPos;
    }

    private void MonsterAttack()
    {
        for (int i = 0; i < monsterTrans.Count; i++)
        {
            var curMon = monsterTrans[i];
            Vector3 playerPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            if (Vector3.Distance(curMon.position, playerPos) < 2f)
            {
                player.HP -= 10;
                Debug.Log($"현재 HP = {player.HP}");
                if (player.HP <= 0)
                    player.Die();
                Vector3 ranPos = GetGeneratePosition();
                curMon.position = ranPos;
            }
        }
    }

}
