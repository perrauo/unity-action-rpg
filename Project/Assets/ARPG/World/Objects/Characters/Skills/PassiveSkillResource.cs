using UnityEngine;
using System.Collections;
using Cirrus.Editor;
using Cirrus.ARPG.Items;
using Cirrus.ARPG.Actions;

namespace Cirrus.ARPG.World.Objects.Characters.Actions
{
    public class PassiveSkillPersistence : SkillPersistence
    {
        public PassiveSkillResource _resource;

        public PassiveSkillPersistence(PassiveSkillResource res)
        {
            _resource = res;
        }

        public override Sprite Icon => _resource.Icon;

        public override string Description => _resource._description.Text;

        public override string Name => _resource.name;

    }

    [CreateAssetMenu(menuName = "Cirrus/Objects/Characters/Actions/Passive Skill")]
    public class PassiveSkillResource : AssetSkill
    {
        public Sprite Icon;

        [SerializeField]
        public Description _description;

        [SerializeField]
        public string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public void OnValidate()
        {
            if (_name != null &&_name.Equals(""))
            {
                _name = name;
            }
        }

        public PassiveSkillPersistence Create()
        {
            return new PassiveSkillPersistence(this);
        }

    }
}
