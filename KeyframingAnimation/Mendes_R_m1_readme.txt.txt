Ryan Mendes
mendesry@gpc.edu
rmendes3

posted to www.prism.gatech.edu/~rmendes3/WebBuild.html

Relevant Files:
Game scene: "Scene 2" in Assets
Animation Controller: RobotController in Assets
Animation Script: RobotController.cs in Assets
Animation Files in "AnimsNew" folder
Model in "ROBOTS" folder

Controls:
***Best to use a combination of 360 controller and mouse
-360 left joystick for forward/backward movement (alternatively W and S)
-Left mouse to crouch (alternatively A button on 360)
-Right mouse to jump, while moving (alternatively Y on 360)
-Mouse to look around


Requirement breakdown:
Completed
-Level created with terrain appropriate for testing character interaction
-Model obtained from Turbosquid, rigged in Mixamo, animations acquired from Unity Asset Store
-Mechanim controller with 7 states, two of which ("WalkJogRun" and "Jumping") are blend trees each containing 3 animations. Animations featuring walking, jogging, running, jumping, and crouching
-Animation controller features 4 paramaters which are used to manipulate the character via script
-Character avatar translation is achieved via animations' root motion

Buggy
-Gravity behavior when jumping. I implemented curves for gravityWeight to disable gravity while jumping and a paramater for controlling the size of the capsule collider (similar to the mechanim tutorial in the assignment description), however I could not get the behavior exactly correct. I believe this to be a product of the jump state being a blend tree with three different animations, which means having 2 different curves to handle for each state. In the current implementation, I disabled the rigidbody's gravity while in the jump state, but this of course means that jumping off of platforms has a Wile E. Coyote effect.
-Crouching. The animation itself works great but the problem comes down to the collider. Manipulating the capsule collider's size doesn't work here since the height attribute acts as vertical scaling, meaning that the collider is pulled away from the avatar's feet causing it to sink into the floor - therefore manipulating collider height with a curve would not have really worked. The solution to this would be resize the collider while also moving its center, but the center attributes are read only so this could not be done outside of the editor. I attempted to remedy this by creating a sphere collider toward's the character's feet, and when entering/leaving crouch toggling the colliders such that the capsule is on while standing and the sphere is on while crouched, while disabling the other. Unfortunately this caused clipping when moving and made the character flip and rotate randomly, despite those paramaters being constrained in the editor. So in this implementation, crouching LOOKS like it works but the collider is never resized, meaning you can't actually crouch under anything as intended.

Acquired Assets:
-SimpleSmoothMouseLook - one of my favorite scripts. This also controls character rotation.
http://forum.unity3d.com/threads/a-free-simple-smooth-mouselook.73117/
-Animations - Mobility Free from Unity Asset Store
https://www.assetstore.unity3d.com/en/#!/content/26695
-Model - "Robot" by BlackKeima on TurboSquid
http://www.turbosquid.com/3d-models/robot-bot-max-free/817753
-Model rigged with Mixamo

Notes
-I believe I hit all the assignment requirements (sans the bugged jumping) despite the disfunctional crouch collider behavior, since I still have at least 3 states even if I omitted the crouching
-I disagree with the requirment to have translation occur from animation root motion. It makes more sense in reality to control actual player movement via script, where you have more control over what speed you would like the avatar to move in the game. Especially with acquired assets, there could be an instance where an animation looks great but doesn't move your character at a speed appropriate your games needs. This was my case with the crouched walking animations, which felt too slow for me, and the only fix for this with root motion is to increase the animation speed, which just ends up looking awkard. It would be an easy fix via script.