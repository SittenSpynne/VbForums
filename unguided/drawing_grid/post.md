If you want to [i]draw[/i] your grid, you need to be comfortable with a few things. But this tutorial strictly concerns drawing with a grid. Borders and some other nice things will be reserved for another topic.

Drawing to a grid is a lot like dealing with a 2D array. Only now, our cells have a width and a height. So while in the array, (0, 0) and (0, 1) are right next to each other, on the screen (0, 0) takes up some space.  It's just a square, so it's easy to conceptualize. 

Let's say our **width is 64** and **height is 64**. That's a nice, easy number to work with. If we draw a square, and its top-left corner is at (0, 0), then we know its "bottom" is at 64 and its "right" is at 64. So its corners are (0, 0), (0, 64), (64, 0), and (64, 64).

![Single cell dimensions](./singlecell.png)

If we want to draw another cell to the right, we have to start at (64, 0). If we want to draw another cell to the bottom, we have to start at (0, 64). For every 1 "unit" we move in the array, we need to move 64 pixels in tha direction on the screen. This is going to come in handy later, when we want to know what cell we clicked on! But for now, we can make a really simple loop that draws a checkerboard pattern.

Have a look at the project [grid_checkerboard](grid_checkerboard/grid_checkerboard/Form1.vb). It's the most basic "drawing a grid" project. It uses the Paint event to draw a checkerboard grid.

As a style note, don't skimp on constants in your code! Having the ones I chose at the top can make it easy to change the size of the grid, or the size of the cells. If you write your code properly, that's all you have to do to update things. And if you start by depending on constants, then later features like "make the grid resize with the form" become eaiser, too!

When we work with 2D grids, it's very common to find a row loop with a column loop nested inside. The same is true of 2D arrays. In this case, the logic is very simple:

* Start with a White square.
* For each column:
    * For each row:
        * Draw a square with the right color at `(currentX, currentY)`.
        * Change the color to the opposite one.
        * Move `CELL_WIDTH` pixels to the right.
    * After the row is finished, move `CELL_HEIGHT` pixels down.

There's a slightly different way I could have done it, but it will show up in future "lessons". For now, tweak the constants. Make the cells bigger. Make them rectangular. Add rows and columns. It's a little boring, but it's good to see how what you do affects the program.