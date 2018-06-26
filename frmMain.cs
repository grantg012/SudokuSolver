using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class frmMain : Form
    {
        // Constructor
        public frmMain() { 
            InitializeComponent();
            grid = new SudokuCell[9, 9];
            cellsToElimPoss = new LinkedList<CellIndices>();
            cellsToRender = new Queue<CellIndices>();
            cellsLeft = 81;
            step = 1;
            haveInputtedGrid = false;
            guesses = new Stack<GuessCell>();
        }

        // Fields
        public static SudokuCell[,] grid;
        public static bool shouldGuess = true;
        public LinkedList<CellIndices> cellsToElimPoss;
        public static Queue<CellIndices> cellsToRender;
        public static int cellsLeft;
        private int step;
        public static Stack<GuessCell> guesses;

        // calculation methods based on grid
        public DictionaryPossible getRowPossibilities(int row) {
            DictionaryPossible result = new DictionaryPossible();
            for(int i = 0; i < 9; i++)
                result.remove(grid[row, i].value);

            return result; 
        }

        public DictionaryPossible getColummnPossibilities(int col) {
            DictionaryPossible result = new DictionaryPossible();
            for(int i = 0; i < 9; i++)
                result.remove(grid[i, col].value);

            return result;
        }

        public DictionaryPossible getMiniBlockPossibilities(int row, int col) {
            int baseRow = row / 3 * 3, baseCol = col / 3 * 3;
            DictionaryPossible result = new DictionaryPossible();
            for(int iRow = 0; iRow < 3; iRow++)
                for(int iCol = 0; iCol < 3; iCol++)
                    result.remove(grid[baseRow + iRow, baseCol + iCol].value);

            return result;
        }

        // Events 
        private void frmMain_Load(object sender, EventArgs e) {
            // Make the dgv a 9x9 grid with row names
            dgvSoduku.Rows.Add(9);
            for(int i = 1; i <= 9; i++)
                dgvSoduku.Rows[i - 1].HeaderCell.Value = "Row " + i;
        }

        private void dgvSoduku_Paint(object sender, PaintEventArgs e) {
            // Draw 3x3 boundaries 
            Pen pen = new Pen(Color.Black);
            
            // Horizontal
            e.Graphics.DrawLine(pen, 80, 21, 349, 21);
            e.Graphics.DrawLine(pen, 80, 87, 349, 87);
            e.Graphics.DrawLine(pen, 80, 153, 349, 153);
            e.Graphics.DrawLine(pen, 80, 219, 349, 219);

            // Vertical
            e.Graphics.DrawLine(pen, 80, 21, 80, 218);
            e.Graphics.DrawLine(pen, 170, 21, 170, 218);
            e.Graphics.DrawLine(pen, 260, 21, 260, 218);
            e.Graphics.DrawLine(pen, 350, 21, 350, 218);
        }

        private void btnImport_Click(object sender, EventArgs e) {
            /* 
            int[,] inputArray = new int[,] {{0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}, 
                                            {0,0,0, 0,0,0, 0,0,0}};
            
            int[,] inputArray = new int[,] {{3,0,0, 8,2,0, 4,0,0}, 
                                            {0,0,0, 1,0,6, 3,0,0}, 
                                            {7,8,9, 5,0,4, 0,0,0}, 
                                            {9,0,5, 2,6,8, 7,1,3}, 
                                            {0,0,0, 7,0,5, 0,0,0}, 
                                            {6,7,1, 9,4,3, 8,0,2}, 
                                            {0,0,0, 3,0,1, 6,4,7}, 
                                            {0,0,8, 4,0,2, 0,0,0}, 
                                            {0,0,7, 0,0,9, 0,0,1}};
            
            int[,] inputArray = new int[,] {{0,5,0, 7,0,0, 0,3,0}, 
                                            {0,0,0, 8,0,0, 0,4,6}, 
                                            {4,0,0, 2,0,3, 9,5,0}, 
                                            {0,0,7, 0,0,0, 0,0,5}, 
                                            {0,0,0, 0,1,0, 0,0,0}, 
                                            {5,0,0, 0,0,0, 8,0,0}, 
                                            {0,4,5, 1,0,9, 0,0,2}, 
                                            {9,6,0, 0,0,8, 0,0,0}, 
                                            {0,7,0, 0,0,4, 0,8,0}};
            
			int[,] inputArray = new int[,] {{5,0,0, 0,0,1, 3,0,0}, 
                                            {0,0,0, 0,6,5, 1,7,0}, 
                                            {0,0,0, 4,0,0, 0,2,5}, 
                                            {0,6,0, 0,7,0, 0,3,0}, 
                                            {0,7,5, 0,0,0, 6,8,0}, 
                                            {0,8,0, 0,4,0, 0,1,0}, 
                                            {8,2,0, 0,0,6, 0,0,0}, 
                                            {0,5,6, 3,8,0, 0,0,0}, 
                                            {0,0,1, 7,0,0, 0,0,3}};
			
            int[,] inputArray = new int[,] {{0,2,0, 0,0,0, 0,0,6}, 
                                            {0,0,6, 0,5,8, 1,0,0}, 
                                            {0,7,0, 3,0,0, 0,0,0}, 
                                            {0,4,0, 5,0,0, 8,0,0}, 
                                            {1,0,0, 0,0,0, 0,0,7}, 
                                            {0,0,5, 0,0,4, 0,2,0}, 
                                            {0,0,0, 0,0,7, 0,8,0}, 
                                            {0,0,8, 1,2,0, 7,0,0}, 
                                            {4,0,0, 0,0,0, 0,3,0}};
            
            int[,] inputArray = new int[,] {{0,3,1, 0,2,0, 5,4,0},
                                            {5,0,0, 6,0,4, 0,0,9},
                                            {0,0,0, 0,3,0, 0,0,0},
                                            {2,9,0, 0,0,0, 0,6,4},
                                            {0,0,7, 0,0,0, 8,0,0},
                                            {4,1,0, 0,0,0, 0,5,3},
                                            {0,0,0, 0,4,0, 0,0,0},
                                            {9,0,0, 2,0,1, 0,0,5},
                                            {0,2,4, 0,9,0, 3,1,0}};
                                            */
            int[,] inputArray = new int[,] {{0,4,3, 0,8,0, 2,5,0},
                                            {6,0,0, 0,0,0, 0,0,0},
                                            {0,0,0, 0,0,1, 0,9,4},

                                            {9,0,0, 0,0,4, 0,7,0},
                                            {0,0,0, 6,0,8, 0,0,0},
                                            {0,1,0, 2,0,0, 0,0,3},
                                            
                                            {8,2,0, 5,0,0, 0,0,0},
                                            {0,0,0, 0,0,0, 0,0,5},
                                            {0,3,4, 0,9,0, 7,1,0}};
            loadArray(inputArray);
        }

        private bool haveInputtedGrid;
        private void btnSolve_Click(object sender, EventArgs e) {
            if(!haveInputtedGrid) {
                inputPuzzle();
                highlightFixedGray();
                fillPossibles();
                btnOpen.Enabled = false;
                haveInputtedGrid = true;
            }

            ViolationInfo v = checkForViolations();
            if(v != null) {
                MessageBox.Show("The current grid is not valid.\n" + v.ToString());
                resetForm();
                resetSolvingVars();
                btnOpen.Enabled = true;
                return;
            }

            if(chkStep.Checked) {
                btnStep.Visible = true;
                btnSolve.Enabled = false;
            } 

            solveStep1();
            if(!chkStep.Checked)
                solve();
            else {
                int nSteps = (int)nudNSteps.Value - 1; // -1 for solveStep1(). 
                if(nSteps > 0)
                    solve(nSteps);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e) {
            Application.Restart();
        }

        private void btnStep_Click(object sender, EventArgs e) {
            solve();
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                string contents = System.IO.File.ReadAllText(openFileDialog1.FileName);
                string[] text = contents.Split(',');
                if(text.Length == 81) {
                    int[,] values = new int[9, 9];
                    for(int i = 0; i < 81; i++)
                        values[i / 9, i % 9] = Convert.ToInt32(text[i].Trim());

                    loadArray(values);
                } else {
                    MessageBox.Show("Error: wrong number of elements. Found " + text.Length + " elements.");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
                StringBuilder contents = new StringBuilder(92);
                for(int row = 0; row < 9; row++) {
                    for(int col = 0; col < 8; col++) {
                        if(dgvSoduku.Rows[row].Cells[col].Value != null && (chkSaveProgress.Checked || (grid[row, col] == null || grid[row, col] is SudokuCellFixed)))
                            contents.Append(dgvSoduku.Rows[row].Cells[col].Value).Append(',');
                        else
                            contents.Append("0,");

                        if(col % 3 == 2)
                            contents.Append(' ');
                    }
                    if(dgvSoduku.Rows[row].Cells[8].Value != null)
                        contents.Append(dgvSoduku.Rows[row].Cells[8].Value);
                    else
                        contents.Append("0");
                    if(row != 8)
                        contents.Append(',');

                    contents.Append('\n');
                    if(row == 2 || row == 5)
                        contents.Append('\n');
                }
                System.IO.File.WriteAllText(saveFileDialog1.FileName, contents.ToString());
            }
        }

        private void modifyPossibilitiesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmPossibilites f = new frmPossibilites();
            int row = dgvSoduku.CurrentCell.RowIndex, col = dgvSoduku.CurrentCell.ColumnIndex;
            f.lblCell.Text = "Cell in row " + (row + 1) + ", column " + (col + 1);
            SudokuCellSolve cell = grid[row, col].asSCS;
            CheckBox[] checkBoxes = new CheckBox[] { f.chk1, f.chk2, f.chk3, f.chk4, f.chk5, f.chk6, f.chk7, f.chk8, f.chk9};
            for(int number = 1; number <= 9; number++)
                if(cell.isPossible(number))
                    checkBoxes[number - 1].Checked = true;
                else
                    checkBoxes[number - 1].Enabled = false;

            f.ShowDialog();

            if(f.DialogResult == DialogResult.OK) {
                int[] initalPossibilities = cell.getPossible.possibleNumbers;
                int nPossible = initalPossibilities.Length;
                List<int> eliminatedNumbers = new List<int>();
                foreach(int number in initalPossibilities)
                    if(!checkBoxes[number - 1].Checked) {
                        cell.eliminateNumber(number);
                        nPossible--;
                        eliminatedNumbers.Add(number);
                    }

                // The user must have done something to take action. 
                if(eliminatedNumbers.Count > 0) {
                    if(nPossible == 1) {
                        activateNumberInCell(row, col, cell.value, type:"u");
                    } else {
                        displayCellHover(row, col);
                        txtLog.AppendText("Step " + (step++) + ": You eliminated " + eliminatedNumbers.elementsToString() 
                            + " as possibilities in cell [" + (row + 1) + ", " + (col + 1) + "] \r\n");
                    }
                }
            }

            f.Dispose();
        }

        private void dgvSoduku_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            // If the user right click a solvable cell...
            if(e.RowIndex >= 0 && e.Button == MouseButtons.Right && grid[e.ColumnIndex, e.RowIndex] is SudokuCellSolve) {
                dgvSoduku.CurrentCell = dgvSoduku[e.ColumnIndex, e.RowIndex];
                dgvSoduku.CurrentCell.ContextMenuStrip = cmsGrid;
            }
        }

        private void chkStep_CheckedChanged(object sender, EventArgs e) {
            nudNSteps.Visible = chkStep.Checked;
        }

        // Back-end helper methods, etc. 
        private void loadArray(int[,] inputArray) {
            // Inputs the array parameter into the DataGridView and the grid object for solving. 
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    if(inputArray[row, col] > 0) {
                        grid[row, col] = new SudokuCellFixed(inputArray[row, col]);
                        dgvSoduku.Rows[row].Cells[col].Value = "" + inputArray[row, col];
                    } else
                        grid[row, col] = new SudokuCellSolve(row, col);
        }

        private void inputPuzzle() {
            // Transfers the user's data in their grid to the back-end data structures. 
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    if(dgvSoduku.Rows[row].Cells[col].Value != null) {
                        grid[row, col] = new SudokuCellFixed(dgvSoduku.Rows[row].Cells[col].Value);
                        cellsLeft--;
                    } else
                        grid[row, col] = new SudokuCellSolve(row, col);
        }

        private void highlightFixedGray() {
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    if(grid[row, col] is SudokuCellFixed)
                        dgvSoduku.Rows[row].Cells[col].Style.BackColor = Color.FromArgb(180, 180, 180);
        }

        private void fillPossibles() {
            // Declare and initialize the arrays
            DictionaryPossible[] rowPossibles = new DictionaryPossible[9];
            DictionaryPossible[] colPossibles = new DictionaryPossible[9];
            DictionaryPossible[,] miniBlockPossibles = new DictionaryPossible[3, 3];
            for(int i = 0; i < 9; i++) {
                rowPossibles[i] = new DictionaryPossible();
                colPossibles[i] = new DictionaryPossible();
                miniBlockPossibles[i / 3, i % 3] = new DictionaryPossible();
            }

            // Get dictionaries of all the possibilities by row, column, and mini-block. 
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++) {
                    rowPossibles[row].remove(grid[row, col].value);
                    colPossibles[col].remove(grid[row, col].value);
                    miniBlockPossibles[row / 3, col / 3].remove(grid[row, col].value);
                }

            // Update the possibilities for each cell. 
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++) {
                    if(grid[row, col] is SudokuCellSolve) {
                        DictionaryPossible dp = new DictionaryPossible(rowPossibles[row], colPossibles[col], miniBlockPossibles[row / 3, col / 3]);
                        grid[row, col].asSCS.setNumbers(dp);

                        dgvSoduku.Rows[row].Cells[col].ToolTipText = dp.stringPossibleNumbers;
                    }
                }
        }

        private void rerenderGrid(bool regray = true) {
            // Rerenders the grid the the DataGridView based on the back-end objects. (Usually after an incorrect guess. 
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++) {
                    SudokuCell cell = grid[row, col];
                    int cellValue = cell.value;
                    dgvSoduku.Rows[row].Cells[col].Value = (cellValue != -1) ? "" + cellValue : null;
                    if(cell is SudokuCellSolve)
                        dgvSoduku.Rows[row].Cells[col].ToolTipText = cell.asSCS.getPossible.stringPossibleNumbers;
                }
        }

        private bool activateNumberInCell(int row, int col, int number, bool enqueue = true, string type = "") {
            // This method sets number to the number of the cell, renders it, and queues it for solving the puzzle. 

            // Exit if this cell is already activated
            if(dgvSoduku.Rows[row].Cells[col].Value != null)
                return false;
            
            cellsLeft--;
            grid[row, col].activateNumber(number);
            dgvSoduku.Rows[row].Cells[col].Value = number;
            dgvSoduku.Rows[row].Cells[col].ToolTipText = "" + number;

            // Use red text if in "guessing mode".
            if(guesses.Count == 0)
                dgvSoduku.Rows[row].Cells[col].Style.ForeColor = Color.Black;
            else
                dgvSoduku.Rows[row].Cells[col].Style.ForeColor = Color.DarkRed;

            if(enqueue)
                cellsToElimPoss.AddFirst(new CellIndices(row, col));

            if(type == "r") {
                txtLog.AppendText("Step " + (step++) + ": The only cell in row " + (row + 1) +
                            " that can have " + number + " is in column " + (col + 1) + "\r\n");
            } else if(type == "c") {
                txtLog.AppendText("Step " + (step++) + ": The only cell in column " + (col + 1) +
                            " that can have " + number + " is in row " + (row + 1) + "\r\n");
            } else if(type == "mb") {
                txtLog.AppendText("Step " + (step++) + ": The only cell in 3x3 [" + (row / 3 + 1) +
                            ",  " + (col / 3 + 1) + "] that can have " + number + " is in [" +
                            (row + 1) + ",  " + (col + 1) + "] \r\n");
            } else if(type == "o") {
                txtLog.AppendText("Step " + (step++) + ": The only possibility for cell [" + (row + 1) +
                            ", " + (col + 1) + "] is " + grid[row, col].value + "\r\n");
            } else if(type == "u") {
                txtLog.AppendText("Step " + (step++) + ": You eliminated the possibilities in cell ["
                            + (row + 1) + ", " + (col + 1) + "] to only " + grid[row, col].value + "\r\n");
            }
            if(type != "")
                dgvSoduku.CurrentCell = dgvSoduku.Rows[row].Cells[col];
            return true; 
        }

        private void displayCellHover(int row, int col) {
            if(grid[row, col] is SudokuCellSolve) {
                //if(grid[row, col].value != -1) {
                //    dgvSoduku.Rows[row].Cells[col].Value = "" + grid[row, col].value;
                //    dgvSoduku.Rows[row].Cells[col].ToolTipText = "" + grid[row, col].value;
                //} else 
                    dgvSoduku.Rows[row].Cells[col].ToolTipText = grid[row, col].asSCS.getPossible.stringPossibleNumbers;
            }
        }

        // Solving
        private void solveStep1() {
            // Check the whole grid for a cell with one possiblitity
            txtLog.AppendText("Step 1: Search for cells that have only 1 possibility. \r\n");
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    if(grid[row, col] is SudokuCellSolve && grid[row, col].asSCS.possibilities == 1) {
                        activateNumberInCell(row, col, grid[row, col].value);
                        txtLog.AppendText("Step 1: The only possibility for cell [" + (row + 1) +
                            ", " + (col + 1) + "] is " + grid[row, col].value + "\r\n");
                    }

            step++;
        }

        private void solve(int stepsToDo = -2) {
            // If the caller supplied a number of steps use that, otherwise use user's number. 
            stepsToDo = (stepsToDo != -2) ? stepsToDo : (int)nudNSteps.Value;
            int i = 0;
            do {
                bool progress = solveHierarchy(chkStep.Checked, stepsToDo);
                if(!progress)
                    break;
                i++;
                if(i > 250) {
                    txtLog.AppendText("Did 250 attempts. Stopping.");
                    btnStep.Enabled = true;
                    return;
                }
                stepsToDo--;
	        } while((!chkStep.Checked || stepsToDo != 0) && cellsLeft > 0);

            if(cellsLeft == 0) {
                txtLog.AppendText("Puzzle Complete!");
                btnSolve.Enabled = btnStep.Enabled = false;
                if(guesses.Count > 0) {
                    // A guess is currently under way and it's correct. Change the highlighting. 
                    for(int row = 0; row < 9; row++)
                        for(int col = 0; col < 9; col++)
                            if(dgvSoduku.Rows[row].Cells[col].Style.ForeColor == Color.DarkRed)
                                dgvSoduku.Rows[row].Cells[col].Style.ForeColor = Color.DarkGreen;
                }
            }
        }

        private bool solveHierarchy(bool inSteps, int stepsLeft) { 
            // True if progess was made. 

            // Check if there's a guess that has gone wrong
            if(guessValidity()) {

                // If there's a cell that can eliminate numbers from it's row, column & mini-block
                if(cellsToRender.Count >= 1 || cellsToElimPoss.Count >= 1)
                    solveByCell();
                else {
                    // Search for a cell that that is the only possibility in it's row, column or mb
                    if(!solveForOneOccur())

                            // If that fails, try to eliminate cells based on a number psuedo occuring. 
                            if(!findPsuedoOccurences())

                                if(!solveForMutuallyExclusive()) {
                                    if(shouldGuess)
                                        solveGuess(inSteps, stepsLeft);
                                    else {
                                        // If that fails, stop. 
                                        txtLog.AppendText("Failed to make any progress. Stopping. \r\n");
                                        btnStep.Enabled = true;
                                        return false;
                                    }
                                }
                }
            }
            
            return true;
        }

        private void solveByCell() {
            int stepStart = step;

            // This method takes the next cell in the Queue of solved cells and eliminates
            // its value in its row, column, and mini-block
            CellIndices cellInfo;
            if(cellsToRender.Count >= 1) {
                // Since the cells to render Queue displays a new cell, we'll count that 
                // as a step and exit if we're going step by step. Otherwise, proceed. 
                cellInfo = cellsToRender.Dequeue();
                activateNumberInCell(cellInfo.row, cellInfo.col, grid[cellInfo.row, cellInfo.col].value, false, "o");
                stepStart++;
                if(chkStep.Checked) {
                    cellsToElimPoss.AddFirst(cellInfo);
                    return;
                }
            } else {
                cellInfo = cellsToElimPoss.First();
                cellsToElimPoss.RemoveFirst();
            }


            // Ensure this cell isn't fixed and is solved. 
            if(grid[cellInfo.row, cellInfo.col] is SudokuCellFixed || grid[cellInfo.row, cellInfo.col].value == -1)
                return;

            SudokuCellSolve cell = grid[cellInfo.row, cellInfo.col].asSCS;

            txtLog.AppendText("Step " + step + ": Updating possibilities eliminated by cell [" +
                (cellInfo.row + 1) + ", " + (cellInfo.col + 1) + "] \r\n");
            dgvSoduku.CurrentCell = dgvSoduku.Rows[cellInfo.row].Cells[cellInfo.col];

            // Go through each cell in this cell's row, column, and mini-block and 
            // remove its value as a possibility. Take care not to eliminate from itself. 
            // Also, display the updated cell if removing cell.value changed the possibilities. 
            for(int i = 0; i < 9; i++) {
                if(i != cellInfo.col) // go through its row
                    if(grid[cellInfo.row, i].eliminateNumber(cell.value)) // this is a modifying method call
                        displayCellHover(cellInfo.row, i);

                if(i != cellInfo.row) // go through its column
                    if(grid[i, cellInfo.col].eliminateNumber(cell.value))  // this is a modifying method call
                        displayCellHover(i, cellInfo.col);

                // go through its mini-block
                int mBRow = cellInfo.majorRow + i / 3, mBCol = cellInfo.majorCol + i % 3;
                if(mBRow != cellInfo.row || mBCol != cellInfo.col)
                    if(grid[mBRow, mBCol].eliminateNumber(cell.value)) // this is a modifying method call
                        displayCellHover(mBRow, mBCol);
            }

            if(step == stepStart)
                step++; // increment if it didn't already
        }

        private bool solveForOneOccur() {
            // checks the whole grid for a number that has only one potential position in its row, column, and miniblock
            bool solvedACell = solveRows();
            solvedACell = solvedACell || solveColumns();
            solvedACell = solvedACell || solveMiniBlocks();
            return solvedACell;
        }

        private bool solveRows() {
            bool solvedACell = false; // true if a number with one occurence was found. 

            // Check each row for a number in one possible location. 
            for(int row = 0; row < 9; row++) { 
                OccurenceSet rowSet = new OccurenceSet();
                for(int col = 0; col < 9; col++)
                    if(grid[row, col] is SudokuCellSolve) // && ((SodukuCellSolve)grid[row, col]).possibilities > 1)
                        rowSet.addDictionary(grid[row, col].asSCS.getPossible);

                // Go through and write in any number that occured once
                List<int> oneOccurences = rowSet.oneOfs;
                //solvedACell = solvedACell || oneOccurences.Count > 1;
                foreach(int number in oneOccurences)
                    for(int col = 0; col < 9; col++)
                        if(grid[row, col].isPossible(number)) {
                            solvedACell = solvedACell || activateNumberInCell(row, col, number, type: "r");
                            continue; // skip the rest of the row
                        }

            }
            return solvedACell;
        }

        private bool solveColumns() {
            bool solvedACell = false; // true if a number with one occurence was found. 

            // Check each column for a number in one possible location. 
            for(int col = 0; col < 9; col++) { 
                OccurenceSet colSet = new OccurenceSet();
                for(int row = 0; row < 9; row++)
                    if(grid[row, col] is SudokuCellSolve) // && ((SodukuCellSolve)grid[row, col]).possibilities > 1)
                        colSet.addDictionary(grid[row, col].asSCS.getPossible);

                // Go through and write in any number that occured once
                List<int> oneOccurences = colSet.oneOfs;
                //solvedACell = solvedACell || oneOccurences.Count > 1;
                for(int i = 0; i < oneOccurences.Count; i++)
                    for(int row = 0; row < 9; row++)
                        if(grid[row, col].isPossible(oneOccurences[i])) {
                            solvedACell = solvedACell || activateNumberInCell(row, col, oneOccurences[i], type: "c");
                            continue; // skip the rest of the column
                        }
            }
            return solvedACell;
        }

        private bool solveMiniBlocks() {
            bool solvedACell = false; // true if a number with one occurence was found. 

            // Check each mini-block for a number in one possible location. 
            for(int mainRow = 0; mainRow < 3; mainRow++) 
                for(int mainCol = 0; mainCol < 3; mainCol++) {
                    OccurenceSet miniBlockSet = new OccurenceSet();
                    for(int subRow = 0; subRow < 3; subRow++)
                        for(int subCol = 0; subCol < 3; subCol++) {
                            SudokuCell cell = grid[mainRow * 3 + subRow, mainCol * 3 + subCol];
                            if(cell is SudokuCellSolve) // && ((SodukuCellSolve)cell).possibilities > 1)
                                miniBlockSet.addDictionary(cell.asSCS.getPossible);
                        }

                    // Go through and write in any number that occured once
                    List<int> oneOccurences = miniBlockSet.oneOfs;
                    for(int i = 0; i < oneOccurences.Count; i++)
                        for(int subRow = 0; subRow < 3; subRow++)
                            for(int subCol = 0; subCol < 3; subCol++) {
                                int currentRow = mainRow * 3 + subRow, currentCol = mainCol * 3 + subCol;
                                if(grid[currentRow, currentCol].isPossible(oneOccurences[i])) {
                                    solvedACell = solvedACell || activateNumberInCell(currentRow, currentCol, oneOccurences[i], type: "mb");
                                    continue; // skip the rest of the mini block
                                }
                            }
                }
            return solvedACell;
        }

        private bool findPsuedoOccurences() {
            // This method searchs the each mini block for numbers that occur in only 1 row/column
            // If there is such an occurence, it can be eliminated from the rest of the row/column
            txtLog.AppendText("Step " + step + ": Look for any numbers in a 3x3 block that only occur in one row or column, " +
                "if so, the numbers can be eliminated from the rest of their row or column. \r\n");


            bool madeProgress = false;

            // Check each miniblock
            for(int majorRow = 0; majorRow < 9; majorRow += 3)
                for(int majorCol = 0; majorCol < 9; majorCol += 3) {

                    // Initialize the stuff 
                    DictionaryPossible[] rowPossibles = new DictionaryPossible[3];
                    DictionaryPossible[] colPossibles = new DictionaryPossible[3];
                    for(int i = 0; i < 3; i++) {
                        rowPossibles[i] = new DictionaryPossible(false);
                        colPossibles[i] = new DictionaryPossible(false);
                    }
                    List<CellIndices>[] locations = new List<CellIndices>[10];
                    for(int i = 1; i <= 9; i++)
                        locations[i] = new List<CellIndices>();

                    // In each mb, find what numbers are present as possibilities in each row and column
                    for(int i = 0; i < 3; i++)
                        for(int j = 0; j < 3; j++) {
                            if(grid[majorRow + i, majorCol + j] is SudokuCellSolve) {
                                rowPossibles[i].addPossibles(grid[majorRow + i, majorCol + j].asSCS.getPossible);

                                // Record where the numbers occur. Pretty sure this only needs to be added once. 
                                addLocations(locations, grid[majorRow + i, majorCol + j].asSCS);
                            }
                            if(grid[majorRow + j, majorCol + i] is SudokuCellSolve) 
                                colPossibles[i].addPossibles(grid[majorRow + j, majorCol + i].asSCS.getPossible);
                            
                        }

                    // Check for numbers that occurred in only one of the rows/columns
                    List<int> rowOnces = new OccurenceSet(rowPossibles).oneOfs;
                    List<int> colOnces = new OccurenceSet(colPossibles).oneOfs;

                    if(rowOnces.Count > 0)
                        foreach(int number in rowOnces) {
                            CellIndices firstLoc = locations[number].First();
                            for(int col = 0; col < 9; col++)
                                // Don't eliminate from the mb where the exclusivity was found
                                if(col / 3 != firstLoc.col / 3) { 
                                    bool changed = grid[firstLoc.row, col].eliminateNumber(number);
                                    if(changed) {
                                        displayCellHover(firstLoc.row, col);
                                        txtLog.AppendText("Step " + step + ": Since " + number + " can only occur in 3x3 columns " + (firstLoc.majorCol + 1)
                                            + '-' + (firstLoc.majorCol + 3) + " and row " + (firstLoc.row + 1) + " it can be eliminated from cell [" 
                                            + (firstLoc.row + 1) + ", " + (col + 1) + "]\r\n");
                                        madeProgress = madeProgress || changed;
                                    }
                                }
                        }
                    if(colOnces.Count > 0) 
                        foreach(int number in colOnces) {
                            CellIndices firstLoc = locations[number].First();
                            for(int row = 0; row < 9; row++)
                                // Don't eliminate from the mb where the exclusivity was found
                                if(row / 3 != firstLoc.row / 3) {
                                    bool changed = grid[row, firstLoc.col].eliminateNumber(number);
                                    if(changed) {
                                        displayCellHover(row, firstLoc.col);
                                        txtLog.AppendText("Step " + step + ": Since " + number + " can only occur in 3x3 rows " + (firstLoc.majorRow + 1) 
                                            + '-' + (firstLoc.majorRow + 3) + " and column " + (firstLoc.col + 1) + " it can be eliminated from cell [" 
                                            + (row + 1) + ", " + (firstLoc.col + 1) + "]\r\n");
                                        madeProgress = madeProgress || changed;
                                    }
                                }
                        }

                    
                }
            step++;
            return madeProgress;
        }

        private bool solveForMutuallyExclusive() {
            // probably should change to bool to see if it makes changes
            // checks row, col, & mb for numbers that occur with each other as the only possibilities in 2 cells. 
            // If so elinimate them from the rest of the row, col, or mb. 

            txtLog.AppendText("Step " + (step++) + ": Look for two numbers that only occur in only two cells in their grouping, they can be " + 
                "eliminated from the rest of their 3x3 block, row, or column. \r\n");

            bool madeProgress = false;

            for(int i = 0; i < 9; i++) {
                // Scan the row, column, and mb for a cell with 2 occurences. 
                List<SudokuCellSolve> rowTwoOfs = new List<SudokuCellSolve>();
                List<SudokuCellSolve> colTwoOfs = new List<SudokuCellSolve>();
                List<SudokuCellSolve> mbTwoOfs = new List<SudokuCellSolve>();
                List<List<SudokuCellSolve>> listList = new List<List<SudokuCellSolve>>(3);
                listList.Add(rowTwoOfs);
                listList.Add(colTwoOfs);
                listList.Add(mbTwoOfs);
                for(int j = 0; j < 9; j++) {
                    if(grid[i, j] is SudokuCellSolve && grid[i, j].asSCS.possibilities == 2)
                        rowTwoOfs.Add(grid[i, j].asSCS);
                    if(grid[j, i] is SudokuCellSolve && grid[j, i].asSCS.possibilities == 2)
                        colTwoOfs.Add(grid[j, i].asSCS);

                    int mbRow = i / 3 * 3 + j / 3, mbCol = i % 3 * 3 + j % 3;
                    if(grid[mbRow, mbCol] is SudokuCellSolve && grid[mbRow, mbCol].asSCS.possibilities == 2)
                        mbTwoOfs.Add(grid[mbRow, mbCol].asSCS);
                }

                int type = 0;
                foreach(List<SudokuCellSolve> l in listList) {
                    // "Sort" any list with 3 or more elements
                    if(l.Count >= 3) {
                        l.Sort(new SudokuCellSolveCompare());
                        // Find any cells with the same possibilities and eliminate the numbers from everything else. 
                        for(int m = 0; m < l.Count - 1; m++) {
                            if(l[m].getPossible == l[m + 1].getPossible)
                                madeProgress = eliminateFromGrid(l[m].getPossible, l[m].getCellIndicies, l[m + 1].getCellIndicies, type) || madeProgress;
                        }

                        // Otherwise, if there are 2 elements of the same possibility. 
                    } else if(l.Count == 2 && l.First().getPossible == l.Last().getPossible) {
                        madeProgress = eliminateFromGrid(l.First().getPossible, l.First().getCellIndicies, l.Last().getCellIndicies, type) || madeProgress;
                    }
                    type++;
                }
            }

            return madeProgress;
        }

        private bool eliminateFromGrid(DictionaryPossible numbers, CellIndices cell1, CellIndices cell2, int type) {
            // Eliminates the numbers from passed from the grouping dictated by the other parameters. Called by solveForMutuallyExclusive()

            // Type should be 0 for row, 1 for column, or 2 for mini block
            int[] possNum = numbers.possibleNumbers;
            int firstNumber = possNum[0], secondNumber = possNum[1];
                
            bool madeChanges = false;

            // Loop through the grouping and remove the 2 numbers as a possibility
            int changes = 0;
            if(type == 0) { // row
                int row = cell1.row;
                for(int col = 0; col < 9; col++)
                    if(col != cell1.col && col != cell2.col) {
                        changes = 0;
                        changes += grid[row, col].eliminateNumber(firstNumber).toInt();
                        changes += grid[row, col].eliminateNumber(secondNumber).toInt() * 2;
                        if(changes > 0) {
                            string numberString = (changes == 1) ? firstNumber.ToString() : ((changes == 2) ? secondNumber.ToString() : ("" + firstNumber + " and " + secondNumber));
                            string pronoun = (changes == 3) ? ", they" : ", it";
                            txtLog.AppendText("Step " + step + ": Since " + numberString + " can only occur in columns " + (cell1.col + 1) // printing logic error
                                + " and " + (cell2.col + 1) + " in row " + (row + 1) + pronoun + " can be eliminated from column " + (col + 1) + "\r\n");
                            madeChanges = true;
                        }
                    }
            } else if(type == 1) { // column
                int col = cell1.col;
                for(int row = 0; row < 9; row++)
                    if(row != cell1.row && row != cell2.row) {
                        changes = 0;
                        changes += grid[row, col].eliminateNumber(firstNumber).toInt();
                        changes += grid[row, col].eliminateNumber(secondNumber).toInt() * 2;
                        if(changes > 0) {
                            string numberString = (changes == 1) ? firstNumber.ToString() : ((changes == 2) ? secondNumber.ToString() : ("" + firstNumber + " and " + secondNumber));
                            string pronoun = (changes == 3) ? ", they" : ", it";
                            txtLog.AppendText("Step " + step + ": Since " + numberString + " can only occur in rows " + (cell1.row + 1)
                                + " and " + (cell2.row + 1) + " in column " + (col + 1) + pronoun + " can be eliminated from row " + (row + 1) + "\r\n");
                            madeChanges = true;
                        }
                    }
            } else if(type == 2) { // mini-block
                int topRow = cell1.row / 3 * 3, leftCol = cell1.col / 3 * 3;
                for(int miniRow = 0; miniRow < 3; miniRow++)
                    for(int miniCol = 0; miniCol < 3; miniCol++) {
                        CellIndices x = new CellIndices(topRow + miniRow, leftCol + miniCol);
                        if(x != cell1 && x != cell2) {
                            changes = 0;
                            changes += grid[x.row, x.col].eliminateNumber(firstNumber).toInt();
                            changes += grid[x.row, x.col].eliminateNumber(secondNumber).toInt() * 2;
                            if(changes > 0) {
                                string numberString = (changes == 1) ? firstNumber.ToString() : ((changes == 2) ? secondNumber.ToString() : ("" + firstNumber + " and " + secondNumber));
                                string pronoun = (changes == 3) ? ", they" : ", it";
                                txtLog.AppendText("Step " + step + ": Since " + numberString + " can only occur in cells " + cell1.ToString() + " and " + cell2.ToString()
                                    + " in that 3x3 block" + pronoun + " can be eliminated from " + x.ToString() + "\r\n");
                                madeChanges = true;
                            }
                        }
                    }

            }

            return madeChanges;
        }

        private void solveGuess(bool inSteps, int stepsLeft) {
            // Makes a good guess and puts the program in that state. 
            if(inSteps && stepsLeft <= 0)
                return;

            SudokuCell[,] saved = new SudokuCell[9, 9];
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    saved[row, col] = grid[row, col].copy();

                        
            // Find the cell with the least possibilites (but at least 2 possibilities).
            int least = 10, minRow = -1, minCol = -1;
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++)
                    if(grid[row, col] is SudokuCellSolve) { 
                        int possibilities = grid[row, col].asSCS.possibilities;
                        if(possibilities < least && possibilities >= 2) {
                            minRow = row;
                            minCol = col;
                            least = possibilities;
                            // Break if found a cell suitable for guessing. 
                            if(possibilities == 2) {
                                row += 9; col += 9;
                            }
                        }
                    }

            // Guess that boi. 
            int guessedNumber = grid[minRow, minCol].asSCS.getPossible.possibleNumbers.First();
            txtLog.AppendText("Step " + step + ": Guessing " + guessedNumber + " for cell [" +
                (minRow + 1) + ", " + (minCol + 1) + "] \r\n");
            guesses.Push(new GuessCell(guessedNumber, new CellIndices(minRow, minCol), step, saved, cellsLeft));
            activateNumberInCell(minRow, minCol, guessedNumber, type: "g");
            step++;

            /* 
            // See how the guess goes
            while(checkForViolations() == null && cellsLeft > 0) { //  && (!inSteps || stepsLeft > 0)
                try {
                    solveHierarchy(inSteps, stepsLeft--);
                } catch(ArgumentOutOfRangeException) { }

            }
            if(checkForViolations() == null) {
                // The guess worked and everything is solved
            } else {
                // Guess went wrong. 
                txtLog.AppendText("Step " + step + ": Guess of " + guessedNumber + " for cell [" +
                (minRow + 1) + ", " + (minCol + 1) + "] failed so it is not possible. \r\n");
                grid = saved;
                cellsToRender.Clear();
                cellsToUpdate.Clear();
                // tooltips
                grid[minRow, minCol].eliminateNumber(guessedNumber);
            }
            */ 
        }

        private bool guessValidity() {
            // This checks if a guess is currently underway and if returns false if it's gone wrong. 
            if(guesses.Count > 0) {
                // If in "guessing mode", check for a violation. 
                ViolationInfo violation = checkForViolations();
                //if(violation != null) 
                //    violation = checkForViolations();

                if(violation != null) {
                    // If was was found, the guess was incorrect. 
                    GuessCell g = guesses.Pop();
                    txtLog.AppendText("Step " + step++ + ": Guess of " + g.guess + " for cell " + g.indices.ToString() + 
                        " from step " + g.step + " failed, so it is not possible. Violation: " + violation.ToString() + ". ");
                    cellsLeft = g.cellsLeft;
                    grid = g.saved;
                    cellsToRender.Clear();
                    cellsToElimPoss.Clear();
                    rerenderGrid();

                    SudokuCell cell = grid[g.indices.row, g.indices.col];
                    cell.eliminateNumber(g.guess);
                    if(cell.asSCS.possibilities == 1) {
                        activateNumberInCell(g.indices.row, g.indices.col, cell.value, type: "g");
                        cellsToElimPoss.Clear();
                        cellsToElimPoss.AddFirst(g.indices);
                        cellsToRender.Clear();
                        txtLog.AppendText(cell.value + " is left as the only possible value for cell " + g.indices.ToString() + '.');
                        // eliminateNumber() queues the cell to `cellsToUpdate` then activateNumberInCell(). 
                        // But we're doing that here so clear the queue. 
                    }
                    txtLog.AppendText("\r\n");
                    return false;
                }
            }
            return true;
        }
        
        private static List<int> findOneOfs(DictionaryPossible dp1, DictionaryPossible dp2, DictionaryPossible dp3) {
            List<int> result = new List<int>();
            for(int number = 1; number <= 9; number++)
                if(1 == boolSum(dp1.isPossible(number), dp2.isPossible(number), dp3.isPossible(number)))
                    result.Add(number);

            return result;
        }

        private static int boolSum(bool b1, bool b2, bool b3) {
            int sum = b1 ? 1 : 0;
            sum += b2 ? 1 : 0;
            sum += b3 ? 1 : 0;
            return sum;
        }

        private static void addLocations(List<CellIndices>[] locations, SudokuCellSolve cell) {
            int[] possNumbers = cell.getPossible.possibleNumbers;
            foreach(int number in possNumbers)
                locations[number].Add(cell.getCellIndicies);
        }

        private void frmMain_Resize(object sender, EventArgs e) {
            const int formWidth = 792;
            const int formHeight = 418;
            const int textWidth = 372;
            const int textHeight = 355;

            txtLog.Width = textWidth + (this.Width - formWidth);
            txtLog.Height = textHeight + (this.Height - formHeight);
        }

        // Project Euler Problem 96
        private void btnEuler_Click(object sender, EventArgs e) {
            string path = @"C:\Users\Grant\Documents\Docs\p096_sudoku.txt";
            string[] contents = System.IO.File.ReadAllLines(path);
            long sum = 0;
            for(int puzzle = 0; puzzle < 50; puzzle++) {
                Console.Write("Puzzle " + (puzzle + 1) + ": ");
                resetForm();
                readPuzzle(contents, puzzle * 10);
                
                highlightFixedGray();
                fillPossibles();
                solveStep1();
                btnStep.Enabled = btnStep.Visible = true;
                solve();
                if(cellsLeft > 0) {
                    txtLog.AppendText("Failed on puzzle " + (puzzle + 1));
                    return;
                }

                //this.SuspendLayout();
                //this.ResumeLayout();

                sum += grid[0, 0].value * 100 + grid[0, 1].value * 10 + grid[0, 2].value;
            }
            txtLog.Text = "Sum: " + sum;
        }

        private void readPuzzle(string[] contents, int startingLine) {
            cellsLeft = 81;

            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++) {
                    char digit = contents[startingLine + 1 + row][col];
                    if(digit == '0')
                        grid[row, col] = new SudokuCellSolve(row, col);
                    else {
                        grid[row, col] = new SudokuCellFixed(digit + 1 - '1');
                        cellsLeft--;
                        dgvSoduku.Rows[row].Cells[col].Value = "" + (digit + 1 - '1');
                    }
                }

            cellsToElimPoss = new LinkedList<CellIndices>();
            cellsToRender = new Queue<CellIndices>();
            guesses = new Stack<GuessCell>();
            step = 1;
            haveInputtedGrid = true;
        }

        private int[,] readPuzzleArray(string[] contents, int startingLine) {
            int[,] numbers = new int[9, 9];
            for(int row = 0; row < 9; row++)
                for(int col = 0; col < 9; col++) {
                    char digit = contents[startingLine + 1 + row][col];
                    if(digit != '0')
                        numbers[row, col] = (digit + 1 - '1');
                }
            return numbers;
        }

        private void btnCheckSol_Click(object sender, EventArgs e) {
            bool valid = checkForValidity();
            MessageBox.Show(valid.ToString());
        }

        private bool checkForValidity() {
            // returns true if the current configuration is a complete, valid solution. 
            // aka returns true if each row, column, and mini-block is a complete, valid set.
            for(int i = 0; i < 9; i++) {
                SetChecker rowSet = new SetChecker();
                SetChecker colSet = new SetChecker();
                SetChecker mbSet = new SetChecker();
                for(int j = 0; j < 9; j++) {
                    rowSet.addNumber(grid[i, j].value);
                    colSet.addNumber(grid[j, i].value);
                    int mbRow = i / 3 * 3 + j / 3, mbCol = i % 3 * 3 + j % 3;
                    mbSet.addNumber(grid[mbRow, mbCol].value);
                }

                if(!rowSet.validSet || !colSet.validSet || !mbSet.validSet)
                    return false;
            }
            return true;
        }

        private ViolationInfo checkForViolations() {
            // returns true if each row, column, and mini-block is a valid possibility. 
            for(int i = 0; i < 9; i++) {
                ViolationChecker rowChecker = new ViolationChecker();
                ViolationChecker colChecker = new ViolationChecker();
                ViolationChecker mbChecker = new ViolationChecker();
                for(int j = 0; j < 9; j++) {
                    rowChecker.addValue(grid[i, j].valueRaw);
                    if(grid[i, j] is SudokuCellSolve) 
                        rowChecker.addPossibilities(grid[i, j].asSCS.getPossible);

                    colChecker.addValue(grid[j, i].valueRaw);
                    if(grid[j, i] is SudokuCellSolve)
                        colChecker.addPossibilities(grid[j, i].asSCS.getPossible);

                    int mbRow = i / 3 * 3 + j / 3, mbCol = i % 3 * 3 + j % 3;
                    mbChecker.addValue(grid[mbRow, mbCol].valueRaw);
                    if(grid[mbRow, mbCol] is SudokuCellSolve)
                        mbChecker.addPossibilities(grid[mbRow, mbCol].asSCS.getPossible);
                }

                ViolationInfo violation = rowChecker.isValid;
                if(violation != null) {
                    violation = rowChecker.isValid;
                    violation.grouping = ViolationInfo.Grouping.row;
                    violation.groupingArea = i;
                    return violation;
                }

                violation = colChecker.isValid;
                if(violation != null) {
                    violation = colChecker.isValid;
                    violation.grouping = ViolationInfo.Grouping.column;
                    violation.groupingArea = i;
                    return violation;
                }

                violation = mbChecker.isValid;
                if(violation != null) {
                    violation = mbChecker.isValid;
                    violation.grouping = ViolationInfo.Grouping.miniblock;
                    violation.groupingArea = i;
                    return violation;
                }
            }
            return null;
        }

        private void resetForm() {
            txtLog.Text = "";
            dgvSoduku.Rows.Clear();
            dgvSoduku.Rows.Add(9);
            for(int i = 1; i <= 9; i++)
                dgvSoduku.Rows[i - 1].HeaderCell.Value = "Row " + i;
        }

        private void resetSolvingVars() {
            grid = new SudokuCell[9, 9];
            cellsToElimPoss = new LinkedList<CellIndices>();
            cellsToRender = new Queue<CellIndices>();
            cellsLeft = 81;
            step = 1;
            haveInputtedGrid = false;
            guesses = new Stack<GuessCell>();
        }

        private void btnCheckVi_Click(object sender, EventArgs e) {
            MessageBox.Show(checkForViolations()?.ToString() ?? "No violations");
        }

        private void btnProjEul2_Click(object sender, EventArgs e) {
            string path = @"C:\Users\Grant\Documents\Docs\p096_sudoku.txt";
            string[] contents = System.IO.File.ReadAllLines(path);

            int puzzle = (int)nudEulProb.Value - 1;
            Console.Write("Puzzle " + (puzzle + 1) + ": ");
            resetForm();
            //readPuzzle(contents, puzzle * 10);
            loadArray(readPuzzleArray(contents, puzzle * 10));

            //highlightFixedGray();
            //fillPossibles();
            //solveStep1();
            //btnStep.Enabled = btnStep.Visible = true;
            //solve();
            //if(cellsLeft > 0) {
            //    txtLog.AppendText("Failed on puzzle " + (puzzle + 1));
            //    return;
            //}

            //this.SuspendLayout();
            //this.ResumeLayout();

            
        }

        /* 
        // Add a handler for cell text editing
        private static bool shouldAddEditHandle = true;
        private void dgvSoduku_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            if(shouldAddEditHandle) {
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
                //tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                tb.TextChanged += new EventHandler(dataGridViewTextBox_TextChanged);
                shouldAddEditHandle = false;
            }
        }
        
        private void dataGridViewTextBox_TextChanged(object sender, EventArgs e) {
            // If there is one valid digit in the cell, move to the next cell
            int row = dgvSoduku.CurrentCell.RowIndex, col = dgvSoduku.CurrentCell.ColumnIndex;
            if(row >= 0 && col >= 0) {
                dgvSoduku.EndEdit();
                DataGridViewCell cell = dgvSoduku.Rows[row].Cells[col];
                object cellValue = dgvSoduku.CurrentCell.EditedFormattedValue;

                if(cellValue != null) {
                    int intCV;
                    if(int.TryParse(cellValue.ToString(), out intCV) && intCV >= 1 && intCV <= 9) {
                        int newLocation = 9 * row + col + 1;
                        dgvSoduku.Rows[row].Cells[col].Value = cellValue.ToString();
                        try {
                            //dgvSoduku.CurrentCell = dgvSoduku.Rows[newLocation / 9].Cells[newLocation % 9];
                            dgvSoduku.Rows[newLocation / 9].Cells[newLocation % 9].Selected = true;
                            dgvSoduku.BeginEdit(true);
                        } catch(InvalidOperationException ex) {
                            Console.Write("");
                        } catch(NullReferenceException ex) {
                            Console.Write("");
                        }
                    }
                }
            }
        }
        */
    }
}
