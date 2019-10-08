using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


// TODO scale amounts based on size
namespace Cirrus.ARPG.World.Objects.Characters.Progression
{
    [System.Serializable]
    public class Tier
    {
        [HideInInspector]
        public string Name;

        [Header("0: Free, 1: full reward size required.")]
        [Range(0, 1)]
        public float Requirement;

        [Header("If percentage option checked, the amount of gem is based on percentage completion of the tier.")]
        public bool IsExpPercent;
        public int Experience = 0;

        public bool IsGemPercent;
        public int Gems = 0;

        [SerializeField]
        public List<Items.Collectibles.CollectibleResource> _collectibles;

        [SerializeField]
        public List<GameObject> _droppedCollectibles;
    }

    public class Reward : MonoBehaviour
    {
        [Header("Tiers should be of increasing sizes.")]
        [SerializeField]
        [Range(0, 1)]
        public float Size;

        [SerializeField]
        private Tier[] _tiers;
    
        public bool Claim(BaseObject source, BaseObject recipient)
        {
            // Find the best suited tier
            Tier candidate = null;
            int idx = 0;
            for (int i = 0; i < _tiers.Length; i++)
            {

                if (Size > _tiers[i].Requirement)
                {
                    idx = i;
                    candidate = _tiers[i];
                }
                else
                {
                    // No reward
                    return false;
                }
            
            }

            // candidate
            if (candidate.IsExpPercent)
            {
                float res1 = Size - _tiers[idx].Requirement;
                float res2 = _tiers[idx + 1].Requirement - _tiers[idx].Requirement;

                float perc = res1 / res2;
                //TODO clamp?? no greater thantiers
            }


            return true;

        }



        ///////////////////////////////////////////////


        private float _reorderDelay = .2f;


        private void OnValidate()
        {
            CancelInvoke("Reorder");
            Invoke("Reorder", _reorderDelay);
         }

        private void Reorder()
        {
            _tiers = _tiers.OrderBy(x => x.Requirement).ToArray();
            Tier prev = null;
            int count = 1;
            foreach (Tier tier in _tiers)
            {
                tier.Name = $"Tier {count}";
                count++;

                if (prev != null)
                {
                    Debug.Assert(tier.Gems >= prev.Gems, "Gems amount must be in increasing order of tier.");
                    Debug.Assert(tier.Experience >= prev.Experience, "Experience amount must be in increasing order of tier.");
                    prev = tier;
                }
            }
        }

    } 

}
