# Surface Tension
Created by Holmium67

## Description
When the nuclear warhead in the site is detonated and not everyone is dead yet, this plugin will wait a given amout of time and then start ticking their health down until they die. All times are configurable and damage is configurable. Damage can either be by number or percent.

## Config Settings
Config Setting | Config Type | Default Value | Description
:---: | :---: | :---: | :------
is_enabled | bool | true | Enables/Disables the plugin.
delay_time | int | 90 | Time (in seconds) to wait after the nuke is detonated before damaging players. Set to 0 to disable.
damage_amount | int | 1 | Amount of damage to deal to players.
damage_interval | float | 1f | Time (in seconds) to wait in between dealing damage to players.
damage_as_percent | bool | true | Changes what the damage type is set as. True treats the value passed in st_damage as % of max health, False treats the the damage as normal HP.
