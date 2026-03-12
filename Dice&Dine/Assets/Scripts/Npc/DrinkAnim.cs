using UnityEngine;

public class DrinkAnim : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DrinkingChampagne()
    {
        _animator.SetBool("IsDrinkingChampagne", true);
    }

    public void DrinkingCocktail()
    {
        _animator.SetBool("IsDrinkingCocktail", true);
    }

    public void DrinkingWishkey()
    {
        _animator.SetBool("IsDrinkingWhishkey", true);
    }

    public void StopDrinking()
    {
        _animator.SetBool("IsNotDrinking", true);
    }
}
