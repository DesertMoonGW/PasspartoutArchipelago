# world/mygame/__init__.py

import settings
import typing
from .Options import PasspartoutOptions  # the options we defined earlier
from .Items import item_table, PasspartoutItem  # data used below to add items to the World
from .Locations import location_table, act1_loc, PasspartoutLocation  # same as above
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
    game = "Passpartout"  # name of the game/world
    options_dataclass = PasspartoutOptions  # options the player can set
    options: PasspartoutOptions  # typing hints for option results
    topology_present = True  # show path to required location checks in spoiler
    base_id = 6455000

    # The following two dicts are required for the generation to know which
    # items exist. They could be generated from json or something else. They can
    # include events, but don't have to since events will be placed manually.
    item_name_to_id = {name: data.code for name, data in item_table.items()}
    location_name_to_id = {name: data.code for name, data in location_table.items()}

def create_regions(self):
        # Create Vanilla Regions
        menu_region = Region("Menu", self.player, self.multiworld)
        self.multiworld.regions.append(menu_region)

        act1_region = Region("Act I", self.player, self.multiworld)
        act1_region.addlocations(act1_loc)
        self.multiworld.regions.append(act1_region)

        menu_region.connect(act1_region)

def create_item(self, item: str):
    item_data = item_table[item]
    itempass = PasspartoutItem(item, item_data.item_type, self.item_name_to_id[item], self.player)
    return itempass

def create_items(self):
    for item in map(self.create_item, item_table):
        self.multiworld.itempool.append(item)
        
def set_rules(self):
    self.multiworld.completion_condition[self.player] = lambda state: state.has("winor", self.player)

def fill_slot_data(self):
    return self.options.as_dict("goal")

def get_filler_item_name(self):
    return "Pride :)"