import typing
from BaseClasses import MultiWorld, Item, ItemClassification
from worlds.AutoWorld import World

class PasspartoutItem(Item):  # or from Items import MyGameItem
    game = "Passpartout"  # name of the game/world this item is from

class ItemData(typing.NamedTuple):
    category: str
    code: int
    item_type: ItemClassification = ItemClassification.filler
    weight: typing.Optional[int] = None
    
item_table: typing.Dict[str, ItemData] = {
    "$50": ItemData("Money", 6455000, ItemClassification.filler, 64),
    "$100": ItemData("Money", 6455001, ItemClassification.filler, 32),
    "$250": ItemData("Money", 6455002, ItemClassification.filler, 16),
    "$500": ItemData("Money", 6455003, ItemClassification.filler, 8),
    "$1000": ItemData("Money", 6455004, ItemClassification.filler, 4),
    "$2500": ItemData("Money", 6455005, ItemClassification.filler, 2),
    "winor": ItemData("Progress", 6455006, ItemClassification.progression, 2),
    }