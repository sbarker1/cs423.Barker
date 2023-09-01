//Samuel Barker
//00100768
//sbarker1@my.athens.edu
//Assignment 02

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

//NOTE: When running, please don't forget to pull up the canvas window and console window when running to see the astericks update. 

namespace TurtleGraphicsApp
{
     public partial class MainWindow : Window
     {
          private int numRows = 50; // Number of rows
          private int numCols = 50; // Number of columns
          private int tileSize = 10; // Size of each tile in pixels
          private int[,] floorGrid; // 2D array to represent the floor grid
          private int currentRow = 0; // Current row position of the turtle
          private int currentCol = 0; // Current column position of the turtle
          private bool isPenDown = false; // Pen status
          private TurtleDirection currentDirection = TurtleDirection.Up; // Current direction of the turtle

          public MainWindow()
          {
               InitializeComponent();
               InitializeFloorGrid();
          }

          private void InitializeFloorGrid()
          {
               floorGrid = new int[numRows, numCols];
               ClearGrid();

               // Mark the starting position at the bottom-left corner (0, numRows - 1)
               currentRow = numRows - 1;
               currentCol = 0;
               DisplayGrid();
          }


          private void ExecuteCommand(string command)
          {
               string[] parts = command.Split(',');
               int cmd = int.Parse(parts[0]);

               switch (cmd)
               {
                    case 1: // Pen Up
                         isPenDown = false;
                         break;

                    case 2: // Pen Down
                         isPenDown = true;
                         break;

                    case 3: // Turn Right
                         TurnRight();
                         break;

                    case 4: // Turn Left
                         TurnLeft();
                         break;

                    case 5: // Move Forward
                         int distance = int.Parse(parts[1]);
                         MoveTurtle(distance);
                         break;

                    case 6: // Display Grid
                         DisplayGrid();
                         break;

                    case 7: // Clear Grid
                         ClearGrid();
                         break;

                    case 9: // Terminate program
                         TerminateProgram();
                         break;

                    default:
                         // Handle invalid command
                         HandleInvalidCommand();
                         break;
               }
          }

          private void TerminateProgram()
          {
               // Close the application
               Application.Current.Shutdown();
          }

          private void HandleInvalidCommand()
          {
               // Handle the invalid command here, display an error message
               MessageBox.Show("Invalid command entered.");
          }

          private void TurnRight()
          {
               // Turn the turtle right logic
               currentDirection = (TurtleDirection)(((int)currentDirection + 1) % 4);
          }

          private void TurnLeft()
          {
               // Turn the turtle left logic
               currentDirection = (TurtleDirection)(((int)currentDirection + 3) % 4);
          }

          private void MoveTurtle(int distance)
          {
               // Move the turtle forward logic
               for (int step = 0; step < distance; step++)
               {
                    if (isPenDown)
                    {
                         // Mark the current tile
                         floorGrid[currentRow, currentCol] = 1;
                    }

                    switch (currentDirection)
                    {
                         case TurtleDirection.Up:
                              if (currentRow > 0)
                                   currentRow--;
                              break;

                         case TurtleDirection.Down:
                              if (currentRow < numRows - 1)
                                   currentRow++;
                              break;

                         case TurtleDirection.Left:
                              if (currentCol > 0)
                                   currentCol--;
                              break;

                         case TurtleDirection.Right:
                              if (currentCol < numCols - 1)
                                   currentCol++;
                              break;

                         default:
                              break;
                    }
               }

               // Redraw the grid after moving
               DisplayGrid();
          }

 

          private void DisplayGrid()
          {
               DrawingCanvas.Children.Clear();
               

               for (int row = 0; row < numRows; row++)
               {
                    for (int col = 0; col < numCols; col++)
                    {
                         Rectangle rect = new Rectangle
                         {
                              Width = tileSize,
                              Height = tileSize,
                              Stroke = Brushes.Black,
                              StrokeThickness = 1
                         };

                         if (floorGrid[row, col] == 1)
                         {
                              rect.Fill = Brushes.Black;
                              Console.Write("*"); // Output asterisk to console
                         }
                         else
                         {
                              rect.Fill = Brushes.White;
                              Console.Write(" "); // Output space to console
                         }

                         Canvas.SetTop(rect, row * tileSize);
                         Canvas.SetLeft(rect, col * tileSize);

                         DrawingCanvas.Children.Add(rect);
                    }
                    Console.WriteLine(); // Move to the next row in the console
               }
          }

          private void ClearGrid()
          {
               for (int row = 0; row < numRows; row++)
               {
                    for (int col = 0; col < numCols; col++)
                    {
                         floorGrid[row, col] = 0;
                    }
               }

               DrawingCanvas.Children.Clear();
              
          }

          private void ExecuteButton_Click(object sender, RoutedEventArgs e)
          {
               string command = CommandTextBox.Text;
               ExecuteCommand(command);
          }
     }

     enum TurtleDirection
     {
          Up,
          Right,
          Down,
          Left
     }
}


