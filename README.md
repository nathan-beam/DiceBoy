# DiceBoy
A quick and easy dice roller for tabletop games written in C#


To use: 
Simply run the application via DiceBoy.exe, and use the listed keyboard keys to roll the specified die. Rolls made within 500ms of the last will be grouped together. I.e., 3 rapid "T" presses in a row will register as 3d6, and add the result together. If the rolls were 3, 5, and 1, you will see the total in the center (9), as well as a breakdown of each roll. 

Modifiers can also be added at any time with a number row key. These are not required to be within 500ms of the last roll. Press space to emulate the "lucky" feature and reroll all natural 1s.

Have fun!
