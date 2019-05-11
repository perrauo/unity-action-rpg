using UnityEngine;
using System.Collections;

namespace Cirrus.ARPG.Objects.Characters
{
    public class Persistence : MonoBehaviour
    {
        [SerializeField]
        public Tags.Tag Tag;

        [SerializeField]
        public Attributes.AttributesPersistence Attributes;

        [SerializeField]
        public Controls.AI.AgentPersistence Agent;

        [SerializeField]
        public Items.InventoryPersistence Inventory;


        // TODO replace old unused values (after set)
        public void Set(Persistence persistence)
        {
            Attributes = persistence.Attributes;
            Agent = persistence.Agent;
            Inventory = persistence.Inventory;
        }
        
        public void OnValidate()
        {
            if (Attributes == null)
                Attributes = GetComponent<Attributes.AttributesPersistence>();

            if(Agent == null)
                Agent = GetComponent<Controls.AI.AgentPersistence>();

            if(Inventory == null)
                Inventory = GetComponent<Items.InventoryPersistence>();
        }

    }
}