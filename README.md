# SCP-682
# What is it? | 这是啥？
This is a plugin for SCP: Secret Laboratory | 这是SCP:秘密实验室的插件
# plugin content | 插件内容
939-89 have chance to be scp682 when it spawn，682 has this abilities:
| 939-89出生时有几率变成SCP682，,682有以下技能：

682 can healing hp with time(can move)
| 682可以随时间回血（走路也能回）

682 can destroy door like 096
| 682可以像096一样拆门

682 can kill hunman one hit
| 682可以秒杀人类玩家

682 can eat human to healing hp with attacked
| 682每次攻击可以吃掉敌人来回血

PS:682 still blind because it use role.SCP939,682 has red rank SCP-682

PS:682仍旧是瞎子因为他用的是939模型，682有一个红色的头衔SCP-682表明身份

# How do I use it? | 我如何使用它？
download the dll from [here](https://github.com/cushaw1/SCPSL-scp682/releases/tag/1.3)
| 点击下载 [插件](https://github.com/cushaw1/SCPSL-scp682/releases/tag/1.3)

put it in the folder titled sm_plugins.
| 把插件放入sm_plugins文件夹内

set online_mode: true,because it use steamID
| 设置online_mode: true，因为插件使用了steamID

if you use scp_healing_duration,set scp682_maxhp <= scp939_89_hp

如果你使用了scp_healing_duration让scp们可以站立回血，请把scp682_maxhp的值设置小于scp939_89_hp的值

new config scp682_door_eat,if set true,scp682_door_chance will now work(682 can destroy one door after eat one human)

新的参数scp682_door_eat，如果设置为true，scp682_door_chance参数就没用了（682吃掉一个人后可用撞破一扇门）

# Config Options （English）
Config Option | Value Type | Default Value | Description
--- | :---: | :---: | ---
scp682_enable | Boolean | True | SCP-682 plugin enable/disable
scp682_door | Boolean | True | SCP-682 destroy door enable/disable
scp682_door_eat | Boolean | True | SCP-682 destroy door when 682 eated enable/disabl
scp682_kill | Boolean | True | SCP-682 kill player one hit enable/disable
scp682_spawn | Integer | 30 | 682 spawn probability(%)
scp682_door_chance| Integer | 100 | 682 destroy door probability(%)
scp682_maxhp | Integer | 2200 | 682 healing max hp(automatic heal and eat heal)
scp682_heal_hp | Integer | 5 | 682 automatic heal hp
scp682_heal_time | Integer | 1 | 682 automatic heal time(s)
scp682_eat_hp | Integer | 100 | 682 eat human heal hp

# 参数设置 （中文）
参数名 | 参数类型 | 默认值 | 注释
--- | :---: | :---: | ---
scp682_enable | 布尔值 | True | 开启/关闭插件
scp682_door | 布尔值 | True | 开启/关闭682破坏门功能
scp682_door_eat | Boolean | True | 开启/关闭682吃一个人撞一扇门功能
scp682_kill | 布尔值 | True | 开启/关闭682秒杀功能
scp682_spawn | 整数 | 30 | 682出生几率(%)
scp682_door_chance| 整数 | 100 | 682拆门几率(%)
scp682_maxhp | 整数 | 2200 | 682回血最大值（自动回血与吃人回血）
scp682_heal_hp | 整数 | 5 | 682自动回血值
scp682_heal_time | 整数 | 1 | 682每隔多长时间回血（秒）
scp682_eat_hp | 整数 | 100 | 682吃人回血值
