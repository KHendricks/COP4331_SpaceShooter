# COP4331_SpaceShooter

For Spring of 2018, a group of six people worked on this project together to make it a reality. It is a singleplayer and multiplayer 3D, on-rails space shooter style of game. This game was developed in the Unity Game Engine which allowed for an simple build process for Android devices. 

# Documented Changes
There were two notable areas in which the development process was altered. Those areas are: the leaderboard and multiplayer implementation. Originally, we were going to utilize the Google Play Services API for both the leaderboard and multiplayer. However, after running into some unexpected issues with the leaderboard that approach was scrapped and instead we used a Unity asset called Dreamlo. Secondly, we wanted multiplayer to use a client-server approach and the Google Player Service API only allowed for peer-to-peer connections, so instead of utilizing that API for multiplayer we transitioned to another Unity Asset called Photon Unity Networking. 
