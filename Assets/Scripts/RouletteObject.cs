using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [Header("# 룰렛 오브젝트")]
    public GameObject m_RouletteObject;

    [Header("# 룰렉 제동력")]
    public float m_BrakingForce = 1500.0f;

    /// <summary>
    /// 현재 적용된 z축 회전 속도입니다.
    /// 0일 경우 회전하지 않습니다.
    /// </summary>
    private float _ZRotayionVelocity;

    private bool _lsRotatingAllowed;
    private bool _lsRotayiongAllowed;

    private void Update()
    {
        //input.GetKeyDown : 눌릴 경우 한번 True
        //input.GetKey : 눌려 있을 경우 True
        //input.GetKeyUp : 때어졌을 경우 하번 True

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lnitializeRoulette();
        }

        //룰렉 회전 
        RotationRoulette();
    }

    /// <summary>
    /// 룰렛 로브젝트를 토기화합니다.
    /// </summary>
    private void lnitializeRoulette()
    {
        //회전 속도 초기화
        lnitializeRotationVelocity();

        //회전 허용
        _lsRotatingAllowed = true;
    }

    private void lnitializeRotationVelocity()
    {
        _ZRotayionVelocity = 3000.0f;
    }

    /// <summary>
    /// 룰렛을 회전시킵니다
    /// </summary>

    private void RotationRoulette()
    {

        if (_lsRotatingAllowed)
        {

            //룰렛의 현재 회전을 얻습니다.
            Vector3 rouletteRoration = m_RouletteObject.transform.localEulerAngles;

            //제동력을 제공합니다.
            _ZRotayionVelocity -= m_BrakingForce * Time.deltaTime;

            // 회전 속도가 0미만인 경우 회전을 진행하지 암ㅎ습니다.
            if (_ZRotayionVelocity < 0.0f)
            {
                //회전을 멈추도록 합니다.
                _lsRotatingAllowed = false;
            }

            // 다음 회전 값을 설정합니다. 
            rouletteRoration.z -= _ZRotayionVelocity * Time.deltaTime;

            //룰렛의 회전을 설정합니다
            m_RouletteObject.transform.localEulerAngles -= rouletteRoration;
        }

    }
}
