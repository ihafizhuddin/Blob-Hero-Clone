using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : BaseProjectile{
    public Transform target;
    [SerializeField]protected LayerMask enemyLayer;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    void OnDrawGizmos(){
        if(target != null){
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }

    // Update is called once per frame
    void Update(){
        if(target == null)Retargeting();
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        direction.z = 0;
        //PR Rotate misilie agar bergerak maju bukan menyamping
        // Vector3 rightDir = direction;
        // Vector3 forwardDir = Vector3.Cross(rightDir, Vector3.right);
        // if (forwardDir.sqrMagnitude == Vector3.zero) {
        //     return;
        // }
        // transform.rotation = Quaternion.LookRotation(forwardDir);
        // transform.position += (direction *Time.deltaTime * projectileSpeed);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
    }
    void Retargeting(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Mathf.Infinity, enemyLayer);
        float minDistance = Mathf.Infinity;
        foreach (Collider col in hitColliders){
            float distance = Vector3.Distance(transform.position, col.transform.position);
            if(distance < minDistance){
                minDistance = distance;
                target = col.transform;
            }
        }
        

    }

    protected override void OnTriggerEnter(Collider col){
        base.OnTriggerEnter(col);
        if(col.gameObject.tag == "Enemy"){
            // Destroy(this.gameObject);
            this.gameObject.SetActive(false);

            //damage enemy
        
        // Destroy(col.gameObject);
        }

        
    }
}
