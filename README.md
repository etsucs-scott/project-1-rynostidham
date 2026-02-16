[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/2QC0Bpz-)
# CSCI 1260 — Project

## Project Instructions
All project requirements, grading criteria, and submission details are provided on **D2L**.  
Refer to D2L as the *authoritative source* for this assignment.

This repository is intentionally minimal. You are responsible for:
- Creating the solution and projects
- Designing the class structure
- Implementing the required functionality

---

This project implements a text‑based Adventure Game written in C#. The player navigates a maze, collects items, encounters monsters, and attempts to reach the exit.

--## To run game ##--
Open visual studios and run the Program.cs

--## Controls and Gameplay ##--
The player moves using W A S D 
W - Up
A - Left
S - Down 
D - Right 

Each turn shows 
- Player health
- Tile description 
- Items in inventory 
- Monsters on tile 
- Movement prompt 
- Battle results if applicable 

--## Battle System ##--
A battle begins when a player enters a tile with a monster. The player attacks first and then the monster attacks after if still alive. Combat continues until ether the player or the monsters hp reaches 0. Potions heal the player on pickup. 

--## How to win / lose ##-- 
Win - Reach the maze exit before health reaches 0 
lose - Player's health reaches zero during a battle 

--## UML Diagram --## 
The UML diagram is included as AdventureGameUML.png and includes all classes, interfaces, relationships, cardinality, and inheritance used in the project. 

--## Git Usage ##-- 
git clone
git pull
git add .
git commit -m
git push