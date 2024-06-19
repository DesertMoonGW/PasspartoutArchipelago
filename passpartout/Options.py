from Options import Choice, PerGameCommonOptions
from dataclasses import dataclass

class Goal(Choice):
    """
    What would you like your end goal to be? You can choose either:

    [0] Any Ending - Achieve any of the four endings.
    [1] Random Ending - Achieve a specific ending that is randomly selected.
    [2] All Endings - Achieve every ending once. Warning: This can take a while.
    """
    display_name = "Goal"
    option_any = 0
    option_ran = 1
    option_all = 2
    default = 0

@dataclass
class PasspartoutOptions(PerGameCommonOptions):
    goal: Goal