# Attributes Reloaded

This mods aims to add more sense to Attributes (Vigor, Control, Endurance, Cunning, Social, Intelligence), so they affect more parts of gameplay than just learning rate and limits of respective skills

## Features
1. All attributes now provide additional bonuses:  
   **VIGOR:** increase melee damage (default: **2.5%** per attribute) and attack speed (default: **0.0%** per attribute)  
   **CONTROL:** increase range damage (default: **0.0%** per attribute) and attack speed (default: **2.5%** per point)  
   **ENDURANCE:** increase HP (default: **2.5%** per attribute) and move speed (default: **1.0%** per attribute)  
   **CUNNING:** increase effects of other attributes (default: **5.0%** per attribute)  
   **SOCIAL:** increase party size (default: **2.5%** per attribute) and persuade chance (default: **1.0%** per attribute). Party size could be also affected by companions (default: **true**).  
   **INTELLIGENCE:** increase learning rate __*__ of all skills (default: **10.0%** per attribute), increase clan total income (default: **1.0%** per attribute) and decrease clan total expenses  (default: **1.0%** per attribute)  
2. All this bonuses correctly shown in your **Character Window** upon selecting specific attribute
3. Size of bonuses can be adjusted through in-game menu (thanks to [MCM](https://www.nexusmods.com/mountandblade2bannerlord/mods/612)). Defaults were selected to be as balanced as possible, but I assumed my set of mods and in your case you might want to have different values.  
   **NOTE:** be carefull, because the bigger values you select, the bigger difference between low-level and high-level characters is (including all NPC's and even troops)
4. Companions, lords and even regular troops affected as well
5. Regular troops are patched to have reasonable attributes (and not zeros) to receive bonuses from this new mechanic  
   **NOTE:** patching is made in memory, so it should be compatible with any mod that adds new troops  
   **NOTE 2:** it probably could be great feature for playing with [Distinguished Service](https://www.nexusmods.com/mountandblade2bannerlord/mods/1101), but I haven't tested it yet
6. **ALL** NPC's have at least 2 points in each attribute (similar to Player)

## TODO:
- [ ] Adjust learning rate numbers in UI so it reflects effect of INT attribute
- [x] ~~Show explanation for party size in party screen~~
- [ ] Improve algorithm for assigning base attributes for regular troops (now it's linear and considers only highest skill level)
- [ ] Add API for translations
- [ ] Support [Summarize Cashflow](https://www.nexusmods.com/mountandblade2bannerlord/mods/505)
- [ ] Invent something more interesting for **VIGOR**, **CONTROL**, **ENDURANCE**, **SOCIAL** attributes like I made for **CUNNING** and **INTELLIGENCE**. BTW, ideas are highly appreciated;) 

## In Addition:
 - Big thanks to [8thor8](https://www.nexusmods.com/mountandblade2bannerlord/users/3969384) with his mod [Attributes Matter](https://www.nexusmods.com/mountandblade2bannerlord/mods/1374), which inspired me to adjust his original idea to this state
 - Visit github page of this mod if you want collaborate in developing