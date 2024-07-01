# MenuConfigurationTouches

A Unity project that provides a configurable key binding menu using the Unity InputSystem.

## Features

- **Key Binding Menu**: Easily configurable key bindings through a dynamically generated menu.
- **InputSystem Integration**: Utilizes Unity's new InputSystem for handling input actions.
- **Dynamic UI**: The menu is automatically generated based on the input actions defined in the InputAction asset.

## Getting Started

### Prerequisites

- Unity 2022.3.17f1 (This project was created and tested with this version)
- Unity InputSystem package

### Installation

1. Clone the repository to your local machine:
   ```sh
   git clone https://github.com/oneblack74/MenuConfigurationTouches.git
   ```

2. Open the project in Unity

### Usage

  1. Setting Up the Scene:
  - Create a new GameObject in your scene and name it InputHandler.
  - Attach the InputHandler script to this GameObject.
  - Create a ScrollView under the InputHandler GameObject.
  - In the InputHandler script, set the following references in the Inspector:
    - Input Actions: Reference to the InputAction asset that contains your input configurations.
    - Button Prefab: A prefab for the button used to display and change key bindings.
    - Content Transform: The Transform component of the Content GameObject inside the ScrollView.

  2. Generating the Menu:
  - The key binding menu will be automatically generated based on the input actions defined in the InputAction asset.

## Status
(Project under development)
