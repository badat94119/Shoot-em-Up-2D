using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int KillScore { get; private set; }

    [SerializeField]
    private EnemyBaseAttributes _baseAttributes;

    private void Awake()
    {
        SetAttributeModifier(1);
    }

    public void SetAttributeModifier(float modifier)
    {

        KillScore = Mathf.RoundToInt(_baseAttributes.KillScore * modifier);
    }
}
