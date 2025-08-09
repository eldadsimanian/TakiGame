# 🎯 TakiGame – Taki Card Game in C#

## 📖 Project Overview
TakiGame is a digital version of the popular Israeli card game Taki, developed in C# using Windows Forms.  
It includes a Player vs. Computer mode, a friendly graphical interface, and SQL database integration for saving a live high-score leaderboard 🏆.

The game fully implements all original Taki rules, including special cards and strategic mechanics, along with intelligent AI logic for the computer opponent.

### ✨ Key Features
- 🎮 **Full Taki Gameplay** – All original game rules implemented, including:

  - Stop 🛑  
  - Plus ➕  
  - Change Direction 🔄  
  - Open Taki 🎨  
  - Change Color 🌈  
  - Super Taki 💥  

- 🤖 **Player vs. AI** – The AI analyzes the current game state and its hand to make smart moves.

- 💾 **SQL Database Integration** – Stores player names and game times, displayed in a sorted leaderboard.

- 🖥 **User-Friendly Interface** – Includes instruction screens, a visual catalog of all cards, and a dynamic game board that updates in real time.

- 🧩 **Object-Oriented Design (OOP)** – Uses separate classes for game components:

  - Card, Deck, CardBox, Yad  
  - Custom Forms: Game, Instruction, ShowCards, AboutCards1-5, PutName, Leaderboard

- 🏆 **Live High Scores** – Automatically updated leaderboard after each game.

### 🛠 Technologies Used
- C#  
- Windows Forms  
- ADO.NET for database connectivity  
- OOP principles: encapsulation, inheritance, polymorphism  
- SQL Database (Db1.mdb)  

### 📂 System Architecture
- **Card Class** – Represents a single card (number, color, position, image).  
- **Deck Class** – Creates a complete 4×15 card matrix.  
- **CardBox Class** – Manages the game pile as a Stack<Card>.  
- **Yad Class** – Manages player/computer hands as linked lists.  

**Forms:**  
- Form1 – Main menu  
- Game – Main game screen  
- Instruction – How to play  
- ShowCards – Full card catalog  
- AboutCards – Special card explanations  
- PutName – Enter winner’s name  
- Leaderboard – High-score table  

### 🗄 Database Structure
**Table:** Scores  

| Column   | Description       |
| -------- | ----------------- |
| UserName | Winner’s name     |
| Points   | Game time in seconds |


## 📜 How to Run (For Players)

1. **Download the project:** Clone the repository or download the project files as a ZIP.  
2. **Open in Visual Studio:** Open the `Taki.sln` solution file in Visual Studio.  
3. **Database:** Ensure the database file `Db1.mdb` is in the correct project directory.  
4. **Launch:** Press the Start ▶️ button to run the game.

## 👨‍💻 Developer Setup

### Main Areas for Modification:

- **AI Logic:** Modify the `Comp()` method in `Game.cs` to change the computer's behavior.  
- **Graphics:** Customize the card visuals in the `PaintCard()` and `BackPaintCard()` methods within `Card.cs`.  
- **Leaderboard UI:** Adjust the design and functionality of the Leaderboard form.

### Development Goals:

- Strengthen OOP skills.  
- Practice using data structures: Stack, Linked List, Matrix.  
- Build an interactive UI.  
- Integrate with an external SQL database.

## 📸 Suggested Screenshots

- Main Menu  
- Game in progress  
- High-score leaderboard

## 💡 Possible Future Improvements

- 🌐 **Online Multiplayer Mode:** Transition from a client-side game to a client/server model.  
- 🎨 **Custom Card Themes:** Add options for different visual styles.  
- 📱 **Mobile Version:** Port the game to a mobile platform.  
- 📊 **Detailed Player Statistics:** Track more comprehensive game data.

---

> Built with passion, late nights, lots of coffee ☕, and a true love for Taki! 😄
