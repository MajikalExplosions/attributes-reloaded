using MBOptionScreen.Settings;
using MBOptionScreen.Attributes;
using MBOptionScreen.Attributes.v2;

namespace AttributesReloaded
{
    public class Config : AttributeSettings<Config>
    {
        public override string Id { get; set; } = "Igmat.AttributesReloaded_v1";
        public override string ModName => "Attributes Reloaded";
        public override string ModuleFolderName => "AttributesReloaded";

        [SettingPropertyGroup("Vigor", order: 0)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Melee Damage", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much more damage you deal in melee for each Vigor point", RequireRestart = false)]
        public float melee_bonus_dmg { get; set; } = 0.025f;

        [SettingPropertyGroup("Vigor", order: 0)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Melee Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much faster you are in melee for each Vigor point", RequireRestart = false)]
        public float melee_bonus_speed { get; set; } = 0;

        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Range Damage", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much more damage you deal in range for each Control point", RequireRestart = false)]
        public float rng_bonus_dmg { get; set; } = 0;
        
        [SettingPropertyGroup("Control", order: 1)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Range Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much faster you are in range for each Control point", RequireRestart = false)]
        public float rng_bonus_speed { get; set; } = 0.025f;
        
        [SettingPropertyGroup("Endurance", order: 2)]
        [SettingPropertyFloatingInteger(displayName: "Bonus HP", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much more HP you get for each Endurance point", RequireRestart = false)]
        public float bonus_hp { get; set; } = 0.025f;
        
        [SettingPropertyGroup("Endurance", order: 2)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Move Speed", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much faster you move for each Endurance point", RequireRestart = false)]
        public float bonus_movespeed { get; set; } = 0.01f;
        
        [SettingPropertyGroup("Cunning", order: 3)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Attribute Effects", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much better your attributes work for each Cunning point", RequireRestart = false)]
        public float attribute_effects { get; set; } = 0.05f;
        
        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Persuation", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much higher your change to persuade for each Social point", RequireRestart = false)]
        public float bonus_persuade { get; set; } = 0.01f;
        
        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyFloatingInteger(displayName: "Bonus Party Size", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much bigger your party size limit for each Social point", RequireRestart = false)]
        public float bonus_partysize { get; set; } = 0.025f;
        
        [SettingPropertyGroup("Social", order: 4)]
        [SettingPropertyBool(displayName: "Include bonuse Party Size from Companions", HintText = "Enable this to include Social points from your Companions to calculate bonus party size", RequireRestart = false)]
        public bool party_size_from_all_heroes { get; set; } = true;
        
        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger(displayName: "Bonus XP", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much more XP you get for each Intelligence point", RequireRestart = false)]
        public float bonus_xp { get; set; } = 0.1f;
        
        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger(displayName: "Increase Income", minValue: 0f, maxValue: 1f, valueFormat: "#0.0%", HintText = "How much more gold you get for each Intelligence point", RequireRestart = false)]
        public float bonus_income { get; set; } = 0.01f;

        [SettingPropertyGroup("Intelligence", order: 5)]
        [SettingPropertyFloatingInteger(displayName: "Decrease Expenses", minValue: 0f, maxValue: 0.1f, valueFormat: "#0.0%", HintText = "How much less gold you spent for each Intelligence point", RequireRestart = false)]
        public float bonus_economy { get; set; } = 0.01f;

        [SettingPropertyGroup("Additional", order: 6)]
        [SettingPropertyBool(displayName: "Show info messages", HintText = "Enable this to see how much bonuses you get from attributes", RequireRestart = false)]
        public bool enable_messages { get; set; } = false;
    }
}
