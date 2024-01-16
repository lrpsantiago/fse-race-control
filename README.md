# FSE Race Control Script

FSESS Compatibility: v11.0.0+

**WITH DYNAMIC WEATHER**

## SETUP
- Place the 4 LCDs and name them: "Race Main LCD", "Race Laps LCD", "Race Fastest Laps LCD",  "Race Speedtrap LCD";
- Place the "Start/Finish Sensor", and each of the checkpoint sensors: "Checkpoint Sensor 1", "Checkpoint Sensor 2";
- Place the "Pit Entry Sensor" and the "Pit Exit Sensor";
- Place the start lights and create a group for each of the countdown: "Start Lights 1", "Start Lights 2", ..., "Start Lights 5";
- Optionally you can have the green lights in a group called: "Start Lights Go";
- You can also have a LCD group called "Lap Counter LCDs" to display leader's lap count.

You can always have more or less checkpoints, start lights and laps, you just need to set this up on the script variables.

## ARGUMENT LIST
- FREE   => That's the Free Practice mode (default mode), it will let people to run freely and set lap times;
- RACE   => After the warmup time the light sequence will start and then start the race (limited by laps);
- QUALI  => (Work In Progress) It's not working yet, but this would order the racers by their fastest lap, instead of total lap times;
- FLAG_G => Set the current flag to Green (racers can run freely);
- FLAG_Y => Set the current flag to Yellow (racers can't overtake and all cars are limited to 45m/s);
- FLAG_R => Set the current flag to Red (it will force all the cars to brake instantly);
