using Unity.Mathematics;
using UnityEngine;

public class RewardVisualizer : MonoBehaviour
{
    [SerializeField] private RewardPanel rewardPanel;
    

    public void GeneratePanel(Transform target,float money)
    {
        rewardPanel.SetText(money);
        Instantiate(rewardPanel, target.position, quaternion.identity);
    }
}
