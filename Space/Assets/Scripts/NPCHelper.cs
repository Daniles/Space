using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class NPCHelper : MonoBehaviour {
    
    public float Health = 100;
    public GameObject subtractHelperPrefab;
    public ShootType shootType;
    public float attackInterval;
    private float attackTimer = 0f;
    private GameObject subtractHelper;
    private Transform muzzle;
    // Use this for initialization
    void Start () {
        subtractHelper = Instantiate(subtractHelperPrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity) as GameObject;
        subtractHelper.transform.SetParent(GameObject.Find("Canvas").transform, true);
        subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, 0);
        muzzle = transform.FindChild("Muzzle");

        shootType = ShootType.twoFire;
        attackInterval = 3f;
        attackTimer = attackInterval;
}
	
	// Update is called once per frame
	void Update () {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackInterval)
        {
            attackTimer = 0;
            Shoot(shootType);
        }
        if (subtractHelper.GetComponent<Text>().color.a > 0) // изменение прозрачности текста с отнятым хп
        {
            subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, subtractHelper.GetComponent<Text>().color.a - 0.01f);
        }
	}

    void OnTriggerEnter2D(Collider2D colliderEnter)
    {
        if (colliderEnter.gameObject.GetComponent<BallController>() && colliderEnter.gameObject.GetComponent<BallController>().player)
        {
            Destroy(colliderEnter.gameObject);
            Health -= colliderEnter.gameObject.GetComponent<BallController>().damage;
            if (Health <= 0)
            {
                transform.parent.gameObject.GetComponent<SpawnNPC>().NPCDestroy();
                Destroy(subtractHelper);
                Destroy(gameObject);
            }
            subtractHelper.GetComponent<Text>().text = "-" + colliderEnter.gameObject.GetComponent<BallController>().damage.ToString();
            subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, 1);

        }
    }
    public void Shoot(ShootType currentShootType)
    {
        switch (currentShootType)
        {
            case ShootType.oneFire:
                {
                    foreach (float angle in ShootOneFireParameters.angle)
                    {
                        GameObject shootBall = Instantiate(ShootOneFireParameters.prefab, muzzle.position, Quaternion.identity) as GameObject;
                        shootBall.GetComponent<BallController>().damage = ShootOneFireParameters.damage;
                        shootBall.GetComponent<BallController>().flySpeed = ShootOneFireParameters.flySpeed;
                        shootBall.GetComponent<BallController>().angle = angle + Mathf.PI;
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
                        shootBall.GetComponent<BallController>().angle = angle + Mathf.PI;
                    }
                    break;
                }
        }
    }
}
