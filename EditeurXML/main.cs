using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using System.Xml.Linq;

namespace EditeurXML
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        double resultat = 0;    // rapport nb noeuds treeview sur nb noeuds xml (% de la progressbar)
        double nbnoeud = 0;    // nombre de noeuds dans le treeview
        double nbnoeudxml = 0; // nombre de noeuds dans le xml
        TreeNode tNode;

        // Nouveau tread dédié au chargement du xml.
        // Le fichier xml sera chargé en arrière-plan.
        // Le tread principal n'étant pas sollicité
        // cela permet d'éviter le "ne répond pas" de windows.
        BackgroundWorker bgw1 = new BackgroundWorker();


        public delegate void Add(int i);
        /////////////////////////////////////// FORM LOAD
        private void main_Load(object sender, EventArgs e)
        {
            bgw1.DoWork += new DoWorkEventHandler(backgroundWorkerLoad_DoWork);
            bgw1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorkerLoad_ProgressChanged);
            bgw1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerLoad_RunWorkerCompleted);
            bgw1.WorkerReportsProgress = true;
            labelsur.Visible = false;
        }

        /////////////////////////////////////// CHARGER LE FICHIER XML DANS LE TREEVIEW
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; // initialisation
            nbnoeud = 0;
            nbnoeudxml = 0;
            labelsur.Visible = true;
            bgw1.RunWorkerAsync();  // démarrage du tread secondaire
        }

        private void FillTree()
        {
            try
            {
                var settings = new XmlReaderSettings();
                var doc = new XmlDocument();

                using (var sr = new StreamReader(@textBoxUrl.Text))
                {
                    using (var reader = XmlReader.Create(sr, settings))
                    {
                        doc.Load(reader);   // chargement du fichier xml
                        nbnoeudxml = doc.DocumentElement.GetElementsByTagName("*").Count;   // on compte les noeuds du fichier xml
                        nbnoeudxml++; // +1 car le noeud parent n'est pas pris en compte

                        treeViewXML.Nodes.Clear();  //initialisation du treeview
                        // on ajoute ensuite les noeuds du xml dans le treeview
                        // en utilisant le tread secondaire précédement crééé
                        treeViewXML.Invoke((MethodInvoker)(() => treeViewXML.Nodes.Add(new TreeNode(doc.DocumentElement.Name))));
                        TreeNode tNode = new TreeNode();
                        tNode = treeViewXML.Nodes[0];
                        AddNode(doc.DocumentElement, tNode);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Le chemin d'accès ou le fichier à charger est invalide");
            }
        }

        // La fonction AddNode permet d'ajouter un noeud du fichier xml au treeview
        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nbnoeud++;  // on compte en même temps le nombre de noeuds du treeview
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    treeViewXML.Invoke((MethodInvoker)(() => inTreeNode.Nodes.Add(new TreeNode(xNode.Name))));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                    
                    // On calcule au fur et à mesure le nombre de noeuds du treeview
                    // sur le nombre de noeuds du xml
                    // cela nous donne un pourcentage utilisé par la progressbar
                    resultat = ((nbnoeud) / (nbnoeudxml) * 100);
                    if (resultat > 100) // mesure de sécurité au cas où la progressbar dépasserais sa valeur max (ça ne devrait pas arriver)
                    {
                        resultat = 100;
                    }
                    // deux labels nous donnent l'avancement précis du rapport
                    treeViewXML.Invoke((MethodInvoker)(() => labelnbnoeud.Text = nbnoeud.ToString()));
                    treeViewXML.Invoke((MethodInvoker)(() =>labelnbnoeudxml.Text = nbnoeudxml.ToString()));
                    // la progressbar donne l'avancement global
                    treeViewXML.Invoke((MethodInvoker)(() => progressBar1.Value = Convert.ToInt32(resultat)));
                }
            }
            else
            {
                treeViewXML.Invoke((MethodInvoker)(() => inTreeNode.Text = (inXmlNode.OuterXml).Trim()));
            }
        }
        public void Add1(int i)
        {
            tNode = treeViewXML.Nodes.Add(i.ToString());
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////////////////////////// PARCOURIR L'ARBORESCENCE DU DISQUE
        private void button2_Click(object sender, EventArgs e)
        {
            treeViewXML.Nodes.Clear();  // initialisation du treeview
            textBoxUrl.Text = "";       // initialisation du textbox
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = "mif";
            openFile.Filter = "Fichier XML (*.xml)|*.xml";  // seuls les fichiers .xml apparaissent
            openFile.ShowDialog();
            if (openFile.FileNames.Length > 0)
            {
                foreach (string filename in openFile.FileNames)
                {
                    textBoxUrl.Text = filename;
                }
            }
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////////////////////////// EVENEMENT CLIC DROIT SUR UN NOEUD DU TREEVIEW
        private void treeViewXML_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // si clic-droit
            {
                treeViewXML.SelectedNode = treeViewXML.GetNodeAt(e.X, e.Y); // le noeud sur la position du clic est selectionné

                if (treeViewXML.SelectedNode != null)
                {
                    contextMenuStrip1.Show(treeViewXML, e.Location);    // sinon on selectionne le noeud le plus proche
                }
            }
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////////////////////////// MENU CONTEXTUEL CREER RENOMMER SUPPRIMER
        private void toolStripMenuItemCreer_Click(object sender, EventArgs e)
        {
            treeViewXML.SelectedNode.Nodes.Add("Nouveau noeud");    // ajoute un noeud
            treeViewXML.SelectedNode.Expand();  // déploie son noeud parent
            treeViewXML.SelectedNode.LastNode.BeginEdit(); // Edition du nom du nouveau noeud
        }
        private void toolStripMenuItemRenommer_Click(object sender, EventArgs e)
        {
            treeViewXML.LabelEdit = true;
            treeViewXML.SelectedNode.BeginEdit();  // Edition du nom du noeud        
        }
        private void toolStripMenuItemSupprimer_Click(object sender, EventArgs e)
        {
            treeViewXML.SelectedNode.Remove();  // supprenssion du noeud
        }
        ///////////////////////////////////////////////////////////////////
        /////////////////////////////////////// BACKGROUNDWORKER
        private void backgroundWorkerLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            // désactivation de tous les contrôles pendant le chargement
            treeViewXML.Invoke((MethodInvoker)(() => buttonCharger.Enabled = false));
            treeViewXML.Invoke((MethodInvoker)(() => buttonCharger.Text = "Chargement..."));
            treeViewXML.Invoke((MethodInvoker)(() => textBoxUrl.Enabled = false));
            treeViewXML.Invoke((MethodInvoker)(() => buttonParcourir.Enabled = false));
            treeViewXML.Invoke((MethodInvoker)(() => contextMenuStrip1.Enabled = false));

            FillTree();     //fonction de chargement du fichier xml

            // réactivation des contrôles
            treeViewXML.Invoke((MethodInvoker)(() => buttonCharger.Text = "Charger"));
            treeViewXML.Invoke((MethodInvoker)(() => buttonCharger.Enabled = true));
            treeViewXML.Invoke((MethodInvoker)(() => textBoxUrl.Enabled = true));
            treeViewXML.Invoke((MethodInvoker)(() => buttonParcourir.Enabled = true));
            treeViewXML.Invoke((MethodInvoker)(() => contextMenuStrip1.Enabled = true));
        }

        private void backgroundWorkerLoad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        ///////////////////////////////////////////////////////////////////

    }
}