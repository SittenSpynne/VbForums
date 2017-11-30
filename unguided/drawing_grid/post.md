If you want to [i]draw[/i] your grid, you need to be comfortable with a few things. But this tutorial strictly concerns drawing with a grid. Borders and some other nice things will be reserved for another topic.

Drawing to a grid is a lot like dealing with a 2D array. Only now, our cells have a width and a height. So while in the array, (0, 0) and (0, 1) are right next to each other, on the screen (0, 0) takes up some space.  It's just a square, so it's easy to conceptualize. 

Let's say our **width is 32** and **height is 32**. That's a nice, easy number to work with. If we draw a square, and its top-left corner is at (0, 0), then we know its "bottom" is at 32 and its "right" is at 32. So its corners are (0, 0), (0, 32), (32, 0), and (32, 32).

![Single cell dimensions](./singlecell.png)

If we want to draw another cell to the right, we have to start at (32, 0). If we want to draw another cell to the bottom, we have to start at (0, 32). For every 1 "unit" we move in the array, we need to move 32 pixels in tha direction on the screen. This is going to come in handy later, when we want to know what cell we clicked on! But for now, we can make a really simple loop that draws a checkerboard pattern.

