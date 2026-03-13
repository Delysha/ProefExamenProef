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

        var moneyTake = Random.Range(8, 12);
        customer.money -= moneyTake;
        MainEconomy.Instance.CustomerLeavesMoney(customer.money);
        _monoBehaviour.StartCoroutine(OrderReceived());
    }

    private IEnumerator OrderReceived()
    {
        customer.Satisfied();
        yield return new WaitForSeconds(_delay);
        customer.GetComponent<Component>().gameObject.SetActive(false);
    }

    public override void ExitState()
    {
        base.ExitState();
        customer._timer.StopWaiting();
    }
}
