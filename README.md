# 🏗️ **Procedural Tower Builder – Touch to Create & Collapse**  
**Assignment 3 – CS4046: Game Design & Development**  
**Developed by Talha Tofeeq ✨**

---

## 📱 **Project Overview**  
Welcome to **Procedural Tower Builder**, a thrilling mobile game where players stack swinging blocks to build the highest and most stable tower! However, the challenge is real: If the tower tilts too much, it will collapse. 🌪️  

This project is developed for **Assignment 3** under the supervision of **Saba Ghani** at **FAST-NUCES**.

---

## 🎮 **Gameplay Features**

### 🖐️ **Touch Input & Raycasting**  
- **Mobile Support**: Players can tap the screen to drop blocks (using `Input.GetTouch(0)`).
- **Editor Support**: For easy testing in Unity Editor, mouse clicks are used for block placement.

### 🧱 **Swinging Block Mechanic**  
- The blocks swing left and right before the player taps to drop them.
- **Precision** is key! Players need to time their taps perfectly to stack blocks.

### 🎨 **Procedural Block Variations**  
- **Randomized Sizes**: Each block has a unique size.
- **Vibrant Colors**: Blocks come in different bright and lively colors, adding variety and fun!

### 🌀 **Physics-Based Sway**  
- Blocks are equipped with **Rigidbody physics** for realistic movement.
- The **swaying increases** as the tower gets taller, adding an extra layer of challenge.

### ⚡ **Perfect Placement Detection**  
- **Perfect Stack Bonus**: If a block lands perfectly on the previous one, a special "Perfect Placement" message is displayed! 🎯

---

## 🏆 **Score Tracking & Game Over Mechanic**

### 📊 **Live Score Updates**  
- **Score System**: Players earn points with each successfully placed block.
- **TextMeshPro UI**: The current score is displayed live as the game progresses.

### ☠️ **Game Over Mechanic**  
- **Tilt Limit**: If the tower tilts beyond 30°, the tower collapses.
- **Slow-Motion Effect**: A dramatic slow-motion effect is triggered during the collapse to heighten the tension.

---

## 🔁 **Replay Button**  
After a game over, players can instantly retry with a **single tap**, allowing them to immediately challenge themselves again and improve their skills.

---

## 🎥 **Camera Follow System**  
The camera smoothly follows the growing tower, ensuring players always have a clear view of their creation from below. The higher the tower, the further the camera moves upwards.

---

### **Technologies Used**  
- **Unity** for game development.
- **C#** for scripting mechanics and physics.
- **TextMeshPro** for UI display.

---

## 🚀 **Future Enhancements**  
- **Multiplayer Mode**: Compete with friends to see who can build the tallest tower.
- **Level Difficulty**: Introduce new block types, obstacles, and challenges as the player progresses.

---

### **How to Run the Project**  
1. Clone the repository.
2. Open the project in Unity.
3. Press Play to start building your tower.

---
