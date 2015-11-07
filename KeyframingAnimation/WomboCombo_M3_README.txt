Milestone 3: AI
Team Wombo Combo:
Neal Kaviratna, nkaviratna@gatech.edu, PRISM: nkaviratna3
Clay Anderson, canderson70@gatech.edu, PRISM: canderson70
Robert Borowicz, rborowicz3@gatech.edu, PRISM: rborowicz3
Rich Li, li4rich@gatech.edu, PRISM: li4rich
Ryan Mendes, mendesry@gatech.edu, PRISM: mendesry


ACQUIRED ASSETS:
All of our animations were either taken from Unity’s Standard assets or from Mixamo.com
Additionally, of course, we used the RAIN plugin.
3D Models acquired include:
https://www.assetstore.unity3d.com/en/#!/content/10656
All of the warehouse elements such as shelves and cones and such we acquired through the unity asset store and are used for scenery and obstacles




INSTALL INSTRUCTIONS:
Nothing special should be required. This is a standard web build.


REQUIREMENTS MET/GRADING WALKTHROUGH
We chose to implement our AI using the RAIN plugin, so below is the enumeration of our work on each requirement. The scene used for this milestone is BackupScene.unity


1) Navmesh is baked into the scene in accordance with what seemed appropriate for our AIs. It can be seen in the inspector.


2) Our suicide bot AI makes use of Navigation Targets as a means of knowing where to go to find mine stashes. When he spots the player, he will make way for a stash of mines and, once he grabs one, he’ll pursue the player to blow him up.


3) The Waypoint Network proved difficult for us. We were able to set up the waypoint network, which you can see in the inspector view. However, Rain has very little documentation on getting networks working correctly. The only thing we could find was an old YouTube video using an outdated version of rain that had to use custom scripts just to get the waypoint network working. There is a robot that was made to utilize the network, that is set to inactive so it doesn’t show up in scene, who should use this network we created, but we were unable to get the behavior tree and memory variable to move around correctly.


4) We have a waypoint route rig that is in use by the robot patrolling the leftmost wall of the scene. He walks in a zig-zag pattern along the rig, which can of course be seen directly in the inspector. While patrolling, he walks at half speed. When he sees the player, he’ll pursue in a full sprint, but if the player leaves his field of view, he’ll walk back to his usual patrol.


5) All of our NPCs should have their movement controlled by mecanim motors. Their behavior trees pass in different speed values and such to adjust their animations. Again, a good example is the AI mentioned just above. When patrolling, he walks at .5 speed, but when he encounters the player, he runs at full speed (1).


6) Our NPC characters leverage animation states as well. The patrol bot on the far left punches when he is in melee range of the player character. There is also a character towards the back right of the level that patrols the doors. When he sees the character come into range, he executes an animation and fires a projectile at the player. These utilize the direct mecanim animation states as required.


7) The algorithm we created for this project was one to predict the shot an NPC needed to take to lead the player and hit him. It takes into account the movement of the player to determine a vector direction to fire a “Hadouken” in. You can see this by moving near the character towards the back right of the level by the doors. If you run by him, he will fire a shot that leads you with the intention to hit the player by using our algorithm. The script is attached as a custom RAIN element in this NPC’s behavior tree


8) Our NPCs meet all of the requirements mentioned in the assignment description. We feel that all three demonstrate significantly different behaviors. For example, one NPC, when he spots the player, immediately runs for a mine and tracks the player down to kill him. Another is not so aggressive and chases the player when in range, but returns to patrolling when he loses the player. The third NPC is like a gate guardian and only patrols his little area until the player comes near, in which case he fires shots to take the player down. All three NPCs incorporate some type of waypoint or navigation target into its tree, and each NPC also has some sort of detect feature in order to react to the player.


9) Game Feel: We believe that our interactions with the NPCs definitely keep true to the game feel. The characters do not clip through the shelves or other objects in the level, and the characters respond quickly when noticing you. One of our emotional elements was that the factory you’re in has just woken up so everything is on high alert, thus why NPCs are quick to react and chase you down or shoot at you. We think that this quick reaction and alert sense of the NPCs contributes to our overall game feel. We think that it helps give the feeling of being on alert and having to move at a fast past when spotted by an enemy.


Description of AIs and How to See Behaviors:
All AI’s are moving via the mecanim motor combined with a RAIN navmesh. All patrols use the RAIN Waypoint Route rig or Navigation Targets.

Observe the red robot patrolling near the shelves as the game begins. If you enter his line of sight, he will freak out, and attempt to find any mines near himself to suicide rush you with. If he does not find any, he will rush to one of two know Mine Stashes (navigation targets). When he has grabbed a mine he will navigate back to the player in a suicide charge. To reset after being blown up by a mine press ‘r’

There is a robot patrolling along the left most wall. When he notices you he will run up and punch you, this is an animation played via behaviour tree. You can also notice that he will chase you if you run away, until you reach a certain distance at which point he gives up and returns to partolling

There is an enemy in the far right corner patrolling the gate who will shoot a fireball spell at you upon seeing you. He leads this shot with a course predicting algorithm. He will not chase you very far, but will shoot at you until you leave his area.


Scene to check:
Ironically - BackupScene.unity. There was some issues with scene conflicts in git and this ended up being our main file.


Web Link:
https://www.prism.gatech.edu/~rborowicz3/Index.html for landing page
https://www.prism.gatech.edu/~rborowicz3/M3.html for Game