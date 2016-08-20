using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AgusRdz_TFS_TestCaseExportTool
{
    public partial class frmMain : Form
    {
        // Detectar una colección de proyectos.
        // Proporcionar las credenciales del usuario.
        private TfsTeamProjectCollection _tfs;
        private ITestManagementTeamProject _teamProject;
        private ITestPlanCollection plans;
        private ITestCaseCollection testCases;
        private WorkItemStore _store = null;
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        Excel.Range chartRange;
        object misValue = System.Reflection.Missing.Value;
        int row = 2;
        int upperBound = 0;
        int lowerBound = 0;
        int sheetNum = 1;
        int defaultSheets = 0;

        private delegate void Execute();

        public frmMain()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int derecha, izquierda, superior, inferior;
        }
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins margs);

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.Color.Gray;
            Margins margenes = new Margins();
            margenes.derecha = -1;
            margenes.izquierda = -1;
            margenes.superior = -1;
            margenes.inferior = -1;
            IntPtr hwn = this.Handle;
            //int result = DwmExtendFrameIntoClientArea(hWnd, ref margenes);

        }

        /// <summary>
        /// Permite seleccionar el proyacto de Visual Studio al que se quiere conectar
        /// para realizar la exportación
        /// </summary>
        private void btnTeamProject_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            // Muestra un cuadro de dialogo con los proyectos disponibles
            TeamProjectPicker tpp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);
            tpp.ShowDialog();

            // Si se selecciona un proyecto
            if (tpp.SelectedTeamProjectCollection != null)
            {
                this._tfs = tpp.SelectedTeamProjectCollection;
                ITestManagementService test_service = (ITestManagementService)_tfs.GetService(typeof(ITestManagementService));
                _store = (WorkItemStore)_tfs.GetService(typeof(WorkItemStore));
                this._teamProject = test_service.GetTeamProject(tpp.SelectedProjects[0].Name);

                // Mostrar el nombre del proyecto seleccionado
                txtTeamProject.Text = tpp.SelectedProjects[0].Name;
                // Recuperar los planes de prueba existentes
                Get_TestPlans(_teamProject);
            }
        }

        /// <sumary>    
        /// Recupera los planes de prueba que estan contenidos en el proyecto
        /// </sumary>
        private void Get_TestPlans(ITestManagementTeamProject teamProject)
        {
            // Consultar los planes
            this.plans = teamProject.TestPlans.Query("SELECT * FROM TestPlan");
            // Mostrar los planes en el combobox
            comBoxTestPlan.Items.Clear();
            // Llenar el árbol con las suites
            treeView_suite.BackColor = Color.White;
            foreach (ITestPlan plan in plans)
            {
                comBoxTestPlan.Items.Add(plan.Name);
            }
        }

        /// <summary>
        /// Mostrar las suites contenidas en los planes de prueba
        /// </summary>
        private void comBoxTestPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            treeView_suite.Nodes.Clear();
            int i = -1;
            if (comBoxTestPlan.SelectedIndex >= 0)
            {
                i = comBoxTestPlan.SelectedIndex;
                this.Cursor = Cursors.Arrow;
                if (plans[i].RootSuite != null)
                {
                    TreeNode rootNode = new TreeNode();
                    rootNode.Name = plans[i].RootSuite.Id.ToString();
                    rootNode.Text = plans[i].RootSuite.Title.ToString();
                    treeView_suite.Nodes.Add(rootNode);
                    if (plans[i].RootSuite.SubSuites != null && plans[i].RootSuite.SubSuites.Count > 0)
                    {
                        Get_subsuites(plans[i].RootSuite, rootNode);
                    }
                }
            }
        }

        /// <sumary>
        /// Muestra las subsuites contenidas en la suite primaria
        /// </sumary>
        private void Get_subsuites(IStaticTestSuite rootsuite1, TreeNode node1)
        {
            ITestSuiteCollection subsuite1 = rootsuite1.SubSuites;
            foreach (ITestSuiteBase suite in subsuite1)
            {
                if (suite != null)
                {
                    TreeNode subnode = new TreeNode();
                    subnode.Text = suite.Title.ToString();
                    subnode.Name = suite.Id.ToString();
                    node1.Nodes.Add(subnode);
                    if (suite.TestSuiteType == TestSuiteType.StaticTestSuite)
                    {
                        IStaticTestSuite subsuite2 = suite as IStaticTestSuite;
                        if (subsuite2 != null && (subsuite2.SubSuites.Count > 0))
                        {
                            Get_subsuites(subsuite2, subnode);
                        }
                    }
                }
            }
        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = null;
            folderBrowserDialog.ShowDialog();
            txtSaveFolder.Text = folderBrowserDialog.SelectedPath;

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (NoSubSuite.Checked == true)
            {
                SeparateSheets.Checked = false;
                SeparateSheets.Enabled = false;
            }
            if (NoSubSuite.Checked == false)
            {
                SeparateSheets.Enabled = true;
            }
        }


        private string removehtmltags(string text)
        {
            //text = text.Replace("</P><P>", System.Environment.NewLine);
            text = Regex.Replace(text, "<.*?>", "");
            text = text.Replace("&#160;", "");

            return text;
        }
        private string formatsheetname(string str)
        {
            str = str.Replace("/", "");
            str = str.Replace("\\", "");
            str = str.Replace(":", "");
            str = str.Replace("?", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("*", "");

            if (str.Length > 30)
                str = str.Substring(0, 30);

            return str;

        }

        private void Get_TestCases(ITestSuiteBase testSuite)
        {
            this.testCases = testSuite.AllTestCases;
            if (NoSubSuite.Checked == true)
            {
                this.testCases.Clear();
                foreach (ITestSuiteEntry tse in testSuite.TestCases)
                {
                    if (tse.EntryType == TestSuiteEntryType.TestCase)
                    {
                        if (tse.TestCase != null)
                        {
                            testCases.Add(tse.TestCase);
                        }
                    }
                }
            }
        }


        private void export(Excel.Worksheet xlWorkSheet, ITestCaseCollection testcases)
        {
            xlWorkSheet.Cells[1, 1] = "TC No";
            xlWorkSheet.Cells[1, 2] = "Test Case Title";
            xlWorkSheet.Cells[1, 3] = "Summary";
            xlWorkSheet.Cells[1, 4] = "Action";
            xlWorkSheet.Cells[1, 5] = "Expected Result";
            //xlWorkSheet.Cells[1, 6] = "Actual Result";
            xlWorkSheet.Cells[1, 6] = "Pass/Fail";
            xlWorkSheet.Cells[1, 7] = "Bug ID";
            xlWorkSheet.Cells[1, 8] = "Comments";

            (xlWorkSheet.Columns["A", Type.Missing]).ColumnWidth = 9;
            (xlWorkSheet.Columns["B", Type.Missing]).ColumnWidth = 35;
            (xlWorkSheet.Columns["C", Type.Missing]).ColumnWidth = 30;
            (xlWorkSheet.Columns["D", Type.Missing]).ColumnWidth = 50;
            (xlWorkSheet.Columns["E", Type.Missing]).ColumnWidth = 50;
            //(xlWorkSheet.Columns["F", Type.Missing]).ColumnWidth = 30;
            (xlWorkSheet.Columns["F", Type.Missing]).ColumnWidth = 12;
            (xlWorkSheet.Columns["G", Type.Missing]).ColumnWidth = 12;
            (xlWorkSheet.Columns["H", Type.Missing]).ColumnWidth = 20;

            foreach (ITestCase testCase in testCases)
            {

                //upperBound = "a";
                //lowerBound = "a";
                //xlWorkSheet.Cells[row, col] = testCase.Title;

                upperBound = row;
                TestActionCollection testActions = testCase.Actions;
                var testResults = _teamProject.TestResults.ByTestId(testCase.Id);

                int i = 1;
                foreach (ITestAction action in testActions)
                {
                    ISharedStep shared_step = null;
                    ISharedStepReference shared_ref = action as ISharedStepReference;
                    if (shared_ref != null)
                    {
                        shared_step = shared_ref.FindSharedStep();
                        foreach (ITestAction shr_action in shared_step.Actions)
                        {
                            var stest_step = shr_action as ITestStep;
                            xlWorkSheet.Cells[row, 4] = removehtmltags(stest_step.Title.ToString());
                            xlWorkSheet.Cells[row, 5] = removehtmltags(stest_step.ExpectedResult.ToString());
                            xlWorkSheet.Cells[row, 1] = stest_step.Id.ToString();
                        }

                    }
                    else
                    {
                        var testStep = action as ITestStep;
                        xlWorkSheet.Cells[row, 4] = removehtmltags(testStep.Title.ToString());
                        xlWorkSheet.Cells[row, 5] = removehtmltags(testStep.ExpectedResult.ToString());
                        xlWorkSheet.Cells[row, 1] = testCase.Id.ToString() + "." + i;
                        row++;
                        i++;

                    }
                    if (ExportResults.Checked == true)
                    {
                        foreach (ITestCaseResult result in testResults)
                        {
                            int top = result.Iterations.Count;
                            if (top > 0)
                            {
                                var topIteration = result.Iterations[top];
                                if (topIteration == null)
                                    continue;
                                int actionindex = testActions.IndexOf(action.Id);
                                if (actionindex < topIteration.Actions.Count)
                                {
                                    var actionResult = topIteration.Actions[actionindex];
                                    if (actionResult.Outcome.ToString() != "None")
                                        xlWorkSheet.Cells[row, 6] = actionResult.Outcome.ToString();
                                    xlWorkSheet.Cells[row, 8] = actionResult.ErrorMessage.ToString();
                                }
                            }
                        }
                    }
                }
                lowerBound = (row - 1);

                xlWorkSheet.get_Range("c" + upperBound, "c" + lowerBound).Merge(false);
                chartRange = xlWorkSheet.get_Range("c" + upperBound, "c" + lowerBound);
                chartRange.FormulaR1C1 = removehtmltags(testCase.Description.ToString());

                xlWorkSheet.get_Range("b" + upperBound, "b" + lowerBound).Merge(false);
                chartRange = xlWorkSheet.get_Range("b" + upperBound, "b" + lowerBound);
                chartRange.FormulaR1C1 = testCase.Title.ToString();

                chartRange.HorizontalAlignment = 1;
                chartRange.VerticalAlignment = 1;

                //populate bugs

                if (ExportResults.Checked == true)
                {
                    Query query = new Query(_store, string.Format("SELECT [Target].[System.Id] FROM WorkItemLinks WHERE ([Source].[System.Id] = {0}) and ([Source].[System.WorkItemType] = 'Test Case')  And ([Target].[System.WorkItemType] = 'Bug')mode(MustContain)", testCase.Id));

                    WorkItemLinkInfo[] workItemLinkInfoArray = null;
                    if (query.IsLinkQuery)
                    {

                        workItemLinkInfoArray = query.RunLinkQuery();

                    }

                    else
                    {

                        throw new Exception("Run link query fail. Query passed is not a link query");

                    }
                    string bug_list = "";
                    bool multibug = false;
                    for (int k = 0; k < workItemLinkInfoArray.Length; k++)
                    {
                        if (workItemLinkInfoArray[k].LinkTypeId != 0)
                        {
                            if (multibug == true)
                            {
                                bug_list = bug_list + ",";
                            }
                            bug_list = bug_list + workItemLinkInfoArray[k].TargetId.ToString();
                            multibug = true;
                        }
                    }


                    xlWorkSheet.get_Range("G" + upperBound, "G" + lowerBound).Merge(false);
                    chartRange = xlWorkSheet.get_Range("G" + upperBound, "G" + lowerBound);
                    chartRange.FormulaR1C1 = bug_list;
                }


            }
            lowerBound = (row - 1);
            chartRange = xlWorkSheet.get_Range("H" + lowerBound, "H1");
            //chartRange.Font.Bold = true;
            //chartRange.Interior.Color = 18018018;


            chartRange = xlWorkSheet.get_Range("a1", "H" + lowerBound);
            chartRange.Cells.WrapText = true;
            chartRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


            //chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            chartRange = xlWorkSheet.get_Range("a1", "H1");
            chartRange.Borders.LineStyle = Excel.XlLineStyle.xlDouble;
            chartRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            chartRange.Font.Bold = true;

            row = 2;
            upperBound = 0;
            lowerBound = 0;

        }

        int i = 0;
        private void exportmultisheet(ITestSuiteBase itsb, Excel.Workbook xlBook)
        {


            bool testcasefound = false;

            foreach (ITestSuiteEntry tse in itsb.TestCases)
            {
                if (tse.EntryType == TestSuiteEntryType.TestCase)
                {
                    if (tse.TestCase != null)
                    {

                        testCases.Add(tse.TestCase);
                        testcasefound = true;
                    }
                }
            }
            if (testcasefound == true)
            {
                i++;

                if (sheetNum > defaultSheets)
                {

                    xlBook.Sheets.Add(Type.Missing, xlBook.Sheets[sheetNum - 1], Type.Missing, Type.Missing);

                }
                xlWorkSheet = (Excel.Worksheet)xlBook.Worksheets.get_Item(sheetNum);
                //xlWorkSheet.Name = formatsheetname(itsb.Title);
                xlWorkSheet.Name = formatsheetname(Convert.ToString(i));
                export(xlWorkSheet, testCases);
                sheetNum++;
                testcasefound = false;
                testCases.Clear();
            }


            if (itsb.TestSuiteType == TestSuiteType.StaticTestSuite)
            {
                IStaticTestSuite staticsuite = itsb as IStaticTestSuite;
                foreach (ITestSuiteBase tse in staticsuite.SubSuites)
                {
                    exportmultisheet(tse, xlBook);
                }
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != null && txtFileName.Text != "" && treeView_suite.SelectedNode != null && txtSaveFolder.Text != null && txtSaveFolder.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                btnExport.Enabled = false;
                btnCancel.Enabled = false;
                btnHelp.Enabled = false;
                btnTeamProject.Enabled = false;
                btnFolderBrowse.Enabled = false;
                comBoxTestPlan.Enabled = false;
                int k;
                xlApp = new Excel.Application();
                k = Convert.ToInt32(treeView_suite.SelectedNode.Name.ToString());
                ITestSuiteBase suite1 = _teamProject.TestSuites.Find(k);
                Get_TestCases(suite1);
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                sheetNum = 1;
                defaultSheets = xlWorkBook.Sheets.Count;
                if (SeparateSheets.Checked == true)
                {

                    if (suite1.TestSuiteType.ToString() == "StaticTestSuite")
                    {

                        testCases.Clear();
                        exportmultisheet(suite1, xlWorkBook);

                    }
                }
                else
                {
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNum);
                    xlWorkSheet.Name = formatsheetname(suite1.Title);
                    if (testCases.Count > 0)
                    {
                        export(xlWorkSheet, testCases);
                        testCases.Clear();
                    }


                }



                try
                {
                    xlWorkBook.SaveAs(txtSaveFolder.Text + "\\" + txtFileName.Text + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlApp);
                    releaseObject(xlWorkBook);
                    releaseObject(xlWorkSheet);
                    this.Cursor = Cursors.Arrow;
                    btnExport.Enabled = true;
                    btnCancel.Enabled = true;
                    btnHelp.Enabled = true;
                    btnTeamProject.Enabled = true;
                    btnFolderBrowse.Enabled = true;
                    comBoxTestPlan.Enabled = true;
                    txtFileName.Text = "";
                    MessageBox.Show("Test Cases exported successfully to specified file.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    //txtTeamProject.Text = "";
                    //comBoxTestPlan.Items.Clear();

                    //txtSaveFolder.Text = "";

                }
                catch (Exception ex)
                {
                    if (ex.Message == "Cannot access '" + txtFileName.Text + ".xls'.")
                    {
                        MessageBox.Show("File with same name exists in specified location", "File Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtFileName.Text = "";
                    }
                    //else
                    //{
                    //MessageBox.Show("Application has encountered Fatal Errro. \nPlease contact your System Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }

            }
            else
            {
                MessageBox.Show("All fields are not populated.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
