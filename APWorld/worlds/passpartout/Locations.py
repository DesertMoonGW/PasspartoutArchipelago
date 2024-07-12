import typing
from BaseClasses import Location
from worlds.AutoWorld import World

class PasspartoutLocation(Location):  # or from Locations import MyGameLocation
    game = "Passpartout"  # name of the game/world this location is in

class LocationData(typing.NamedTuple):
    category: str
    code: typing.Optional[int] = None

act1_loc: typing.Dict[str, LocationData] = {
    "Act I - Painting Sale #1": LocationData("Act I", 6455000),
    "Act I - Painting Sale #2": LocationData("Act I", 6455001),
    "Act I - Painting Sale #3": LocationData("Act I", 6455002),
    "Act I - Painting Sale #4": LocationData("Act I", 6455003),
    "Act I - Painting Sale #5": LocationData("Act I", 6455004),
    "Act I - Painting Sale #6": LocationData("Act I", 6455005),
    "Act I - Painting Sale #7": LocationData("Act I", 6455006),
    "Act I - Painting Sale #8": LocationData("Act I", 6455007),
    "Act I - Painting Sale #9": LocationData("Act I", 6455008),
    "Act I - Painting Sale #10": LocationData("Act I", 6455009),
    "Act I - Bills Paid #1": LocationData("Act I", 6455030),
    "Act I - Bills Paid #2": LocationData("Act I", 6455031),
    "Act I - Bills Paid #3": LocationData("Act I", 6455032),
    "Act I - Bills Paid #4": LocationData("Act I", 6455033),
    "Act I - Bills Paid #5": LocationData("Act I", 6455034),
    }

act2_loc: typing.Dict[str, LocationData] = {
    "Act II - Painting Sale #1": LocationData("Act II", 6455010),
    "Act II - Painting Sale #2": LocationData("Act II", 6455011),
    "Act II - Painting Sale #3": LocationData("Act II", 6455012),
    "Act II - Painting Sale #4": LocationData("Act II", 6455013),
    "Act II - Painting Sale #5": LocationData("Act II", 6455014),
    "Act II - Painting Sale #6": LocationData("Act II", 6455015),
    "Act II - Painting Sale #7": LocationData("Act II", 6455016),
    "Act II - Painting Sale #8": LocationData("Act II", 6455017),
    "Act II - Painting Sale #9": LocationData("Act II", 6455018),
    "Act II - Painting Sale #10": LocationData("Act II", 6455019),
    "Act II - Bills Paid #1": LocationData("Act II", 6455035),
    "Act II - Bills Paid #2": LocationData("Act II", 6455036),
    "Act II - Bills Paid #3": LocationData("Act II", 6455037),
    "Act II - Bills Paid #4": LocationData("Act II", 6455038),
    "Act II - Bills Paid #5": LocationData("Act II", 6455039),
    }

act3_loc: typing.Dict[str, LocationData] = {
    "Act III - Painting Sale #1": LocationData("Act III", 6455020),
    "Act III - Painting Sale #2": LocationData("Act III", 6455021),
    "Act III - Painting Sale #3": LocationData("Act III", 6455022),
    "Act III - Painting Sale #4": LocationData("Act III", 6455023),
    "Act III - Painting Sale #5": LocationData("Act III", 6455024),
    "Act III - Painting Sale #6": LocationData("Act III", 6455025),
    "Act III - Painting Sale #7": LocationData("Act III", 6455026),
    "Act III - Painting Sale #8": LocationData("Act III", 6455027),
    "Act III - Painting Sale #9": LocationData("Act III", 6455028),
    "Act III - Painting Sale #10": LocationData("Act III", 6455029),
    "Act III - Bills Paid #1": LocationData("Act III", 6455040),
    "Act III - Bills Paid #2": LocationData("Act III", 6455041),
    "Act III - Bills Paid #3": LocationData("Act III", 6455042),
    "Act III - Bills Paid #4": LocationData("Act III", 6455043),
    "Act III - Bills Paid #5": LocationData("Act III", 6455044),
    }

location_table = {
    **act1_loc,
    **act2_loc,
    **act3_loc,
    }