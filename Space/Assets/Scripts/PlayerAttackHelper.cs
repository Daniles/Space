using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public enum ShootType
{
    oneFire,
    twoFire
}
public class PlayerAttackHelper : MonoBehaviour {

    public GameObject ball;
    public float[] shootInterval = new float[2];
    public ShootType[] shootType = new ShootType[2];
    private float[] timerAttack = new float[2];
    private Transform muzzle;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < timerAttack.Length; i++)
        {
            timerAttack[i] = 0f;
        }
        muzzle = GameObject.Find("Muzzle").transform;
        if (muzzle == null) muzzle = transform;
    }

    void Update()
    {
        for (int i = 0; i < timerAttack.Length; i++)
        {
            timerAttack[i] += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetAxis("Fire1") == 1 && timerAttack[0] >= shootInterval[0])
        {
            timerAttack[0] = 0f;
            Shoot(shootType[0]);
        }
        if (Input.GetAxis("Fire2") == 1 && timerAttack[1] >= shootInterval[1])
        {
            timerAttack[1] = 0f;
            Shoot(shootType[1]);
        }
    }
    private void Shoot(ShootType currentShootType)
    {
        switch (currentShootType)
        {
            case ShootType.oneFire:
                {
                    foreach(float angle in ShootOneFireParameters.angle)
                    {
                        GameObject shootBall = Instantiate(ShootOneFireParameters.prefab, muzzle.position, Quaternion.identity) as GameObject;
                        shootBall.GetComponent<BallController>().damage = ShootOneFireParameters.damage;
                        shootBall.GetComponent<BallController>().flySpeed = ShootOneFireParameters.flySpeed;
                        shootBall.GetComponent<BallController>().angle = angle;
                        shootBall.GetComponent<BallController>().player = true;
                    }
                    break;
                }
            case ShootType.twoFire:
                {
                    foreach (float angle in ShootTwoFireParameters.angle)
                    {
                        GameObject shootBall = Instantiate(ShootTwoFireParameters.prefab, muzzle.position, Quaternion.identity) as GameObject;
                        shootBall.GetComponent<BallController>().damage = ShootTwoFireParameters.damage;
                        shootBall.GetComponent<BallController>().flySpeed = ShootTwoFireParameters.flySpeed;
                        shootBall.GetComponent<BallController>().angle = angle;
                        shootBall.GetComponent<BallController>().player = true;
                    }
                    break;
                }
        }
    }
}
