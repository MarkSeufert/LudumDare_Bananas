# Death, Taxes, and Bananas
*"An FPS fighter game where you play as Grandma Betty, where you sell bananas and fight Tax Agents"* <br> <br> 
![Splash art](https://drive.google.com/uc?id=1T5jxDtLTsgsLrhRl74IH4H6B2Fk-QsvY) <br>

## Background
This game was made as a part of [Ludum Dare 50](https://ldjam.com/events/ludum-dare/50/games), where we were given 48 hours to make a game about "delaying the inevitable". As we all know, there's two certainties in life: death and taxes. So in that theme, I wanted to make a game where you try and delay paying your taxes for as long as possible by fighting off tax collectors. You also sell bananas in between fights to raise enough money to buy better weapons, to survive longer. 

**link to play**: https://markseufert.itch.io/death-taxes-and-bananas <br>
**Ludum Dare submission**: https://ldjam.com/events/ludum-dare/50/death-taxes-and-bananas


## Implementation
Death, Taxes, and Bananas was implemented in C# using the Unity game engine. There are four main sections of code which I seperated by folder, which together forms the entire game. Below is a brief summary of each section, including **pseudocode**:

#### 1: Player Movement and Selection
Player movement is pretty easy to achieve in Unity. We can take the keyboard input and put it into two axes, where the **"Vertical"** axis is the forward and back keys (`w` and `s`), and the **"Horizontal"** axis are the left and right keys (`a` and `s`). We can acheive movement by applying a force on the player based off the inputs:
```
player.AddForce(transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"), ForceMode.Acceleration);
```
Looking around using the mouse is also trivial in Unity. Using two new axis **"Mouse X"** and **"Mouse Y"** which correspond to the x and y movement of the mouse, we rotate the player by that amount every frame.
```
player.rotation = Quaternion.Euler(new Vector3(Input.GetAxis("Mouse Y") * -1, Input.GetAxis("Mouse X"), 0));
```

#### 2: NPC movement
TODO
#### 3: Tax Collector Fight Logic
TODO
#### 4: Guns
TODO
