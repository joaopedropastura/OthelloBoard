GameFileManipulation read = new GameFileManipulation();
OthelloBoard sla = new OthelloBoard(1, 68853694464, 2, 34628173824, 2);

ulong temp = sla.GetBorderGame();

System.Console.WriteLine(temp);

sla.PlaysAvailable();




