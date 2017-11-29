Eh, "hard" means different things to a lot of people. In this context I felt like I didn't have enough time to do an example of rendering a grid, but mostly I have a tendency to want to tutorialize and that makes it take a long, long time. It's a new day, and now I sort of have time. Let's have a class while I wait on a meeting.

If you want to [i]draw[/i] your grid, you need to be comfortable with a few things. 

First, a crash-course in how you draw things in Windows Forms. When Windows decides it's time to draw, the Paint event is raised for the form and every control on it in some order that's not important for the discussion. So if you want to draw things on a Form or Control, you have to handle the Paint event. This event gives you a PaintEventArgs that has the Graphics object you use to draw, and some properties to help you understand the coordinates you should use to draw. Normally Windows decides when it wants to redraw by itself. If you need to MAKE it redraw, the best way is to call the Invalidate() method. What that does is really interesting, but for this topic you only need to know "that's what makes it redraw".

Next: be super sure you're comfy with thinking about coordinate spaces in "layers". This can be a mind-breaker via text, but it's not [i]ridiculous[/i] complicated. Here's what I mean.

Suppose I have my grid that represents the game state. One of the cells is (0, 0), that's the "first" one. If I want to draw my grid on the form at (20, 20), then mentally I can say "The 'grid' coordinate (0, 0) is the same thing as the 'form' coordinate (20, 20)". The next layer is the "screen". If our form is located at (100, 100) on the screen, then its top-left corner is more or less at that location. So (20, 20) inside the form is at (120, 120) on the screen. Thus sometimes we have to think, "(0, 0) in the grid is located at (20, 20) on the form, but that is (120, 120) on the screen". The main reason this matters is if you're in a control, then you have a "grid" coordinate, a "control" coordinate, a "form" coordinate, and a "screen" coordinate. All are different numbers but mean the same pixel on the screen!

Why care? Well, some mouse events use "screen" coordinates, and you have to be careful to convert them to the coordinates you'd like to use. Other mouse events are in "control" coordinates, but you might rather have them in "form" or "screen" coordinates. 

One more layer: let's say we decide a grid cell is 32x32. Now we can say how "big" a grid cell is. That means if I draw one cell at (0, 0), the cell to the right should be at (32, 0), then the next one at (64, 0), etc. The cell below it should be (0, 32), the next one (0, 64), etc. This should look really familiar: it's just like moving around the "grid" coordinates, only for every cell we move over in the grid, we need to move over 32 pixels on the form. 

EXCEPT: what if there is a border around each cell? Well, a border has a width. You have to decide what to do about that, and it can get tricky. Let's say we have a nice 3-pixel border. A 1-pixel border makes everything really easy, so let's go ahead and talk about borders with a size. There are choices to make.

We can draw the border "inside' the cell. This means the pixels are always fully inside our 32x32 region, but that the border is covering 3 of our pixels. So our cell is "really" 29x29 internally. If we really want 32x32 inside our border, we'll need to make each grid cell 35x35 so it fits.

We can also draw the border "on" the cell. This means we line up the center of our 3-pixel border with the outer edge of the cell, so 1 pixel is "outside" and 1 pixel is "inside". This means the cell, with border, takes up 33x33 on the screen. And because 1 pixel is inside the cell, it only has 31x31 on the inside. So with this scheme, if we want every cell to have 32x32 on the inside, we need to make them 33x33 and they will take up a 34x34 area on the screen.

We can also draw the border "outside" the cell. This means the border's "inside" pixels are completely outside the 32x32 area. So in this setup, our 32x32 cells are actually 35x35. Just like with the "inside" approach, if we really want 32x32 then we can only draw in a 29x29 space.

This matters because if we're going to draw a grid, and especially if we want to handle clicks, we need to be able to calculate the coordinates for any given grid cell, and we need to have a good feeling for what each one looks like.
