#from .Options import PasspartoutOptions  # the options we defined earlier
from .Items import item_table, PasspartoutItem  # data used below to add items to the World
from .Locations import location_table, act1_loc, act2_loc, act3_loc, PasspartoutLocation  # same as above
from .Regions import create_regions
from worlds.generic.Rules import add_rule, set_rule, forbid_item, add_item_rule
from worlds.AutoWorld import World, WebWorld
from BaseClasses import Region, Location, Entrance, Item, ItemClassification, Tutorial

class PasspartoutWeb(WebWorld):
    theme = "partyTime"
    tutorials = [Tutorial(
        "Multiworld Setup Guide",
        "A guide to setting up the Passpartout integration for Archipelago multiworld games.",
        "English",
        "setup_en.md",
        "setup/en",
        ["DesertMoonGW"]
    )]
    

class PasspartoutWorld(World):
    """Passpartout is a game about drawing and selling art to pay the rent and eventually become famous!"""
    
    #options_dataclass = PasspartoutOptions  # options the player can set
    #options: PasspartoutOptions  # typing hints for option results
    game = "Passpartout"  # name of the game/world
    web = PasspartoutWeb()
    topology_present = True  # show path to required location checks in spoiler
    base_id = 6455000
    
    item_name_to_id = {name: data.code for name, data in item_table.items()}
    location_name_to_id = {name: data.code for name, data in location_table.items()}

    def create_regions(self) -> None:
        create_regions(self.multiworld, self.player)

            #menu_region = Region("Menu", self.player, self.multiworld)
            #self.multiworld.regions.append(menu_region)

            #act1_region = Region("Act I", self.player, self.multiworld)
            #act1_region.add_locations(act1_loc)
            #self.multiworld.regions.append(act1_region)

            #act2_region = Region("Act II", self.player, self.multiworld)
            #act2_region.add_locations(act2_loc)
            #self.multiworld.regions.append(act2_region)

            #act3_region = Region("Act III", self.player, self.multiworld)
            #act3_region.add_locations(act3_loc)
            #self.multiworld.regions.append(act3_region)

            #menu_region.connect(act1_region)
            #act1_region.add_exits({"Act II": "Enter Act II"}, {"Enter Act II": lambda state: state.has("Progressive Fame", self.player, 4)})
            #act2_region.add_exits({"Act III": "Enter Act III"}, {"Enter Act III": lambda state: state.has("Progressive Fame", self.player, 7)})
            #act3_region.locations.append(PasspartoutLocation(self.player, "End", None, act3_region))

    def create_item(self, item: str):
        item_data = item_table[item]
        return PasspartoutItem(item, item_data.item_type, item_data.code, self.player)

    def create_event(self, event: str):
        #fin_loc = PasspartoutLocation(self.player, "FIN", None)
        #fin_loc.place_locked_item(PasspartoutItem("FIN", ItemClassification.progression, None, self.player))
        return PasspartoutItem(event, ItemClassification.progression, None, self.player)

    def create_items(self):
        for name, data in item_table.items():
            self.multiworld.itempool += [self.create_item(name) for _ in range(0, data.max_quantity)]
        
    #def fill_slot_data(self):
    #    return self.options.as_dict("goal")

    def set_rules(self):
        set_rule(self.multiworld.get_entrance("Enter Act II", self.player),
             lambda state: state.has("Progressive Fame", self.player, 4))
        
        set_rule(self.multiworld.get_entrance("Enter Act III", self.player),
             lambda state: state.has("Progressive Fame", self.player, 7))
        
        set_rule(self.multiworld.get_location("End", self.player),
             lambda state: state.has("Progressive Fame", self.player, 8))

        self.multiworld.get_location("End", self.player).place_locked_item(self.create_event("FIN"))
        self.multiworld.completion_condition[self.player] = lambda state: state.has("FIN", self.player)