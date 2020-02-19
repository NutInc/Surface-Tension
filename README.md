# Surface Tension
Created by Holmium67

## Description
When the nuclear warhead in the site is detonated and not everyone is dead yet, this plugin will wait a given amout of time and then start ticking their health down until they die. All times are configurable and damage is configurable. Damage can either be by number or percent.

## Config Settings
Config Setting | Config Type | Default Value | Description
:---: | :---: | :---: | :------
st_enable | bool | true | Enables/Disables the plugin.
st_enable_delay | bool | true | Enables/disables having to wait between the nuke going off and the damaging of players.
st_delay_time | float | 90f | Time (in seconds) to wait after the nuke is detonated before damaging players.
st_damage | int | 1 | Amount of damage to deal to players.
st_time_between_dmg | float | 1f | Time (in seconds) to wait in between dealing damage to players.
st_is_damage_type_percent | bool | true | Changes what the damage type is set as. True treats the value passed in st_damage as % of max health, False treats the the damage as normal HP.

