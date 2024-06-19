import typing
from BaseClasses import Location
from worlds.AutoWorld import World

class PasspartoutLocation(Location):  # or from Locations import MyGameLocation
    game = "Passpartout"  # name of the game/world this location is in

class LocationData(typing.NamedTuple):
    category: str
    code: typing.Optional[int] = None

act1_loc = {
    "Act I - Painting Sale #1": LocationData("Act I", 6455000),
    "Act I - Painting Sale #2": LocationData("Act I", 6455001),
    "Act I - Painting Sale #3": LocationData("Act I", 6455002),
    "Act I - Painting Sale #4": LocationData("Act I", 6455003),
    "Act I - Painting Sale #5": LocationData("Act I", 6455004),
    "Act I - Painting Sale #6": LocationData("Act I", 6455005),
    }

location_table = {
    **act1_loc,
    }