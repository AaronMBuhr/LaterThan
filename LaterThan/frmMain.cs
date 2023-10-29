namespace LaterThan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void PopulateDataGridView( List<SelectableFileInfo> files )
        {
            // Clear any existing rows and columns
            filesDataGridView.Rows.Clear();
            filesDataGridView.Columns.Clear();

            // Add a checkbox column
            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 50;
            checkboxColumn.ReadOnly = false;
            checkboxColumn.FillWeight = 10; // This makes the column width fixed
            checkboxColumn.ReadOnly = false;
            filesDataGridView.Columns.Add( checkboxColumn );

            // Add text columns
            filesDataGridView.Columns.Add( "Path", "Path" );
            filesDataGridView.Columns.Add( "FileName", "FileName" );
            filesDataGridView.Columns.Add( "CreatedDate", "Created Date" );
            filesDataGridView.Columns.Add( "ModifiedDate", "Modified Date" );
            filesDataGridView.Columns.Add( "Size", "Size" );

            foreach( var file in files )
            {
                // Add a row for the file
                int rowIndex = filesDataGridView.Rows.Add();
                filesDataGridView.Rows[rowIndex].Cells[0].Value = file.IsSelected;
                filesDataGridView.Rows[rowIndex].Cells[1].Value = Path.GetDirectoryName( file.Path );
                filesDataGridView.Rows[rowIndex].Cells[2].Value = file.Name;
                filesDataGridView.Rows[rowIndex].Cells[3].Value = file.CreatedDate;
                filesDataGridView.Rows[rowIndex].Cells[4].Value = file.ModifiedDate;
                filesDataGridView.Rows[rowIndex].Cells[5].Value = file.Size;
            }
        }

        private bool DataGridViewContains( DataGridView dgv, string name )
        {
            foreach( DataGridViewRow row in dgv.Rows )
            {
                if( row.Cells[0].Value.ToString().Trim() == name )
                {
                    return true;
                }
            }
            return false;
        }

        private async void textboxStartPath_DoubleClick( object sender, EventArgs e )
        {
            // Create a new FolderBrowserDialog instance.
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial directory to the current directory.
            folderBrowserDialog.InitialDirectory = Environment.CurrentDirectory;

            // Show the dialog box.
            DialogResult result = folderBrowserDialog.ShowDialog();

            // If the user clicked OK, get the selected directory path.
            if( result == DialogResult.OK )
            {
                textboxStartPath.Text = folderBrowserDialog.SelectedPath;
                this.Cursor = Cursors.WaitCursor;
                List<SelectableFileInfo> files = null;
                await Task.Run( () =>
                {
                    files = SelectableFileInfo.GetFiles( folderBrowserDialog.SelectedPath, datetimepickerStartDate.Value );
                } );

                PopulateDataGridView( files );
                this.Cursor = Cursors.Default;
            }
        }

        public List<SelectableFileInfo> GetSelectedFilesFromGrid()
        {
            List<SelectableFileInfo> files = new List<SelectableFileInfo>();

            foreach( DataGridViewRow row in filesDataGridView.Rows )
            {
                SelectableFileInfo file = new SelectableFileInfo();
                file.IsSelected = Convert.ToBoolean( row.Cells[0].Value );
                file.Path = Convert.ToString( row.Cells[1].Value );
                file.Name = Convert.ToString( row.Cells[2].Value );
                file.CreatedDate = Convert.ToDateTime( row.Cells[3].Value );
                file.ModifiedDate = Convert.ToDateTime( row.Cells[4].Value );
                file.Size = Convert.ToInt64( row.Cells[5].Value );

                files.Add( file );
            }

            return files;
        }

        private void buttonExport_Click( object sender, EventArgs e )
        {
            // Create a new SaveFileDialog instance.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set the default file name.
            // saveFileDialog.FileName = "MyTextFile.txt";

            // Set the filter to text files.
            saveFileDialog.Filter = "Text files (*.txt)|*.txt";

            // Show the dialog box.
            DialogResult result = saveFileDialog.ShowDialog();

            // If the user clicked OK, create or replace the text file.
            if( result == DialogResult.OK )
            {
                // Get the full file path.
                string filePath = saveFileDialog.FileName;

                var files = GetSelectedFilesFromGrid();
                if (files == null || files.Count == 0)
                {
                    MessageBox.Show( "No files avaiable." );
                    return;
                }

                // Create or replace the text file.
                using( StreamWriter fileStream = new StreamWriter( filePath ) )
                {
                    foreach( var file in files )
                    {
                        if( file.IsSelected )
                        {
                            fileStream.WriteLine(file.Path + Path.DirectorySeparatorChar + file.Name );
                        }
                    }
                }
                MessageBox.Show( "Exported." );
            }
        }
    }
}