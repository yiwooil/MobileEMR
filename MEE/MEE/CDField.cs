using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class CDField
    {
        private String m_FieldId;
        private String m_FieldName;

        public CDField(String fieldId, String fieldName)
        {
            m_FieldId = fieldId;
            m_FieldName = fieldName;
        }

        public String FieldId
        {
            get
            {
                return m_FieldId;
            }
            //set
            //{
            //    m_FieldId = value;
            //}
        }

        public String FieldName
        {
            get
            {
                return m_FieldName;
            }
            //set
            //{
            //    m_FieldName = value;
            //}
        }
    }
}
