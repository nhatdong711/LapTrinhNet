namespace Bai_5._4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            tvDepartments = new TreeView();
            cboView = new ComboBox();
            lsvEmployees = new ListView();
            imgIcons = new ImageList(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 35);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvDepartments);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(cboView);
            splitContainer1.Panel2.Controls.Add(lsvEmployees);
            splitContainer1.Size = new Size(800, 433);
            splitContainer1.SplitterDistance = 262;
            splitContainer1.TabIndex = 0;
            // 
            // tvDepartments
            // 
            tvDepartments.Location = new Point(0, 3);
            tvDepartments.Name = "tvDepartments";
            tvDepartments.Size = new Size(259, 427);
            tvDepartments.TabIndex = 0;
            tvDepartments.AfterSelect += tvDepartments_AfterSelect;
            // 
            // cboView
            // 
            cboView.DropDownStyle = ComboBoxStyle.DropDownList;
            cboView.FormattingEnabled = true;
            cboView.Location = new Point(3, 3);
            cboView.Name = "cboView";
            cboView.Size = new Size(528, 28);
            cboView.TabIndex = 1;
            cboView.SelectedIndexChanged += cboView_SelectedIndexChanged;
            // 
            // lsvEmployees
            // 
            lsvEmployees.FullRowSelect = true;
            lsvEmployees.GridLines = true;
            lsvEmployees.Location = new Point(3, 34);
            lsvEmployees.Name = "lsvEmployees";
            lsvEmployees.Size = new Size(528, 396);
            lsvEmployees.TabIndex = 0;
            lsvEmployees.UseCompatibleStateImageBehavior = false;
            lsvEmployees.View = View.Details;
            // 
            // imgIcons
            // 
            imgIcons.ColorDepth = ColorDepth.Depth32Bit;
            imgIcons.ImageSize = new Size(16, 16);
            imgIcons.TransparentColor = Color.Transparent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TreeView tvDepartments;
        private ComboBox cboView;
        private ListView lsvEmployees;
        private ImageList imgIcons;
    }
}
