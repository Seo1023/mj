using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRayCast : MonoBehaviour
{
    public int Point = 0;                             //���ε� ��� ����
    public GameObject TargetObject;                   //Ÿ�� ������
    public float CheckTime = 0;                       //Ÿ�� Gen �ð� ����
    public float GameTime = 30.0f;                    //���� �ð� ����

    public Text pointUI;
    public Text timeUI;


    // Update is called once per frame
    void Update()
    { 
        CheckTime += Time.deltaTime;                       //�������� �����Ǿ� �ð��� ����ϰ� �Ѵ�.
        GameTime -= Time.deltaTime;                        //������ �ð��� �����Ͽ� 30�� -> 0�ʷ� ���� �Ѵ�.
        
        if (CheckTime <= 0)                                //0.5�� ���� �ൿ�� �Ѵ�.
        {
            int RandomX = Random.Range(0, 12);             //0~11������ �������� �̾Ƴ���.
            int RandomY = Random.Range(0, 12);             //0~11������ �������� �̾Ƴ���.
            GameObject temp = Instantiate(TargetObject);          //Instantiacte �Լ��� ���ؼ� �������� �����Ѵ�.
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);      //�������� ���ؼ� -6 ~ 5 ������ ���� �����ϰ� ��ġ
            Destroy(temp, 1.0f);                   //���� �� �ı��� 1���Ŀ� ���ش�.
            CheckTime = 0;                         //�ð��� �ʱ�ȭ ���ش�. (0.5�� ���� �ݺ��ϰ� �ϱ� ���ؼ�)
        }

        if (Input.GetMouseButtonDown(1))           //���콺 ������ ��ư�� ������ ���
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);       //ī�޶� ȭ�� �������� ���콺 �����ǿ��� Ray�� ����.

            RaycastHit hit;                                                     //�� Ray�� �޾ƿ��� ����

            if (Physics.Raycast(cast, out hit))                                 //Ray�� ����Ȱ��� ������
            {
                Debug.Log(hit.collider.gameObject.name);                        //����� ������Ʈ �̸��� ������ش�. 
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);        //Ray�� �������� ǥ�� ���ִ� �Լ�

                if (hit.collider.gameObject.tag == "Target")
                {
                    Point += 1;
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }
}


        