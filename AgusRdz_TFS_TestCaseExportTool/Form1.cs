using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        Excel.Range chartRange;
        object misValue = System.Reflection.Missing.Value;
        int row = 2;
        int upperBound = 0;
        int lowerBound = 0;
        int sheetNum = 1;
        int defaultSheets;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
