using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobOrb : ActiveSkill{
    // [SerializeField]protected Transform player;
    [SerializeField]protected float orbRotationRadius;
    [SerializeField]protected float rotationSpeed;
    [SerializeField]protected RotatingProjectile orb;
    [SerializeField]protected List<RotatingProjectile> orbs = new List<RotatingProjectile>();

    protected override void Update(){
        // base.Update();
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime,0));
        if(Input.GetKeyDown(KeyCode.Space)){
            Action();
        }
    }

    public override void Action(){
        //instantiate orb on circle
        Debug.Log("Spawn new Orbs");
        int nextEnemyCount = orbs.Count + 1;
        var radians = 2 * Mathf.PI /nextEnemyCount;
        float vertOrdinat = Mathf.Sin(radians);
        float horiOrdinat = Mathf.Cos(radians);
        Vector3 spawnPos = new Vector3(horiOrdinat, 0 , vertOrdinat);
        RotatingProjectile newOrbs = Instantiate(orb, transform.position, Quaternion.identity, this.transform);
        // RotatingProjectile newOrbs = Instantiate(orb, transform.position, Quaternion.identity);
        newOrbs.gameObject.SetActive(true);
        // newOrbs.transform.parent = this.transform;
        orbs.Add(newOrbs);
        int i = 1;
        foreach (RotatingProjectile orb in orbs){
            radians =  2 * Mathf.PI /orbs.Count* i;
            horiOrdinat = Mathf.Sin(radians);
            vertOrdinat = Mathf.Cos(radians);
            spawnPos = new Vector3(horiOrdinat, 0 , vertOrdinat);
            Vector3 newPos = transform.position + spawnPos * orbRotationRadius;
            i++;
            orb.transform.position = newPos;
        }
    }
   
}
