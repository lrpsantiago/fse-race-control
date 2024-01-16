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
- RACE   => After the warmup time the light sequence will start and then start the race limited by laps and with dynamic weather;
- QUALI  => (Work In Progress) It's not working yet, but this would order the racers by their fastest lap, instead of total lap times;
- FLAG_G => Set the current flag to Green (racers can run freely);
- FLAG_Y => Set the current flag to Yellow (racers can't overtake and all cars are limited to 45m/s);
- FLAG_R => Set the current flag to Red (it will force all the cars to brake instantly);

## VIRTUAL DYNAMIC WEATHER SYSTEM
It's a simple dynamic weather simulation to bring a bit of surprise to the races. It will work only in RACE mode, and currently there's no way to disable it. Every track can have its own initial Risk Of Rain (RoR) value, defined by the INITIAL_RISK_OF_RAIN variable (50% by default). Whenever the race leader crosses the start/finish line, it will either increase or decrease the RoR percentage randomly (from -4% to +8%). Once the RoR% reachs the 100% it will start a countdown defined by the WEATHER_CHANGE_TIME variable (in milliseconds), by default it's 10 seconds. When the countdown is over, the weather will change to RAIN and all slick tyres (ULTRA, SOFT, MEDIUM, HARD, EXTRA) will lose 50% of their current friction (which can be quite undrivable). The RoR percentage and the current weather are available to all drivers onboard, so they have to keep an eye to this in order to get the perfect timing to change tyres. For now, once it starts raining it will remain raining until the end of the race.
