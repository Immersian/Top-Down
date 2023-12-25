using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class EnemyFollowing : MonoBehaviour

{
    public int speed;
    public LayerMask targetLayer;
    public GameObject NPC;

    void Update()
    {
        GameObject player = FindTargetWithTag("Player");
        GameObject baseObject = FindTargetWithTag("Base");

        GameObject target = ChooseCloserTarget(player, baseObject);
        if (NPC == null)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
    }

    GameObject FindTargetWithTag(string targetTag)
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);

        return target;
    }
    GameObject ChooseCloserTarget(GameObject target1, GameObject target2)
    {
        if (target1 == null && target2 == null)
        {
            return null;
        }
        else if (target1 == null)
        {
            return target2;
        }
        else if (target2 == null)
        {
            return target1;
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target1.transform.position);
            float distanceToBase = Vector3.Distance(transform.position, target2.transform.position);

            return distanceToPlayer < distanceToBase ? target1 : target2;
        }

    }
}
