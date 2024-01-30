using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementBehaviour
{
    public void Rotate(Vector2 rotation);
    public void Move();
    public void Move(Vector3 dir);
    public void Move(Vector3 dir, float speed);
    public void SetDir(Vector3 dir);
    public void SetSpeed(float speed);
    public void Jump();
    public void JumpReset();
    public void SpeedCap();
}
