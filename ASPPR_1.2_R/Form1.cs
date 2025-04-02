using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ASPPR_1._2_R
{
    public partial class Form1 : Form
    {
        private string logText = "";

        public Form1()
        {
            InitializeComponent();
        }

        double[,] ModifiedJordanElimination(double[,] matrix, int r, int s)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] newMatrix = (double[,])matrix.Clone();
            double originalPivot = matrix[r, s];

            logText += $"Розв’язувальний елемент: [{r}, {s}] = {originalPivot:F2}\n";

            newMatrix[r, s] = 1.0;

            for (int i = 1; i < rows; i++)
            {
                if (i != r)
                {
                    newMatrix[i, s] = -newMatrix[i, s];
                }
            }

            for (int i = 1; i < rows; i++)
            {
                if (i == r) continue;
                for (int j = 1; j < cols; j++)
                {
                    if (j == s) continue;
                    newMatrix[i, j] = (matrix[i, j] * originalPivot) - (matrix[i, s] * matrix[r, j]);
                }
            }

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    newMatrix[i, j] /= originalPivot;
                }
            }

            SwapElements(newMatrix, r, 0, 0, s);

            logText += "Матриця після виконання МЖВ:\n" + MatrixToString(newMatrix);

            return newMatrix;
        }

        public void SwapElements(double[,] array, int row1, int col1, int row2, int col2)
        {
            double temp = array[row1, col1];
            array[row1, col1] = array[row2, col2];
            array[row2, col2] = temp;
        }
        private string MatrixToString(double[,] matrix)
        {
            string result = "";
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    result += matrix[i, j].ToString("F2") + " ";
                }
                result += "\n";
            }
            return result;
        }

        private string SolutionToString(double[] solution)
        {
            string result = "";
            int cols = solution.GetLength(0);
            for (int j = 0; j < cols; j++)
            {
                result += solution[j].ToString("F2") + " ";
            }
            result += "\n";
            return result;
        }

        private void SolveLinearProgrammingProblem(double[] objectiveFunction, double[,] constraints, int[] constraintTypes)
        {
            int numConstraints = constraintTypes.Length;
            int cols = constraints.GetLength(1);
            int rows = constraints.GetLength(0);
            int n = cols - 1;
            double[] x = new double[(int)numVar.Value];
            double[,] transformedConstraints = new double[numConstraints + 1, cols];
            double[,] simplexTable = new double[numConstraints+2, cols+1];

            logText = "Перепишемо систему обмежень:\n";

            for (int i = 0; i < numConstraints; i++)
            {
                if (constraintTypes[i] == 1)
                {
                    transformedConstraints[i, n] = constraints[i, n];
                    for (int k = 0; k < n; k++)
                    {
                        transformedConstraints[i, k] = constraints[i, k] * -1;
                    }
                }
                else
                {
                    transformedConstraints[i, n] = -constraints[i, n];
                    for (int k = 0; k < n; k++)
                    {
                        transformedConstraints[i, k] = constraints[i, k];
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    logText += $"{transformedConstraints[i, j]:F2} * X[{j+1}]";
                    transformedConstraints[i, j] *= -1;
                    if(j < n-1)
                    {
                        logText += " + ";
                    }
                    else
                    {
                        logText += $" + {transformedConstraints[i, cols-1]} >= 0\n";
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                transformedConstraints[numConstraints, i] = objectiveFunction[i] * -1;
            }

            for (int i = 0; i < cols + 1; i++)
            {
                simplexTable[0, i] = i;
                if (i == cols)
                {
                    simplexTable[0, i] = 1;
                }
            }

            for (int i = 0; i < numConstraints+2; i++)
            {
                simplexTable[i, 0] = -i;
            }

            for (int i = 1; i < numConstraints+2; i++)
            {
                for (int j = 1; j < cols+1; j++)
                {
                    simplexTable[i, j] = transformedConstraints[i-1, j-1];
                }
            }

            (x, simplexTable) = FindSupportSolution(simplexTable);
            logText += "Знайдено опорний розв'язок: " + SolutionToString(x);
            textSupportSolution.Text = SolutionToString(x);

            (x, simplexTable) = FindOptimalSolution(simplexTable);
            logText += "Знайдено оптимальний розв'язок: " + SolutionToString(x);
            textOptimalSolution.Text = SolutionToString(x);

            logText += $"\nMax (Z) = {simplexTable[numConstraints + 1, cols]}";
            textZ.Text = simplexTable[numConstraints + 1, cols].ToString("F2");

            if (checkBoxSaveLog.Checked)
            {
                SaveLogToFile();
            }
        }

        private (double[], double[,]) FindSupportSolution(double[,] simplexTable)
        {
            int rows = simplexTable.GetLength(0);
            int cols = simplexTable.GetLength(1);
            double[] x = new double[(int)numVar.Value];
            double[,] newSimplexTable = (double[,])simplexTable.Clone();

            int pivotRow;
            int pivotCol;
            double minRatio;

            while (true)
            {
                pivotRow = -1;
                pivotCol = -1;
                simplexTable = (double[,])newSimplexTable.Clone();
                minRatio = double.MaxValue;

                for (int i = 1; i < rows; i++)
                {
                    if (simplexTable[i, cols - 1] < 0)
                    {
                        pivotRow = i;
                        break;
                    }
                }

                if (pivotRow == -1) break;

                for (int i = 1; i < cols + 1; i++)
                {
                    if (simplexTable[pivotRow, i] < 0)
                    {
                        pivotCol = i;
                        break;
                    }
                }

                if (pivotCol == -1) break;

                for (int i = 1; i < rows; i++)
                {
                    simplexTable[i, cols - 1] /= simplexTable[i, pivotCol];
                }

                for (int i = 1; i < rows; i++)
                {
                    if (simplexTable[i, cols - 1] < minRatio && simplexTable[i, cols - 1] > 0 && simplexTable[i,pivotCol] > 0)
                    {
                        minRatio = simplexTable[i, cols - 1];
                        pivotRow = i;
                    }
                }

                newSimplexTable = ModifiedJordanElimination(newSimplexTable, pivotRow, pivotCol);

                for (int i = 1; i < rows; i++)
                {
                    if (newSimplexTable[i, 0] > 0)
                    {
                        x[(int)newSimplexTable[i, 0] - 1] = newSimplexTable[i, cols - 1];
                    }
                }
            }
            return (x, newSimplexTable);
        }

        private (double[], double[,]) FindOptimalSolution(double[,] simplexTable)
        {
            int rows = simplexTable.GetLength(0);
            int cols = simplexTable.GetLength(1);
            double[] x = new double[(int)numVar.Value];
            double[,] newSimplexTable = (double[,])simplexTable.Clone();

            int pivotRow;
            int pivotCol;
            double minRatio;
            while (true)
            {
                pivotCol = -1;
                pivotRow = -1;
                simplexTable = (double[,])newSimplexTable.Clone();
                minRatio = double.MaxValue;

                for (int i = 1; i < cols; i++)
                {
                    if (simplexTable[rows-1, i] < 0)
                    {
                        if (pivotCol == -1)
                        {
                            pivotCol = i;
                            break;
                        }
                    }

                }

                if (pivotCol == -1) break;

                for (int i = 1; i < rows; i++)
                {
                    simplexTable[i, cols - 1] /= simplexTable[i, pivotCol];
                }

                for (int i = 1; i < rows; i++)
                {
                    if (simplexTable[i, cols - 1] < minRatio && simplexTable[i, cols - 1] >= 0 && simplexTable[i, pivotCol] > 0)
                    {
                        minRatio = simplexTable[i, cols - 1];
                        pivotRow = i;
                    }
                }

                newSimplexTable = ModifiedJordanElimination(newSimplexTable, pivotRow, pivotCol);

                x = new double[(int)numVar.Value];

                for(int i = 1; i < rows; i++)
                {
                    if (newSimplexTable[i, 0] > 0)
                    {
                        x[(int)newSimplexTable[i, 0] - 1] = newSimplexTable[i, cols - 1];
                    }
                }

            }
            return (x, newSimplexTable);
        }

        private void buttonSolve_Click(object sender, EventArgs e)
        {
            double[,] constraints = ParseConstraints(textConstraints.Text);
            double[] objectiveFunction = ParseObjective(textObjective.Text);
            int[] constraintTypes = ParseConstraintTypes(textConstraints.Text);
            SolveLinearProgrammingProblem(objectiveFunction, constraints, constraintTypes);
        }

        private double[,] ParseConstraints(string input)
        {
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int numRows = lines.Length;
            int numCols = 0;

            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, @"[+-]?\d*x\d+");
                numCols = Math.Max(numCols, matches.Count);
            }

            double[,] matrix = new double[numRows, numCols + 1];

            for (int i = 0; i < numRows; i++)
            {
                var matches = Regex.Matches(lines[i], @"([+-]?\d*)x(\d+)");
                foreach (Match match in matches)
                {
                    int coefficient = match.Groups[1].Value == "-" ? -1 :
                                      string.IsNullOrEmpty(match.Groups[1].Value) || match.Groups[1].Value == "+" ? 1 :
                                      int.Parse(match.Groups[1].Value);
                    int index = int.Parse(match.Groups[2].Value) - 1;
                    matrix[i, index] = coefficient;
                }

                var rhsMatch = Regex.Match(lines[i], @"[<>]=\s*(-?\d+)");
                if (rhsMatch.Success)
                {
                    matrix[i, numCols] = double.Parse(rhsMatch.Groups[1].Value);
                }
            }

            return matrix;
        }

        private int[] ParseConstraintTypes(string input)
        {
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int[] constraintTypes = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("<="))
                {
                    constraintTypes[i] = 1;
                }
                else if (lines[i].Contains(">="))
                {
                    constraintTypes[i] = -1;
                }
                else if (lines[i].Contains("="))
                {
                    constraintTypes[i] = 0;
                }
                else
                {
                    throw new ArgumentException("Невірний формат обмежень");
                }
            }

            return constraintTypes;
        }

        private double[] ParseObjective(string input)
        {
            var matches = Regex.Matches(input, @"([+-]?\d*)x(\d+)");
            int numVars = (int)numVar.Value;

            double[] coefficients = new double[numVars];

            foreach (Match match in matches)
            {
                int coefficient = match.Groups[1].Value == "-" ? -1 :
                                  string.IsNullOrEmpty(match.Groups[1].Value) || match.Groups[1].Value == "+" ? 1 :
                                  int.Parse(match.Groups[1].Value);
                int index = int.Parse(match.Groups[2].Value) - 1;
                coefficients[index] = coefficient;
            }

            return coefficients;
        }

        private void SaveLogToFile()
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = Path.Combine(folderDialog.SelectedPath, "log.txt");
                    File.WriteAllText(filePath, logText);
                    MessageBox.Show("Лог збережено: " + filePath, "Збереження логу", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
