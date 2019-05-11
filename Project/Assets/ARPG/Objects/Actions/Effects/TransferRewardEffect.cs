//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cirrus.Editor;

//namespace Cirrus.ARPG.Objects.Actions
//{
//    //TODO temporary vs permanet attributes

//    public class TransferRewardEffect : Effect
//    {
//        [SerializeField]
//        public bool IsNewReward = false;

//        [Header("This value should not be greater than number of rewards in target.")]
//        [SerializeField, Min(0)]
//        public int SourceNumber = 0;

//        [ConditionalHide("IsNewReward", false)]
//        [SerializeField, Min(0)]
//        public int DestinationNumber = 0;

//        [ConditionalHide("IsNewReward", true)]
//        [SerializeField]
//        public GameObject RewardPrefab = null;

//        [SerializeField]
//        public Numeric.Operation Operation;

//        public override void Apply(BaseObject target)
//        {
//            //Debug.Assert(effect.DestinationNumber < _rewards.Count, "Please make sure that the number of the reward to update is contained in the list.");
//            //Rewards.Reward reward = _rewards[effect.DestinationNumber];
//            //reward.Worth = effect.Operation.Process(reward.Worth);
//        }

//    }
//}
