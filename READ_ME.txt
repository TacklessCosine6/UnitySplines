To create a spline tool, create an empty object and add the Bezier Spline script (because the object is empty the spline will not be visible when not the selected object).
To use the spline tool, click on a handle while the spline object is selected and move the handle or point to the desired location.
To add to the spline hit the button to add a point which will create a new series of handles and a new endpoint along the x axis from the current endpoint.
To make the spline loop back to the beginning, hit the loop check box (it is reccommended that this take place after the remainder of your spline is in place).

To make an object "walk" the spline:
1) Choose your game object
2) Attach the Spline Walker script
4) Give the walker a reference to the spline you want it to walk (variable named "spline")
5) Tell the walker how long you want it to take to complete a "walk-through"
6) Check or uncheck if you want your object to rotate along with the splines direction of travel
7) If desired, add a percentage starting offset for the walker to start along the spline
8) Choose the walking mode from: once, loop, and ping pong (go to end and then go backwards to start, repeat)