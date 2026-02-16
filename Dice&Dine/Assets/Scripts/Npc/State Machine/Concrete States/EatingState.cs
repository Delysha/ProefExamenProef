using System.Collections;
using UnityEngine;

public class EatingState : State
{
    private MonoBehaviour _monoBehaviour;
    private int _delay = 3;
    public EatingState(Customer customer, StateMachine stateMachine, MonoBehaviour monoBehaviour) : base(customer, stateMachine)
    {
        _monoBehaviour = monoBehaviour;
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("EatingState");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(!Input.GetKeyDown(KeyCode.Space)) return;
        _monoBehaviour.StartCoroutine(OrderReceived());
    }

    private IEnumerator OrderReceived()
    {
        yield return new WaitForSeconds(_delay);
        var sprite = customer.GetComponent<SpriteRenderer>();
        sprite.color = Color.green;
        customer.StateMachine.ChangeState(customer.WalkState);
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log(customer.money);
    }
}
