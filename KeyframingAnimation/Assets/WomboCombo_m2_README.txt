i) Team members
	Robert Borowicz, rborowicz3@gatech.edu, rborowicz3
	Neal Kaviratna,
	Clay Anderson
	Ryan Mendes
	Rich Li

Game Controls:
	Run forward: 'W'
	Turn/Change Direction: Mouse
	Punch Combo: 'Right Mouse'
	Left Uppercut: 'Left Mouse'
	Crouch: 'C'
	Ragdoll/Reset: 'R'

ii) All group requirements have been completed. Details for how each requirement was completed is detailed below. Individual requirements are described in each team member's section in part v.

	Basic Physics Interaction: This requirement is met by having our character interact with the environment and object around it. In game, the character can run into different objects and knock them over, push balls around, etc. Collisions are detected and colliding object react accordingly to when a player hits them. There is also interaction with the fists, which can also punch objects if they are within range.

	Collider Animation: The only animation we used that required a dynamic collider was the crouch animation. This meets the requirement of dynamically resizing the collider based on a specific animation that is playing. This requirement can be scene in levels by crouching and going under certain objects that you normally could not crouch under. The details for how to see this in each level will be included in each individual level description.

	Ragdoll Simulation: We met this requirement by creating a full ragdoll for our character and we plan to use it for when the character dies. The game feels gardens for this assignment will not really have enemies, so some of the gardens may also include ways to die and trigger ragdoll, which will be detailed in each level. Another way to see the ragdoll at any given time in the level to prove we have completed this requirement is to press 'R' which enters the character into a ragdoll state. Pressing 'R' again will return the player to normal.

	Game Feel: We met this requirement through a few aspects. Our controls are responsive and all realtime. The animation for speed is blended between idle, walk, and run when moving forward, but this is hard to see on a keyboard. However, the animations and mecanim for it are there and will work when we implement gamepad controls. The crouching animations are also blended for walking and are blended for speed. The mouse movement also adds an aspect of game feel by allowing the player to control the direction of the player in real time as well. Furthermore, the responsive punches as well as combo punches allow for the input to feel more responsive and dynamic.
	As for our character feeling, we were going for an aggressive and ready to attack character. He is large, yet he is also strong and mobile. The movements are very sharp and the punches are fast. Our character was trapped and contained for years, and now he's awake and angry and wants to escape. This is why the character idles in a fighting position as well. You can also notice, if you stand still, that the camera slightly pulses and bounces with the character to give the feeling of being ready to fight. The snappy controls and the ready to fight idle state along with the slightly pulsing camera allows us to create this kind of feel for the character.

iii) Assets used
	MouseLook Script: This script was acquired to allow the smooth turning based on mouse position.
	Animations: Many animations were downloaded from the standard assets package within Unity
	Animations:	Some animations were taken from Mixamo.com and are used for the punches
	Model: The model was acquired from Mixamo.com


!!!!!Too complete below!!!!!

iv) No special install instructions

v) 
	Neal Kaviratna - Ice Garden
		This Garden has interactive mines in it. These proximity mines will give warning the closer you get to them, as well countdown to detonation faster. The player will be hurt and thrown into ragdoll anytime they are hurt by a mine. The player can reset the character by pressing 'r' or by reloading the scene. The Ice section of the level is slippery, however due to the previous requirement that our game make use primarily of root motion. The character retains normal motion on the ice while navigating right now. When the character is put in ragdoll, either by an explosion, or by hitting 'r'. Then it will slide across the ice. Additionally other objects such as the ice blocks or the mines will slide on the ice.

vi) Since there are multiple scenes, one for each team member, any of these scenes can be opened.

vii) Someone's prism URL