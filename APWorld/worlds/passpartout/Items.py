import typing
from BaseClasses import MultiWorld, Item, ItemClassification
from worlds.AutoWorld import World

class PasspartoutItem(Item):  # or from Items import MyGameItem
    game = "Passpartout"  # name of the game/world this item is from

class ItemData(typing.NamedTuple):
    category: str
    code: int
    item_type: ItemClassification = ItemClassification.filler
    max_quantity: int = 1
    
item_table: typing.Dict[str, ItemData] = {
    "Progressive Fame": ItemData("Fame", 6455001, ItemClassification.progression, 8),
    "Spray Can Tool": ItemData("Tool", 6455002, ItemClassification.useful),
    "Caligraphy Pen Tool": ItemData("Tool", 6455003, ItemClassification.useful),
    "$50": ItemData("Money", 6455004, ItemClassification.filler, 5),
    "$100": ItemData("Money", 6455005, ItemClassification.filler, 5),
    "$150": ItemData("Money", 6455006, ItemClassification.filler, 5),
    "$200": ItemData("Money", 6455007, ItemClassification.filler, 3),
    "$250": ItemData("Money", 6455008, ItemClassification.filler, 3),
    "$500": ItemData("Money", 6455009, ItemClassification.filler, 3),
    "$750": ItemData("Money", 6455010, ItemClassification.filler, 3),
    "$1000": ItemData("Money", 6455011, ItemClassification.filler, 3),
    "$1500": ItemData("Money", 6455012, ItemClassification.filler),
    "$2000": ItemData("Money", 6455013, ItemClassification.filler),
    "$2500": ItemData("Money", 6455014, ItemClassification.filler),
    "$5000": ItemData("Money", 6455015, ItemClassification.filler),
    "$7500": ItemData("Money", 6455016, ItemClassification.filler),
    }