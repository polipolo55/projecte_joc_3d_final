using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/StopFleeing")]
    public class StopFleeing : Action
    {
        public float distanceTarget = 5f;
        public override void Act(StateController controller)
        {
            var mb = controller.GetComponent<IMovementBehaviour>();
            mb.MoveToPoint(controller.transform.position);
        }
    }
}
