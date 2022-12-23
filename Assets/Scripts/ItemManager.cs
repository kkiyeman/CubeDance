using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public int Score { get; private set; } // 프로퍼티, 점수를 가져올 순 있지만 수정할 순 없다.

    [SerializeField] CubeMoveRotXR player; //어트리뷰트, private이지만 인스펙터창에서는 보인다.
    [SerializeField] private int coin;

    List<Transform> itemTrans = new List<Transform>();
    GameObject itemRoot;

    void Start()
    {
        itemRoot = new GameObject("ItemRoot");
        

        InitItemTrans(30);
    }

    private void InitItemTrans(int itemcount)
    {
        var coin = Resources.Load<Transform>("Coin");
       
        for (int i=0;i<itemcount; i++)
        {
            var itemcoin = Instantiate(coin, itemRoot.transform);

            Vector3 ranPos = Vector3.zero;
            while (true)
            {
                float X = Random.Range(-50, 50);
                float Z = Random.Range(-15, 85);
                ranPos = new Vector3(X, -0.8f, Z);

                Vector3 playerPos = new Vector3(player.transform.position.x, -0.8f, player.transform.position.z);
                if (Vector3.Distance(ranPos, playerPos) > 0.2f)
                    break;
            }
            itemcoin.position = ranPos;
            itemTrans.Add(itemcoin);
        }
    }

    void Update()
    {
        for(int i = 0; i<itemTrans.Count;i++)
        {
            var curItem = itemTrans[i];
            Vector3 playerPos = new Vector3(player.transform.position.x, -0.8f, player.transform.position.z);
            if (Vector3.Distance(curItem.position, playerPos) <1f)
            {
                Score += 10;
                curItem.gameObject.SetActive(false);
            }
        }
    }

}
