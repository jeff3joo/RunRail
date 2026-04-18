# RunRail - 3D Endless Runner Game

A fast-paced 3D endless runner inspired by *Subway Surfers*, built using Unity and C#. The game focuses on core gameplay mechanics such as lane switching, obstacle avoidance, procedural track generation, and score progression.
## Controls

### Keyboard
* **Move Left** → `A` / `←`
* **Move Right** → `D` / `→`
* **Jump** → `Space` / `W` / `↑`
* **Pause** → `Esc`

### Swipe Input
* **Swipe Left/Right** → Change lanes
* **Swipe Up** → Jump

## Core Systems & Scripts
### PlayerController.cs

Handles all player-related mechanics:

* Continuous forward movement
* 3-lane switching system
* Physics-based jumping using Rigidbody
* Collision detection with obstacles
* Game over trigger and high score saving
* Dynamic speed scaling based on distance

### Platform & Level System
#### Platform.cs
* Spawns obstacles dynamically 2 per platform
* Uses object pooling for performance optimization
* Recycles platforms when out of view

#### PlatformSpawner.cs
* Manages procedural track generation
* Maintains platform queue
* Controls spawn positions and sequencing

### ObjectPool.cs
* Reuses GameObjects instead of instantiating/destroying
* Reduces garbage collection spikes
* Improves runtime performance for endless gameplay

### CameraFollower.cs
* Smoothly follows player movement
* Locks horizontal axis for consistent framing
* Maintains vertical offset

### UI & Game Flow
#### UIManager.cs
* Displays score and high score
* Updates score based on distance traveled
* Persists high score using PlayerPrefs

#### MainMenu.cs
* Handles scene loading
* Play and Quit functionality

#### Events.cs
* UI button interactions
* Restart, pause/resume, and navigation

### SwipeManager.cs
* Detects touch gestures
* Converts swipe input into movement actions

## Gameplay Mechanics
### Movement
* Constant forward motion
* Lane-based movement (-1, 0, +1)
* Smooth transitions using interpolation

### Jump System
* Physics-based jump using impulse force
* Ground detection via raycasting
* Integrated with animation system

### Score System
* Score increases based on distance traveled
* Game speed increases every 100 units
* Speed capped for balance
* High score saved locally

### Obstacle System
* Random obstacle spawning per platform
* Multiple obstacle types supported
* Collision triggers game over

## Technical Highlights
* Procedural environment generation using chunk-based system
* Object pooling for optimized performance
* Modular architecture (separation of concerns)
* Input abstraction (keyboard + touch support)
* Scalable system design for future features

## Asset Usage
* Simple train tract - Polyler
* Low Poly Wooden Crate - Aegis77

## Known Issues
* Lane transition speed may need tuning based on gameplay feel
* Ground detection depends on correct layer assignment
* Minor clipping may occur at high speeds

## Future Improvements
* Add power-ups (e.g., speed boost, magnet)
* Improve animations and character model
* Add sound effects and background music
* Enhance UI responsiveness for mobile devices
* 

## Summary

RunRail demonstrates core endless runner mechanics including procedural level generation, responsive controls, and optimized performance systems. The project focuses on clean architecture and scalable design over visual complexity.
