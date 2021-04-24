using UnityEngine;

[CreateAssetMenu]
public class LootDescription : ScriptableObject
{
    [SerializeField] private DropProbabilityPair[] drops;

    public void SetDrops(params DropProbabilityPair[] drops)
    {
        this.drops = drops;
    }

    public Drop SelectDropRandomly()
    {   
        float rnd = Random.value;
        
        for (int i = 0; i < drops.Length; i++)
        {
            DropProbabilityPair pair = drops[i];

            if (rnd < pair.Probability)
            {
                return pair.Drop;
            }
            else
            {
                rnd -= pair.Probability;
            }
        }
        return null;
    }
}

[System.Serializable]
public struct DropProbabilityPair
{
    public Drop Drop;

    [Range(0, 1)]
    public float Probability;
}
