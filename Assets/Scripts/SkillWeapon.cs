using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SkillWeapon : MonoBehaviour
{
    public string recticlePrefName; //��ƼŬ ������ �̸�
    public bool isSelected;
    public XRRayInteractor interactor; // Hand Controller
    public GameObject recticle; // ��ƼŬ = ����ĳ��Ʈ�� ��� ��ġ�� ����� �� ������Ʈ
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
        //���Ⱑ ���õ��� �ʾҴٸ� ����X
        if (!isSelected)
            return;

        //���ͷ��Ͱ� ���ٸ� ����X
        if (interactor == null)
            return;

        //��ƼŬ�� ���ٸ� ����X
        if (recticle == null)
            return;


        //���ͷ����� ����ĳ��Ʈ�� �޾ƿͼ� �浹���� �ִ��� üũ
        RaycastHit hit;
        if(interactor.TryGetCurrent3DRaycastHit(out hit))
        {
            //�浹�ߴٸ� �ش� ��ġ�� ��ƼŬ�� �̵�
            recticle.transform.position = hit.point;
            //��ƼŬ�� Ȱ��ȭ
            recticle.SetActive(true);
        }
        
        //�浹���� �ʾҴٸ� ��ƼŬ�� ��Ȱ��ȭ
        else
          recticle.SetActive(false);
    }

    public void OnSelect()
    {
        //Select Entered�� ���� �Լ�
        isSelected = true;
    }

    public void DeSelect()
    {
        //Select Exited�� ���� �Լ�
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
