README for lab2
Lujia Wang and Shuning Dong work on this lab together.
02/01/2019

To run online, using Chrome, go to http://htmlpreview.github.io/?https://github.com/lujiawang/RandomMaze/blob/master/index.html 
Part of the code are in the Code samples folder.




/* The following setting are already been settled in submission */
In inspector area of “Maze”:
Under “Maze Manager” script, set object “MazeCube” to Maze Cube Profab, object
“endCube” for End Preafab, “maze (Transform)” for Maze Parent. Maze Row, Maze
Col, and Scale can be set as the player want.
In inspector area of “MeshArrow”:
Under “Build Mesh” script, the value could be changed to change the shape of the
mesh.
Under “Object Movement” script, set “maze (Transform)” to Parent.
Under “Switch Camera” script, set “Main Camera (Camera)” to Main Camera,
“ExpandCamera (Camera)” to First Camera.
Under “Game Success” script, set “WinText (Text)” to Win Text.
- Scene is created automatically and the scene is different each time the program is
ran. (3)
- The entire scene rotates and the model within the scene remains in the same position
relative to the maze (1). Hit “1” will rotate the maze clockwise, “0” rotate anticlockwise.
- The model (arrow) is constructed using a Mesh in a script (3).
- The arrow’s motion is affected based on the scene (1) and arrow can rotate on its
own axis (1). Gamer can control the arrow object by “W / Up” (forward), “A /
Left” (left), “S / Down” (backward), and “D / Right” (right). The arrow will rotate
towards the direction it goes.
- The numbers of the cube could be changed under maze inspector – Maze Manager
(Script) – Maze Row and Maze Col (extra).
- The shape of the mesh (default as an arrow) could be changed under MeshArrow
inspector – Build Mesh (Script) (extra).
- Gamer can use “C” to switch perspective. The camera will follow the arrow you
control (extra).
- When the gamer controls the arrow to the green cube at the exit, a page shows
“YOU WIN!” will pop up and the arrow can only rotate but no longer move
(extra).
