from BaseClasses import MultiWorld, Region, Entrance, Location
from .Locations import PasspartoutLocation, location_table, act1_loc, act2_loc, act3_loc



def create_regions(world: MultiWorld, player: int) -> None:

    
    menu = Region("Menu", player, world)

    reg1 = Region("Act I", player, world)
    reg1.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg1) for loc_name in act1_loc]

    reg2 = Region("Act II", player, world)
    reg2.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg2) for loc_name in act2_loc]

    reg3 = Region("Act III", player, world)
    reg3.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg3) for loc_name in act3_loc]
    reg3.locations.append(PasspartoutLocation(player, "End", None, reg3))

    menu_to_act1 = Entrance(player, "Enter Act I", menu)
    menu.exits.append(menu_to_act1)
    menu_to_act1.connect(reg1)

    act1_to_act2 = Entrance(player, "Enter Act II", reg1)
    reg1.exits.append(act1_to_act2)
    act1_to_act2.connect(reg2)

    act2_to_act3 = Entrance(player, "Enter Act III", reg2)
    reg2.exits.append(act2_to_act3)
    act2_to_act3.connect(reg3)

    world.regions += [menu, reg1, reg2, reg3]

    #regMen = Region("Menu", player, world)
    #regMen.exits.append(Entrance(player, "GameStart", regMen))
    #world.regions.append(regMen)

    #reg1 = Region("Act I", player, world)
    #reg1.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg1) for loc_name in act1_loc]
    #reg1.exits.append(Entrance(player, "Enter Act II", reg1))
    #world.regions.append(reg1)

    #reg2 = Region("Act II", player, world)
    #reg2.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg2) for loc_name in act2_loc]
    #reg2.exits.append(Entrance(player, "Enter Act III", reg2))
    #world.regions.append(reg2)

    #reg3 = Region("Act III", player, world)
    #reg3.locations += [PasspartoutLocation(player, loc_name, location_table[loc_name], reg3) for loc_name in act3_loc]
    #reg3.locations.append(PasspartoutLocation(player, "End", None, reg3))
    #world.regions.append(reg3)

    #world.get_entrance("GameStart", player) \
    #    .connect(world.get_region("Act I", player))

    #world.get_entrance("Enter Act II", player) \
    #    .connect(world.get_region("Act II", player))

    #world.get_entrance("Enter Act III", player) \
    #    .connect(world.get_region("Act III", player))