using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cirrus.ARPG.World.Objects;
using Cirrus.ARPG.World.Objects.Characters;
using Cirrus.ARPG.Conditions;

using System.Linq;

namespace Cirrus.ARPG.Actions
{

    public class AssetEffect : ScriptableObject, IEffect
    {
        [System.Serializable]
        public class Conditions
        {
            [SerializeField]
            public List<AssetCondition> _globalConditions;

            [SerializeField]
            public List<AssetCondition> _sourceConditions;

            [SerializeField]
            public List<AssetCondition> _targetConditions;
        }

        [SerializeField]
        private Conditions _conditions;

        public IEnumerable<ICondition> GlobalConditions { get { return _conditions._globalConditions; } }



        public IEnumerable<ICondition> SourceConditions { get { return _conditions._sourceConditions; } }



        public IEnumerable<ICondition> TargetConditions { get { return _conditions._targetConditions; } }


        private bool Unconditional
        {
            get
            {
                return
                        GlobalConditions.Count() == 0 &&
                        SourceConditions.Count() == 0 &&
                        TargetConditions.Count() == 0;
            }
        }


        private bool Check(ICondition condition, BaseObject target)
        {
            return target.Verify(condition);
        }

        private bool Check(ICondition condition, Character target)
        {
            return target.Verify(condition);
        }

        //////////////////////////////////////////////



        //// 

        public bool TryApply(World.Objects.Actions.ActionProduct action)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }
            }

            DoApply(action);
            return true;
        }

        protected virtual void DoApply(World.Objects.Actions.ActionProduct action)
        {

        }


        ////


        public bool TryApply(World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }
            }

            DoApply(action, target);
            return true;
        }


        protected virtual void DoApply(World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            DoApply(action);
        }


        ////

        public bool TryApply(World.Objects.Actions.ActionProduct action, Character target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }
            }

            DoApply(action, target);
            return true;
        }

        protected virtual void DoApply(World.Objects.Actions.ActionProduct action, World.Objects.Characters.Character target)
        {
            DoApply(action, target as BaseObject);
        }

        ////


        public virtual bool TryApply(BaseObject source, World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }

                foreach (var cond in SourceConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, source))
                        return false;
                }
            }

            DoApply(source, action, target);
            return true;
        }

        protected virtual void DoApply(BaseObject source, World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            DoApply(action, target as BaseObject);
        }

        ////

        public virtual bool TryApply(World.Objects.Characters.Character source, World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }

                foreach (var cond in SourceConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, source))
                        return false;
                }
            }

            DoApply(source, action, target);
            return true;
        }

        protected virtual void DoApply(World.Objects.Characters.Character source, World.Objects.Actions.ActionProduct action, BaseObject target)
        {
            DoApply(source as BaseObject, action, target);
        }


        ////


        public virtual bool TryApply(World.Objects.Characters.Character source, World.Objects.Actions.ActionProduct action, World.Objects.Characters.Character target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }

                foreach (var cond in SourceConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, source))
                        return false;
                }
            }

            DoApply(source, action, target);
            return true;
        }

        protected virtual void DoApply(World.Objects.Characters.Character source, World.Objects.Actions.ActionProduct action, World.Objects.Characters.Character target)
        {
            DoApply(source as BaseObject, action, target);
        }

        ////


        public virtual bool TryApply(BaseObject source, World.Objects.Actions.ActionProduct action, World.Objects.Characters.Character target)
        {
            if (!Unconditional)
            {
                foreach (var cond in GlobalConditions)
                {
                    if (cond == null)
                        continue;

                    if (!cond.Verify())
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, target))
                        return false;
                }

                foreach (var cond in TargetConditions)
                {
                    if (cond == null)
                        continue;

                    if (!Check(cond, source))
                        return false;
                }
            }

            DoApply(source, action, target);
            return true;
        }

        protected virtual void DoApply(BaseObject source, World.Objects.Actions.ActionProduct action, World.Objects.Characters.Character target)
        {
            DoApply(source, action, target as BaseObject);

        }

    }
}
