# unity-junior-gameplay-mechanics-prototype-4

## Screenshots

https://github.com/user-attachments/assets/f05d040c-e2be-4d1b-a2b1-efa3e4188a09

## Table of Contents
1. [Description](#description)
2. [Installation](#installation)
3. [Run](#run)
4. [Credits](#credits)
5. [Contributing](#contributing)
6. [License](#license)

## Description

This prototype is part of the Junior Programmer Pathway from Unity Learn. Its purpose is to teach the fundamentals of gameplay mechanics through scripting in C#.
Each prototype includes:
- A Learning section that guides you through building core features step by step.
- A Challenge section where you're given a broken or incomplete project to fix and extend, testing your understanding and problem-solving skills.

### Purpose

The objective of this prototype is to create two simple games:

- **Sumo Ball** : You play as a ball on a floating island, trying to push other balls off the platform using movement and power-ups. Outlast your opponents to win!
- **Score** : In this game, you're a ball guarding a goal. Soccer balls appear and try to enter your goal—you must push them into the opposing goal instead!

#### Bonus Features (Sumo Ball) :

- Add a new more difficult type of enemy and randomly select which is spawned. 
- Create a new powerup that gives the player the ability to launch projectiles at enemies to knock them off (or something that automatically fires projectiles in all directions when the powerup is enabled).
- Create a new powerup that allows the player to hop up into the air and smash down onto the ground, sending any enemies nearby flying away from the player. Ideally, the closer an enemy is, the more it should be impacted by the smash.
- After a certain number of waves, program a mini “boss battle,” where the boss has some completely new abilities. For example, maybe the boss can fire projectiles at you, maybe it is extremely agile, or maybe it occasionally generates little minions that come after you.

#### Fixing problems (Score) : 

- Hitting an enemy sends it back towards you -> When you hit an enemy, it should send it away from the player.
- A new wave spawns when the player gets a powerup -> A new wave should spawn when all enemy balls have been removed.
- The powerup never goes away -> The powerup should only last for a certain duration, then disappear.
- 2 enemies are spawned in every wave -> One enemy should be spawned in wave 1, two in wave 2, three in wave 3, etc.
- The enemy balls are not moving anywhere -> The enemy balls should go towards the “Player Goal” object.
- The player needs a turbo boost -> The player should get a speed boost whenever the player presses spacebar - and a particle effect should appear when they use it .
- The enemies never get more difficult -> The enemies’ speed should increase in speed by a small amount with every new wave
  
## Controls

**Both Game**
| **Key** | **Action**              |
|:-------:|-------------------------|
| `W` or `↑`| Move forward          |
| `S` or `↓`| Move backward         |
| `A` or `←`| Rotate camero to left |
| `D` or `→`| Rotate camero to right|
| `ESCAPE`  | Return to menu        |

**In Score Game**
| **Key** | **Action**            |
|:-------:|-----------------------|
| `SPACE`  | Boost player velocity|


### Technologies used

- **Unity** – Version 6000.0.47f1
- **C#** – Used for gameplay scripting
  
### Challenges and Future Features

I encountered several challenges, especially with implementing bonus features like the "smash up" mechanic. It was difficult to manage the ball's movement, deciding when it should go up or come back down required the correct use of a coroutine.
Another tricky part was implementing the auto projectile feature. Initially, I struggled with firing the projectile in the correct direction from the player. I later learned that the solution involved calculating a direction vector, normalizing it, and then using Quaternion.LookRotation to set the correct rotation for the projectile.

## Installation

You can download pre-built releases for your supported operating system from the GitHub Releases page. Available builds include:
- macOS
- Windows
- Linux

## Run

To run the program, simply double-click the executable file for your operating system.

### MacOS

Unzip and open the .app file.

### Windows

Unzip and double-click the .exe file.

### Linux

```bash
chmod +x Prototype_4_Linux.x86_64
./Prototype_4_Linux.x86_64
```

### Web

Play on [browser](https://vpekdas.github.io/unity-junior-gameplay-mechanics-prototype-4)

## Credits

This project is based on the Unity **Junior Programmer Pathway** by Unity Learn.
Many thanks to the instructors for their excellent step-by-step video tutorials and guidance.

## Contributing

To report issues, please create an issue here:  [issue tracker](https://github.com/Vpekdas/unity-junior-sound-and-effects-prototype-4/issues).

If you'd like to contribute, please follow the steps outlined in [CONTRIBUTING.md](CONTRIBUTING.md).

## License

This project is licensed under the [MIT License](LICENSE).
