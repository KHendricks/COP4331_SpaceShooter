How to install the player prefab to a single player level:
1) Drag the prefab into the proper scene
2) From the Player GameObject in the scene remove the following
3) Remove the Photon Transform View (Script) component
4) Remove the Photon View (Script) component
5) Remove the Player Network (Script) component
6) Now the player should be usable in an offline scene

** IMPORTANT: **
ONLY REMOVE THE COMPONENTS MENTIONED ABOVE FROM THE PLAY GAMEOBJECT IN
THE SCENE NOT FROM THE ACTUAL PREFAB IN THE RESOURCES FOLDER