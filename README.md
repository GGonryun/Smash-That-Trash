## Smash That Trash!
![Game Screen](https://media.githubusercontent.com/media/GGonryun/Smash-That-Trash/master/Images/Image4.png?raw=true)
### Github Instructions: 
Download the project => Open the Executable folder and run the Techlaturge.exe file, you may also build it through Unity3D if you wish.

### Brief Description: 
In ‘Smash That Trash!’ the player must quickly clean up the incoming garbage that’s washed up ashore. Players must type the words that appear above the recycling bin as quickly as possible. Players can modify the dictionary to learn any specific vocabulary words. The Project was built in Unity3D using version 2018.3.8f1

### Learning Objectives:
- Teach the player how to type faster.
- Improve letter and word recognition.
- Learn vocabulary words and their definitions.
- Improve typing accuracy.

### Layouts: 
The entire game was built in the sample scene, we use a UIManager to alternate between the Game Start, Game, and GameOver screens. The various GUIs will be populated when their corresponding event is triggered. Game screen will be displayed when the game begins, Game Over will be displayed when the player runs out of health, and Game Start is only displayed when first opening the game.

#### Game Start Screen:
The Game Start screen describes the buttons required to play the game, along with a game start button.

#### Game Screen:
The Game screen will show the current wave number, health points remaining, and the user’s current targeting mode.

#### Game Over Screen:
This screen will display all the words you scored on the left hand side, along with all the score and definition on the right.
![GameOver](https://media.githubusercontent.com/media/GGonryun/Smash-That-Trash/master/Images/Image5.png?raw=true)

### Assets: 
Recycling Bin - Player (Windows)

Recyclable Materials: Beer Bottle, Can of Beans, Coffee Mug, Cola Bottle, Glass Jar, Large Box, Laundry Detergent, Milk Jug, NewsPaper, Paper Bag, Pizza Box, Soda Can, Spray Paint, Styrofoam Cup, Tuna Can, Water Bottle. Provided by: https://opengameart.org/content/topdown-tileset

Dictionary Provided by:  https://github.com/adambom/dictionary

Tile Set provided by: https://opengameart.org/content/topdown-tileset

Audio Provided by: https://www.zapsplat.com/author/zapsplat/

### Game Play: 
The primary object is to remove all incoming trash from the screen. Recyclable materials will spawn at the bottom of the map and slowly approach the player at the center of the screen. The player must type the words that appear above their name as quickly as possible, for each letter they get correct they will launch out a single red orb which will deal damage to the recyclables. The bigger the recyclable is and more durable, the longer it will take to destroy them. If enough recyclable materials reach the overflowing recycling bin then you will lose the game. Afterwards you will be displayed your accuracy and a short list of all the words you were able to type.

Players can freely switch targeting modes, they may select Closest, Furthest, and Random.

### How to Win: 
Players cannot win the game, the game gets progressively more difficult as time goes on, the game ends when a player runs out of health.
![How To Play](https://media.githubusercontent.com/media/GGonryun/Smash-That-Trash/master/Images/Image1.png?raw=true)

### How To Play:
Use the letter keys A-Z to type out the words above the character.

Use the space key to summon a new word!

Use the number keys 1-3 to select targeting modes.

### Known Bugs:
[View The Issue's Tab :)](https://github.com/GGonryun/Smash-That-Trash/issues)


![Game Play Screen Shot](https://media.githubusercontent.com/media/GGonryun/Smash-That-Trash/master/Images/Image6.png?raw=true)
### What’s Next?
##### Player selected dictionaries:
I would have prefered to allow players to select their own words, this way they can study all sorts of subjects.
##### Different spells:
The primary goal was to have a wizard shooting fireballs, icicles, and lightning bolts. Each projectile would have unique properties.
##### Multiplayer:
This feature would allow coaches, friends, or teachers to select which words to spawn and in what order.

This feature would also allow multiple people to participate at once, allowing classrooms to practice spelling, typing, and word recognition.
##### Clearer Interfaces:
The UI is currently lacking, I would have prefered a much more robust and well designed user interface.
##### Improved End Game Statistics:
Players should be able to review specific words more closely. This way they can analyze which letter combinations cause them the most trouble.

