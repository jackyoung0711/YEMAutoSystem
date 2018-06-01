using System.Collections.Generic;
using System.Windows.Forms;

namespace JYM.AutoSystem
{
    //创建对象
    public class CreateContextMenuStripInstance
    {
        private readonly ContextMenuStrip _cst;

        public CreateContextMenuStripInstance()
        {
            this._cst = new ContextMenuStrip();
        }

        //添加ToolStripMenuItem
        public void AddToolStripMenuItems(IEnumerable<ToolStripMenuItem> list)
        {
            foreach (ToolStripMenuItem t in list)
            {
                this._cst.Items.Add(t);
            }
        }

        public ContextMenuStrip GetContexMenuStrip()
        {
            return this._cst;
        }
    }
}