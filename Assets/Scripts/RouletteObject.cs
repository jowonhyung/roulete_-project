using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [Header("# �귿 ������Ʈ")]
    public GameObject m_RouletteObject;

    [Header("# �귺 ������")]
    public float m_BrakingForce = 1500.0f;

    /// <summary>
    /// ���� ����� z�� ȸ�� �ӵ��Դϴ�.
    /// 0�� ��� ȸ������ �ʽ��ϴ�.
    /// </summary>
    private float _ZRotayionVelocity;

    private bool _lsRotatingAllowed;
    private bool _lsRotayiongAllowed;

    private void Update()
    {
        //input.GetKeyDown : ���� ��� �ѹ� True
        //input.GetKey : ���� ���� ��� True
        //input.GetKeyUp : �������� ��� �Ϲ� True

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lnitializeRoulette();
        }

        //�귺 ȸ�� 
        RotationRoulette();
    }

    /// <summary>
    /// �귿 �κ���Ʈ�� ���ȭ�մϴ�.
    /// </summary>
    private void lnitializeRoulette()
    {
        //ȸ�� �ӵ� �ʱ�ȭ
        lnitializeRotationVelocity();

        //ȸ�� ���
        _lsRotatingAllowed = true;
    }

    private void lnitializeRotationVelocity()
    {
        _ZRotayionVelocity = 3000.0f;
    }

    /// <summary>
    /// �귿�� ȸ����ŵ�ϴ�
    /// </summary>

    private void RotationRoulette()
    {

        if (_lsRotatingAllowed)
        {

            //�귿�� ���� ȸ���� ����ϴ�.
            Vector3 rouletteRoration = m_RouletteObject.transform.localEulerAngles;

            //�������� �����մϴ�.
            _ZRotayionVelocity -= m_BrakingForce * Time.deltaTime;

            // ȸ�� �ӵ��� 0�̸��� ��� ȸ���� �������� �Ϥ����ϴ�.
            if (_ZRotayionVelocity < 0.0f)
            {
                //ȸ���� ���ߵ��� �մϴ�.
                _lsRotatingAllowed = false;
            }

            // ���� ȸ�� ���� �����մϴ�. 
            rouletteRoration.z -= _ZRotayionVelocity * Time.deltaTime;

            //�귿�� ȸ���� �����մϴ�
            m_RouletteObject.transform.localEulerAngles -= rouletteRoration;
        }

    }
}
