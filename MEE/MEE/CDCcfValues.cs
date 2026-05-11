using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class CDCcfValues
    {
        private List<CDCcfValue> m_List = null;

        public CDCcfValues()
        {
            m_List = new List<CDCcfValue>();
            m_List.Clear();
	    }
    	
	    public void clear(){
		    m_List.Clear();
	    }
    	
	    public void addCcfValue(String field, float x, float y, float w, float h, String autoFit, String typeName, String groupName){
		    m_List.Add(new CDCcfValue(field, x, y, w, h, autoFit, typeName, groupName));
	    }

        public void addCcfValue(String field, String x, String y, String w, String h, String autoFit, String typeName, String groupName)
        {
		    float fx = toFloat(x);
            float fy = toFloat(y);
            float fw = toFloat(w);
            float fh = toFloat(h);
            m_List.Add(new CDCcfValue(field, fx, fy, fw, fh, autoFit, typeName, groupName));
	    }
    	
	    public int getCount(){
            return m_List.Count;
	    }

        public String getField(int idx)
        {
            return m_List[idx].getField();
        }

        public float getX(int idx)
        {
            return m_List[idx].getX();
	    }
    	
	    public float getY(int idx){
            return m_List[idx].getY();
	    }

        public float getW(int idx)
        {
            return m_List[idx].getW();
        }

        public float getH(int idx)
        {
            return m_List[idx].getH();
        }

        public String getAutoFit(int idx)
        {
            return m_List[idx].getAutoFit();
        }

        private float toFloat(String v)
        {
            try
            {
                float ret = float.Parse(v);
                return ret;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public String getTypeName(int idx)
        {
            return m_List[idx].getTypeName();
        }

        public String getGroupName(int idx)
        {
            return m_List[idx].getGroupName();
        }
    }
}
