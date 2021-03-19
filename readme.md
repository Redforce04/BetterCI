# Better Chaos Insurgency
### Adds Subclasses for Chaos Insurgency

This plugin is currently a work in progress, originally designed for synapsesl by Ace, and adapted for Exiled by Redforce04.

Configs:
|Type|Config Name|Description|Default Config|
|---|---|---|---|
|bool|IsEnabled|Whether or not the plugin is enabled.|true|
|int|ChaosCommanders|Amount of chaos to be spawned in as chaoscommanders each chaos spawn wave.|1|
|string|ChaosCommanderBroadcast|What to broadcast to someone once selected as a chaoscommander.|You have been selected as Chaos Commander|
|ushort|ChaosCommanderBroadcastTime|How long to broadcast the previous message to someone spawned in as a chaoscommander.|5|
|string|ChaosCommanderPrefix|Text that will appear above a person's name.|Chaos Commander|

Permissions:

|Permission Name|Usage|
---|---
|betterci.\*|All Permissions| 
|betterci.list|Allows Players to use the bci list command.|
|betterci.spawn|Allows Players to spawn and despawn players as a subclass.|

Commands:
|Command Name|Aliases|Description|Permission required|
|---|---|---|---|
|BetterCI|BCI|Base Command for subcommands.|none|
|BetterCI List|BCI L|Lists players spawned in as a subclass.|betterci.list / betterci.\*|
|BetterCI Spawn \[*class*\] \[*player*\]|BCI Spawn \[*class*\] \[*player*\]|Spawns a player as a subclass.|betterci.spawn / betterci.\*|
|BetterCI Despawn \[*player*\]|BCI Despawn \[*player*\]|Despawns a player who is a subclass.|betterci.spawn / betterci.\*|
