 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour{

    public Transform bulletPoint;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public Sprite imgRedBullet;
    public Sprite imgBlueBullet;
    public Image swapBullet; 
    public int idArma = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            changeCannon();
            Debug.Log(idArma);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            //Atirar
            shoot();
        }
    }

    //Criar um método só para atirar
    private void shoot()
    {
        if (idArma == 0){
            Instantiate(blueBulletPrefab, bulletPoint.position, bulletPoint.rotation);
        }
        else if (idArma == 1){
            Instantiate(redBulletPrefab, bulletPoint.position, bulletPoint.rotation);
        }
    }

    private void changeCannon(){
        swapBullet.overrideSprite = imgRedBullet;
        idArma++;
        if (idArma > 1){
            swapBullet.overrideSprite = imgBlueBullet;
            idArma = 0;
        }
    }

}
