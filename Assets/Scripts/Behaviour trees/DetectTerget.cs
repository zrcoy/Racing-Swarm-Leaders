using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : Task {
    LayerMask mask;
    
    public override NodeResult Execute()
    {
        
        RaycastHit hitInfo;
        //Debug.DrawRay(muzzle.transform.position, muzzle.transform.forward * 30);
        if (Physics.Raycast(tree.gameObject.transform.position, tree.gameObject.transform.forward, out hitInfo, 30.0f, mask))
        {
            //Debug.Log("hit!");
            if(hitInfo.transform.gameObject != null)
            tree.SetValue("HitObject", hitInfo.transform.gameObject);
            
            return NodeResult.SUCCESS;
        }
        else
        {

            if (tree.GetValue("Line") != null)
            {
                LineRenderer g = (LineRenderer)tree.GetValue("Line");//get boid object 
                g.positionCount = 0;// get line renderer component of this object 
                
            }
            return NodeResult.RUNNING;
        }
    }

    public override void Reset()
    {
        mask = (LayerMask)tree.GetValue("Mask");
        base.Reset();
    }
}
