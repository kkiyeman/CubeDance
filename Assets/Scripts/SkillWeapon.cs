using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SkillWeapon : MonoBehaviour
{
    public string recticlePrefName; //렉티클 프리펩 이름
    public bool isSelected;
    public XRRayInteractor interactor; // Hand Controller
    public GameObject recticle; // 렉티클 = 레이캐스트가 닿는 위치에 생기게 할 오브젝트
    public bool canUse = true;
    public float delay = 1.5f;
    public GameObject skill;


    void Start()
    {
        var rect = Resources.Load<GameObject>(recticlePrefName);
        recticle = Instantiate(rect);
        recticle.SetActive(false);

        var skillRef = Resources.Load<GameObject>("Skill");
        skill = Instantiate(skillRef);
        skill.SetActive(false);
    }

    void Update()
    {
        //무기가 선택되지 않았다면 실행X
        if (!isSelected)
            return;

        //인터렉터가 없다면 실행X
        if (interactor == null)
            return;

        //렉티클이 없다면 실행X
        if (recticle == null)
            return;


        //인터렉터의 레이캐스트를 받아와서 충돌값이 있는지 체크
        RaycastHit hit;
        if(interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            //충돌했다면 해당 위치에 렉티클을 이동
            recticle.transform.position = hit.point;
            //렉티클을 활성화
            recticle.SetActive(true);
        }
        
        //충돌하지 않았다면 렉티클을 비활성화
        else
          recticle.SetActive(false);
    }

    public void OnSelect()
    {
        //Select Entered에 넣을 함수
        isSelected = true;
    }

    public void DeSelect()
    {
        //Select Exited에 넣을 함수
        isSelected = false;
        recticle.SetActive(false);
    }

    public void OnActive()
    {
        if (!canUse)
            return;

        canUse = false;

        skill.transform.position = recticle.transform.position;
        skill.SetActive(true);

       
        Invoke("CheckDelay", delay);

    }

    void CheckDelay()
    {
        canUse = true;
    }


}
