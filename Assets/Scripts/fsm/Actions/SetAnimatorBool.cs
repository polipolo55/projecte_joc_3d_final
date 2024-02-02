
using UnityEngine;


namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Action/SetAnimationBool")]
    public class SetAnimatorBool : Action
    {
        public string propertyName;
        public bool value;
        public override void Act(StateController controller)
        {
            controller.GetComponent<Animator>().SetBool(propertyName, value);
        }
    }
}
