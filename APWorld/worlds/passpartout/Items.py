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
    "$250": ItemData("Money", 6455004, ItemClassification.filler, 35),
    }