# Game of Life 🦠

## 📌 Description
A **C# implementation** of the classic **Conway's Game of Life**, a zero-player cellular automaton where cells evolve based on simple rules. This project demonstrates how initial configurations change over time based on a set of survival conditions. You can read more about it on [Wikipedia](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life).

## 🔧 Features
- 🎨 **Grid-based visualization** of cell generations.
- 🕹️ **Interactive controls** to start, pause, and reset the simulation.
- ⚙️ **Customizable settings** for grid size and simulation speed.
- 🔄 **Automatically updates each generation** based on Conway's rules:
  - Any live cell with **fewer than two** live neighbors **dies** (underpopulation).
  - Any live cell with **two or three** live neighbors **survives**.
  - Any live cell with **more than three** live neighbors **dies** (overpopulation).
  - Any dead cell with **exactly three** live neighbors **becomes alive** (reproduction).
