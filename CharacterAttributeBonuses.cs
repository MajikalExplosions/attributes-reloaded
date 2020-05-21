using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace AttributesReloaded
{
    class CharacterAttributeBonuses
    {
        public CharacterAttributeBonuses(CharacterObject character)
        {
            this.character = character;
        }

        public float AttributeEffectMultiplier
        {
            get
            {
                return 1 + (this.isEnabled
                    ? this.config.attribute_effects * this.cunning
                    : 0);
            }
        }
        public float MeleeDamageMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.melee_bonus_dmg * this.vigor * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float MeleeSpeedMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.melee_bonus_speed * this.vigor * this.AttributeEffectMultiplier
                    :0;
            }
        }
        public float RangeDamageMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.rng_bonus_dmg * this.control * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float RangeSpeedMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.rng_bonus_speed * this.control * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float HPMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_hp * this.endurance * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float MoveSpeedMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_movespeed * this.endurance * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float PartySizeMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_partysize * this.social * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float PersuadeAddition
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_persuade * this.social * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float XPMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_xp * this.intelligence * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float IncomeMultiplier
        {
            get
            {
                return this.isEnabled
                    ? this.config.bonus_income * this.intelligence * this.AttributeEffectMultiplier
                    : 0;
            }
        }
        public float ExpensesMultiplier
        {
            get
            {
                var result = this.config.bonus_decreas * this.intelligence * this.AttributeEffectMultiplier;
                result = - (result < 1
                    ? result
                    : 1);
                return this.isEnabled
                    ? result
                    : 0;
            }
        }

        private Config config = Config.Instance;
        private CharacterObject character;
        private bool isEnabled
        {
            get
            {
                if (this.character.IsPlayerCharacter) return true;
                if (!this.character.IsHero && this.config.disable_troops) return false;
                if (this.character.IsHero)
                {
                    if (this.character.HeroObject.IsPlayerCompanion && this.config.disable_companions) return false;
                    if (!this.character.HeroObject.IsPlayerCompanion && this.config.disable_lords) return false;
                }
                return true;
            }
        }
        private int vigor { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Vigor); } }
        private int control { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Control); } }
        private int endurance { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Endurance); } }
        private int cunning { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Cunning); } }
        private int social { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Social); } }
        private int intelligence { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Intelligence); } }
    }
}
