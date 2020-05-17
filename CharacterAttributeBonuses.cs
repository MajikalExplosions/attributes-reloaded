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

        public float AttributeEffectMultiplier { get { return 1 + this.config.attribute_effects * this.cunning; } }
        public float MeleeDamageMultiplier { get { return this.config.melee_bonus_dmg * this.vigor * this.AttributeEffectMultiplier; } }
        public float MeleeSpeedMultiplier { get { return this.config.melee_bonus_speed * this.vigor * this.AttributeEffectMultiplier; } }
        public float RangeDamageMultiplier { get { return this.config.rng_bonus_dmg * this.control * this.AttributeEffectMultiplier; } }
        public float RangeSpeedMultiplier { get { return this.config.rng_bonus_speed * this.control * this.AttributeEffectMultiplier; } }
        public float HPMultiplier { get { return this.config.bonus_hp * this.endurance * this.AttributeEffectMultiplier; } }
        public float MoveSpeedMultiplier { get { return this.config.bonus_movespeed * this.endurance * this.AttributeEffectMultiplier; } }
        public float PartySizeMultiplier { get { return this.config.bonus_partysize * this.social * this.AttributeEffectMultiplier; } }
        public float PersuadeAddition { get { return this.config.bonus_persuade * this.social * this.AttributeEffectMultiplier; } }
        public float XPMultiplier { get { return this.config.bonus_xp * this.intelligence * this.AttributeEffectMultiplier; } }
        public float IncomeMultiplier { get { return this.config.bonus_income * this.intelligence * this.AttributeEffectMultiplier; } }
        public float ExpensesMultiplier {
            get {
                var result = this.config.bonus_economy * this.intelligence * this.AttributeEffectMultiplier;
                return result > 1
                    ? - 1
                    : - result;
            } }

        private Config config = Config.Instance;
        private CharacterObject character;
        private int vigor { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Vigor); } }
        private int control { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Control); } }
        private int endurance { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Endurance); } }
        private int cunning { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Cunning); } }
        private int social { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Social); } }
        private int intelligence { get { return this.character.GetAttributeValue(CharacterAttributesEnum.Intelligence); } }
    }
}
