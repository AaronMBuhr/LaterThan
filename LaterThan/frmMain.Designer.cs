namespace LaterThan
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textboxStartPath =  new TextBox() ;
            datetimepickerStartDate =  new DateTimePicker() ;
            filesDataGridView =  new DataGridView() ;
            buttonExport =  new Button() ;
            ( (System.ComponentModel.ISupportInitialize) filesDataGridView  ).BeginInit();
            SuspendLayout();
            // 
            // textboxStartPath
            // 
            textboxStartPath.Location =  new Point( 55, 106 ) ;
            textboxStartPath.Name =  "textboxStartPath" ;
            textboxStartPath.Size =  new Size( 690, 43 ) ;
            textboxStartPath.TabIndex =  0 ;
            textboxStartPath.DoubleClick +=  textboxStartPath_DoubleClick ;
            // 
            // datetimepickerStartDate
            // 
            datetimepickerStartDate.Location =  new Point( 55, 39 ) ;
            datetimepickerStartDate.Name =  "datetimepickerStartDate" ;
            datetimepickerStartDate.Size =  new Size( 450, 43 ) ;
            datetimepickerStartDate.TabIndex =  2 ;
            // 
            // filesDataGridView
            // 
            filesDataGridView.AllowUserToAddRows =  false ;
            filesDataGridView.AllowUserToDeleteRows =  false ;
            filesDataGridView.Anchor =      AnchorStyles.Top  |  AnchorStyles.Bottom   |  AnchorStyles.Left   |  AnchorStyles.Right   ;
            filesDataGridView.ColumnHeadersHeightSizeMode =  DataGridViewColumnHeadersHeightSizeMode.AutoSize ;
            filesDataGridView.EditMode =  DataGridViewEditMode.EditOnEnter ;
            filesDataGridView.Location =  new Point( 55, 197 ) ;
            filesDataGridView.Name =  "filesDataGridView" ;
            filesDataGridView.RowHeadersWidth =  92 ;
            filesDataGridView.RowTemplate.Height =  45 ;
            filesDataGridView.Size =  new Size( 1087, 687 ) ;
            filesDataGridView.TabIndex =  3 ;
            // 
            // buttonExport
            // 
            buttonExport.Location =  new Point( 884, 60 ) ;
            buttonExport.Name =  "buttonExport" ;
            buttonExport.Size =  new Size( 169, 52 ) ;
            buttonExport.TabIndex =  4 ;
            buttonExport.Text =  "Export" ;
            buttonExport.UseVisualStyleBackColor =  true ;
            buttonExport.Click +=  buttonExport_Click ;
            // 
            // frmMain
            // 
            AutoScaleDimensions =  new SizeF( 15F, 37F ) ;
            AutoScaleMode =  AutoScaleMode.Font ;
            ClientSize =  new Size( 1174, 958 ) ;
            Controls.Add( buttonExport );
            Controls.Add( filesDataGridView );
            Controls.Add( datetimepickerStartDate );
            Controls.Add( textboxStartPath );
            Name =  "frmMain" ;
            Text =  "LaterThan" ;
            ( (System.ComponentModel.ISupportInitialize) filesDataGridView  ).EndInit();
            ResumeLayout( false );
            PerformLayout();
        }

        #endregion



        private TextBox textboxStartPath;
        private DateTimePicker datetimepickerStartDate;
        private DataGridView filesDataGridView;
        private Button buttonExport;
    }
}