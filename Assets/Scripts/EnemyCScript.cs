using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemyMovement : Movement
//{
//    public Transform Target;

//    protected override void HandleInput()
//    {
//        if (Target == null)
//        {
//            Target = GameObject.FindWithTag("Player").transform;
//        }

//        if (Target == null)
//        {
//            return;
//        }

//        _inputDirection = (Target.position - transform.position).normalized;
//    }



//    //private void FixedUpdate()
//    //{
//    //    if (Horizontal != 0 && Vertical != 0)
//    //    {
//    //        Horizontal *= MoveLimiter;
//    //        Vertical *= MoveLimiter;
//    //    }
//    //    _rigidBody.velocity = new Vector2(Horizontal * Speed * Time.deltaTime, Vertical * Speed * Time.deltaTime);
//    //}
//}

