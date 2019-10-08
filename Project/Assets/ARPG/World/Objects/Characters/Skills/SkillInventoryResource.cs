using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    [System.Serializable]
    public class SkillInventoryPersistence
    {
        private SkillInventoryResource _resource;
        
        [SerializeField]
        private List<ActiveSkillPersistence> _basicSkills;

        public List<ActiveSkillPersistence> Basics
        {
            get
            {
                return _basicSkills;
            }
        }



        [SerializeField]
        private List<ActiveSkillPersistence> _activeSkills;

        public List<ActiveSkillPersistence> Actives
        {
            get
            {
                return _activeSkills;
            }
        }



        [SerializeField]
        private List<PassiveSkillPersistence> _passiveSkills;

        public List<PassiveSkillPersistence> Passives
        {
            get
            { 
                return _passiveSkills;
            }
        }



        public SkillInventoryPersistence(SkillInventoryResource resource)
        {
            _resource = resource;

            _basicSkills = new List<ActiveSkillPersistence>();
            _activeSkills = new List<ActiveSkillPersistence>();
            _passiveSkills = new List<PassiveSkillPersistence>();

            foreach (var skill in resource._simpleSkills)
            {
                if (skill == null)
                    continue;

                _basicSkills.Add(skill.Create());
            }
            foreach (var skill in resource._activeSkills)
            {
                if (skill == null)
                    continue;

                _activeSkills.Add(skill.Create());
            }

            foreach (var skill in resource._passiveSkills)
            {
                if (skill == null)
                    continue;

                _passiveSkills.Add(skill.Create());
            }
        }

    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Actions/Skill Inventory")]
    public class SkillInventoryResource : ScriptableObject
    {
        // Things like switching character, basic attack basic heal ..etc
        [SerializeField]
        public ActiveSkillResource[] _simpleSkills;

        [SerializeField]
        public ActiveSkillResource[] _activeSkills;

        [SerializeField]
        public PassiveSkillResource[] _passiveSkills;

        public SkillInventoryPersistence CreatePersistence()
        {
            return new SkillInventoryPersistence(this);
        }

    }
}
