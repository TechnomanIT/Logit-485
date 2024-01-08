using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.CustomControls
{
    public partial class EntityListBox : ListBox
    {
        EntityObjCollection items;
        DAL.Device_Config selectedEntity;


        public EntityListBox()
        {
            InitializeComponent();
        }
        public DAL.Device_Config SelectedEntity
        {
            get { return selectedEntity; }
        }


        public new int SelectedIndex
        {
            get { return base.SelectedIndex; }
            set { base.SelectedIndex = value; }
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
           
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }
            string s = this.SelectedItem.ToString();
            string[] splt = s.Split('_');
            selectedEntity = items[Convert.ToInt16( splt[0])];
            base.OnDoubleClick(e);
        }


        public EntityListBox(System.ComponentModel.IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }
        public new EntityObjCollection Items
        {
            get
            {
                if (items == null)
                {
                    items = new EntityObjCollection(this);
                }
                return items;
            }
        }        

        public class EntityObjCollection
        {
            Dictionary<int, DAL.Device_Config> entityDictionary = new Dictionary<int, DAL.Device_Config>();
            ListBox listBox;
            public EntityObjCollection(ListBox listBox)
            {
                this.listBox = listBox;                
            }

            public int Add(DAL.Device_Config masterBaseEntity)
            {
                int result = -1;
                try
                {
                    if (!entityDictionary.ContainsValue(masterBaseEntity))
                    {
                        entityDictionary.Add((int)masterBaseEntity.Device_Id, masterBaseEntity);
                        result = listBox.Items.Add(masterBaseEntity.Device_Id+"_"+ masterBaseEntity.Location+"_"+ masterBaseEntity.Instrument);
                        listBox.Refresh();
                    }                   
                }
                catch (Exception e)
                {                   
                    MessageBox.Show(((Form)listBox.Parent), e.Message);
                }
                return result;
            }

            public void Remove(DAL.Device_Config masterBaseEntity)
            {
                try
                {
                    if (masterBaseEntity != null)
                    {
                        entityDictionary.Remove((int)masterBaseEntity.Device_Id);
                        listBox.Items.Remove(masterBaseEntity.Location);    
                    }                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(((Form)listBox.Parent), e.Message);
                }
            }

            //public DAL.Device_Config this[int index]
            //{
            //    get
            //    {
            //        DAL.Device_Config masterBaseEntity = null;
            //        try
            //        {
            //            masterBaseEntity = entityDictionary[(int)listBox.Items[index]];
            //        }
            //        catch (Exception)
            //        {
            //        }
            //        return masterBaseEntity;
            //    }
            //}

            public DAL.Device_Config this[int name]
            {
                get
                {
                    DAL.Device_Config masterBaseEntity = null;
                    try
                    {
                        masterBaseEntity = entityDictionary[name];
                    }
                    catch (Exception)
                    {
                    }
                    return masterBaseEntity;
                }
            }

            public void Clear()
            {
                entityDictionary.Clear();
                listBox.Items.Clear();                
            }

            public int Count
            {
                get { return listBox.Items.Count; }
            
            }

            public EntityObjCollection GetSelectedAccount()
            {
                //AccountCollection accountCollection = new AccountCollection();
                //foreach (Account account in entityDictionary.Values)
                //{
                //    accountCollection.Add(account);
                //}
                return null; // accountCollection;
            }

            public bool Contains(DAL.Device_Config masterBaseEntity)
            {
                return entityDictionary.ContainsKey((int)masterBaseEntity.Device_Id);
            }
        }
    }
}
