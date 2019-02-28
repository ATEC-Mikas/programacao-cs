using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LibGit2Sharp;

namespace Git_Client
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFolder_Click(object sender, EventArgs e)
        {
            if(DialogResult.OK == FolderBrowser.ShowDialog())
            {
                try
                {
                    foreach(string n in Directory.GetDirectories(FolderBrowser.SelectedPath))
                    {
                        if (Repository.IsValid(n))
                        {
                            
                            MessageBox.Show("Sucesso!","Git encontrado");
                            Repo = new Repository(n);
                            FolderBrowser.SelectedPath = String.Empty;
                            EstadoGit.PerformClick();
                            break;
                        }
                    }
                } catch(Exception erro)
                {
                    MessageBox.Show("Erro! " + erro.Message.ToString());
                }
            }
        }

        private void EstadoGit_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if(Repo!=null)
            {
                foreach (StatusEntry t in Repo.RetrieveStatus().Untracked)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.OrangeRed;
                    listView1.Items.Add(item);
                }
                foreach (StatusEntry t in Repo.RetrieveStatus().Modified)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.PaleVioletRed;
                    listView1.Items.Add(item);
                }
                foreach (StatusEntry t in Repo.RetrieveStatus().RenamedInIndex)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.LightGreen;
                    listView1.Items.Add(item);
                }
                foreach (StatusEntry t in Repo.RetrieveStatus().RenamedInWorkDir)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.LightGreen;
                    listView1.Items.Add(item);
                }
                foreach (StatusEntry t in Repo.RetrieveStatus().Staged)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.Green;
                    listView1.Items.Add(item);
                }
                foreach (StatusEntry t in Repo.RetrieveStatus().Added)
                {
                    ListViewItem item = new ListViewItem(t.FilePath);
                    item.BackColor = Color.LightGreen;
                    listView1.Items.Add(item);
                }
            } else
            {
                MessageBox.Show("Não tem nenhum Repositório aberto","AVISO");
            }

                
        }

        private void AddAll_Click(object sender, EventArgs e)
        {
            Commands.Stage(Repo, "*");
            EstadoGit.PerformClick();
        }
        
        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtCommit.Text))
            {
                Signature sign= new Signature(System.Security.Principal.WindowsIdentity.GetCurrent().Name, Environment.MachineName,DateTimeOffset.Now);
                Repo.Commit(txtCommit.Text, sign, sign);
            } else
            {
                MessageBox.Show("Mensagem de commit inválida!");
            }
        }
    }
}
